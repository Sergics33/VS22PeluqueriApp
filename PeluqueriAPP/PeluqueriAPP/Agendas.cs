using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PeluqueriAPP
{
    public partial class Agendas : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/agendas/";
        private List<AgendaResponseDTO> listaAgendasOriginal = new List<AgendaResponseDTO>();

        public Agendas()
        {
            InitializeComponent();

            dgvServicios.AutoGenerateColumns = false;
            dgvServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicios.MultiSelect = false;
            ConfigurarColumnas();

            // Suscripción a eventos de botones
            btnAnyadir.Click -= btnAnyadir_Click;
            btnAnyadir.Click += btnAnyadir_Click;
            btnEditar.Click -= btnEditar_Click;
            btnEditar.Click += btnEditar_Click;
            btnBorrar.Click -= btnBorrar_Click;
            btnBorrar.Click += btnBorrar_Click;

            this.Load += async (s, e) => await CargarAgendas();
        }

        private void ConfigurarColumnas()
        {
            dgvServicios.Columns.Clear();
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "id", Name = "IdCol", Visible = false });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Aula", DataPropertyName = "aula", Name = "AulaCol", AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Inicio", DataPropertyName = "fechaInicioStr", Name = "InicioCol", Width = 120 });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fin", DataPropertyName = "horaFinStr", Name = "FinCol", Width = 80 });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Servicio", DataPropertyName = "servicioNombre", Name = "ServicioCol", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Grupo", DataPropertyName = "grupoNombre", Name = "GrupoCol", Width = 100 });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Estado", DataPropertyName = "disponibilidadStr", Name = "EstadoCol", Width = 200 });
        }

        private async Task CargarAgendas()
        {
            try
            {
                if (!Session.IsLoggedIn) return;

                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var response = await httpClient.GetAsync(API_BASE_URL);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    listaAgendasOriginal = JsonConvert.DeserializeObject<List<AgendaResponseDTO>>(json) ?? new List<AgendaResponseDTO>();

                    // Aplicamos el filtro (si hay algo escrito en el buscador se mantiene, si no, carga todo)
                    AplicarFiltroYActualizarGrid();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error de carga: " + ex.Message); }
        }

        private void AplicarFiltroYActualizarGrid()
        {
            string filtro = tbBusqueda.Text.Trim().ToLower();

            // 1. Mapeamos la lista original a los strings que el usuario ve en el Grid
            var listaMapeada = listaAgendasOriginal.Select(a => new
            {
                id = a.Id,
                aula = a.Aula ?? "",
                fechaInicioStr = a.HoraInicio.ToString("dd/MM/yyyy HH:mm"),
                horaFinStr = a.HoraFin.ToString("HH:mm"),
                servicioNombre = a.Servicio?.Nombre ?? "N/A",
                grupoNombre = a.Grupo?.NombreCompleto ?? "N/A",
                disponibilidadStr = a.Bloqueada
                    ? "BLOQUEADA: " + (string.IsNullOrEmpty(a.MotivoBloqueo) ? "Manual" : a.MotivoBloqueo)
                    : (a.HorasDisponiblesEstado != null
                        ? string.Join(" | ", a.HorasDisponiblesEstado.OrderBy(h => h.Key).Select(h => $"{h.Key.Substring(Math.Max(0, h.Key.Length - 5))}: {(h.Value ? "Libre" : "Ocupado")}"))
                        : "Sin datos")
            }).ToList();

            // 2. Filtramos sobre la lista ya procesada
            var filtrados = listaMapeada.Where(x =>
                x.aula.ToLower().Contains(filtro) ||
                x.servicioNombre.ToLower().Contains(filtro) ||
                x.grupoNombre.ToLower().Contains(filtro) ||
                x.disponibilidadStr.ToLower().Contains(filtro) ||
                x.fechaInicioStr.Contains(filtro)
            ).ToList();

            dgvServicios.DataSource = null;
            dgvServicios.DataSource = filtrados;
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroYActualizarGrid();
        }

        private async void btnAnyadir_Click(object sender, EventArgs e)
        {
            using (AnyadirAgenda form = new AnyadirAgenda())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var n = form.NuevaAgenda;
                    if (n == null) return;

                    var dto = new
                    {
                        aula = n.Aula,
                        horaInicio = n.HoraInicio.ToString("yyyy-MM-ddTHH:mm:ss"),
                        horaFin = n.HoraFin.ToString("yyyy-MM-ddTHH:mm:ss"),
                        sillas = n.Sillas,
                        servicioId = n.Servicio?.id,
                        grupoId = n.Grupo?.Id
                    };

                    await EnviarApi(HttpMethod.Post, API_BASE_URL, dto);
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count == 0) return;

            long id = (long)dgvServicios.SelectedRows[0].Cells["IdCol"].Value;
            var seleccionada = listaAgendasOriginal.FirstOrDefault(a => a.Id == id);

            using (AnyadirAgenda form = new AnyadirAgenda(seleccionada))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var n = form.NuevaAgenda;
                    if (n == null) return;

                    var dto = new
                    {
                        aula = n.Aula,
                        horaInicio = n.HoraInicio.ToString("yyyy-MM-ddTHH:mm:ss"),
                        horaFin = n.HoraFin.ToString("yyyy-MM-ddTHH:mm:ss"),
                        sillas = n.Sillas,
                        servicioId = n.Servicio?.id,
                        grupoId = n.Grupo?.Id
                    };

                    string urlLimpia = API_BASE_URL.TrimEnd('/') + "/" + id;
                    await EnviarApi(HttpMethod.Put, urlLimpia, dto);
                }
            }
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count == 0) return;
            if (MessageBox.Show("¿Eliminar agenda?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            long id = (long)dgvServicios.SelectedRows[0].Cells["IdCol"].Value;
            await EnviarApi(HttpMethod.Delete, API_BASE_URL + id, null);
        }

        private async Task EnviarApi(HttpMethod metodo, string url, object data)
        {
            try
            {
                this.Enabled = false;
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                HttpResponseMessage res;
                if (metodo == HttpMethod.Post)
                {
                    string json = JsonConvert.SerializeObject(data);
                    res = await httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                }
                else if (metodo == HttpMethod.Put)
                {
                    string json = JsonConvert.SerializeObject(data);
                    res = await httpClient.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                }
                else
                {
                    res = await httpClient.DeleteAsync(url);
                }

                if (res.IsSuccessStatusCode)
                {
                    await CargarAgendas();
                }
                else
                {
                    string errorMsg = await res.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {res.StatusCode}\n{errorMsg}");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            finally { this.Enabled = true; }
        }

        // Navegación
        private void lblServicios_Click(object sender, EventArgs e) { new Servicios().Show(); this.Close(); }
        private void lblHomeAdmin_Click(object sender, EventArgs e) { new Home().Show(); this.Close(); }
        private void lblAdmins_Click(object sender, EventArgs e) { new Admins().Show(); this.Close(); }
    }
}