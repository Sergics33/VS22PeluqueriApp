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
<<<<<<< Updated upstream
=======
            ConfigurarEventoClick(null);
>>>>>>> Stashed changes
        }

        public AnyadirAdmin(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            esEdicion = true;
            ConfigurarEstilosPersonalizados();
<<<<<<< Updated upstream
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
=======
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
>>>>>>> Stashed changes
            }
        }

<<<<<<< Updated upstream
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
=======
            btnAnyadir.Click += BtnAnyadir_Click;
            btnCancelar.Click += (s, e) => this.Close();
>>>>>>> Stashed changes
        }

        private void BtnAnyadir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Nombre y Email son obligatorios.");
                return;
            }
<<<<<<< Updated upstream

            if (!esEdicion && string.IsNullOrWhiteSpace(Contrasena))
            {
                MessageBox.Show("Debes asignar una contraseña al nuevo administrador.");
                return;
            }

=======
>>>>>>> Stashed changes
            DialogResult = DialogResult.OK;
            Close();
        }

        public string Nombre => tbNombre.Text.Trim();
        public string Email => tbEmail.Text.Trim();
        public string Contrasena => tbPassword.Text.Trim();
        public string Especialidad => tbEspecialidad.Text.Trim();
    }
}