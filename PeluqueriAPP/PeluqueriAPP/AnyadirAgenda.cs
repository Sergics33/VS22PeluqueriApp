using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirAgenda : Form
    {
        private HttpClient httpClient = new HttpClient();
        public AgendaResponseDTO NuevaAgenda { get; private set; }
        private bool esEdicion = false;
        private bool cargando = false;
        private bool capsulasCreadas = false;

        private List<Servicio> listaServiciosMaestra = new List<Servicio>();

        public AnyadirAgenda(AgendaResponseDTO agendaExistente = null)
        {
            InitializeComponent();

            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;

            // Suscripción al cambio de grupo para filtrar servicios
            cbGrupos.SelectedIndexChanged += async (s, e) =>
            {
                if (!cargando) await FiltrarServiciosPorGrupo();
            };

            if (agendaExistente != null)
            {
                this.esEdicion = true;
                this.NuevaAgenda = agendaExistente;
                label7.Text = "EDITAR HORARIO";
            }

            this.Load += async (s, e) => {
                ConfigurarEstilosPersonalizados();
                await CargarDatosIniciales();
            };
        }

        private async Task CargarDatosIniciales()
        {
            try
            {
                cargando = true;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                // 1. Cargar servicios maestros
                listaServiciosMaestra = await httpClient.GetFromJsonAsync<List<Servicio>>("http://localhost:8080/api/tipos-servicio/") ?? new List<Servicio>();

                // 2. Cargar Grupos
                var grupos = await httpClient.GetFromJsonAsync<List<Grupo>>("http://localhost:8080/api/grupos/");
                cbGrupos.DataSource = grupos;
                cbGrupos.DisplayMember = "nombreCompleto";
                cbGrupos.ValueMember = "id"; // Si falla en ejecución, prueba "Id"

                if (esEdicion && NuevaAgenda != null)
                {
                    tbAula.Text = NuevaAgenda.Aula;
                    numSillas.Value = (decimal)NuevaAgenda.Sillas;
                    dtpInicio.Value = NuevaAgenda.HoraInicio;
                    dtpFin.Value = NuevaAgenda.HoraFin;
                    monthCalendar1.SetDate(NuevaAgenda.HoraInicio);

                    if (NuevaAgenda.Grupo != null)
                    {
                        dynamic g = NuevaAgenda.Grupo;
                        try { cbGrupos.SelectedValue = g.id; } catch { cbGrupos.SelectedValue = g.Id; }
                    }
                }

                cargando = false;
                await FiltrarServiciosPorGrupo();

                if (esEdicion && NuevaAgenda?.Servicio != null)
                {
                    dynamic s = NuevaAgenda.Servicio;
                    try { cbServicios.SelectedValue = s.id; } catch { cbServicios.SelectedValue = s.Id; }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); cargando = false; }
        }

        private async Task FiltrarServiciosPorGrupo()
        {
            if (cbGrupos.SelectedValue == null) return;

            // CORRECCIÓN AQUÍ: Usamos Convert.ToInt64 sobre el SelectedValue directamente
            // para evitar acceder a la propiedad .id del objeto Grupo que da error.
            try
            {
                long grupoId = Convert.ToInt64(cbGrupos.SelectedValue);

                string url = $"http://localhost:8080/api/agendas/?grupo={grupoId}";
                var response = await httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode) return;

                string jsonRaw = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(jsonRaw);
                var idsServicios = new HashSet<long>();

                foreach (var elemento in doc.RootElement.EnumerateArray())
                {
                    if (elemento.TryGetProperty("servicio", out var serv) && serv.TryGetProperty("id", out var idProp))
                    {
                        idsServicios.Add(idProp.GetInt64());
                    }
                }

                // Filtrar la maestra
                var filtrados = listaServiciosMaestra.Where(s => {
                    dynamic ds = s;
                    try { return idsServicios.Contains((long)ds.id); }
                    catch { return idsServicios.Contains((long)ds.Id); }
                }).ToList();

                cargando = true;
                cbServicios.DataSource = filtrados.Any() ? filtrados : null;
                cbServicios.DisplayMember = "nombre";
                cbServicios.ValueMember = "id"; // Si falla en ejecución, cambiar a "Id"
                cargando = false;
            }
            catch { cargando = false; }
        }

        // --- MÉTODOS VISUALES ---

        private void ConfigurarEstilosPersonalizados()
        {
            if (capsulasCreadas) return;
            btnGuardar.Paint += (s, e) => DibujarBordeRedondeado(btnGuardar, e.Graphics, 38);
            btnCancelar.Paint += (s, e) => DibujarBordeRedondeado(btnCancelar, e.Graphics, 38);
            ConfigurarCapsulaControl(tbAula, 20, 38, 340);
            ConfigurarCapsulaControl(cbServicios, 20, 108, 160);
            ConfigurarCapsulaControl(cbGrupos, 200, 108, 160);
            ConfigurarCapsulaControl(dtpInicio, 20, 178, 160);
            ConfigurarCapsulaControl(dtpFin, 200, 178, 160);
            ConfigurarCapsulaControl(numSillas, 20, 248, 100);
            capsulasCreadas = true;
        }

        private void ConfigurarCapsulaControl(Control ctrl, int x, int y, int width)
        {
            Panel pnl = new Panel { BackColor = Color.White, Size = new Size(width, 36), Location = new Point(x, y) };
            if (ctrl is ComboBox cb) { cb.DropDownStyle = ComboBoxStyle.DropDownList; cb.FlatStyle = FlatStyle.Flat; }
            if (ctrl is DateTimePicker dtp) { dtp.Format = DateTimePickerFormat.Custom; dtp.CustomFormat = "HH:mm"; dtp.ShowUpDown = true; }
            ctrl.Parent = pnl;
            ctrl.BackColor = Color.White;
            ctrl.Width = pnl.Width - 10;
            ctrl.Location = new Point(5, 7);
            panelContenedor.Controls.Add(pnl);
            pnl.BringToFront();
            pnl.Paint += (s, e) => DibujarBordeRedondeado(pnl, e.Graphics, 15);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(tbAula.Text) || cbServicios.SelectedItem == null || cbGrupos.SelectedItem == null)
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.");
                return;
            }

            try
            {
                // 2. Obtención de los objetos seleccionados
                var servicioSel = (Servicio)cbServicios.SelectedItem;
                var grupoSel = (Grupo)cbGrupos.SelectedItem;

                // 3. Construcción del objeto coincidiendo EXACTAMENTE con AgendaRequest.java
                var agendaRequest = new
                {
                    // Java espera Strings para horaInicio y horaFin según tu AgendaRequest
                    horaInicio = monthCalendar1.SelectionStart.Date.Add(dtpInicio.Value.TimeOfDay).ToString("yyyy-MM-ddTHH:mm:ss"),
                    horaFin = monthCalendar1.SelectionStart.Date.Add(dtpFin.Value.TimeOfDay).ToString("yyyy-MM-ddTHH:mm:ss"),

                    // Nombres de variables idénticos a los de tu clase Java
                    grupoId = (long)grupoSel.Id,   // Usamos .Id (Mayúscula) de tu clase Grupo C#
                    servicioId = (long)servicioSel.id, // Usamos .id (Minúscula) de tu clase Servicio C#

                    aula = tbAula.Text,
                    sillas = (int)numSillas.Value
                };

                // 4. Envío de la petición
                string url = "http://localhost:8080/api/agendas/";
                HttpResponseMessage response;

                if (esEdicion && NuevaAgenda != null)
                {
                    response = await httpClient.PutAsJsonAsync(url + NuevaAgenda.Id, agendaRequest);
                }
                else
                {
                    response = await httpClient.PostAsJsonAsync(url, agendaRequest);
                }

                // 5. Manejo de respuesta
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Agenda guardada con éxito.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string errorDetalle = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Error del servidor: " + errorDetalle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la aplicación: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                Color.FromArgb(255, 140, 0), Color.FromArgb(255, 220, 150), LinearGradientMode.ForwardDiagonal))
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void DibujarBordeRedondeado(Control control, Graphics g, int radio)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radio, radio, 180, 90);
                path.AddArc(control.Width - radio, 0, radio, radio, 270, 90);
                path.AddArc(control.Width - radio, control.Height - radio, radio, radio, 0, 90);
                path.AddArc(0, control.Height - radio, radio, radio, 90, 90);
                control.Region = new Region(path);
            }
        }
    }
}