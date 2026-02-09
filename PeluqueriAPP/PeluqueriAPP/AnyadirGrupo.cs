using System;
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

        // Propiedades públicas para que Admins pueda leer los datos
        public string Nombre => tbNombre.Text.Trim();
        public string Email => tbEmail.Text.Trim();
        public string Password => tbPassword.Text.Trim();
        public string Clase => tbClase.Text.Trim();

        public AnyadirGrupo(Usuario usuario = null)
        {
            InitializeComponent();
            _usuarioParaEditar = usuario;
            btnAnyadir.Click += BtnAnyadir_Click;

            if (_usuarioParaEditar != null)
            {
                lbltitulo.Text = "EDITAR GRUPO";
                btnAnyadir.Text = "ACTUALIZAR";
                tbNombre.Text = _usuarioParaEditar.NombreCompleto;
                tbEmail.Text = _usuarioParaEditar.Email;
                tbClase.Text = _usuarioParaEditar.Clase;
            }
            else
            {
                lbltitulo.Text = "AÑADIR GRUPO";
                btnAnyadir.Text = "AÑADIR GRUPO";
            }
        }

        private async void BtnAnyadir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Clase))
            {
                MessageBox.Show("Campos obligatorios incompletos.");
                return;
            }

            // Si es EDICIÓN, simplemente cerramos con OK para que Admins.cs ejecute el PUT
            if (_usuarioParaEditar != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            // Si es NUEVO, mantenemos tu lógica de POST original
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
    }
}