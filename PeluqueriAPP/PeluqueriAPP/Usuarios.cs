using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

            textBox1.TextChanged += textBox1_TextChanged;

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;

            ConfigurarColumnas(); // 🔥 Evita errores de columnas inexistentes

            if (Session.IsLoggedIn)
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);
            }
        }

        // ============================
        //   CARGA DE COLUMNAS
        // ============================
        private void ConfigurarColumnas()
        {
            dataGridView2.Columns.Clear();

            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ID",
                HeaderText = "ID",
                DataPropertyName = "Id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Nombre",
                HeaderText = "Nombre Completo",
                DataPropertyName = "NombreCompleto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Telefono",
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Alergenos",
                HeaderText = "Alérgenos",
                DataPropertyName = "Alergenos",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Observaciones",
                HeaderText = "Observaciones",
                DataPropertyName = "Observaciones",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        // ============================
        //   CARGAR USUARIOS
        // ============================
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

                listaClientes = todosUsuarios
                    .Where(u => u.Role == "ROLE_CLIENTE")
                    .ToList();

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = listaClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message);
            }
        }

        // ============================
        //   BUSCAR POR NOMBRE
        // ============================
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox1.Text.ToLower();

            var listaFiltrada = listaClientes
                .Where(u => !string.IsNullOrEmpty(u.NombreCompleto) &&
                            u.NombreCompleto.ToLower().Contains(filtro))
                .ToList();

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = listaFiltrada;
        }

        // ============================
        //   NAVEGACIÓN
        // ============================
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

    // ============================
    //   CLASE USUARIO CORRECTA
    // ============================
    public class Usuario
    {
        public long Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Role { get; set; }
        public string Telefono { get; set; }
        public string Observaciones { get; set; }
        public string Alergenos { get; set; }
    }
}
