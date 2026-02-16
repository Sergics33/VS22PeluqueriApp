using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // O System.Data.SqlClient según tu proyecto

namespace PeluqueriAPP
{
    public partial class Home : Form
    {
        private Form formularioActivo = null;

        // Configura aquí tu cadena de conexión (o usa la de tu clase global)
        private string cadenaConexion = "Server=TU_SERVIDOR;Database=PeluqueriAPP;Integrated Security=True;TrustServerCertificate=True;";

        public Home()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            ConfigurarTransparencias();
            ConfigurarEfectosMenu();

            EstilizarTabla(dgvCitasHoy);
            CargarCitasHoy();
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
                lbl.MouseEnter += (s, e) => { ((Label)s).ForeColor = Color.Silver; ((Label)s).Cursor = Cursors.Hand; };
                lbl.MouseLeave += (s, e) => { ((Label)s).ForeColor = Color.White; ((Label)s).Cursor = Cursors.Default; };
            }
        }

        private void EstilizarTabla(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.GridColor = Color.FromArgb(224, 224, 224);

            // Cabecera Naranja
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(255, 128, 0);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeight = 40;
            dgv.EnableHeadersVisualStyles = false;

            // Celdas
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.SelectionBackColor = Color.FromArgb(255, 230, 200);
            cellStyle.SelectionForeColor = Color.Black;
            cellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle = cellStyle;
            dgv.RowTemplate.Height = 35;
        }

        private void CargarCitasHoy()
        {
            // Consulta SQL para traer solo las citas de hoy
            // Ajusta los nombres de las columnas según tu tabla real
            string query = @"SELECT Hora, Cliente, Servicio, Aula 
                             FROM Citas 
                             WHERE CAST(Fecha AS DATE) = CAST(GETDATE() AS DATE)
                             ORDER BY Hora ASC";

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvCitasHoy.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                // En caso de que la tabla aún no exista o falle la conexión, 
                // mostramos el error pero no bloqueamos la app
                Console.WriteLine("Error de conexión: " + ex.Message);
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

        // --- EVENTOS Y MÉTODOS DEL DISEÑADOR ---
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

        private void lblHome_Click(object sender, EventArgs e)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo = null;
                lblUbi.Text = "Home";
                lblTitulo.Text = "Home";
                CargarCitasHoy(); // Refresca las citas al volver al Home
            }
        }

        private void lblCitas_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Citas());
        private void lblServicios_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Servicios());
        private void label7_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Admins());
        private void lblAgenda_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Agendas());
        private void lblCerrarSesion_Click(object sender, EventArgs e) => Application.Exit();

        // Métodos vacíos para evitar errores de referencia en el Designer
        private void lblBernatS_Click(object sender, EventArgs e) { }
        private void lblUbi_Click(object sender, EventArgs e) { }
        private void lblTitulo_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void lblBernat_Click(object sender, EventArgs e) { }
        private void lblPanel_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void iconoFP_Click(object sender, EventArgs e) { }
        private void lblGestion_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void lblAdmin_Click(object sender, EventArgs e) { }
        private void IconoPerfil_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}