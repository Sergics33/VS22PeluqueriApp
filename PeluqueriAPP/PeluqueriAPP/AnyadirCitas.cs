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

                // 1. CARGAR CLIENTES: Según tu lista es /api/clientes/
                var clientes = await httpClient.GetFromJsonAsync<List<ClienteDTO>>("http://localhost:8080/api/clientes/");
                cmbCliente.DataSource = clientes;
                cmbCliente.DisplayMember = "nombreCompleto";
                cmbCliente.ValueMember = "id";

                // 2. CARGAR AGENDAS: Según tu lista es /api/agendas/
                var agendas = await httpClient.GetFromJsonAsync<List<AgendaDTO>>("http://localhost:8080/api/agendas/");
                cmbAgenda.DataSource = agendas;

                // Formato visual para el combo de agendas
                cmbAgenda.Format += (s, e) => {
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
            if (cmbCliente.SelectedItem == null || cmbAgenda.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un cliente y una agenda.");
                return;
            }

            // EXTRAER FECHA Y LIMPIAR SEGUNDOS Y MILISEGUNDOS
            DateTime seleccionada = dtpFechaHora.Value;
            DateTime fechaLimpia = new DateTime(
                seleccionada.Year,
                seleccionada.Month,
                seleccionada.Day,
                seleccionada.Hour,
                seleccionada.Minute, // Asegúrate de elegir 00 o 30 en el control
                0, // SEGUNDOS SIEMPRE 0
                0  // MILISEGUNDOS SIEMPRE 0
            );

            NuevaCita = new Cita
            {
                id = citaId ?? 0,
                fechaHoraInicio = fechaLimpia,
                cliente = (ClienteDTO)cmbCliente.SelectedItem,
                agenda = (AgendaDTO)cmbAgenda.SelectedItem
            };
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}