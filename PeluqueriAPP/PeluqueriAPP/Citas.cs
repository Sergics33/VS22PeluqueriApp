using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class Citas : Form
    {
        private const string API_CITAS_URL = "http://localhost:8080/api/citas/";
        private HttpClient httpClient = new HttpClient();
        private List<Cita> listaCitasOriginal = new();

        public Citas()
        {
            InitializeComponent();
            dgvCitas.AutoGenerateColumns = false;
            dgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            dgvCitas.Columns.Clear();
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Name = "IdCol", Visible = false });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha", DataPropertyName = "Fecha", Name = "FechaCol", Width = 100 });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Hora", DataPropertyName = "Hora", Name = "HoraCol", Width = 80 });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cliente", DataPropertyName = "Cliente", Name = "ClienteCol", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Servicio", DataPropertyName = "Servicio", Name = "ServicioCol", Width = 150 });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Aula", DataPropertyName = "Aula", Name = "AulaCol", Width = 100 });
        }

        private async Task CargarCitas()
        {
            if (string.IsNullOrEmpty(Session.AccessToken)) return;
            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var citas = await httpClient.GetFromJsonAsync<List<Cita>>(API_CITAS_URL);
                listaCitasOriginal = citas ?? new List<Cita>();
                ActualizarGrid(listaCitasOriginal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar citas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarGrid(List<Cita> citas)
        {
            var listaParaGrid = citas.Select(c => new
            {
                Id = c.id,
                Fecha = c.fechaHoraInicio.ToString("dd/MM/yyyy"),
                Hora = c.fechaHoraInicio.ToString("HH:mm"),
                Cliente = c.cliente?.nombreCompleto ?? "N/A",
                Servicio = c.agenda?.servicio?.nombre ?? "N/A",
                Aula = c.agenda?.aula ?? "N/A"
            }).ToList();

            dgvCitas.DataSource = null;
            dgvCitas.DataSource = listaParaGrid;
        }

        // --- ACCIONES PRINCIPALES ---

        private async void btnAnyadir_Click(object sender, EventArgs e)
        {
            using (AnyadirCitas form = new AnyadirCitas())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var n = form.NuevaCita;
                    var payload = new
                    {
                        // Para añadir, NO enviamos ID o enviamos 0
                        fechaHoraInicio = n.fechaHoraInicio.ToString("yyyy-MM-ddTHH:mm:ss"),
                        clienteId = n.cliente.id,
                        agendaId = n.agenda.id
                    };

                    await EnviarApiCita(HttpMethod.Post, API_CITAS_URL, payload);
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una cita para editar.");
                return;
            }

            long id = (long)dgvCitas.SelectedRows[0].Cells["IdCol"].Value;
            var seleccionada = listaCitasOriginal.FirstOrDefault(c => c.id == id);

            if (seleccionada == null) return;

            using (AnyadirCitas form = new AnyadirCitas(seleccionada))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var n = form.NuevaCita;

                    // Enviamos el objeto con la estructura que Spring suele preferir para PUT
                    var payload = new
                    {
                        id = id,
                        fechaHoraInicio = n.fechaHoraInicio.ToString("yyyy-MM-ddTHH:mm:ss"),
                        clienteId = n.cliente.id,
                        agendaId = n.agenda.id
                    };

                    // IMPORTANTE: La URL debe terminar en el ID sin barras extra
                    string urlEditar = API_CITAS_URL.TrimEnd('/') + "/" + id;

                    // Volvemos a intentar PUT. Si falla con 405, el problema está en el Backend (CORS)
                    await EnviarApiCita(HttpMethod.Put, urlEditar, payload);
                }
            }
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0) return;
            long id = (long)dgvCitas.SelectedRows[0].Cells["IdCol"].Value;

            if (MessageBox.Show("¿Estás seguro de borrar esta cita?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string urlDelete = API_CITAS_URL.TrimEnd('/') + "/" + id;
                await EnviarApiCita(HttpMethod.Delete, urlDelete, null);
            }
        }

        private async Task EnviarApiCita(HttpMethod metodo, string url, object data)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                HttpResponseMessage response;

                if (metodo == HttpMethod.Post)
                    response = await httpClient.PostAsJsonAsync(url, data);
                else if (metodo == HttpMethod.Put)
                    response = await httpClient.PutAsJsonAsync(url, data); // Enviamos PUT real
                else if (metodo == HttpMethod.Delete)
                    response = await httpClient.DeleteAsync(url);
                else return;

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Operación realizada con éxito.");
                    await CargarCitas();
                }
                else
                {
                    string errorDetail = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error {response.StatusCode}: {errorDetail}");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // --- MÉTODOS DE NAVEGACIÓN (CONSERVADOS) ---

        private async void Citas_Load(object sender, EventArgs e)
        {
            await CargarCitas();
        }

        private void lblHome_Click_1(object sender, EventArgs e)
        {
            new Home().Show();
            this.Close();
        }

        private void lblHome_Click(object sender, EventArgs e) { new Home().Show(); this.Close(); }
        private void lblServicios_Click(object sender, EventArgs e) { new Servicios().Show(); this.Close(); }
        private void lblAgenda_Click(object sender, EventArgs e) { new Agendas().Show(); this.Close(); }
        private void label7_Click(object sender, EventArgs e) { new Admins().Show(); this.Close(); }
    }

    // --- DTOs ---
    public class Cita
    {
        public long id { get; set; }
        public DateTime fechaHoraInicio { get; set; }
        public ClienteDTO cliente { get; set; }
        public AgendaDTO agenda { get; set; }
    }

    public class ClienteDTO
    {
        public long id { get; set; }
        public string nombreCompleto { get; set; }
    }

    public class AgendaDTO
    {
        public long id { get; set; }
        public string aula { get; set; }
        public ServicioSimpleDTO servicio { get; set; }
    }

    public class ServicioSimpleDTO
    {
        public long id { get; set; }
        public string nombre { get; set; }
    }
}