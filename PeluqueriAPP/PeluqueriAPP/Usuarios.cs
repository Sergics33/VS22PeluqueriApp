using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class Usuarios : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/usuarios/";
        private List<Usuario> listaClientes = new List<Usuario>();

        public Usuarios()
        {
            InitializeComponent();
            Load += Usuarios_Load;

            // Evento para filtrar
            textBox1.TextChanged += textBox1_TextChanged;

            // Configuración del DataGridView
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
        }

        private async void Usuarios_Load(object sender, EventArgs e)
        {
            await CargarUsuarios();
        }

        private async Task CargarUsuarios()
        {
            try
            {
                var response = await httpClient.GetAsync(API_BASE_URL);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al obtener usuarios: " + response.StatusCode);
                    return;
                }

                var todosUsuarios = await response.Content.ReadFromJsonAsync<List<Usuario>>();

                // Filtrar solo clientes (Role == 0)
                listaClientes = todosUsuarios
                    .Where(u => u.Role == 0)
                    .ToList();

                // Mostrar en DataGridView
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = listaClientes;

                // Mapear columnas con nombres exactos (sin tildes en Name)
                dataGridView2.Columns["ID"].DataPropertyName = "Id";
                dataGridView2.Columns["Nombre"].DataPropertyName = "Nombre";
                dataGridView2.Columns["Telefono"].DataPropertyName = "Telefono";
                dataGridView2.Columns["Alergenos"].DataPropertyName = "Alergenos";
                dataGridView2.Columns["Observaciones"].DataPropertyName = "Observaciones";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox1.Text.ToLower();

            var listaFiltrada = listaClientes
                .Where(u => !string.IsNullOrEmpty(u.Nombre) && u.Nombre.ToLower().Contains(filtro))
                .ToList();

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = listaFiltrada;
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            Close();
        }

        private void lblServicios_Click(object sender, EventArgs e)
        {
            Servicios servicios = new Servicios();
            servicios.Show();
            Close();
        }
    }
}
