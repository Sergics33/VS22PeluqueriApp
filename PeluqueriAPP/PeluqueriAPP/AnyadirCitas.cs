using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirCitas : Form
    {
        private HttpClient httpClient = new HttpClient();
        public Cita NuevaCita { get; private set; }
        private long? citaId = null;

        public AnyadirCitas(Cita cita = null)
        {
            InitializeComponent();

            // CONFIGURACIÓN DEL SELECTOR DE FECHA Y HORA
            dtpFechaHora.Format = DateTimePickerFormat.Custom;
            dtpFechaHora.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFechaHora.ShowUpDown = true; // Usa flechas para evitar errores de selección

            if (cita != null)
            {
                citaId = cita.id;
                this.Text = "Editar Cita";
                dtpFechaHora.Value = cita.fechaHoraInicio;
            }

            this.Load += async (s, e) => await CargarDatosCombos(cita);
        }

        private async Task CargarDatosCombos(Cita citaExistente)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                // 1. CARGAR CLIENTES
                var clientes = await httpClient.GetFromJsonAsync<List<ClienteDTO>>("http://localhost:8080/api/clientes/");
                cmbCliente.DataSource = clientes;
                cmbCliente.DisplayMember = "nombreCompleto";
                cmbCliente.ValueMember = "id";

                // 2. CARGAR AGENDAS
                var agendas = await httpClient.GetFromJsonAsync<List<AgendaDTO>>("http://localhost:8080/api/agendas/");
                cmbAgenda.DataSource = agendas;
                cmbAgenda.ValueMember = "id"; // Aseguramos que tenga ValueMember

                // Formato visual para el combo de agendas
                cmbAgenda.Format += (s, e) =>
                {
                    var a = (AgendaDTO)e.ListItem;
                    string servicioNombre = a.servicio?.nombre ?? "Sin servicio";
                    e.Value = $"{a.aula} - {servicioNombre}";
                };

                // Si estamos editando, seleccionamos los valores actuales
                if (citaExistente != null)
                {
                    if (citaExistente.cliente != null)
                        cmbCliente.SelectedValue = citaExistente.cliente.id;

                    if (citaExistente.agenda != null)
                        cmbAgenda.SelectedValue = citaExistente.agenda.id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del servidor: " + ex.Message, "Error API", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones de selección
            if (cmbCliente.SelectedItem == null || cmbAgenda.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un cliente y una agenda.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Capturar la fecha del DateTimePicker
            DateTime seleccionada = dtpFechaHora.Value;

            // 3. VALIDACIÓN DE BLOQUES DE 30 MINUTOS
            // Esto evita que el servidor Java de error 400 por "huecos no encontrados"
            if (seleccionada.Minute != 0 && seleccionada.Minute != 30)
            {
                MessageBox.Show("Las citas solo se pueden reservar en bloques de 30 minutos (ejemplo: 10:00, 10:30, 11:00...).",
                    "Minutos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 4. LIMPIEZA DE DATOS (Segundos y Milisegundos a 0)
            DateTime fechaLimpia = new DateTime(
                seleccionada.Year,
                seleccionada.Month,
                seleccionada.Day,
                seleccionada.Hour,
                seleccionada.Minute,
                0, 0
            );

            // 5. Validación de horario comercial
            if (fechaLimpia.Hour < 8 || fechaLimpia.Hour > 21)
            {
                MessageBox.Show("El centro está cerrado. Selecciona una hora entre las 08:00 y las 21:00.",
                    "Horario no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 6. Crear el objeto NuevaCita
            NuevaCita = new Cita
            {
                id = citaId ?? 0,
                fechaHoraInicio = fechaLimpia,
                cliente = (ClienteDTO)cmbCliente.SelectedItem,
                agenda = (AgendaDTO)cmbAgenda.SelectedItem
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AnyadirCitas_Load(object sender, EventArgs e)
        {

        }
    }
}