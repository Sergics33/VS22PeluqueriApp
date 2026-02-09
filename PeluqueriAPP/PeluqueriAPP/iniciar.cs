using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

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
        }

        private void ConfigurarEstilos()
        {
            // Redondeo tipo "píldora" (extremo) para el botón
            btnIniciar.Paint += (s, e) => DibujarBordeRedondeado(btnIniciar, e.Graphics, 38);
        }

        private void DibujarBordeRedondeado(Control control, Graphics g, int radio)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
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

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasenya.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Debes ingresar usuario y contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    var data = JsonSerializer.Deserialize<LoginResponse>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    Session.AccessToken = data.AccessToken;
                    Session.TokenType = data.TokenType;
                    Session.UserId = data.Id;
                    Session.Username = data.Username;

                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            public long Id { get; set; }
            public string Username { get; set; }
        }
    }
}