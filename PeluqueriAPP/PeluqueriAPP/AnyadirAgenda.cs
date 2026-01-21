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

        // Constructor para AÑADIR
        public AnyadirAgenda()
        {
            InitializeComponent();
            esEdicion = false;
        }

        // Constructor para EDITAR
        public AnyadirAgenda(AgendaResponseDTO agendaExistente) : this()
        {
            esEdicion = true;
            NuevaAgenda = agendaExistente;
        }

        private async void AnyadirAgenda_Load(object sender, EventArgs e)
        {
            ConfigurarLimitesYFormatos();

            // 1. Cargar datos de la API primero
            await CargarCatalogos();

            // 2. Aplicar estilo y rellenar si es edición
            ConfigurarInterfazModoEdicion();
        }

        private void ConfigurarLimitesYFormatos()
        {
            dtpInicio.Format = DateTimePickerFormat.Custom;
            dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFin.Format = DateTimePickerFormat.Custom;
            dtpFin.CustomFormat = "dd/MM/yyyy HH:mm";
            numSillas.Minimum = 1;
            numSillas.Maximum = 100;
        }

        private void ConfigurarInterfazModoEdicion()
        {
            if (esEdicion && NuevaAgenda != null)
            {
                // Cambiar textos al estilo "Editar"
                label7.Text = "EDITAR HORARIO";
                btnGuardar.Text = "GUARDAR";
                this.Text = "Editar Agenda";

                // Rellenar campos
                tbAula.Text = NuevaAgenda.Aula;
                dtpInicio.Value = NuevaAgenda.HoraInicio;
                dtpFin.Value = NuevaAgenda.HoraFin;
                numSillas.Value = (decimal)NuevaAgenda.Sillas;

                // Seleccionar en ComboBoxes
                if (NuevaAgenda.Servicio != null)
                    cbServicios.SelectedValue = NuevaAgenda.Servicio.id;

                if (NuevaAgenda.Grupo != null)
                    cbGrupos.SelectedValue = NuevaAgenda.Grupo.Id;
            }
            else
            {
                label7.Text = "AÑADIR AL HORARIO";
                btnGuardar.Text = "AÑADIR";
                this.Text = "Añadir Agenda";
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
                MessageBox.Show("Error al cargar catálogos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                if (NuevaAgenda == null) NuevaAgenda = new AgendaResponseDTO();

                // Mapeo de datos del formulario al DTO
                NuevaAgenda.Aula = tbAula.Text.Trim();
                NuevaAgenda.HoraInicio = dtpInicio.Value;
                NuevaAgenda.HoraFin = dtpFin.Value;
                NuevaAgenda.Sillas = (int)numSillas.Value;
                NuevaAgenda.Servicio = (Servicio)cbServicios.SelectedItem;
                NuevaAgenda.Grupo = (Grupo)cbGrupos.SelectedItem;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar datos: " + ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(tbAula.Text))
            {
                MessageBox.Show("El campo 'Aula' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbServicios.SelectedValue == null || cbGrupos.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un Servicio y un Grupo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtpFin.Value <= dtpInicio.Value)
            {
                MessageBox.Show("La hora de fin debe ser posterior a la de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}