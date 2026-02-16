using System;
using System.Collections.Generic;
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
        private static readonly HttpClient httpClient = new HttpClient();

        public Home()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            ConfigurarTransparencias();
            ConfigurarEfectosMenu();
            EstilizarTabla(dgvCitasHoy);
        }

        private void ConfigurarTransparencias()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is Label || c is PictureBox)
                {
                    c.BackColor = Color.Transparent;
                }
            }
        }

        private void ConfigurarEfectosMenu()
        {
            Label[] menuItems = { lblHome, lblCitas, lblServicios, label7, lblAgenda, lblCerrarSesion };

            foreach (var lbl in menuItems)
            {
                lbl.MouseEnter += (s, e) => {
                    ((Label)s).ForeColor = Color.Silver;
                    ((Label)s).Cursor = Cursors.Hand;
                };
                lbl.MouseLeave += (s, e) => {
                    ((Label)s).ForeColor = Color.White;
                    ((Label)s).Cursor = Cursors.Default;
                };
            }
        }

        private void EstilizarTabla(DataGridView dgv)
        {
            // --- CONFIGURACIÓN DE ESTRUCTURA ---
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = true; // Permite mover columnas si se desea
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

            // --- DIMENSIONES (Copiado de tu Designer de Citas) ---
            dgv.Location = new Point(50, 234);
            dgv.Size = new Size(903, 379);
            dgv.RowTemplate.Height = 40;
            dgv.ColumnHeadersHeight = 45;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // --- ESTILO DE CABECERA (dataGridViewCellStyle1) ---
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(45, 45, 48); // El color oscuro de tu app
            headerStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            headerStyle.ForeColor = Color.White;
            headerStyle.Padding = new Padding(10, 0, 0, 0);
            headerStyle.SelectionBackColor = Color.FromArgb(45, 45, 48);
            headerStyle.SelectionForeColor = Color.White;
            headerStyle.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;

            // --- ESTILO DE CELDAS (dataGridViewCellStyle2) ---
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 9.5F);
            cellStyle.ForeColor = Color.FromArgb(70, 70, 70);
            cellStyle.Padding = new Padding(10, 0, 0, 0);
            cellStyle.SelectionBackColor = Color.FromArgb(235, 245, 255);
            cellStyle.SelectionForeColor = Color.FromArgb(0, 120, 215);
            cellStyle.WrapMode = DataGridViewTriState.False;
            dgv.DefaultCellStyle = cellStyle;
        }

        // METODO MODIFICADO: Genera información falsa para previsualización
        private async Task CargarCitasHoy()
        {
            // Simulamos carga
            await Task.Delay(100);

            // Lista de datos falsos para probar el diseño y la ordenación
            var listaFalsa = new List<CitaResumenHoy>
    {
        new CitaResumenHoy { Hora = "09:00", Cliente = "Juan Pérez", Servicio = "Corte Caballero", Aula = "Aula 101" },
        new CitaResumenHoy { Hora = "12:00", Cliente = "Carlos López", Servicio = "Barba Pro", Aula = "Aula 101" },
        new CitaResumenHoy { Hora = "10:30", Cliente = "María García", Servicio = "Tinte y Peinado", Aula = "Aula 102" },
        new CitaResumenHoy { Hora = "16:00", Cliente = "Ana Martínez", Servicio = "Mechas Balayage", Aula = "Aula 103" },
        new CitaResumenHoy { Hora = "18:30", Cliente = "Luis Rodríguez", Servicio = "Corte Clásico", Aula = "Aula 102" }
    };

            // Usamos una BindingList para que el grid soporte ordenación automática de objetos
            var bindingList = new System.ComponentModel.BindingList<CitaResumenHoy>(listaFalsa);
            var source = new BindingSource(bindingList, null);

            dgvCitasHoy.DataSource = source;

            // Habilitamos el modo de ordenación en cada columna explícitamente
            foreach (DataGridViewColumn col in dgvCitasHoy.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        // Clase DTO necesaria para que la ordenación funcione correctamente en el grid
        public class CitaResumenHoy
        {
            public string Hora { get; set; }
            public string Cliente { get; set; }
            public string Servicio { get; set; }
            public string Aula { get; set; }
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            await CargarCitasHoy();
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

        // --- NAVEGACIÓN ---
        private async void lblHome_Click(object sender, EventArgs e)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo = null;
                lblUbi.Text = "Home";
                lblTitulo.Text = "Home";
                await CargarCitasHoy();
            }
        }

        private void lblCitas_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Citas());
        private void lblServicios_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Servicios());
        private void label7_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Admins());
        private void lblAgenda_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Agendas());
        private void lblCerrarSesion_Click(object sender, EventArgs e) => Application.Exit();

        // --- MÉTODOS DEL DISEÑADOR (NO BORRAR) ---
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                panel1.ClientRectangle,
                Color.FromArgb(255, 128, 0),
                Color.FromArgb(255, 200, 100),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, panel1.ClientRectangle);
            }
        }

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