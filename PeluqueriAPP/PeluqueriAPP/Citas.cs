using System;
using System.Collections.Generic;
using System.Drawing;
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

        // Listas para el manejo de datos
        private List<Cita> listaCitasOriginal = new();
        private List<dynamic> listaFiltrable = new();

        public Citas()
        {
            InitializeComponent();

            // --- AJUSTES PARA SER FORMULARIO HIJO ---
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(242, 242, 242);

            // IMPORTANTE: Evita que la tabla cree columnas nuevas al filtrar
            dgvCitas.AutoGenerateColumns = false;
            dgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            ConfigurarColumnas();

            // Suscripción de eventos
            tbBusqueda.TextChanged -= tbBusqueda_TextChanged;
            tbBusqueda.TextChanged += tbBusqueda_TextChanged;
        }

        private void ConfigurarColumnas()
        {
            // Estilos visuales para que coincida con Bloqueos
            dgvCitas.EnableHeadersVisualStyles = false;
            dgvCitas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvCitas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCitas.ColumnHeadersHeight = 45;
            dgvCitas.RowTemplate.Height = 40;
            dgvCitas.BackgroundColor = Color.White;
            dgvCitas.BorderStyle = BorderStyle.None;
            dgvCitas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

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

                // Preparamos la lista filtrable con los mismos nombres de propiedad que Bloqueos
                listaFiltrable = listaCitasOriginal.Select(c => (dynamic)new
                {
                    Id = c.id,
                    Fecha = c.fechaHoraInicio.ToString("dd/MM/yyyy"),
                    Hora = c.fechaHoraInicio.ToString("HH:mm"),
                    Cliente = c.cliente?.nombreCompleto ?? "N/A",
                    Servicio = c.agenda?.servicio?.nombre ?? "N/A",
                    Aula = c.agenda?.aula ?? "N/A"
                }).ToList<dynamic>();

                AplicarFiltro();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar citas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltro()
        {
            string busqueda = tbBusqueda.Text.Trim().ToLower();

            var filtrados = listaFiltrable.Where(c =>
                c.Cliente.ToLower().Contains(busqueda) ||
                c.Servicio.ToLower().Contains(busqueda) ||
                c.Aula.ToLower().Contains(busqueda) ||
                c.Fecha.ToLower().Contains(busqueda) ||
                c.Hora.ToLower().Contains(busqueda)
            ).ToList();

            dgvCitas.DataSource = null;
            dgvCitas.DataSource = filtrados;
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private async void Citas_Load(object sender, EventArgs e)
        {
            await CargarCitas();
        }

        // --- MÉTODOS DE ACCIÓN ---

        private async void btnAnyadir_Click(object sender, EventArgs e)
        {
            using (AnyadirCitas form = new AnyadirCitas())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var n = form.NuevaCita;
                    var payload = new
                    {
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
                    var payload = new
                    {
                        id = id,
                        fechaHoraInicio = n.fechaHoraInicio.ToString("yyyy-MM-ddTHH:mm:ss"),
                        clienteId = n.cliente.id,
                        agendaId = n.agenda.id
                    };
                    string urlEditar = API_CITAS_URL.TrimEnd('/') + "/" + id;
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
                if (metodo == HttpMethod.Post) response = await httpClient.PostAsJsonAsync(url, data);
                else if (metodo == HttpMethod.Put) response = await httpClient.PutAsJsonAsync(url, data);
                else if (metodo == HttpMethod.Delete) response = await httpClient.DeleteAsync(url);
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

        private void lblHome_Click(object sender, EventArgs e) { }
    }

    // --- DTOs ---
    public class Cita { public long id { get; set; } public DateTime fechaHoraInicio { get; set; } public ClienteDTO cliente { get; set; } public AgendaDTO agenda { get; set; } }
    public class ClienteDTO { public long id { get; set; } public string nombreCompleto { get; set; } }
    public class AgendaDTO { public long id { get; set; } public string aula { get; set; } public ServicioSimpleDTO servicio { get; set; } }
    public class ServicioSimpleDTO { public long id { get; set; } public string nombre { get; set; } }
}