using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
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
            // Evento opcional
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasenya.Text.Trim();

            // Validación de campos vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Debes ingresar usuario y contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bloquear botón para evitar múltiples clics
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

                    // Guardar datos en la clase Session (Asegúrate de que la clase Session exista)
                    Session.AccessToken = data.AccessToken;
                    Session.TokenType = data.TokenType;
                    Session.UserId = data.Id;
                    Session.Username = data.Username;

                    // Abrir Home y ocultar Login
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con el servidor: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restaurar estado del botón
                btnIniciar.Enabled = true;
                btnIniciar.Text = "Iniciar Sesion";
            }
        }

        // Modelo de respuesta de la API
        private class LoginResponse
        {
            public string AccessToken { get; set; }
            public string TokenType { get; set; }
            public long Id { get; set; }
            public string Username { get; set; }
        }
    }
}