using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Http.Headers;

namespace PeluqueriAPP
{
    public partial class iniciar : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/auth/login";

        public iniciar()
        {
            InitializeComponent();
            ConfigurarEstilos();

            pnlLateral.Paint += PnlLateral_Paint;
            iconoFP.Paint += IconoFP_Paint;
        }

        private void ConfigurarEstilos()
        {
            // Forzamos el redondeo en el evento Load para asegurar que el Handle esté creado
            this.Load += (s, e) => {
                DibujarBordeRedondeado(btnIniciar, 38);
                DibujarBordeRedondeado(txtUsuario, 10);
                DibujarBordeRedondeado(txtContrasenya, 10);
            };
        }

        private void IconoFP_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            int margenCirculo = 1;
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillEllipse(brush, margenCirculo, margenCirculo, iconoFP.Width - (margenCirculo * 2), iconoFP.Height - (margenCirculo * 2));
            }

            if (iconoFP.Image != null)
            {
                int paddingLogo = 12;
                int yOffset = 5;
                Rectangle rectLogo = new Rectangle(paddingLogo, paddingLogo + yOffset, iconoFP.Width - (paddingLogo * 2), iconoFP.Height - (paddingLogo * 2));
                e.Graphics.DrawImage(iconoFP.Image, rectLogo);
            }
        }

        private void PnlLateral_Paint(object sender, PaintEventArgs e)
        {
            Color colorInicio = Color.FromArgb(255, 110, 0);
            Color colorFin = Color.FromArgb(255, 170, 40);
            using (LinearGradientBrush brush = new LinearGradientBrush(pnlLateral.ClientRectangle, colorInicio, colorFin, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, pnlLateral.ClientRectangle);
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

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasenya.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Debes introducir el usuario y la contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnIniciar.Enabled = false;
            btnIniciar.Text = "CARGANDO...";

            try
            {
                var loginData = new { email = usuario, password = contrasena };
                var response = await httpClient.PostAsJsonAsync(API_BASE_URL, loginData);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<LoginResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    Session.AccessToken = data.AccessToken;
                    Session.TokenType = data.TokenType;
                    Session.Username = data.Username;

                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
            finally
            {
                btnIniciar.Enabled = true;
                btnIniciar.Text = "INICIAR SESIÓN";
            }
        }

        private class LoginResponse
        {
            public string AccessToken { get; set; }
            public string TokenType { get; set; }
            public string Username { get; set; }
        }
    }
}