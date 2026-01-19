using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;

namespace PeluqueriAPP
{
    public partial class AnyadirAgenda : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        public AgendaResponseDTO NuevaAgenda { get; private set; }
        private bool esEdicion = false;

        public AnyadirAgenda()
        {
            InitializeComponent();
        }

        public AnyadirAgenda(AgendaResponseDTO agendaExistente) : this()
        {
            esEdicion = true;
            NuevaAgenda = agendaExistente;
        }

        private async void AnyadirAgenda_Load(object sender, EventArgs e)
        {
            // Formatos de fecha y límites del numérico
            dtpInicio.Format = DateTimePickerFormat.Custom;
            dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFin.Format = DateTimePickerFormat.Custom;
            dtpFin.CustomFormat = "dd/MM/yyyy HH:mm";
            numSillas.Minimum = 0;
            numSillas.Maximum = 100;

            await CargarCatalogos();

            if (esEdicion && NuevaAgenda != null)
            {
                this.Text = "Editar Agenda";
                tbAula.Text = NuevaAgenda.Aula;
                dtpInicio.Value = NuevaAgenda.HoraInicio;
                dtpFin.Value = NuevaAgenda.HoraFin;
                numSillas.Value = (decimal)NuevaAgenda.Sillas;

                // Seleccionamos los valores en los combos basándonos en el ID
                cbServicios.SelectedValue = NuevaAgenda.Servicio?.id;
                cbGrupos.SelectedValue = NuevaAgenda.Grupo?.Id;
            }
        }

        private async Task CargarCatalogos()
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                var servicios = await httpClient.GetFromJsonAsync<List<Servicio>>("http://localhost:8080/api/servicios/");
                cbServicios.DataSource = servicios;
                cbServicios.DisplayMember = "Nombre";
                cbServicios.ValueMember = "id";

                var grupos = await httpClient.GetFromJsonAsync<List<Grupo>>("http://localhost:8080/api/grupos/");
                cbGrupos.DataSource = grupos;
                cbGrupos.DisplayMember = "NombreCompleto";
                cbGrupos.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar catálogos: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(tbAula.Text))
            {
                MessageBox.Show("El campo 'Aula' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbServicios.SelectedValue == null || cbGrupos.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un Servicio y un Grupo válidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validación de coherencia de fechas (Evita el NullPointerException en Java)
            if (dtpFin.Value <= dtpInicio.Value)
            {
                MessageBox.Show("La hora de fin debe ser posterior a la hora de inicio.", "Error de fechas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 3. Inicializar el DTO si es una creación nueva
                if (NuevaAgenda == null)
                {
                    NuevaAgenda = new AgendaResponseDTO();
                }

                // 4. MAPEO DE DATOS (La parte crucial)
                NuevaAgenda.Aula = tbAula.Text;
                NuevaAgenda.HoraInicio = dtpInicio.Value;
                NuevaAgenda.HoraFin = dtpFin.Value;
                NuevaAgenda.Sillas = (int)numSillas.Value;

                // Asignamos los objetos completos (para uso interno en C#)
                var servicioSeleccionado = (Servicio)cbServicios.SelectedItem;
                var grupoSeleccionado = (Grupo)cbGrupos.SelectedItem;

                NuevaAgenda.Servicio = servicioSeleccionado;
                NuevaAgenda.Grupo = grupoSeleccionado;

                // IMPORTANTE: Asegúrate de que los IDs no viajen nulos a la API.
                // Si tu objeto NuevaAgenda tiene campos 'ServicioId' y 'GrupoId', asígnalos aquí:
                // NuevaAgenda.ServicioId = (int)cbServicios.SelectedValue;
                // NuevaAgenda.GrupoId = (int)cbGrupos.SelectedValue;

                // 5. Finalizar con éxito
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar los datos del formulario: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cerramos indicando CANCELACIÓN
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}