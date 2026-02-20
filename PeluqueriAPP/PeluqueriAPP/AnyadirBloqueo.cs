using System;
using System.Collections.Generic;
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

            btnGuardarBloqueo.Click += btnGuardarBloqueo_Click;
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Load += async (s, e) => await CargarGrupos();
        }

        private async Task CargarGrupos()
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var resGrup = await httpClient.GetAsync("http://localhost:8080/api/grupos/");
                if (resGrup.IsSuccessStatusCode)
                {
                    var jsonGrup = await resGrup.Content.ReadAsStringAsync();
                    var grups = JsonConvert.DeserializeObject<List<GrupoDTO>>(jsonGrup);

                    // Asegúrate de que este nombre sea el mismo que el del diseñador
                    cmbGrupo.DataSource = grups;
                    cmbGrupo.DisplayMember = "NombreCompleto";
                    cmbGrupo.ValueMember = "Id";
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar grupos: " + ex.Message); }
        }

        private void ConfigurarControlesManuales()
        {
            dtpHoraInicio.Format = DateTimePickerFormat.Custom;
            dtpHoraInicio.CustomFormat = "HH:mm";
            dtpHoraInicio.ShowUpDown = true;

            dtpHoraFin.Format = DateTimePickerFormat.Custom;
            dtpHoraFin.CustomFormat = "HH:mm";
            dtpHoraFin.ShowUpDown = true;
        }

        private async void btnGuardarBloqueo_Click(object sender, EventArgs e)
        {
            if (cmbGrupo.SelectedValue == null || string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Por favor, selecciona un grupo e indica el motivo.", "Validación");
                return;
            }

            DateTime dia = calendarioBloqueo.SelectionStart;
            DateTime inicio = dia.Date.Add(dtpHoraInicio.Value.TimeOfDay);
            DateTime fin = dia.Date.Add(dtpHoraFin.Value.TimeOfDay);

            if (fin <= inicio)
            {
                MessageBox.Show("La hora de fin debe ser posterior a la de inicio.");
                return;
            }

            // Enviamos solo los datos del grupo y el tiempo
            var requestBody = new
            {
                fechaInicio = inicio.ToString("yyyy-MM-ddTHH:mm:ss"),
                fechaFin = fin.ToString("yyyy-MM-ddTHH:mm:ss"),
                motivo = txtMotivo.Text.Trim(),
                grupoId = (long)cmbGrupo.SelectedValue
            };

            try
            {
                btnGuardarBloqueo.Enabled = false;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await httpClient.PostAsync(API_BASE_URL, content);

                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Bloqueo de grupo aplicado con éxito.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error: " + await res.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex) { MessageBox.Show("Error de red: " + ex.Message); }
            finally { btnGuardarBloqueo.Enabled = true; }
        }
    }
}