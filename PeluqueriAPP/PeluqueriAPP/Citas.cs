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
            dgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Importante para borrar
            ConfigurarColumnas();
            this.Load += new System.EventHandler(this.Citas_Load);
        }

        private void ConfigurarColumnas()
        {
            dgvCitas.Columns.Clear();
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id", Name = "IdCol", Visible = false });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha", DataPropertyName = "Fecha", Name = "FechaCol" });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Hora", DataPropertyName = "Hora", Name = "HoraCol" });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cliente", DataPropertyName = "Cliente", Name = "ClienteCol", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Servicio", DataPropertyName = "Servicio", Name = "ServicioCol" });
            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Aula", DataPropertyName = "Aula", Name = "AulaCol" });
        }

        private async void Citas_Load(object? sender, EventArgs e)
        {
            await CargarCitas();
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
                MessageBox.Show("Error al cargar citas: " + ex.Message);
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

        // --- BOTÓN BORRAR ---
        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una cita para borrar.");
                return;
            }

            // Obtenemos el ID de la fila seleccionada (usando el nombre de la columna IdCol)
            long id = (long)dgvCitas.SelectedRows[0].Cells["IdCol"].Value;

            var confirmacion = MessageBox.Show("¿Estás seguro de que deseas borrar esta cita?",
                "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                await BorrarCita(id);
            }
        }

        private async Task BorrarCita(long id)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                // Construimos la URL: http://localhost:8080/api/citas/ID
                string urlLimpia = API_CITAS_URL.TrimEnd('/') + "/" + id;
                var response = await httpClient.DeleteAsync(urlLimpia);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cita eliminada correctamente.");
                    await CargarCitas(); // Refrescamos la tabla
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la cita. Código: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con el servidor: " + ex.Message);
            }
        }

        // --- MÉTODOS DE NAVEGACIÓN ---
        private void lblHome_Click(object sender, EventArgs e) { new Home().Show(); Close(); }
        private void label7_Click(object sender, EventArgs e) { new Admins().Show(); this.Close(); }
        private void lblHome_Click_1(object sender, EventArgs e) { new Home().Show(); this.Close(); }
        private void lblServicios_Click(object sender, EventArgs e) { new Servicios().Show(); this.Close(); }
        private void lblAgenda_Click(object sender, EventArgs e) { new Agendas().Show(); this.Close(); }
    }

    // --- CLASES DTO ---
    public class Cita
    {
        public long id { get; set; }
        public DateTime fechaHoraInicio { get; set; }
        public ClienteDTO cliente { get; set; }
        public AgendaDTO agenda { get; set; }
    }
    public class ClienteDTO { public string nombreCompleto { get; set; } }
    public class AgendaDTO
    {
        public string aula { get; set; }
        public ServicioSimpleDTO servicio { get; set; }
    }
    public class ServicioSimpleDTO { public string nombre { get; set; } }
}