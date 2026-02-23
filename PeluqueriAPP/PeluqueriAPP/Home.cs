using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class Home : Form
    {
        private Form formularioActivo = null;
        private const string API_CITAS_URL = "http://localhost:8080/api/citas/";
        private const string API_VALORACIONES_URL = "http://localhost:8080/api/valoraciones/";
        private static readonly HttpClient httpClient = new HttpClient();

        public Home()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            ConfigurarTransparencias();
            ConfigurarEfectosMenu();
            EstilizarTabla(dgvCitasHoy);

            panelEstadisticas.Paint += panelEstadisticas_Paint;
        }

        // --- DTOs PARA LA API ---
        public class CitaResumenHoy
        {
            public string Hora { get; set; }
            public string Cliente { get; set; }
            public string Servicio { get; set; }
            public string Aula { get; set; }
        }

        public class ValoracionDTO
        {
            [JsonProperty("tratoPersonal")]
            public double tratoPersonal { get; set; }
            [JsonProperty("desarrolloServicio")]
            public double desarrolloServicio { get; set; }
            [JsonProperty("claridadComunicacion")]
            public double claridadComunicacion { get; set; }
            [JsonProperty("limpieza")]
            public double limpieza { get; set; }
            [JsonProperty("general")]
            public double general { get; set; }
        }

        // --- LÓGICA DE VALORACIONES ---
        private async Task CargarMediaValoraciones()
        {
            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                if (!string.IsNullOrEmpty(Session.AccessToken))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
                }

                var response = await httpClient.GetAsync(API_VALORACIONES_URL);
                if (response.IsSuccessStatusCode)
                {
                    string jsonRaw = await response.Content.ReadAsStringAsync();
                    var valoraciones = JsonConvert.DeserializeObject<List<ValoracionDTO>>(jsonRaw);

                    if (valoraciones != null && valoraciones.Any())
                    {
                        double mTrato = valoraciones.Average(v => v.tratoPersonal);
                        double mDesarrollo = valoraciones.Average(v => v.desarrolloServicio);
                        double mClaridad = valoraciones.Average(v => v.claridadComunicacion);
                        double mLimpieza = valoraciones.Average(v => v.limpieza);
                        double mGeneral = valoraciones.Average(v => v.general);
                        double mediaGlobal = (mTrato + mDesarrollo + mClaridad + mLimpieza + mGeneral) / 5;

                        this.Invoke((MethodInvoker)delegate
                        {
                            System.Windows.Forms.Label[] todos = { lblMediaGeneral, lblMediaTrato, lblMediaDesarrollo, lblMediaLimpieza, lblMediaClaridad, lblMediaPuntualidad };

                            foreach (var l in todos)
                            {
                                if (!panelEstadisticas.Controls.Contains(l)) panelEstadisticas.Controls.Add(l);
                                l.Dock = DockStyle.None;
                                l.AutoSize = false;
                                l.BackColor = Color.Transparent;
                            }

                            lblMediaGeneral.Text = $"{mediaGlobal:F1} ★";
                            lblMediaGeneral.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
                            lblMediaGeneral.ForeColor = Color.FromArgb(255, 128, 0);
                            lblMediaGeneral.Size = new Size(panelEstadisticas.Width - 10, 70);
                            lblMediaGeneral.TextAlign = ContentAlignment.MiddleCenter;
                            lblMediaGeneral.Location = new Point(5, 10);

                            int yPos = lblMediaGeneral.Bottom + 10;
                            string[] titulos = { "TRATO PERSONAL", "DESARROLLO", "LIMPIEZA", "COMUNICACIÓN", "SATISFACCIÓN" };
                            double[] valores = { mTrato, mDesarrollo, mLimpieza, mClaridad, mGeneral };

                            for (int i = 0; i < todos.Length - 1; i++)
                            {
                                System.Windows.Forms.Label lbl = todos[i + 1];
                                lbl.Size = new Size(panelEstadisticas.Width - 20, 50);
                                lbl.Text = $"{titulos[i]}\n{valores[i]:F1} ★";
                                lbl.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
                                lbl.ForeColor = Color.FromArgb(64, 64, 64);
                                lbl.TextAlign = ContentAlignment.MiddleCenter;
                                lbl.Location = new Point(10, yPos);
                                yPos += lbl.Height + 5;
                                lbl.BringToFront();
                            }
                        });
                    }
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        private async Task CargarCitasHoy()
        {
            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                if (!string.IsNullOrEmpty(Session.AccessToken))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
                }

                var response = await httpClient.GetAsync(API_CITAS_URL);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var todasLasCitasRaw = JsonConvert.DeserializeObject<List<dynamic>>(json);

                    if (todasLasCitasRaw != null)
                    {
                        DateTime hoy = DateTime.Today;
                        var listaHoy = new List<CitaResumenHoy>();

                        foreach (var c in todasLasCitasRaw)
                        {
                            DateTime fechaCita = c.fechaHoraInicio;
                            if (fechaCita.Date == hoy)
                            {
                                string nombreCliente = "ID: " + c.cliente_id;
                                if (c.cliente != null)
                                {
                                    nombreCliente = (string)c.cliente.nombre_completo ?? (string)c.cliente.nombreCompleto ?? (string)c.cliente.nombre ?? "ID: " + (string)c.cliente.id;
                                }

                                listaHoy.Add(new CitaResumenHoy
                                {
                                    Hora = fechaCita.ToString("HH:mm"),
                                    Cliente = nombreCliente,
                                    Servicio = c.agenda != null && c.agenda.servicio != null ? (string)c.agenda.servicio.nombre : "Agenda: " + c.agenda_id,
                                    Aula = c.agenda != null ? (string)c.agenda.aula : "N/A"
                                });
                            }
                        }

                        this.Invoke((MethodInvoker)delegate
                        {
                            dgvCitasHoy.DataSource = null;
                            dgvCitasHoy.DataSource = listaHoy.OrderBy(x => x.Hora).ToList();
                        });
                    }
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Error cargando citas: " + ex.Message); }
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!string.IsNullOrEmpty(Session.Username))
            {
                label1.Text = Session.Username;
            }

            await CargarCitasHoy();
            await CargarMediaValoraciones();
        }

        private void EstilizarTabla(DataGridView dgv)
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(45, 45, 48);
            headerStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            headerStyle.ForeColor = Color.White;
            headerStyle.Padding = new Padding(10, 0, 0, 0);
            headerStyle.SelectionBackColor = Color.FromArgb(45, 45, 48);
            headerStyle.SelectionForeColor = Color.White;
            headerStyle.WrapMode = DataGridViewTriState.True;

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 9.5F);
            cellStyle.ForeColor = Color.FromArgb(70, 70, 70);
            cellStyle.Padding = new Padding(10, 0, 0, 0);
            cellStyle.SelectionBackColor = Color.FromArgb(235, 245, 255);
            cellStyle.SelectionForeColor = Color.FromArgb(0, 120, 215);
            cellStyle.WrapMode = DataGridViewTriState.False;

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = true;
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(230, 230, 230);
            dgv.RowTemplate.Height = 40;
            dgv.ColumnHeadersHeight = 45;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.DefaultCellStyle = cellStyle;
        }

        private void panelEstadisticas_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            float borderRadius = 20f;
            float borderThickness = 2f;
            Color borderColor = Color.FromArgb(64, 64, 64);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
                path.AddArc(panel.Width - borderRadius - 1, 0, borderRadius, borderRadius, 270, 90);
                path.AddArc(panel.Width - borderRadius - 1, panel.Height - borderRadius - 1, borderRadius, borderRadius, 0, 90);
                path.AddArc(0, panel.Height - borderRadius - 1, borderRadius, borderRadius, 90, 90);
                path.CloseAllFigures();
                panel.Region = new Region(path);
                using (Pen pen = new Pen(borderColor, borderThickness)) { e.Graphics.DrawPath(pen, path); }
            }
        }

        private void ConfigurarTransparencias()
        {
            foreach (Control c in panel1.Controls)
                if (c is System.Windows.Forms.Label || c is PictureBox) c.BackColor = Color.Transparent;
        }

        private void ConfigurarEfectosMenu()
        {
            System.Windows.Forms.Label[] menuItems = { lblHome, lblCitas, lblServicios, label7, lblAgenda, lblBloqueos, lblCerrarSesion };
            foreach (var lbl in menuItems)
            {
                lbl.MouseEnter += (s, e) => { ((System.Windows.Forms.Label)s).ForeColor = Color.Silver; ((System.Windows.Forms.Label)s).Cursor = Cursors.Hand; };
                lbl.MouseLeave += (s, e) => { ((System.Windows.Forms.Label)s).ForeColor = Color.White; ((System.Windows.Forms.Label)s).Cursor = Cursors.Default; };
            }
        }

        private void AbrirFormEnPanel(Form formularioHijo)
        {
            if (formularioActivo != null) formularioActivo.Close();
            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            formularioHijo.BackColor = panel2.BackColor;
            panel2.Controls.Add(formularioHijo);
            formularioHijo.BringToFront();
            formularioHijo.Show();
            lblUbi.Text = formularioHijo.Text;
            lblTitulo.Text = formularioHijo.Text;
        }

        private async void lblHome_Click(object sender, EventArgs e)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo = null;
                lblUbi.Text = "Home";
                lblTitulo.Text = "Home";
                await CargarCitasHoy();
                await CargarMediaValoraciones();
            }
        }

        private void lblCitas_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Citas());
        private void lblServicios_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Servicios());
        private void label7_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Admins());
        private void lblAgenda_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Agendas());
        private void lblBloqueos_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Bloqueos());

        // --- MÉTODO CERRAR SESIÓN ACTUALIZADO ---
        private void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            // 1. Limpiamos los datos de la sesión
            Session.Logout();

            // 2. Creamos instancia del Login (reemplaza 'Login' por el nombre real de tu form de inicio)
            iniciar loginForm = new iniciar();

            // 3. Mostramos el Login
            loginForm.Show();

            // 4. Cerramos este formulario (Home)
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(panel1.ClientRectangle, Color.FromArgb(255, 128, 0), Color.FromArgb(255, 200, 100), LinearGradientMode.Vertical))
                e.Graphics.FillRectangle(brush, panel1.ClientRectangle);
        }

        // Handlers vacíos
        private void lblBernat_Click(object sender, EventArgs e) { }
        private void lblPanel_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void iconoFP_Click(object sender, EventArgs e) { }
        private void lblGestion_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void lblAdmin_Click(object sender, EventArgs e) { }
        private void IconoPerfil_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void lblBernatS_Click(object sender, EventArgs e) { }
        private void lblUbi_Click(object sender, EventArgs e) { }
        private void lblTitulo_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
    }
}