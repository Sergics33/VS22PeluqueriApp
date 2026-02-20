using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PeluqueriAPP
{
    public partial class Bloqueos : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/agendas/";

        public Bloqueos()
        {
            InitializeComponent();

            // Configuración del Formulario para que encaje en el panel principal
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            ConfigurarTabla();

            // Suscribimos eventos
            btnNuevoBloqueo.Click -= btnNuevoBloqueo_Click;
            btnNuevoBloqueo.Click += btnNuevoBloqueo_Click;

            // Si tienes el botón de borrar en el diseño, descomenta esto:
            // btnBorrarBloqueo.Click -= btnBorrarBloqueo_Click;
            // btnBorrarBloqueo.Click += btnBorrarBloqueo_Click;

            this.Load += async (s, e) => await CargarHistorial();
        }

        private void ConfigurarTabla()
        {
            dgvBloqueos.AutoGenerateColumns = false;
            dgvBloqueos.Columns.Clear();

            // Los nombres en DataPropertyName deben coincidir con los del objeto anónimo en CargarHistorial
            dgvBloqueos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "id", Visible = false, Name = "IdCol" });
            dgvBloqueos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Aula", DataPropertyName = "aula", Width = 100 });
            dgvBloqueos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Inicio", DataPropertyName = "fechaInicioStr", Width = 130 });
            dgvBloqueos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fin", DataPropertyName = "horaFinStr", Width = 80 });
            dgvBloqueos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Motivo", DataPropertyName = "motivo", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            dgvBloqueos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBloqueos.MultiSelect = false;
            dgvBloqueos.ReadOnly = true;
        }

        private async Task CargarHistorial()
        {
            try
            {
                if (string.IsNullOrEmpty(Session.AccessToken)) return;

                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var response = await httpClient.GetAsync(API_BASE_URL);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var todas = JsonConvert.DeserializeObject<List<AgendaResponseDTO>>(json) ?? new List<AgendaResponseDTO>();

                    // Filtrar y proyectar los datos
                    var soloBloqueadas = todas
                        .Where(a => a.Bloqueada == true)
                        .Select(a => new
                        {
                            id = a.Id,
                            aula = a.Aula ?? "N/A",
                            fechaInicioStr = a.HoraInicio.ToString("dd/MM/yyyy HH:mm"),
                            horaFinStr = a.HoraFin.ToString("HH:mm"),
                            // Prioridad: 1. Motivo real, 2. Texto genérico si viene null
                            motivo = !string.IsNullOrWhiteSpace(a.MotivoBloqueo)
                                     ? a.MotivoBloqueo
                                     : "Bloqueo Administrativo"
                        })
                        .OrderByDescending(a => a.id) // Los más recientes primero
                        .ToList();

                    dgvBloqueos.DataSource = null;
                    dgvBloqueos.DataSource = soloBloqueadas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private async void btnNuevoBloqueo_Click(object sender, EventArgs e)
        {
            using (AnyadirBloqueo form = new AnyadirBloqueo())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Esperamos un poco para que el servidor procese antes de refrescar
                    await Task.Delay(300);
                    await CargarHistorial();
                }
            }
        }

        private async void btnBorrarBloqueo_Click(object sender, EventArgs e)
        {
            if (dgvBloqueos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un bloqueo para eliminar.");
                return;
            }

            var id = dgvBloqueos.SelectedRows[0].Cells["IdCol"].Value;

            if (MessageBox.Show("¿Deseas eliminar este bloqueo y liberar el horario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
                    var res = await httpClient.DeleteAsync(API_BASE_URL + id);

                    if (res.IsSuccessStatusCode)
                    {
                        await CargarHistorial();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el bloqueo. Es posible que ya no exista.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
        }
    }
}