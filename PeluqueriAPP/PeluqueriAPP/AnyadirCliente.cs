using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirCliente : Form
    {
        private Usuario _usuarioParaEditar;

        public string Nombre => tbNombre.Text.Trim();
        public string Telefono => tbTelefono.Text.Trim();
        public string Email => tbEmail.Text.Trim();
        public string Password => tbPassword.Text.Trim();

        public AnyadirCliente(Usuario usuario = null)
        {
            InitializeComponent();
            _usuarioParaEditar = usuario;

            ConfigurarEstilosPersonalizados();

            if (_usuarioParaEditar != null)
            {
                ConfigurarModoEdicion();
            }
        }

        private void ConfigurarEstilosPersonalizados()
        {
            // Transparencia para que se vea el degradado del fondo
            lblTitulo.BackColor = Color.Transparent;

            // Bordes redondeados siguiendo el estilo de AnyadirCitas
            this.Load += (s, e) =>
            {
                DibujarBordeRedondeado(btnAnyadir, 38);
                DibujarBordeRedondeado(btnCancelar, 38);
                DibujarBordeRedondeado(panelContenedor, 20);

                // Redondeo de campos de texto
                Control[] campos = { tbNombre, tbTelefono, tbEmail, tbPassword };
                foreach (var ctrl in campos) DibujarBordeRedondeado(ctrl, 10);
            };
        }

        private void ConfigurarModoEdicion()
        {
            this.Text = "Editar Cliente";
            lblTitulo.Text = "Editar Cliente";
            btnAnyadir.Text = "ACTUALIZAR";

            tbNombre.Text = _usuarioParaEditar.NombreCompleto;
            tbEmail.Text = _usuarioParaEditar.Email;
            tbTelefono.Text = _usuarioParaEditar.Telefono;
        }

        // Fondo con degradado naranja igual que AnyadirCitas
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
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}