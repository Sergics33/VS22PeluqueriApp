using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirUsuario : Form
    {
        private string tipoUsuario;
        private long? usuarioId = null; // Si es null, estamos creando. Si tiene valor, editamos.

        // CONSTRUCTOR PARA AÑADIR NUEVO
        public AnyadirUsuario(string tipo)
        {
            InitializeComponent();
            this.tipoUsuario = tipo;

            lblTitulo.Text = $"AÑADIR {tipo.ToUpper()}";
            btnAnyadir.Text = $"GUARDAR {tipo.ToUpper()}";

            ConfigurarCampos(tipo);
        }

        // CONSTRUCTOR PARA EDITAR EXISTENTE
        public AnyadirUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));
            InitializeComponent();

            this.usuarioId = usuario.Id;
            this.tipoUsuario = usuario.Rol == "ROLE_CLIENTE" ? "Cliente" :
                               usuario.Rol == "ROLE_ADMIN" ? "Admin" : "Grupo";

            lblTitulo.Text = $"EDITAR {tipoUsuario.ToUpper()}";
            btnAnyadir.Text = "ACTUALIZAR DATOS";

            ConfigurarCampos(tipoUsuario);

            // Rellenar los campos con los datos actuales
            tbNombre.Text = usuario.NombreCompleto;
            tbEmail.Text = usuario.Email;

            if (tbTelefono.Visible) tbTelefono.Text = usuario.Telefono;
            if (tbAlergenos.Visible) tbAlergenos.Text = usuario.Alergenos;
            if (tbObservaciones.Visible) tbObservaciones.Text = usuario.Observaciones;

            // En edición, la contraseña se marca como opcional
            lblContrasena.Text = "Contraseña (dejar vacío para no cambiar):";
        }

        private void ConfigurarCampos(string tipo)
        {
            // Reset de visibilidad (por defecto todo visible para Cliente)
            lblNombre.Visible = tbNombre.Visible = true;
            lblEmail.Visible = tbEmail.Visible = true;
            lblContrasena.Visible = tbContrasena.Visible = true;
            lblTelefono.Visible = tbTelefono.Visible = true;
            lblAlergenos.Visible = tbAlergenos.Visible = true;
            lblObservaciones.Visible = tbObservaciones.Visible = true;

            if (tipo == "Admin")
            {
                lblTelefono.Visible = tbTelefono.Visible = false;
                lblAlergenos.Visible = tbAlergenos.Visible = false;
                lblObservaciones.Visible = tbObservaciones.Visible = false;
            }
            else if (tipo == "Grupo")
            {
                lblContrasena.Visible = tbContrasena.Visible = false;
                lblTelefono.Visible = tbTelefono.Visible = false;
                lblAlergenos.Visible = tbAlergenos.Visible = false;
                lblObservaciones.Visible = tbObservaciones.Visible = false;
            }
        }

        private async void BtnAnyadir_Click(object sender, EventArgs e)
        {
            // Validación básica
            if (string.IsNullOrWhiteSpace(tbNombre.Text) || string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("El nombre y el email son obligatorios.");
                return;
            }

            // Preparar el objeto JSON
            var datos = new
            {
                nombreCompleto = tbNombre.Text.Trim(),
                email = tbEmail.Text.Trim(),
                password = string.IsNullOrWhiteSpace(tbContrasena.Text) ? null : tbContrasena.Text.Trim(),
                telefono = tbTelefono.Visible ? tbTelefono.Text.Trim() : null,
                alergenos = tbAlergenos.Visible ? tbAlergenos.Text.Trim() : null,
                observaciones = tbObservaciones.Visible ? tbObservaciones.Text.Trim() : null
            };

            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                HttpResponseMessage response;
                string url;

                if (usuarioId.HasValue)
                {
                    // --- MODO EDICIÓN (PUT) ---
                    // Determinamos el endpoint según el rol
                    string folder = tipoUsuario.ToLower() == "cliente" ? "clientes" : tipoUsuario.ToLower();
                    url = $"http://localhost:8080/api/{folder}/{usuarioId.Value}";
                    response = await client.PutAsJsonAsync(url, datos);
                }
                else
                {
                    // --- MODO CREACIÓN (POST) ---
                    url = $"http://localhost:8080/api/auth/register/{tipoUsuario.ToLower()}";
                    response = await client.PostAsJsonAsync(url, datos);
                }

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(usuarioId.HasValue ? "Usuario actualizado con éxito." : "Usuario creado con éxito.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string errorMsg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error en la operación: {errorMsg}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}");
            }
        }
    }
}