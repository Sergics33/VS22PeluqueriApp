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
        private List<Servicio> listaServiciosMaestra = new List<Servicio>();

        public AnyadirAgenda(AgendaResponseDTO agendaExistente = null)
        {
            InitializeComponent();
            ConfigurarEstilosPersonalizados();

            // Vincular eventos manualmente para asegurar que funcionen
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;

            if (agendaExistente != null)
            {
                this.esEdicion = true;
                this.NuevaAgenda = agendaExistente;
                label7.Text = "EDITAR HORARIO";
                btnGuardar.Text = "ACTUALIZAR";
            }

            this.Load += async (s, e) => await CargarDatosIniciales();
        }

        private void ConfigurarEstilosPersonalizados()
        {
            // Redondeo y Estilo de Botones
            btnGuardar.BackColor = Color.SeaGreen;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.Paint += (s, e) => DibujarBordeRedondeado(btnGuardar, e.Graphics, 38);

            btnCancelar.BackColor = Color.Crimson;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.Paint += (s, e) => DibujarBordeRedondeado(btnCancelar, e.Graphics, 38);

            // Estética del Panel
            panelContenedor.Paint += (s, e) => DibujarBordeRedondeado(panelContenedor, e.Graphics, 25);

            // Crear las cápsulas blancas (X, Y, Ancho)
            ConfigurarCapsulaControl(tbAula, 20, 40, 340);
            ConfigurarCapsulaControl(cbServicios, 20, 110, 160);
            ConfigurarCapsulaControl(cbGrupos, 200, 110, 160);
            ConfigurarCapsulaControl(dtpInicio, 20, 180, 160);
            ConfigurarCapsulaControl(dtpFin, 200, 180, 160);
            ConfigurarCapsulaControl(numSillas, 20, 250, 100);
        }

        private void ConfigurarCapsulaControl(Control ctrl, int x, int y, int width)
        {
            Panel pnl = new Panel { BackColor = Color.White, Size = new Size(width, 36), Location = new Point(x, y) };

            if (ctrl is ComboBox cb) { cb.DropDownStyle = ComboBoxStyle.DropDownList; cb.FlatStyle = FlatStyle.Flat; }
            if (ctrl is DateTimePicker dtp) { dtp.Format = DateTimePickerFormat.Custom; dtp.CustomFormat = "HH:mm"; dtp.ShowUpDown = true; }
            if (ctrl is TextBox tb) { tb.BorderStyle = BorderStyle.None; }

            ctrl.Parent = pnl;
            ctrl.BackColor = Color.White;
            ctrl.Width = pnl.Width - 10;
            ctrl.Location = new Point(5, 8);

            panelContenedor.Controls.Add(pnl);
            pnl.BringToFront();
            pnl.Paint += (s, e) => DibujarBordeRedondeado(pnl, e.Graphics, 15);
        }

        private async Task CargarDatosIniciales()
        {
            try
            {
                cargando = true;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                listaServiciosMaestra = await httpClient.GetFromJsonAsync<List<Servicio>>("http://localhost:8080/api/tipos-servicio/") ?? new List<Servicio>();
                var grupos = await httpClient.GetFromJsonAsync<List<Grupo>>("http://localhost:8080/api/grupos/");

                cbGrupos.DataSource = grupos;
                cbGrupos.DisplayMember = "nombreCompleto";
                cbGrupos.ValueMember = "Id";

                if (esEdicion && NuevaAgenda != null)
                {
                    tbAula.Text = NuevaAgenda.Aula;
                    numSillas.Value = (decimal)NuevaAgenda.Sillas;
                    dtpInicio.Value = NuevaAgenda.HoraInicio;
                    dtpFin.Value = NuevaAgenda.HoraFin;
                    monthCalendar1.SetDate(NuevaAgenda.HoraInicio);
                    cbGrupos.SelectedValue = NuevaAgenda.Grupo.Id;
                }

                cargando = false;
                await FiltrarServiciosPorGrupo();

                // Si es edición, seleccionar el servicio que ya tenía
                if (esEdicion && NuevaAgenda != null)
                {
                    cbServicios.SelectedValue = NuevaAgenda.Servicio.id;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar datos: " + ex.Message); }
        }

        private async Task FiltrarServiciosPorGrupo()
        {
            if (cbGrupos.SelectedValue == null) return;
            try
            {
                long grupoId = Convert.ToInt64(cbGrupos.SelectedValue);
                var response = await httpClient.GetAsync($"http://localhost:8080/api/agendas/?grupo={grupoId}");
                if (!response.IsSuccessStatusCode) return;

                string jsonRaw = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(jsonRaw);
                var idsServicios = new HashSet<long>();

                foreach (var elemento in doc.RootElement.EnumerateArray())
                    if (elemento.TryGetProperty("servicio", out var serv) && serv.TryGetProperty("id", out var idProp))
                        idsServicios.Add(idProp.GetInt64());

                var filtrados = listaServiciosMaestra.Where(s => idsServicios.Contains(s.id)).ToList();

                cargando = true;
                cbServicios.DataSource = filtrados.Any() ? filtrados : null;
                cbServicios.DisplayMember = "nombre";
                cbServicios.ValueMember = "id";
                cargando = false;
            }
            catch { cargando = false; }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación básica
            if (string.IsNullOrWhiteSpace(tbAula.Text) || cbServicios.SelectedValue == null || cbGrupos.SelectedValue == null)
            {
                MessageBox.Show("Por favor, rellena todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var agendaRequest = new
                {
                    horaInicio = monthCalendar1.SelectionStart.Date.Add(dtpInicio.Value.TimeOfDay).ToString("yyyy-MM-ddTHH:mm:ss"),
                    horaFin = monthCalendar1.SelectionStart.Date.Add(dtpFin.Value.TimeOfDay).ToString("yyyy-MM-ddTHH:mm:ss"),
                    grupoId = Convert.ToInt64(cbGrupos.SelectedValue),
                    servicioId = Convert.ToInt64(cbServicios.SelectedValue),
                    aula = tbAula.Text,
                    sillas = (int)numSillas.Value
                };

                string url = "http://localhost:8080/api/agendas/";
                HttpResponseMessage res;

                if (esEdicion)
                {
                    res = await httpClient.PutAsJsonAsync(url + NuevaAgenda.Id, agendaRequest);
                    if (res.IsSuccessStatusCode)
                    {
                        MessageBox.Show("¡Horario actualizado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    res = await httpClient.PostAsJsonAsync(url, agendaRequest);
                    if (res.IsSuccessStatusCode)
                    {
                        MessageBox.Show("¡Horario agregado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (res.IsSuccessStatusCode)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    var error = await res.Content.ReadAsStringAsync();
                    MessageBox.Show("Error al guardar: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();

        // --- DIBUJO ---
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                Color.FromArgb(255, 140, 0), Color.FromArgb(255, 220, 150), LinearGradientMode.ForwardDiagonal))
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
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
                control.Region = new Region(path);
            }
        }
    }
}