using System;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PeluqueriAPP
{
    public partial class AnyadirBloqueo : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/agendas/bloquear";

        public AnyadirBloqueo()
        {
            InitializeComponent();
            ConfigurarControlesManuales();

            // Conexión de eventos
            btnGuardarBloqueo.Click += btnGuardarBloqueo_Click;
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        }

        private void ConfigurarControlesManuales()
        {
            // Ajustes visuales de los controles dentro del panel
            dtpHoraInicio.Format = DateTimePickerFormat.Custom;
            dtpHoraInicio.CustomFormat = "HH:mm";
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Font = new Font("Segoe UI", 11F);

            dtpHoraFin.Format = DateTimePickerFormat.Custom;
            dtpHoraFin.CustomFormat = "HH:mm";
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.Font = new Font("Segoe UI", 11F);

            txtMotivo.Font = new Font("Segoe UI", 11F);
            txtMotivo.Multiline = true;
        }

        private async void btnGuardarBloqueo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Por favor, introduce un motivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime dia = calendarioBloqueo.SelectionStart;
            DateTime inicio = dia.Date.Add(dtpHoraInicio.Value.TimeOfDay);
            DateTime fin = dia.Date.Add(dtpHoraFin.Value.TimeOfDay);

            if (fin <= inicio)
            {
                MessageBox.Show("La hora de fin debe ser posterior a la de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var requestBody = new
            {
                fechaInicio = inicio.ToString("yyyy-MM-ddTHH:mm:ss"),
                fechaFin = fin.ToString("yyyy-MM-ddTHH:mm:ss"),
                motivo = txtMotivo.Text.Trim()
            };

            try
            {
                btnGuardarBloqueo.Enabled = false;
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                // Serializamos con Newtonsoft para asegurar compatibilidad
                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await httpClient.PostAsync(API_BASE_URL, content);

                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Bloqueo aplicado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string error = await res.Content.ReadAsStringAsync();
                    MessageBox.Show("Error al aplicar bloqueo: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de red: " + ex.Message);
            }
            finally
            {
                btnGuardarBloqueo.Enabled = true;
            }
        }
    }
}