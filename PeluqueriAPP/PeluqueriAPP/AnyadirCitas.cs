using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Text.Json;

namespace PeluqueriAPP
{
    public partial class AnyadirCitas : Form
    {
        private HttpClient httpClient = new HttpClient();
        public Cita NuevaCita { get; private set; }
        private long? citaId = null;
        private bool cargando = false;

        private List<Servicio> listaServiciosMaestra = new List<Servicio>();
        private List<AgendaResponseDTO> agendasActuales = new List<AgendaResponseDTO>();

        public AnyadirCitas(Cita cita = null)
        {
            InitializeComponent();

            // EVENTOS PRINCIPALES
            cmbGrupo.SelectedIndexChanged += async (s, e) => {
                if (!cargando)
                {
                    await FiltrarServiciosPorGrupo();
                    await CargarDiasDisponibles();
                }
            };

            cmbServicio.SelectedIndexChanged += async (s, e) => {
                if (!cargando) await CargarDiasDisponibles();
            };

            // Evento del Calendario: Cuando el usuario hace clic en un día
            monthCalendarCitas.DateSelected += (s, e) => {
                if (!cargando) ActualizarComboHoras();
            };

            if (cita != null)
            {
                citaId = cita.id;
                this.Text = "Editar Cita";
            }

            this.Load += async (s, e) => await CargarDatosIniciales(cita);
        }

        private async Task CargarDatosIniciales(Cita citaExistente)
        {
            try
            {
                cargando = true;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                listaServiciosMaestra = await httpClient.GetFromJsonAsync<List<Servicio>>("http://localhost:8080/api/servicios/") ?? new List<Servicio>();

                var clientes = await httpClient.GetFromJsonAsync<List<ClienteDTO>>("http://localhost:8080/api/clientes/");
                cmbCliente.DataSource = clientes;
                cmbCliente.DisplayMember = "nombreCompleto";
                cmbCliente.ValueMember = "id";

                var grupos = await httpClient.GetFromJsonAsync<List<Grupo>>("http://localhost:8080/api/grupos/");
                cmbGrupo.DataSource = grupos;
                cmbGrupo.DisplayMember = "nombreCompleto";
                cmbGrupo.ValueMember = "id";

                cargando = false;
                await FiltrarServiciosPorGrupo();
                await CargarDiasDisponibles();
            }
            catch (Exception ex) { MessageBox.Show("Error inicial: " + ex.Message); }
        }

        private async Task FiltrarServiciosPorGrupo()
        {
            if (cmbGrupo.SelectedValue == null) return;
            long grupoId = Convert.ToInt64(cmbGrupo.SelectedValue);

            try
            {
                string url = $"http://localhost:8080/api/agendas/?grupo={grupoId}";
                var response = await httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode) return;

                string jsonRaw = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(jsonRaw);
                var idsServicios = new HashSet<long>();

                foreach (var elemento in doc.RootElement.EnumerateArray())
                {
                    if (elemento.TryGetProperty("servicio", out var serv) && serv.TryGetProperty("id", out var idProp))
                        idsServicios.Add(idProp.GetInt64());
                }

                var filtrados = listaServiciosMaestra.Where(s => idsServicios.Contains(s.id)).ToList();

                cargando = true;
                cmbServicio.DataSource = null;
                if (filtrados.Any())
                {
                    cmbServicio.DataSource = filtrados;
                    cmbServicio.DisplayMember = "nombre";
                    cmbServicio.ValueMember = "id";
                }
                cargando = false;
            }
            catch { cargando = false; }
        }

        private async Task CargarDiasDisponibles()
        {
            if (cmbGrupo.SelectedValue == null || cmbServicio.SelectedValue == null) return;

            try
            {
                long grupoId = Convert.ToInt64(cmbGrupo.SelectedValue);
                long servicioId = Convert.ToInt64(cmbServicio.SelectedValue);

                string url = $"http://localhost:8080/api/agendas/?servicio={servicioId}&grupo={grupoId}";
                agendasActuales = await httpClient.GetFromJsonAsync<List<AgendaResponseDTO>>(url);

                cargando = true;
                monthCalendarCitas.RemoveAllBoldedDates(); // Limpiar calendario

                if (agendasActuales != null)
                {
                    var fechasLibres = agendasActuales
                        .SelectMany(a => a.HorasDisponiblesEstado)
                        .Where(h => h.Value == true)
                        .Select(h => DateTime.Parse(h.Key).Date)
                        .Distinct()
                        .ToArray();

                    monthCalendarCitas.BoldedDates = fechasLibres; // Marcamos días con huecos
                    monthCalendarCitas.UpdateBoldedDates();

                    if (fechasLibres.Any()) monthCalendarCitas.SelectionStart = fechasLibres.First();
                }

                cargando = false;
                ActualizarComboHoras();
            }
            catch { cargando = false; }
        }

        private void ActualizarComboHoras()
        {
            DateTime fechaSeleccionada = monthCalendarCitas.SelectionStart.Date;
            cmbHoras.Items.Clear();

            foreach (var agenda in agendasActuales)
            {
                if (agenda.HorasDisponiblesEstado != null)
                {
                    var horas = agenda.HorasDisponiblesEstado
                        .Where(h => DateTime.Parse(h.Key).Date == fechaSeleccionada && h.Value == true)
                        .Select(h => DateTime.Parse(h.Key).ToString("HH:mm"))
                        .OrderBy(h => h);

                    foreach (var h in horas)
                    {
                        if (!cmbHoras.Items.Contains(h)) cmbHoras.Items.Add(h);
                    }
                }
            }
            if (cmbHoras.Items.Count > 0) cmbHoras.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbHoras.SelectedItem == null) return;

            DateTime fechaBase = monthCalendarCitas.SelectionStart.Date;
            TimeSpan horaBase = TimeSpan.Parse(cmbHoras.SelectedItem.ToString());
            DateTime fechaFinal = fechaBase.Add(horaBase);

            var agendaSeleccionada = agendasActuales.FirstOrDefault(a =>
                a.HorasDisponiblesEstado != null &&
                a.HorasDisponiblesEstado.Any(h => DateTime.Parse(h.Key) == fechaFinal));

            if (agendaSeleccionada != null)
            {
                NuevaCita = new Cita
                {
                    id = citaId ?? 0,
                    fechaHoraInicio = fechaFinal,
                    cliente = (ClienteDTO)cmbCliente.SelectedItem,
                    agenda = new AgendaDTO { id = agendaSeleccionada.Id }
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
    }
}