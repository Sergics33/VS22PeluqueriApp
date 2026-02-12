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
            ConfigurarEventoClick();
        }

        private void ConfigurarEstilosPersonalizados()
        {
            // 1. Redondeo de Botones
            btnAnyadir.Paint += (s, e) => DibujarBordeRedondeado(btnAnyadir, e.Graphics, 38);
            btnCancelar.Paint += (s, e) => DibujarBordeRedondeado(btnCancelar, e.Graphics, 38);

            // 2. Redondeo del panel principal
            panelContenedor.SizeChanged += (s, e) => DibujarBordeRedondeado(panelContenedor, null, 25);
            DibujarBordeRedondeado(panelContenedor, null, 25);

            // 3. Crear Cápsulas para los TextBox (Fondo blanco con padding interno)
            ConfigurarCapsulaInput(tbNombre, 25, 37, 470);      // Nombre (Ancho total)
            ConfigurarCapsulaInput(tbTelefono, 25, 102, 220);    // Telefono
            ConfigurarCapsulaInput(tbEmail, 275, 102, 220);      // Email
            ConfigurarCapsulaInput(tbPassword, 25, 167, 470);    // Password (Ancho total)
        }

        private void ConfigurarCapsulaInput(TextBox tb, int x, int y, int width)
        {
            Panel pnlFondo = new Panel();
            pnlFondo.BackColor = Color.White;
            pnlFondo.Size = new Size(width, 32);
            pnlFondo.Location = new Point(x, y);

            tb.Parent = pnlFondo;
            tb.BackColor = Color.White;
            tb.BorderStyle = BorderStyle.None;
            tb.Location = new Point(10, 6); // Margen izquierdo para que no se corte el texto
            tb.Width = pnlFondo.Width - 20;

            panelContenedor.Controls.Add(pnlFondo);
            pnlFondo.BringToFront();

            pnlFondo.Paint += (s, e) => DibujarBordeRedondeado(pnlFondo, e.Graphics, 15);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                Color.FromArgb(255, 140, 0),    // Naranja fuerte
                Color.FromArgb(255, 220, 150),  // Naranja suave
                LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void DibujarBordeRedondeado(Control control, Graphics g, int radio)
        {
            Graphics graphics = g ?? control.CreateGraphics();
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radio, radio, 180, 90);
                path.AddArc(control.Width - radio, 0, radio, radio, 270, 90);
                path.AddArc(control.Width - radio, control.Height - radio, radio, radio, 0, 90);
                path.AddArc(0, control.Height - radio, radio, radio, 90, 90);
                path.CloseAllFigures();
                control.Region = new Region(path);
            }
        }

        private void ConfigurarEventoClick()
        {
            if (_usuarioParaEditar != null)
            {
                this.Text = "Editar Cliente";
                lblTitulo.Text = "EDITAR CLIENTE";
                btnAnyadir.Text = "ACTUALIZAR";
                tbNombre.Text = _usuarioParaEditar.NombreCompleto;
                tbEmail.Text = _usuarioParaEditar.Email;
                tbTelefono.Text = _usuarioParaEditar.Telefono;
                tbPassword.PlaceholderText = "Dejar vacío para mantener...";
            }
            else
            {
                lblTitulo.Text = "NUEVO CLIENTE";
                btnAnyadir.Text = "GUARDAR";
            }

            btnAnyadir.Click += BtnAnyadir_Click;
            btnCancelar.Click += (s, e) => this.Close();
        }

        private void BtnAnyadir_Click(object sender, EventArgs e)
        {
            bool esNuevo = _usuarioParaEditar == null;
            if (string.IsNullOrWhiteSpace(Nombre) || (esNuevo && string.IsNullOrWhiteSpace(Password)))
            {
                MessageBox.Show("El nombre es obligatorio (y la contraseña para nuevos registros).", "Validación");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}