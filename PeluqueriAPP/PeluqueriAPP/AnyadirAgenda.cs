using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            ConfigurarEstilosPersonalizados();
        }

        public AnyadirAgenda(AgendaResponseDTO agendaExistente) : this()
        {
            esEdicion = true;
            NuevaAgenda = agendaExistente;
        }

        private void ConfigurarEstilosPersonalizados()
        {
            this.DoubleBuffered = true;
            this.Load += (s, e) =>
            {
                DibujarBordeRedondeado(btnGuardar, 38);
                DibujarBordeRedondeado(btnCancelar, 38);
                DibujarBordeRedondeado(panelContenedor, 20);

                // Aplicar redondeado y color de texto a los inputs
                Control[] inputs = { tbAula, cbServicios, cbGrupos, dtpInicio, dtpFin, numSillas };
                foreach (var ctrl in inputs)
                {
                    DibujarBordeRedondeado(ctrl, 12);
                    ctrl.ForeColor = Color.FromArgb(40, 40, 40);
                }
            };
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                Color.FromArgb(255, 140, 0),
                Color.FromArgb(255, 220, 150),
                LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void DibujarBordeRedondeado(Control control, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(control.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(control.Width - radio, control.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, control.Height - radio, radio, radio, 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }

        private async void AnyadirAgenda_Load(object sender, EventArgs e)
        {
            ConfigurarLimitesYFormatos();
            await CargarCatalogos();
            ConfigurarInterfazModoEdicion();

            // Sincronizar el calendario con los selectores de fecha
            monthCalendar1.DateSelected += (s, ev) =>
            {
                dtpInicio.Value = ev.Start.Date.AddHours(dtpInicio.Value.Hour).AddMinutes(dtpInicio.Value.Minute);
                dtpFin.Value = ev.Start.Date.AddHours(dtpFin.Value.Hour).AddMinutes(dtpFin.Value.Minute);
            };
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
                label7.Text = "EDITAR HORARIO";
                btnGuardar.Text = "GUARDAR CAMBIOS";
                tbAula.Text = NuevaAgenda.Aula;
                dtpInicio.Value = NuevaAgenda.HoraInicio;
                dtpFin.Value = NuevaAgenda.HoraFin;
                numSillas.Value = (decimal)NuevaAgenda.Sillas;
                monthCalendar1.SetDate(NuevaAgenda.HoraInicio);

                if (NuevaAgenda.Servicio != null) cbServicios.SelectedValue = NuevaAgenda.Servicio.id;
                if (NuevaAgenda.Grupo != null) cbGrupos.SelectedValue = NuevaAgenda.Grupo.Id;
            }
            else
            {
                label7.Text = "AÑADIR AL HORARIO";
                btnGuardar.Text = "AÑADIR";
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
            catch { MessageBox.Show("Error al cargar datos de la API."); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            if (NuevaAgenda == null) NuevaAgenda = new AgendaResponseDTO();

            NuevaAgenda.Aula = tbAula.Text.Trim();
            NuevaAgenda.HoraInicio = dtpInicio.Value;
            NuevaAgenda.HoraFin = dtpFin.Value;
            NuevaAgenda.Sillas = (int)numSillas.Value;
            NuevaAgenda.Servicio = (Servicio)cbServicios.SelectedItem;
            NuevaAgenda.Grupo = (Grupo)cbGrupos.SelectedItem;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(tbAula.Text))
            {
                MessageBox.Show("El campo Aula es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtpFin.Value <= dtpInicio.Value)
            {
                MessageBox.Show("La hora de fin debe ser posterior a la de inicio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
    }
}