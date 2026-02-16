using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
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

            // Único cambio: Suscribir el evento para el borde del panel
            panelEstadisticas.Paint += panelEstadisticas_Paint;
        }

        // --- DTOs ---
        public class CitaResumenHoy
        {
            public string Hora { get; set; }
            public string Cliente { get; set; }
            public string Servicio { get; set; }
            public string Aula { get; set; }
        }

        public class ValoracionDTO
        {
            public double tratoPersonal { get; set; }
            public double desarrolloServicio { get; set; }
            public double claridadComunicacion { get; set; }
            public double limpieza { get; set; }
            public double general { get; set; }
        }

        // --- LÓGICA DEL PANEL (BORDES) ---
        private void panelEstadisticas_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            float borderRadius = 20f; // Curvatura
            float borderThickness = 2f; // Grosor
            Color borderColor = Color.FromArgb(64, 64, 64); // Gris oscuro solicitado

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
                path.AddArc(panel.Width - borderRadius - 1, 0, borderRadius, borderRadius, 270, 90);
                path.AddArc(panel.Width - borderRadius - 1, panel.Height - borderRadius - 1, borderRadius, borderRadius, 0, 90);
                path.AddArc(0, panel.Height - borderRadius - 1, borderRadius, borderRadius, 90, 90);
                path.CloseAllFigures();

                panel.Region = new Region(path); // Redondea el fondo

                using (Pen pen = new Pen(borderColor, borderThickness))
                {
                    e.Graphics.DrawPath(pen, path); // Dibuja el borde oscuro
                }
            }
        }

        // --- CARGA DE DATOS ---
        private async Task CargarCitasHoy()
        {
            await Task.Delay(50);

            var listaFalsa = new List<CitaResumenHoy>
            {
                new CitaResumenHoy { Hora = "09:00", Cliente = "Juan Pérez", Servicio = "Corte Caballero", Aula = "Aula 101" },
                new CitaResumenHoy { Hora = "12:00", Cliente = "Carlos López", Servicio = "Barba Pro", Aula = "Aula 101" },
                new CitaResumenHoy { Hora = "10:30", Cliente = "María García", Servicio = "Tinte y Peinado", Aula = "Aula 102" },
                new CitaResumenHoy { Hora = "16:00", Cliente = "Ana Martínez", Servicio = "Mechas Balayage", Aula = "Aula 103" },
                new CitaResumenHoy { Hora = "18:30", Cliente = "Luis Rodríguez", Servicio = "Corte Clásico", Aula = "Aula 102" }
            };

            var bindingList = new BindingList<CitaResumenHoy>(listaFalsa);

            this.Invoke((MethodInvoker)delegate {
                dgvCitasHoy.DataSource = null;
                dgvCitasHoy.DataSource = bindingList;

                foreach (DataGridViewColumn col in dgvCitasHoy.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.Automatic;
                }

                dgvCitasHoy.Refresh();
                dgvCitasHoy.BringToFront();
            });
        }

        private async Task CargarMediaValoraciones()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(API_VALORACIONES_URL);
                if (response.IsSuccessStatusCode)
                {
                    var valoraciones = await response.Content.ReadFromJsonAsync<List<ValoracionDTO>>();
                    if (valoraciones != null && valoraciones.Any())
                    {
                        double sTrato = 0, sDesarrollo = 0, sClaridad = 0, sLimpieza = 0, sGeneral = 0;
                        int total = valoraciones.Count;

                        foreach (var v in valoraciones)
                        {
                            sTrato += v.tratoPersonal;
                            sDesarrollo += v.desarrolloServicio;
                            sClaridad += v.claridadComunicacion;
                            sLimpieza += v.limpieza;
                            sGeneral += v.general;
                        }

                        double mTrato = sTrato / total;
                        double mDesarrollo = sDesarrollo / total;
                        double mClaridad = sClaridad / total;
                        double mLimpieza = sLimpieza / total;
                        double mGeneral = sGeneral / total;
                        double mediaGlobal = (mTrato + mDesarrollo + mClaridad + mLimpieza + mGeneral) / 5;

                        this.Invoke((MethodInvoker)delegate {
                            lblMediaGeneral.Text = $"{mediaGlobal:F1} ★";
                            lblMediaTrato.Text = $"Trato: {mTrato:F1}";
                            lblMediaDesarrollo.Text = $"Servicio: {mDesarrollo:F1}";
                            lblMediaClaridad.Text = $"Comunicación: {mClaridad:F1}";
                            lblMediaLimpieza.Text = $"Limpieza: {mLimpieza:F1}";
                            lblMediaPuntualidad.Text = $"General: {mGeneral:F1}";
                            lblMediaGeneral.ForeColor = mediaGlobal >= 4.0 ? Color.FromArgb(255, 128, 0) : Color.Gray;
                        });
                    }
                }
            }
            catch { /* Backend no disponible */ }
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            await CargarCitasHoy();
            await CargarMediaValoraciones();
        }

        // --- ESTILOS Y NAVEGACIÓN (ORIGINALES) ---
        private void EstilizarTabla(DataGridView dgv)
        {
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

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(45, 45, 48);
            headerStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            headerStyle.ForeColor = Color.White;
            headerStyle.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Font = new Font("Segoe UI", 9.5F);
            cellStyle.ForeColor = Color.FromArgb(70, 70, 70);
            cellStyle.SelectionBackColor = Color.FromArgb(235, 245, 255);
            cellStyle.SelectionForeColor = Color.FromArgb(0, 120, 215);
            dgv.DefaultCellStyle = cellStyle;
        }

        private void ConfigurarTransparencias()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is Label || c is PictureBox) c.BackColor = Color.Transparent;
            }
        }

        private void ConfigurarEfectosMenu()
        {
            Label[] menuItems = { lblHome, lblCitas, lblServicios, label7, lblAgenda, lblCerrarSesion };
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
            panel2.Tag = formularioHijo;
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
        private void lblCerrarSesion_Click(object sender, EventArgs e) => Application.Exit();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(panel1.ClientRectangle, Color.FromArgb(255, 128, 0), Color.FromArgb(255, 200, 100), LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, panel1.ClientRectangle);
            }
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
    }
}