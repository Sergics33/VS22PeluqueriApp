using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class Servicios : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/servicios/";

        public Servicios()
        {
            InitializeComponent();
            Load += Servicios_Load; // Evento Load del formulario
        }

        private async void Servicios_Load(object sender, EventArgs e)
        {
            await CargarServicios();
        }

        private async Task CargarServicios()
        {
            try
            {
                var servicios = await httpClient.GetFromJsonAsync<List<Servicio>>(API_BASE_URL);
                dgvServicios.DataSource = servicios;

                // Ajustar cabeceras
                if (dgvServicios.Columns.Contains("Id")) dgvServicios.Columns["Id"].HeaderText = "ID";
                if (dgvServicios.Columns.Contains("Nombre")) dgvServicios.Columns["Nombre"].HeaderText = "Nombre";
                if (dgvServicios.Columns.Contains("Descripcion")) dgvServicios.Columns["Descripcion"].HeaderText = "Descripción";
                if (dgvServicios.Columns.Contains("Duracion")) dgvServicios.Columns["Duracion"].HeaderText = "Duración (min)";
                if (dgvServicios.Columns.Contains("Precio")) dgvServicios.Columns["Precio"].HeaderText = "Precio (€)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los servicios: " + ex.Message);
            }
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            Home anterior = new Home();
            anterior.Show();
            this.Close();
        }

        private void lblClientes_Click(object sender, EventArgs e)
        {
            Usuarios anterior = new Usuarios();
            anterior.Show();
            this.Close();
        }

        private void btnAnyadir_Click(object sender, EventArgs e)
        {
            AnyadirServicio anterior = new AnyadirServicio();
            anterior.Show();
        }

        private void dgvServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Aquí puedes añadir lógica para clicks en la tabla
        }

        // Clase para mapear los servicios del API
        public class Servicio
        {
            public long Id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public int Duracion { get; set; }
            public double Precio { get; set; }
        }
    }
}
