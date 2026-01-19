using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;

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

            this.Load += Agendas_Load;
            this.tbBusqueda.TextChanged += new System.EventHandler(this.tbBusqueda_TextChanged);
            this.btnAnyadir.Click += new System.EventHandler(this.btnAnyadir_Click);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);

            dgvServicios.AutoGenerateColumns = false;
            dgvServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            dgvServicios.Columns.Clear();
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "id", Name = "IdCol" });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Aula", DataPropertyName = "aula", Name = "AulaCol" });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Inicio", DataPropertyName = "fechaInicioStr", Name = "InicioCol" });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fin", DataPropertyName = "horaFinStr", Name = "FinCol" });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Servicio", DataPropertyName = "servicioNombre", Name = "ServicioCol" });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Grupo", DataPropertyName = "grupoNombre", Name = "GrupoCol" });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Estado", DataPropertyName = "disponibilidadStr", Name = "EstadoCol" });
        }

        private async void Agendas_Load(object sender, EventArgs e) => await CargarAgendas();

        private async Task CargarAgendas()
        {
            try
            {
                if (!Session.IsLoggedIn) return;
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                var response = await httpClient.GetAsync(API_BASE_URL);
                if (response.IsSuccessStatusCode)
                {
                    listaAgendasOriginal = await response.Content.ReadFromJsonAsync<List<AgendaResponseDTO>>() ?? new List<AgendaResponseDTO>();
                    ActualizarGrid(listaAgendasOriginal);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error de carga: " + ex.Message); }
        }

        private void ActualizarGrid(List<AgendaResponseDTO> lista)
        {
            var listaParaGrid = lista.Select(a => new
            {
                id = a.Id,
                aula = a.Aula,
                fechaInicioStr = a.HoraInicio.ToString("dd/MM/yyyy HH:mm"),
                horaFinStr = a.HoraFin.ToString("HH:mm"),
                servicioNombre = a.Servicio?.Nombre ?? "N/A",
                grupoNombre = a.Grupo?.NombreCompleto ?? "N/A",
                disponibilidadStr = a.HorasDisponiblesEstado != null
                    ? string.Join(" | ", a.HorasDisponiblesEstado.OrderBy(h => h.Key).Select(h => $"{h.Key.Substring(Math.Max(0, h.Key.Length - 5))}: {(h.Value ? "Libre" : "Ocupado")}"))
                    : "Sin datos"
            }).ToList();

            dgvServicios.DataSource = null;
            dgvServicios.DataSource = listaParaGrid;
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            string filtro = tbBusqueda.Text.Trim().ToLower();
            var filtrados = listaAgendasOriginal.Where(a =>
                (a.Aula != null && a.Aula.ToLower().Contains(filtro)) ||
                (a.Servicio != null && a.Servicio.Nombre != null && a.Servicio.Nombre.ToLower().Contains(filtro))
            ).ToList();
            ActualizarGrid(filtrados);
        }

        // --- CORRECCIÓN CLAVE: Envío de IDs planos para AgendaRequest ---
        private async void btnAnyadir_Click(object sender, EventArgs e)
        {
            using (AnyadirAgenda form = new AnyadirAgenda())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var n = form.NuevaAgenda;

                    // El objeto anónimo debe coincidir EXACTAMENTE con los campos de tu AgendaRequest en Java
                    var dto = new
                    {
                        aula = n.Aula,
                        horaInicio = n.HoraInicio.ToString("yyyy-MM-ddTHH:mm:ss"), // Formato ISO para evitar errores
                        horaFin = n.HoraFin.ToString("yyyy-MM-ddTHH:mm:ss"),
                        sillas = n.Sillas,
                        servicioId = n.Servicio?.id, // Campo plano: servicioId
                        grupoId = n.Grupo?.Id        // Campo plano: grupoId
                    };

                    await EnviarApi(HttpMethod.Post, API_BASE_URL, dto);
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count == 0) return;

            // 1. Obtener ID de la fila seleccionada
            long id = (long)dgvServicios.SelectedRows[0].Cells["IdCol"].Value;
            var seleccionada = listaAgendasOriginal.FirstOrDefault(a => a.Id == id);

            using (AnyadirAgenda form = new AnyadirAgenda(seleccionada))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var n = form.NuevaAgenda;

                    // 2. Crear el DTO con campos planos (servicioId, grupoId)
                    var dto = new
                    {
                        aula = n.Aula,
                        horaInicio = n.HoraInicio.ToString("yyyy-MM-ddTHH:mm:ss"),
                        horaFin = n.HoraFin.ToString("yyyy-MM-ddTHH:mm:ss"),
                        sillas = n.Sillas,
                        servicioId = n.Servicio?.id,
                        grupoId = n.Grupo?.Id
                    };

                    // 3. Limpiar la URL para evitar la doble barra //
                    // Si API_BASE_URL es ".../agendas/", esto la convierte en ".../agendas/5"
                    string urlLimpia = API_BASE_URL.TrimEnd('/') + "/" + id;

                    await EnviarApi(HttpMethod.Put, urlLimpia, dto);
                }
            }
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count == 0) return;
            if (MessageBox.Show("¿Eliminar agenda?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            long id = (long)dgvServicios.SelectedRows[0].Cells["IdCol"].Value;
            await EnviarApi(HttpMethod.Delete, API_BASE_URL + id, null);
        }

        private async Task EnviarApi(HttpMethod metodo, string url, object data)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);
                HttpResponseMessage res;

                if (metodo == HttpMethod.Post) res = await httpClient.PostAsJsonAsync(url, data);
                else if (metodo == HttpMethod.Put) res = await httpClient.PutAsJsonAsync(url, data);
                else res = await httpClient.DeleteAsync(url);

                if (res.IsSuccessStatusCode)
                {
                    await CargarAgendas();
                }
                else
                {
                    // Leer el error detallado del servidor para depurar
                    string errorMsg = await res.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error en la operación: {res.StatusCode}\nDetalle: {errorMsg}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de comunicación: " + ex.Message);
            }
        }

        #region Navegación
        private void lblHomeAdmin_Click(object sender, EventArgs e) { new Home().Show(); this.Close(); }
        private void lblServicios_Click(object sender, EventArgs e) { new Servicios().Show(); this.Close(); }
        private void lblCitas_Click(object sender, EventArgs e) { new Citas().Show(); this.Close(); }
        private void label7_Click(object sender, EventArgs e) { new Admins().Show(); this.Close(); }
        #endregion
    }
}