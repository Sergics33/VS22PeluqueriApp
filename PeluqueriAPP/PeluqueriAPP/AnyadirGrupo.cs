using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirGrupo : Form
    {
        public Grupo NuevoGrupo { get; private set; }

        private readonly HttpClient httpClient = new HttpClient();

        public AnyadirGrupo()
        {
            InitializeComponent();
            btnAnyadir.Click += BtnAnyadir_Click;
            lbltitulo.Text = "AÑADIR GRUPO";
            btnAnyadir.Text = "AÑADIR GRUPO";
        }

        private async void BtnAnyadir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNombre.Text) ||
                string.IsNullOrWhiteSpace(tbEmail.Text) ||
                string.IsNullOrWhiteSpace(tbPassword.Text) ||
                string.IsNullOrWhiteSpace(tbClase.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios");
                return;
            }

            var request = new
            {
                nombreCompleto = tbNombre.Text.Trim(),
                email = tbEmail.Text.Trim(),
                password = tbPassword.Text.Trim(),
                clase = tbClase.Text.Trim()
            };

            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var response = await httpClient.PostAsJsonAsync(
                    "http://localhost:8080/api/auth/register/grupo",
                    request
                );

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Grupo añadido correctamente");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error {response.StatusCode}\n{error}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión:\n" + ex.Message);
            }
        }

        private void tbClase_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
