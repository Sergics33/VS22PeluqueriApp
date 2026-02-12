using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirAdmin : Form
    {
        private bool esEdicion = false;

        public AnyadirAdmin()
        {
            InitializeComponent();
            ConfigurarEstilosPersonalizados();
            ConfigurarEventoClick(null);
        }

        public AnyadirAdmin(Usuario usuario)
        {
            InitializeComponent();
            esEdicion = true;
            ConfigurarEstilosPersonalizados();
            ConfigurarEventoClick(usuario);
        }

        private void ConfigurarEstilosPersonalizados()
        {
            // 1. Redondeo de Botones
            btnAnyadir.Paint += (s, e) => DibujarBordeRedondeado(btnAnyadir, e.Graphics, 38);
            btnCancelar.Paint += (s, e) => DibujarBordeRedondeado(btnCancelar, e.Graphics, 38);

            // 2. Redondeo del panel principal translúcido
            panelContenedor.SizeChanged += (s, e) => DibujarBordeRedondeado(panelContenedor, null, 25);
            DibujarBordeRedondeado(panelContenedor, null, 25);

            // 3. Crear Capsulas para los TextBox (Fondo blanco redondeado con padding)
            // Esto evita que la curva del redondeo corte la primera letra
            ConfigurarCapsulaInput(tbNombre, 25, 42);
            ConfigurarCapsulaInput(tbEmail, 25, 112);
            ConfigurarCapsulaInput(tbPassword, 275, 42);
            ConfigurarCapsulaInput(tbEspecialidad, 275, 112);
        }

        private void ConfigurarCapsulaInput(TextBox tb, int x, int y)
        {
            // Creamos un panel que servirá de "funda" blanca
            Panel pnlFondo = new Panel();
            pnlFondo.BackColor = Color.White;
            pnlFondo.Size = new Size(220, 32);
            pnlFondo.Location = new Point(x, y);

            // Configuramos el TextBox dentro del panel con margen izquierdo (padding)
            tb.Parent = pnlFondo;
            tb.BackColor = Color.White;
            tb.Location = new Point(10, 6); // 10px de margen izquierdo para que no se corte el texto
            tb.Width = pnlFondo.Width - 20;

            panelContenedor.Controls.Add(pnlFondo);
            pnlFondo.BringToFront();

            // Redondeamos el panel de fondo, no el TextBox directamente
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

        private void ConfigurarEventoClick(Usuario usuario)
        {
            if (esEdicion && usuario != null)
            {
                lblTitulo.Text = "EDITAR ADMINISTRADOR";
                btnAnyadir.Text = "GUARDAR";
                tbNombre.Text = usuario.NombreCompleto;
                tbEmail.Text = usuario.Email;
                tbEspecialidad.Text = usuario.Especialidad;
                tbPassword.PlaceholderText = "Opcional...";
            }
            else
            {
                lblTitulo.Text = "NUEVO ADMIN";
                btnAnyadir.Text = "AÑADIR";
            }

            btnAnyadir.Click += BtnAnyadir_Click;
            btnCancelar.Click += (s, e) => this.Close();
        }

        private void BtnAnyadir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Nombre y Email son obligatorios.");
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