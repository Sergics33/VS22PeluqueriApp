using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirAdmin : Form
    {
        private bool esEdicion = false;
        private Usuario _usuario;

        public AnyadirAdmin()
        {
            InitializeComponent();
            ConfigurarEstilosPersonalizados();
        }

        public AnyadirAdmin(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            esEdicion = true;
            ConfigurarEstilosPersonalizados();
            CargarDatosEdicion();
        }

        private void ConfigurarEstilosPersonalizados()
        {
            lblTitulo.BackColor = Color.Transparent;

            // Aplicar redondeo al cargar
            this.Load += (s, e) =>
            {
                DibujarBordeRedondeado(btnAnyadir, 38);
                DibujarBordeRedondeado(btnCancelar, 38);
                DibujarBordeRedondeado(panelContenedor, 20);

                Control[] campos = { tbNombre, tbEmail, tbPassword, tbEspecialidad };
                foreach (var ctrl in campos) DibujarBordeRedondeado(ctrl, 15);
            };

            if (!esEdicion)
            {
                lblTitulo.Text = "Añadir Nuevo Admin";
                btnAnyadir.Text = "AÑADIR ADMIN";
            }
        }

        private void CargarDatosEdicion()
        {
            lblTitulo.Text = "Editar Administrador";
            btnAnyadir.Text = "GUARDAR CAMBIOS";

            tbNombre.Text = _usuario.NombreCompleto;
            tbEmail.Text = _usuario.Email;
            tbEspecialidad.Text = _usuario.Especialidad;
            tbPassword.PlaceholderText = "Dejar en blanco para no cambiar";
        }

        // Fondo degradado naranja (Mismo que AnyadirCitas)
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                Color.FromArgb(255, 140, 0),
                Color.FromArgb(255, 220, 150),
                LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void DibujarBordeRedondeado(Control control, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(control.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(control.Width - radio, control.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, control.Height - radio, radio, radio, 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }

        private void BtnAnyadir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("El nombre y el email son obligatorios.");
                return;
            }

            if (!esEdicion && string.IsNullOrWhiteSpace(Contrasena))
            {
                MessageBox.Show("Debes asignar una contraseña al nuevo administrador.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        public string Nombre => tbNombre.Text.Trim();
        public string Email => tbEmail.Text.Trim();
        public string Contrasena => tbPassword.Text.Trim();
        public string Especialidad => tbEspecialidad.Text.Trim();
    }
}