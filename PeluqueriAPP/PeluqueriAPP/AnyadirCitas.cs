using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Text.Json;
using System.Drawing;
using System.Drawing.Drawing2D;

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
            ConfigurarEstilosPersonalizados();

            cmbGrupo.SelectedIndexChanged += async (s, e) =>
            {
                if (!cargando)
                {
                    await FiltrarServiciosPorGrupo();
                    await CargarDiasDisponibles();
                }
            };

            cmbServicio.SelectedIndexChanged += async (s, e) =>
            {
                if (!cargando) await CargarDiasDisponibles();
            };

            monthCalendarCitas.DateSelected += (s, e) =>
            {
                if (!cargando) ActualizarComboHoras();
            };

            if (cita != null)
            {
                citaId = cita.id;
                this.Text = "Editar Cita";
                label1.Text = "EDITAR CITA";
            }

            this.Load += async (s, e) => await CargarDatosIniciales(cita);
        }

        private void ConfigurarEstilosPersonalizados()
        {
            // Bordes redondeados para botones
            btnGuardar.Paint += (s, e) => DibujarBordeRedondeado(btnGuardar, e.Graphics, 38);
            btnCancelar.Paint += (s, e) => DibujarBordeRedondeado(btnCancelar, e.Graphics, 38);

            // ComboBoxes redondeados (Blancos sobre el panel translúcido)
            Control[] controlesBlancos = { cmbCliente, cmbGrupo, cmbServicio, cmbHoras };
            foreach (var ctrl in controlesBlancos)
            {
                ctrl.SizeChanged += (s, e) => DibujarBordeRedondeado(ctrl, null, 15);
                DibujarBordeRedondeado(ctrl, null, 15);
            }

            // Calendario
            monthCalendarCitas.TitleBackColor = Color.FromArgb(255, 128, 0);
            monthCalendarCitas.TitleForeColor = Color.White;
        }

        // Fondo con degradado naranja
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

        private void DibujarBordeRedondeado(Control control, Graphics g, int radio)
        {
            Graphics graphics = g ?? control.CreateGraphics();
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radio, radio, 180, 90);
                path.AddArc(control.Width - radio, 0, radio, radio, 270, 90);
                path.AddArc(control.Width - radio, control.Height - radio, radio, radio, 0, 90);
                path.AddArc(0, control.Height - radio, radio, radio, 90, 90);
                path.CloseAllFigures();
                control.Region = new Region(path);
            }
        }

        private async Task CargarDatosIniciales(Cita citaExistente)
        {
            try
            {
                cargando = true;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
                listaServiciosMaestra = await httpClient.GetFromJsonAsync<List<Servicio>>("http://localhost:8080/api/tipos-servicio/") ?? new List<Servicio>();

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
            catch (Exception ex) { MessageBox.Show("Error al cargar datos: " + ex.Message); }
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
                    if (elemento.TryGetProperty("servicio", out var serv) && serv.TryGetProperty("id", out var idProp))
                        idsServicios.Add(idProp.GetInt64());

                var filtrados = listaServiciosMaestra.Where(s => idsServicios.Contains(s.id)).ToList();
                cargando = true;
                cmbServicio.DataSource = filtrados.Any() ? filtrados : null;
                cmbServicio.DisplayMember = "nombre";
                cmbServicio.ValueMember = "id";
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
                monthCalendarCitas.RemoveAllBoldedDates();
                if (agendasActuales != null)
                {
                    var fechasLibres = agendasActuales.SelectMany(a => a.HorasDisponiblesEstado)
                        .Where(h => h.Value == true).Select(h => DateTime.Parse(h.Key).Date).Distinct().ToArray();
                    monthCalendarCitas.BoldedDates = fechasLibres;
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
                if (agenda.HorasDisponiblesEstado != null)
                {
                    var horas = agenda.HorasDisponiblesEstado
                        .Where(h => DateTime.Parse(h.Key).Date == fechaSeleccionada && h.Value == true)
                        .Select(h => DateTime.Parse(h.Key).ToString("HH:mm")).OrderBy(h => h);
                    foreach (var h in horas) if (!cmbHoras.Items.Contains(h)) cmbHoras.Items.Add(h);
                }
            if (cmbHoras.Items.Count > 0) cmbHoras.SelectedIndex = 0;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e) => this.Close();

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (cmbHoras.SelectedItem == null) { MessageBox.Show("Seleccione una hora."); return; }
            DateTime fechaBase = monthCalendarCitas.SelectionStart.Date;
            TimeSpan horaBase = TimeSpan.Parse(cmbHoras.SelectedItem.ToString());
            DateTime fechaFinal = fechaBase.Add(horaBase);
            var agendaSeleccionada = agendasActuales.FirstOrDefault(a => a.HorasDisponiblesEstado != null && a.HorasDisponiblesEstado.Any(h => DateTime.Parse(h.Key) == fechaFinal));
            if (agendaSeleccionada != null)
            {
                NuevaCita = new Cita { id = citaId ?? 0, fechaHoraInicio = fechaFinal, cliente = (ClienteDTO)cmbCliente.SelectedItem, agenda = new AgendaDTO { id = agendaSeleccionada.Id } };
                this.DialogResult = DialogResult.OK; this.Close();
            }
        }
    }
}