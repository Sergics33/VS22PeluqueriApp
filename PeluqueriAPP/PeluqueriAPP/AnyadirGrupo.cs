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

        public AnyadirGrupo(Usuario usuario = null)
        {
            InitializeComponent();
            _usuarioParaEditar = usuario;
            ConfigurarEstilosPersonalizados();
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

            if (_usuarioParaEditar != null)
            {
                lbltitulo.Text = "Editar Grupo";
                btnAnyadir.Text = "ACTUALIZAR";
                tbNombre.Text = _usuarioParaEditar.NombreCompleto;
                tbEmail.Text = _usuarioParaEditar.Email;
                tbClase.Text = _usuarioParaEditar.Clase;
                tbPassword.PlaceholderText = "Opcional en edición";
            }
            else
            {
                lbltitulo.Text = "Nuevo Grupo / Clase";
                btnAnyadir.Text = "AÑADIR GRUPO";
            }
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
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        public string Nombre => tbNombre.Text.Trim();
        public string Email => tbEmail.Text.Trim();
        public string Password => tbPassword.Text.Trim();
        public string Clase => tbClase.Text.Trim();
    }
}