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
            this.Load += AnyadirAgenda_Load;
        }

        public AnyadirAgenda(AgendaResponseDTO agendaExistente) : this()
        {
            esEdicion = true;
            NuevaAgenda = agendaExistente;
        }

        private async void AnyadirAgenda_Load(object sender, EventArgs e)
        {
            // Configuración de los formatos de fecha
            dtpInicio.Format = DateTimePickerFormat.Custom;
            dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFin.Format = DateTimePickerFormat.Custom;
            dtpFin.CustomFormat = "dd/MM/yyyy HH:mm";

            // CARGA DE CATÁLOGOS
            await CargarCatalogos();

            if (esEdicion && NuevaAgenda != null)
            {
                this.Text = "Editar Agenda";
                tbAula.Text = NuevaAgenda.Aula;
                dtpInicio.Value = NuevaAgenda.HoraInicio;
                dtpFin.Value = NuevaAgenda.HoraFin;

                // --- SOLUCIÓN AL ERROR DE SILLAS ---
                numSillas.Minimum = 0; // Permitimos que el mínimo sea 0
                numSillas.Maximum = 100; // Un valor máximo razonable

                // Asignamos el valor asegurándonos de que esté en el rango
                numSillas.Value = Math.Max(numSillas.Minimum, Math.Min(numSillas.Maximum, (decimal)NuevaAgenda.Sillas));
                // ------------------------------------

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

                // 1. Cargar SERVICIOS (Usando tu clase Servicio)
                var servicios = await httpClient.GetFromJsonAsync<List<Servicio>>("http://localhost:8080/api/servicios/");
                cbServicios.DataSource = servicios;
                cbServicios.DisplayMember = "Nombre"; // Tu clase tiene 'Nombre'
                cbServicios.ValueMember = "id";       // Tu clase tiene 'id' minúscula

                // 2. Cargar GRUPOS (Usando tu clase Grupo)
                var grupos = await httpClient.GetFromJsonAsync<List<Grupo>>("http://localhost:8080/api/grupos/");
                cbGrupos.DataSource = grupos;
                cbGrupos.DisplayMember = "NombreCompleto"; // Tu clase tiene 'NombreCompleto'
                cbGrupos.ValueMember = "Id";               // Tu clase tiene 'Id' mayúscula
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAula.Text) || cbServicios.SelectedValue == null)
            {
                MessageBox.Show("Rellena los campos obligatorios.");
                return;
            }

            if (NuevaAgenda == null) NuevaAgenda = new AgendaResponseDTO();

            NuevaAgenda.Aula = tbAula.Text;
            NuevaAgenda.HoraInicio = dtpInicio.Value;
            NuevaAgenda.HoraFin = dtpFin.Value;
            NuevaAgenda.Sillas = (int)numSillas.Value;

            // Casteo a tus clases originales
            NuevaAgenda.Servicio = (Servicio)cbServicios.SelectedItem;
            NuevaAgenda.Grupo = (Grupo)cbGrupos.SelectedItem;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}