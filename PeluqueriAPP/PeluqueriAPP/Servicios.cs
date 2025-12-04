using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;

namespace PeluqueriAPP
{
    public partial class Servicios : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/servicios/";

        public Servicios()
        {
            InitializeComponent();
            Load += Servicios_Load;
            dgvServicios.AutoGenerateColumns = true;
            dgvServicios.ReadOnly = true;
            dgvServicios.AllowUserToAddRows = false;
            dgvServicios.AllowUserToDeleteRows = false;
            dgvServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicios.MultiSelect = false;
        }

        private async void Servicios_Load(object sender, EventArgs e)
        {
            await CargarServicios();
        }

        private async Task CargarServicios()
        {
            try
            {
                if (!Session.IsLoggedIn)
                {
                    MessageBox.Show("No hay sesión iniciada.");
                    return;
                }

                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                var response = await httpClient.GetAsync(API_BASE_URL);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al obtener servicios: " + response.StatusCode);
                    return;
                }

                var servicios = await response.Content.ReadFromJsonAsync<List<Servicio>>();
                dgvServicios.DataSource = servicios;

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
            Close();
        }

        private void lblClientes_Click(object sender, EventArgs e)
        {
            Usuarios anterior = new Usuarios();
            anterior.Show();
            Close();
        }

        private async void btnAnyadir_Click(object sender, EventArgs e)
        {
            AnyadirServicio formAnyadir = new AnyadirServicio();
            if (formAnyadir.ShowDialog() == DialogResult.OK)
            {
                var nuevoServicio = formAnyadir.NuevoServicio;

                try
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                    var response = await httpClient.PostAsJsonAsync(API_BASE_URL, nuevoServicio);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Servicio añadido correctamente.");
                        await CargarServicios();
                    }
                    else
                    {
                        MessageBox.Show("Error al añadir servicio: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al añadir servicio: " + ex.Message);
                }
            }
        }

        private void dgvServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
