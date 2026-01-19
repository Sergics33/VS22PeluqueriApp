using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json; // Requiere el paquete System.Net.Http.Json
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;

namespace PeluqueriAPP
{
    public partial class Agendas : Form
    {
        // 1. ATRIBUTOS (Igual que en Servicios.cs)
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/agendas/";
        private List<AgendaResponseDTO> listaAgendasOriginal = new List<AgendaResponseDTO>();

        public Agendas()
        {
            InitializeComponent();
            
            // Configuración inicial del Grid
            dgvServicios.AutoGenerateColumns = false; 
            dgvServicios.ReadOnly = true;
            dgvServicios.AllowUserToAddRows = false;
            dgvServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            ConfigurarColumnas();

            // Suscribir el evento Load
            this.Load += Agendas_Load;
        }

        private void ConfigurarColumnas()
        {
            dgvServicios.Columns.Clear();

            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { 
                HeaderText = "ID", DataPropertyName = "id", Name = "IdCol" 
            });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { 
                HeaderText = "Aula", DataPropertyName = "aula", Name = "AulaCol" 
            });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { 
                HeaderText = "Fecha e Inicio", DataPropertyName = "fechaInicioStr", Name = "InicioCol" 
            });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { 
                HeaderText = "Hora Fin", DataPropertyName = "horaFinStr", Name = "FinCol" 
            });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { 
                HeaderText = "Servicio", DataPropertyName = "servicioNombre", Name = "ServicioCol" 
            });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { 
                HeaderText = "Grupo", DataPropertyName = "grupoNombre", Name = "GrupoCol" 
            });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { 
                HeaderText = "Disponibilidad", DataPropertyName = "disponibilidadStr", Name = "EstadoCol" 
            });
        }

        private async void Agendas_Load(object sender, EventArgs e)
        {
            await CargarAgendas();
        }

        private async Task CargarAgendas()
        {
            try
            {
                // 2. USO DEL TOKEN DINÁMICO (Session)
                if (!Session.IsLoggedIn)
                {
                    MessageBox.Show("No hay sesión iniciada. Por favor, vuelva al Login.");
                    return;
                }

                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                // 3. LLAMADA A LA API
                var response = await httpClient.GetAsync(API_BASE_URL);

                if (response.IsSuccessStatusCode)
                {
                    var agendas = await response.Content.ReadFromJsonAsync<List<AgendaResponseDTO>>();
                    listaAgendasOriginal = agendas ?? new List<AgendaResponseDTO>();
                    
                    ActualizarGrid(listaAgendasOriginal);
                    PersonalizarDisenoTabla();
                }
                else
                {
                    MessageBox.Show($"Error al obtener agendas: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void ActualizarGrid(List<AgendaResponseDTO> lista)
        {
            // 4. MAPEADO A LISTA ANÓNIMA (Para que el DataPropertyName funcione)
            var listaParaGrid = lista.Select(a => new
            {
                id = a.Id,
                aula = a.Aula,
                fechaInicioStr = a.HoraInicio.ToString("dd/MM/yyyy HH:mm"),
                horaFinStr = a.HoraFin.ToString("HH:mm"),
                servicioNombre = a.Servicio?.Nombre ?? "N/A",
                grupoNombre = a.Grupo?.NombreCompleto ?? "N/A",
                disponibilidadStr = a.HorasDisponiblesEstado != null 
                    ? string.Join(" | ", a.HorasDisponiblesEstado
                        .OrderBy(h => h.Key)
                        .Select(h => $"{h.Key.Substring(Math.Max(0, h.Key.Length - 5))}: {(h.Value ? "Libre" : "Ocupado")}"))
                    : "Sin datos"
            }).ToList();

            dgvServicios.DataSource = listaParaGrid;
        }

        private void PersonalizarDisenoTabla()
        {
            dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicios.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvServicios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            
            // Estética de cabeceras
            dgvServicios.EnableHeadersVisualStyles = false;
            dgvServicios.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
        }

        #region Navegación
        private void lblHomeAdmin_Click(object sender, EventArgs e)
        {
            new Home().Show();
            this.Close();
        }

        private void lblCitas_Click(object sender, EventArgs e)
        {
            new Citas().Show();
            this.Close();
        }

        private void lblServicios_Click(object sender, EventArgs e)
        {
            new Servicios().Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            new Admins().Show();
            this.Close();
        }
        #endregion
    }
}