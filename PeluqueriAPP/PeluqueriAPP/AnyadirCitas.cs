using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace PeluqueriAPP
{
    public partial class AnyadirCitas : Form
    {
        private HttpClient httpClient = new HttpClient();
        public Cita NuevaCita { get; private set; }
        private long? citaId = null;
        private List<AgendaResponseDTO> agendasActuales = new List<AgendaResponseDTO>();

        public AnyadirCitas(Cita cita = null)
        {
            InitializeComponent();

            // Eventos: Cuando cambie Grupo o Servicio, buscamos DÍAS disponibles
            cmbGrupo.SelectedIndexChanged += async (s, e) => await CargarDiasDisponibles();
            cmbServicio.SelectedIndexChanged += async (s, e) => await CargarDiasDisponibles();

            // Evento: Cuando el usuario elija un DÍA, buscamos las HORAS de ese día
            cmbDias.SelectedIndexChanged += (s, e) => ActualizarComboHoras();

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
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var clientes = await httpClient.GetFromJsonAsync<List<ClienteDTO>>("http://localhost:8080/api/clientes/");
                cmbCliente.DataSource = clientes;
                cmbCliente.DisplayMember = "nombreCompleto";
                cmbCliente.ValueMember = "id";

                var grupos = await httpClient.GetFromJsonAsync<List<Grupo>>("http://localhost:8080/api/grupos/");
                cmbGrupo.DataSource = grupos;
                cmbGrupo.DisplayMember = "nombreCompleto";
                cmbGrupo.ValueMember = "id";

                var servicios = await httpClient.GetFromJsonAsync<List<Servicio>>("http://localhost:8080/api/servicios/");
                cmbServicio.DataSource = servicios;
                cmbServicio.DisplayMember = "nombre";
                cmbServicio.ValueMember = "id";

                if (citaExistente != null)
                {
                    cmbCliente.SelectedValue = citaExistente.cliente?.id;
                    // Aquí podrías pre-seleccionar el resto si es edición
                }

                await CargarDiasDisponibles();
            }
            catch (Exception ex) { MessageBox.Show("Error al conectar con el servidor: " + ex.Message); }
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

                cmbDias.Items.Clear();
                cmbHoras.Items.Clear();

                if (agendasActuales != null)
                {
                    // Extraemos fechas únicas que tengan al menos un hueco en 'true'
                    var fechasUnicas = agendasActuales
                        .SelectMany(a => a.HorasDisponiblesEstado)
                        .Where(h => h.Value == true)
                        .Select(h => DateTime.Parse(h.Key).ToString("dd/MM/yyyy"))
                        .Distinct()
                        .ToList();

                    foreach (var fecha in fechasUnicas)
                    {
                        cmbDias.Items.Add(fecha);
                    }
                }

                if (cmbDias.Items.Count > 0) cmbDias.SelectedIndex = 0;
            }
            catch { /* Manejo de error silencioso */ }
        }

        private void ActualizarComboHoras()
        {
            if (cmbDias.SelectedItem == null) return;

            cmbHoras.Items.Clear();
            string fechaSeleccionadaStr = cmbDias.SelectedItem.ToString();
            DateTime fechaSeleccionada = DateTime.Parse(fechaSeleccionadaStr).Date;

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
            if (cmbDias.SelectedItem == null || cmbHoras.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un día y una hora.", "Aviso");
                return;
            }

            DateTime fechaBase = DateTime.Parse(cmbDias.SelectedItem.ToString()).Date;
            TimeSpan horaBase = TimeSpan.Parse(cmbHoras.SelectedItem.ToString());
            DateTime fechaFinal = fechaBase.Add(horaBase);

            // Buscamos la agenda: 
            // Si es una cita nueva (citaId == null), buscamos que sea TRUE.
            // Si estamos editando, permitimos que sea la misma que ya tenemos aunque esté en FALSE (porque nosotros la ocupamos).
            var agendaSeleccionada = agendasActuales.FirstOrDefault(a =>
                a.HorasDisponiblesEstado != null &&
                a.HorasDisponiblesEstado.Any(h => DateTime.Parse(h.Key) == fechaFinal));

            if (agendaSeleccionada != null)
            {
                NuevaCita = new Cita
                {
                    // Si citaId es null, enviamos 0 para que el servidor cree una nueva
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