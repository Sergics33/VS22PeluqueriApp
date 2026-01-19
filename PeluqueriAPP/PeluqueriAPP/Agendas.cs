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

            // --- CONEXIÓN AUTOMÁTICA DE EVENTOS (El "Cableado") ---
            this.Load += Agendas_Load;

            // Conectamos la barra de búsqueda
            this.tbBusqueda.TextChanged += new System.EventHandler(this.tbBusqueda_TextChanged);

            // Conectamos los botones de acción
            this.btnAnyadir.Click += new System.EventHandler(this.btnAnyadir_Click);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);

            // Configuración del Grid
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

            dgvServicios.DataSource = null; // Limpiar para refrescar
            dgvServicios.DataSource = listaParaGrid;
        }

        // --- FUNCIONALIDAD DE BÚSQUEDA ---
        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            string filtro = tbBusqueda.Text.Trim().ToLower();
            var filtrados = listaAgendasOriginal.Where(a =>
                (a.Aula != null && a.Aula.ToLower().Contains(filtro)) ||
                (a.Servicio != null && a.Servicio.Nombre != null && a.Servicio.Nombre.ToLower().Contains(filtro))
            ).ToList();
            ActualizarGrid(filtrados);
        }

        // --- FUNCIONALIDAD DE ACCIONES ---
        private async void btnAbrirAnyadir_Click(object sender, EventArgs e)
        {
            using (var form = new AnyadirAgenda())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // CREAMOS EL OBJETO QUE LA API ESPERA (AgendaRequest)
                    // Es vital que los nombres coincidan con los de tu Java (grupoId, servicioId)
                    var datosParaEnviar = new
                    {
                        aula = form.NuevaAgenda.Aula,
                        horaInicio = form.NuevaAgenda.HoraInicio.ToString("yyyy-MM-ddTHH:mm:ss"),
                        horaFin = form.NuevaAgenda.HoraFin.ToString("yyyy-MM-ddTHH:mm:ss"),
                        sillas = form.NuevaAgenda.Sillas,

                        // AQUÍ ESTABA EL ERROR: Debes pasar el ID numérico explícitamente
                        servicioId = form.NuevaAgenda.Servicio?.id,
                        grupoId = form.NuevaAgenda.Grupo?.Id
                    };

                    // Enviar a la API
                    var response = await httpClient.PostAsJsonAsync("api/agendas", datosParaEnviar);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Agenda creada correctamente");
                        CargarAgendas(); // Refrescar lista
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Error del servidor: " + error);
                    }
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count == 0) return;
            long id = (long)dgvServicios.SelectedRows[0].Cells["IdCol"].Value;
            var seleccionada = listaAgendasOriginal.FirstOrDefault(a => a.Id == id);

            AnyadirAgenda form = new AnyadirAgenda(seleccionada);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var n = form.NuevaAgenda;
                var dto = new { aula = n.Aula, horaInicio = n.HoraInicio, horaFin = n.HoraFin, sillas = n.Sillas, servicio = new { id = n.Servicio.id }, grupo = new { id = n.Grupo.Id } };
                await EnviarApi(HttpMethod.Put, API_BASE_URL + id, dto);
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
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);
            HttpResponseMessage res = (metodo == HttpMethod.Post) ? await httpClient.PostAsJsonAsync(url, data) :
                                     (metodo == HttpMethod.Put) ? await httpClient.PutAsJsonAsync(url, data) :
                                     await httpClient.DeleteAsync(url);
            if (res.IsSuccessStatusCode) await CargarAgendas();
            else MessageBox.Show("Error en la operación");
        }

        #region Navegación
        private void lblHomeAdmin_Click(object sender, EventArgs e) { new Home().Show(); this.Close(); }
        private void lblServicios_Click(object sender, EventArgs e) { new Servicios().Show(); this.Close(); }
        private void lblCitas_Click(object sender, EventArgs e) { new Citas().Show(); this.Close(); }
        private void label7_Click(object sender, EventArgs e) { new Admins().Show(); this.Close(); }
        #endregion
    }
}