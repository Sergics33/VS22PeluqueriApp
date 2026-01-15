using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirUsuario : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private string tipoUsuario; // Admin, Cliente, Grupo

        public AnyadirUsuario(string tipo)
        {
            InitializeComponent();
            tipoUsuario = tipo;

            lblTitulo.Text = $"AÑADIR {tipo.ToUpper()}";
            btnAnyadir.Text = $"AÑADIR {tipo.ToUpper()}";

            ConfigurarCampos(tipo);
            btnAnyadir.Click += BtnAnyadir_Click;
        }

        // Constructor para EDITAR usuario
        public AnyadirUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            InitializeComponent();

            tipoUsuario = usuario.Rol == "ROLE_CLIENTE" ? "Cliente" :
                          usuario.Rol == "ROLE_ADMIN" ? "Admin" : "Grupo";

            lblTitulo.Text = $"EDITAR {tipoUsuario.ToUpper()}";
            btnAnyadir.Text = $"GUARDAR {tipoUsuario.ToUpper()}";

            ConfigurarCampos(tipoUsuario);

            tbNombre.Text = usuario.NombreCompleto;
            tbEmail.Text = usuario.Email;
            if (tbContrasena.Visible) tbContrasena.Text = usuario.Contrasena;
            if (tbTelefono.Visible) tbTelefono.Text = usuario.Telefono;
            if (tbAlergenos.Visible) tbAlergenos.Text = usuario.Alergenos;
            if (tbObservaciones.Visible) tbObservaciones.Text = usuario.Observaciones;

            btnAnyadir.Click += BtnAnyadir_Click;
        }

        private void ConfigurarCampos(string tipo)
        {
            tbNombre.Visible = lblNombre.Visible = true;
            tbEmail.Visible = lblEmail.Visible = true;
            tbContrasena.Visible = lblContrasena.Visible = true;
            tbTelefono.Visible = lblTelefono.Visible = true;
            tbAlergenos.Visible = lblAlergenos.Visible = true;
            tbObservaciones.Visible = lblObservaciones.Visible = true;

            switch (tipo)
            {
                case "Cliente":
                    break; // todo visible
                case "Admin":
                    tbTelefono.Visible = lblTelefono.Visible = false;
                    tbAlergenos.Visible = lblAlergenos.Visible = false;
                    tbObservaciones.Visible = lblObservaciones.Visible = false;
                    break;
                case "Grupo":
                    tbContrasena.Visible = lblContrasena.Visible = false;
                    tbTelefono.Visible = lblTelefono.Visible = false;
                    tbAlergenos.Visible = lblAlergenos.Visible = false;
                    tbObservaciones.Visible = lblObservaciones.Visible = false;
                    break;
            }
        }

        private async void BtnAnyadir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNombre.Text) || string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("Nombre y Email son obligatorios.");
                return;
            }

            // Preparar el objeto según tipo de usuario
            var nuevoUsuario = new
            {
                nombreCompleto = tbNombre.Text.Trim(),
                email = tbEmail.Text.Trim(),
                password = tbContrasena.Visible ? tbContrasena.Text.Trim() : null,
                telefono = tbTelefono.Visible ? tbTelefono.Text.Trim() : null,
                alergenos = tbAlergenos.Visible ? tbAlergenos.Text.Trim() : null,
                observaciones = tbObservaciones.Visible ? tbObservaciones.Text.Trim() : null
            };

            string url = tipoUsuario switch
            {
                "Cliente" => "http://localhost:8080/api/auth/register/cliente",
                "Admin" => "http://localhost:8080/api/auth/register/admin",
                "Grupo" => "http://localhost:8080/api/auth/register/grupo",
                _ => throw new Exception("Tipo de usuario no válido")
            };

            try
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var response = await httpClient.PostAsJsonAsync(url, nuevoUsuario);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"{tipoUsuario} añadido correctamente.");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    // Capturamos error de email duplicado
                    var contenido = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest &&
                        contenido.Contains("email") && contenido.Contains("ya existe"))
                    {
                        MessageBox.Show("Error: ya existe un usuario con este email. Cambia el email e intenta de nuevo.");
                        return; // no cerrar formulario
                    }

                    MessageBox.Show($"Error al añadir usuario: {response.StatusCode}\n{contenido}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }


        // ===========================
        // PROPIEDADES PÚBLICAS PARA Admins.cs
        // ===========================
        public string Nombre => tbNombre.Text.Trim();
        public string Email => tbEmail.Text.Trim();
        public string Contrasena => tbContrasena.Visible ? tbContrasena.Text.Trim() : null;
        public string Telefono => tbTelefono.Visible ? tbTelefono.Text.Trim() : null;
        public string Alergenos => tbAlergenos.Visible ? tbAlergenos.Text.Trim() : null;
        public string Observaciones => tbObservaciones.Visible ? tbObservaciones.Text.Trim() : null;
        public string Rol => tipoUsuario == "Cliente" ? "ROLE_CLIENTE" :
                             tipoUsuario == "Admin" ? "ROLE_ADMIN" : "ROLE_GRUPO";
    }
}
