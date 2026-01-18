using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class Citas : Form
    {
        private const string API_CITAS_URL = "http://localhost:8080/api/citas/";
        private HttpClient httpClient = new HttpClient();
        private List<Cita> listaCitasOriginal = new();

        public Citas()
        {
            InitializeComponent();
            dgvCitas.AutoGenerateColumns = false;
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            dgvCitas.Columns.Clear();

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "Id",
                Name = "IdCol",
                Visible = false
            });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "Fecha",
                Name = "FechaCol"
            });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Hora",
                DataPropertyName = "Hora",
                Name = "HoraCol"
            });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cliente",
                DataPropertyName = "Cliente",
                Name = "ClienteCol"
            });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Servicio",
                DataPropertyName = "Servicio",
                Name = "ServicioCol"
            });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Aula",
                DataPropertyName = "Aula",
                Name = "AulaCol"
            });
        }

        private async void Citas_Load(object? sender, EventArgs e)
        {
            await CargarCitas();
        }

        private async Task CargarCitas()
        {
            if (string.IsNullOrEmpty(Session.AccessToken))
            {
                MessageBox.Show("Sesión no autenticada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                // Ahora consumimos la API que devuelve DTOs
                var citas = await httpClient.GetFromJsonAsync<List<Cita>>(API_CITAS_URL);
                listaCitasOriginal = citas ?? new List<Cita>();

                ActualizarGrid(listaCitasOriginal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar citas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarGrid(List<Cita> citas)
        {
            var listaParaGrid = new List<object>();

            foreach (var c in citas)
            {
                listaParaGrid.Add(new
                {
                    Id = c.Id,
                    Fecha = c.FechaHoraInicio.ToString("dd/MM/yyyy"),
                    Hora = c.FechaHoraInicio.ToString("HH:mm"),
                    Cliente = c.Cliente ?? "",
                    Servicio = c.Servicio ?? "",
                    Aula = c.Aula ?? ""
                });
            }

            dgvCitas.DataSource = null;
            dgvCitas.DataSource = listaParaGrid;
        }
        private void lblHome_Click(object sender, EventArgs e)
        {
            Home anterior = new Home();
            anterior.Show();
            Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Admins nuevaVentana = new Admins();
            nuevaVentana.Show();
            this.Close();
        }

        private void lblHome_Click_1(object sender, EventArgs e)
        {
            Home nuevaVentana = new Home();
            nuevaVentana.Show();
            this.Close();
        }

        private void lblServicios_Click(object sender, EventArgs e)
        {
            Servicios nuevaVentana = new Servicios();
            nuevaVentana.Show();
            this.Close();
        }

        private void lblAgenda_Click(object sender, EventArgs e)
        {
            Agendas nuevaVentana = new Agendas();
            nuevaVentana.Show();
            this.Close();
        }
    }




    // Clase simplificada para consumir el DTO
    public class Cita
    {
        public long Id { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public string Cliente { get; set; }
        public string Servicio { get; set; }
        public string Aula { get; set; }
    }
}
