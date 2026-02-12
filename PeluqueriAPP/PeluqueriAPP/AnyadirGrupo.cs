using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirGrupo : Form
    {
        private Usuario _usuarioParaEditar;
        private readonly HttpClient httpClient = new HttpClient();

<<<<<<< Updated upstream
=======
        public string Nombre => tbNombre.Text.Trim();
        public string Email => tbEmail.Text.Trim();
        public string Password => tbPassword.Text.Trim();
        public string Clase => tbClase.Text.Trim();

>>>>>>> Stashed changes
        public AnyadirGrupo(Usuario usuario = null)
        {
            InitializeComponent();
            _usuarioParaEditar = usuario;
            ConfigurarEstilosPersonalizados();
<<<<<<< Updated upstream
        }

        private void ConfigurarEstilosPersonalizados()
        {
            // Aplicar redondeo al cargar
            this.Load += (s, e) =>
            {
                DibujarBordeRedondeado(btnAnyadir, 38);
                DibujarBordeRedondeado(btnCancelar, 38);
                DibujarBordeRedondeado(panelContenedor, 20);

                Control[] campos = { tbNombre, tbEmail, tbPassword, tbClase };
                foreach (var ctrl in campos) DibujarBordeRedondeado(ctrl, 15);
            };
=======
            ConfigurarEventoClick();
        }
>>>>>>> Stashed changes

        private void ConfigurarEstilosPersonalizados()
        {
            // 1. Redondeo de Botones
            btnAnyadir.Paint += (s, e) => DibujarBordeRedondeado(btnAnyadir, e.Graphics, 38);
            btnCancelar.Paint += (s, e) => DibujarBordeRedondeado(btnCancelar, e.Graphics, 38);

            // 2. Redondeo del panel principal
            panelContenedor.SizeChanged += (s, e) => DibujarBordeRedondeado(panelContenedor, null, 25);
            DibujarBordeRedondeado(panelContenedor, null, 25);

            // 3. Crear Cápsulas para los TextBox (Fondo blanco redondeado con padding interno)
            ConfigurarCapsulaInput(tbNombre, 25, 42);
            ConfigurarCapsulaInput(tbEmail, 25, 112);
            ConfigurarCapsulaInput(tbPassword, 275, 42);
            ConfigurarCapsulaInput(tbClase, 275, 112);
        }

        private void ConfigurarCapsulaInput(TextBox tb, int x, int y)
        {
            Panel pnlFondo = new Panel();
            pnlFondo.BackColor = Color.White;
            pnlFondo.Size = new Size(220, 32);
            pnlFondo.Location = new Point(x, y);

            tb.Parent = pnlFondo;
            tb.BackColor = Color.White;
            tb.BorderStyle = BorderStyle.None;
            tb.Location = new Point(10, 6); // Padding para que no se corte el texto
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
                lbltitulo.Text = "Editar Grupo";
                btnAnyadir.Text = "ACTUALIZAR";
                tbNombre.Text = _usuarioParaEditar.NombreCompleto;
                tbEmail.Text = _usuarioParaEditar.Email;
                tbClase.Text = _usuarioParaEditar.Clase;
<<<<<<< Updated upstream
                tbPassword.PlaceholderText = "Opcional en edición";
            }
            else
            {
                lbltitulo.Text = "Nuevo Grupo / Clase";
                btnAnyadir.Text = "AÑADIR GRUPO";
=======
                tbPassword.PlaceholderText = "Opcional...";
            }
            else
            {
                lbltitulo.Text = "NUEVO GRUPO";
                btnAnyadir.Text = "AÑADIR";
>>>>>>> Stashed changes
            }

            btnAnyadir.Click += BtnAnyadir_Click;
            btnCancelar.Click += (s, e) => this.Close();
        }

        // Fondo degradado naranja (Consistente con la App)
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

        private async void BtnAnyadir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Clase))
            {
                MessageBox.Show("Campos obligatorios incompletos.");
                return;
            }

            if (_usuarioParaEditar != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            var request = new { nombreCompleto = Nombre, email = Email, password = Password, clase = Clase };
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
                var response = await httpClient.PostAsJsonAsync("http://localhost:8080/api/auth/register/grupo", request);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Grupo añadido correctamente");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar el grupo.");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error de red: " + ex.Message); }
        }

        public string Nombre => tbNombre.Text.Trim();
        public string Email => tbEmail.Text.Trim();
        public string Password => tbPassword.Text.Trim();
        public string Clase => tbClase.Text.Trim();
    }
}