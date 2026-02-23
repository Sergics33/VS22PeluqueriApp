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

        // --- LÓGICA DE VALORACIONES (CORREGIDA) ---
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
                            lblMediaGeneral.Text = $"{mediaGlobal:F1} ★";
                            FormatearLabelVistoso(lblMediaTrato, "Trato", mTrato);
                            FormatearLabelVistoso(lblMediaDesarrollo, "Servicio", mDesarrollo);
                            FormatearLabelVistoso(lblMediaClaridad, "Comunicación", mClaridad);
                            FormatearLabelVistoso(lblMediaLimpieza, "Limpieza", mLimpieza);
                            FormatearLabelVistoso(lblMediaPuntualidad, "General", mGeneral);
                        });
                    }
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        private void FormatearLabelVistoso(Label lbl, string titulo, double valor)
        {
            lbl.AutoSize = false;
            lbl.Size = new Size(165, 65);
            lbl.Text = $"{titulo.ToUpper()}\n{valor:F1} ★";
            lbl.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.ForeColor = Color.FromArgb(45, 45, 48);
        }

        // --- LÓGICA DE CARGA DE CITAS (TU ORIGINAL SIN TOCAR) ---
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
                                listaHoy.Add(new CitaResumenHoy
                                {
                                    Hora = fechaCita.ToString("HH:mm"),
                                    Cliente = c.cliente != null ? (string)c.cliente.nombre : "ID: " + c.cliente_id,
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
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando citas: " + ex.Message);
            }
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            await CargarCitasHoy();
            await CargarMediaValoraciones();
        }

        // --- ESTILOS Y DISEÑO ---
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

                using (Pen pen = new Pen(borderColor, borderThickness))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void ConfigurarTransparencias()
        {
            foreach (Control c in panel1.Controls)
                if (c is Label || c is PictureBox) c.BackColor = Color.Transparent;
        }

        private void ConfigurarEfectosMenu()
        {
            Label[] menuItems = { lblHome, lblCitas, lblServicios, label7, lblAgenda, lblBloqueos, lblCerrarSesion };
            foreach (var lbl in menuItems)
            {
                lbl.MouseEnter += (s, e) => { ((Label)s).ForeColor = Color.Silver; ((Label)s).Cursor = Cursors.Hand; };
                lbl.MouseLeave += (s, e) => { ((Label)s).ForeColor = Color.White; ((Label)s).Cursor = Cursors.Default; };
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
        private void lblCerrarSesion_Click(object sender, EventArgs e) => Application.Exit();

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