using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class iniciar : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/auth/login";

        public iniciar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Puedes dejarlo vacío
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasenya.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Debes ingresar usuario y contraseña.");
                return;
            }

            btnIniciar.Enabled = false;
            btnIniciar.Text = "Iniciando...";

            try
            {
                var loginData = new
                {
                    email = usuario,
                    password = contrasena
                };

                var response = await httpClient.PostAsJsonAsync(API_BASE_URL, loginData);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<LoginResponse>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    // Guardar en la sesión
                    Session.AccessToken = data.AccessToken;
                    Session.TokenType = data.TokenType;
                    Session.UserId = data.Id;
                    Session.Username = data.Username;

                    // Abrir Home
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message);
            }
            finally
            {
                btnIniciar.Enabled = true;
                btnIniciar.Text = "Iniciar Sesion";
            }
        }

        // Clase interna para mapear la respuesta del API
        private class LoginResponse
        {
            public string AccessToken { get; set; }
            public string TokenType { get; set; }
            public long Id { get; set; }
            public string Username { get; set; }
        }
    }
}
