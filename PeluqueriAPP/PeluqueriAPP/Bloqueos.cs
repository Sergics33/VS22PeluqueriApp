using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class Bloqueos : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/agendas/";
        private List<AgendaResponseDTO> listaAgendasOriginal = new List<AgendaResponseDTO>();

        public Bloqueos()
        {
            InitializeComponent();

            // --- CONFIGURACIÓN DE FORMULARIO HIJO (IGUAL QUE CITAS) ---
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(245, 245, 245);

            // --- CONFIGURACIÓN DE LA TABLA ---
            dgvBloqueos.AutoGenerateColumns = false;
            dgvBloqueos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBloqueos.MultiSelect = false;
            dgvBloqueos.ReadOnly = true;
            dgvBloqueos.AllowUserToAddRows = false;
            dgvBloqueos.AllowUserToDeleteRows = false;
            dgvBloqueos.RowHeadersVisible = false;
            dgvBloqueos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ConfigurarColumnas();
            ConfigurarEstiloVisual();

            // --- EVENTOS ---
            btnNuevoBloqueo.Click += btnNuevoBloqueo_Click;

            this.Load += async (s, e) =>
            {
                // Eliminamos la llamada a RedondearComponentes para que sea cuadrado
                await CargarHistorial();
            };
        }

        private void ConfigurarEstiloVisual()
        {
            // Título
            lblTitulo.ForeColor = Color.Black;
            lblTitulo.BackColor = Color.Transparent;

            // --- ESTILO CLON DE CITAS (Encabezado Negro y Selección Azul) ---
            dgvBloqueos.BackgroundColor = Color.White;
            dgvBloqueos.BorderStyle = BorderStyle.None;
            dgvBloqueos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBloqueos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBloqueos.GridColor = Color.FromArgb(230, 230, 230);
            dgvBloqueos.EnableHeadersVisualStyles = false;

            // Estilo Encabezados (Gris oscuro/Negro)
            dgvBloqueos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvBloqueos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBloqueos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dgvBloqueos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            dgvBloqueos.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgvBloqueos.ColumnHeadersHeight = 45;
            dgvBloqueos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Estilo Filas (Gris 70 y Selección Azul Claro)
            dgvBloqueos.DefaultCellStyle.BackColor = Color.White;
            dgvBloqueos.DefaultCellStyle.ForeColor = Color.FromArgb(70, 70, 70);
            dgvBloqueos.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvBloqueos.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgvBloqueos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 245, 255);
            dgvBloqueos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 120, 215);
            dgvBloqueos.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dgvBloqueos.RowTemplate.Height = 40;

            // Ajuste del contenedor para que toque los bordes laterales
            panelBlancoFondo.Padding = new Padding(0); // Sin espacio interno para que el Grid toque los bordes
            dgvBloqueos.Dock = DockStyle.Fill;
        }

        private void ConfigurarColumnas()
        {
            dgvBloqueos.Columns.Clear();

            dgvBloqueos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "id",
                Name = "IdCol",
                Visible = false
            });

            dgvBloqueos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Aula",
                DataPropertyName = "aula",
                Name = "AulaCol",
                FillWeight = 20
            });

            dgvBloqueos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha / Inicio",
                DataPropertyName = "fechaInicioStr",
                Name = "InicioCol",
                FillWeight = 30
            });

            dgvBloqueos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fin",
                DataPropertyName = "horaFinStr",
                Name = "FinCol",
                FillWeight = 15
            });

            dgvBloqueos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Motivo del Bloqueo",
                DataPropertyName = "motivo",
                Name = "MotivoCol",
                FillWeight = 35
            });
        }

        private async Task CargarHistorial()
        {
            try
            {
                if (string.IsNullOrEmpty(Session.AccessToken)) return;

                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var response = await httpClient.GetAsync(API_BASE_URL);
                if (response.IsSuccessStatusCode)
                {
                    listaAgendasOriginal = await response.Content.ReadFromJsonAsync<List<AgendaResponseDTO>>() ?? new List<AgendaResponseDTO>();
                    var soloBloqueadas = listaAgendasOriginal.Where(a => a.Bloqueada == 1).ToList();
                    ActualizarGrid(soloBloqueadas);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de red o servidor: " + ex.Message);
            }
        }

        private void ActualizarGrid(List<AgendaResponseDTO> lista)
        {
            var listaParaGrid = lista.Select(a => new
            {
                id = a.Id,
                aula = a.Aula,
                fechaInicioStr = a.HoraInicio.ToString("dd/MM/yyyy HH:mm"),
                horaFinStr = a.HoraFin.ToString("HH:mm"),
                motivo = string.IsNullOrEmpty(a.MotivoBloqueo) ? "Sin motivo" : a.MotivoBloqueo
            }).ToList();

            dgvBloqueos.DataSource = null;
            dgvBloqueos.DataSource = listaParaGrid;
        }

        private async void btnNuevoBloqueo_Click(object sender, EventArgs e)
        {
            using (AnyadirBloqueo form = new AnyadirBloqueo())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await CargarHistorial();
                }
            }
        }
    }
}