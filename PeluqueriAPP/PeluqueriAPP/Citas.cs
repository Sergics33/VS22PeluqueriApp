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
            // El evento Load se gestiona a través del método Citas_Load abajo
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
                        fechaHoraInicio = n.fechaHoraInicio.ToString("s"),
                        clienteId = n.cliente.id,
                        agendaId = n.agenda.id
                    };

                    try
                    {
                        // Intentamos enviar la cita
                        await EnviarApiCita(HttpMethod.Post, API_CITAS_URL, payload);
                        MessageBox.Show("Cita añadida correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Aquí podrías llamar a tu método de refrescar la lista
                    }
                    catch (HttpRequestException ex)
                    {
                        // Si el servidor responde con 400 (Bad Request)
                        if (ex.Message.Contains("400"))
                        {
                            MessageBox.Show("La hora seleccionada no es válida para esta agenda o no hay sillas disponibles. Por favor, elige otra hora.",
                                "Hora no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Error de conexión: " + ex.Message);
                        }
                    }
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una cita de la tabla para editar.");
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
                    var payload = new
                    {
                        id = id,
                        fechaHoraInicio = n.fechaHoraInicio.ToString("yyyy-MM-ddTHH:mm:ss"),
                        cliente = new { id = n.cliente.id },
                        agenda = new { id = n.agenda.id }
                    };

                    string url = API_CITAS_URL.TrimEnd('/') + "/" + id;
                    await EnviarApiCita(HttpMethod.Put, url, payload);
                }
            }
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una cita para borrar.");
                return;
            }

            long id = (long)dgvCitas.SelectedRows[0].Cells["IdCol"].Value;

            if (MessageBox.Show("¿Estás seguro de borrar esta cita?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
                    var response = await httpClient.DeleteAsync($"{API_CITAS_URL}{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Cita eliminada.");
                        await CargarCitas();
                    }
                    else
                    {
                        MessageBox.Show("Error al borrar: " + response.StatusCode);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private async Task EnviarApiCita(HttpMethod metodo, string url, object data)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                HttpRequestMessage request = new HttpRequestMessage(metodo, url)
                {
                    Content = JsonContent.Create(data)
                };

                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Operación exitosa.");
                    await CargarCitas();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error {response.StatusCode}: {error}");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error de conexión: " + ex.Message); }
        }

        // --- MÉTODOS REQUERIDOS POR EL DISEÑADOR (NO BORRAR) ---

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