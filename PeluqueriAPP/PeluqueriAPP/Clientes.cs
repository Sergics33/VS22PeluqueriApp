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
    public partial class Clientes : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/usuarios/";

        // 🔥 Lista general de usuarios
        private List<Usuario> listaUsuariosOriginal = new List<Usuario>();

        public Clientes()
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

            ConfigurarColumnas();

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
        //   LOAD
        // ============================
        private void Usuarios_Load(object sender, EventArgs e)
        {
            // 🔥 Opciones del ComboBox
            comboBox1.Items.Add("Usuarios");
            comboBox1.Items.Add("Cliente");
            comboBox1.Items.Add("Admin");

            comboBox1.SelectedIndex = 1; // por defecto Cliente

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            _ = CargarUsuarios();
        }

        // ============================
        //   CARGAR USUARIOS DEL API
        // ============================
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

                listaUsuariosOriginal = await response.Content.ReadFromJsonAsync<List<Usuario>>();

                FiltrarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message);
            }
        }

        // ============================
        //   FILTRO PRINCIPAL
        // ============================
        private void FiltrarUsuarios()
        {
            if (listaUsuariosOriginal == null) return;

            string seleccion = comboBox1.SelectedItem?.ToString() ?? "";
            List<Usuario> filtrados;

            switch (seleccion)
            {
                case "Admin":
                    filtrados = listaUsuariosOriginal
                        .Where(u => u.Role == "ROLE_ADMIN")
                        .ToList();
                    break;

                case "Cliente":
                    filtrados = listaUsuariosOriginal
                        .Where(u => u.Role == "ROLE_CLIENTE")
                        .ToList();
                    break;

                case "Usuarios":
                    filtrados = listaUsuariosOriginal
                        .Where(u => u.Role == "ROLE_USUARIO")
                        .ToList();
                    break;

                default:
                    filtrados = listaUsuariosOriginal;
                    break;
            }

            // 🔍 Buscador
            string textoBusqueda = textBox1.Text.ToLower();

            if (!string.IsNullOrWhiteSpace(textoBusqueda))
            {
                filtrados = filtrados
                    .Where(u => !string.IsNullOrEmpty(u.NombreCompleto) &&
                                u.NombreCompleto.ToLower().Contains(textoBusqueda))
                    .ToList();
            }

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = filtrados;
        }

        // ============================
        //   BUSCADOR
        // ============================
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FiltrarUsuarios();
        }

        // ============================
        //   COMBOBOX CAMBIO
        // ============================
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarUsuarios();
        }

        // ============================
        //   NAVEGACIÓN
        // ============================

        private void btnAnyadir_Click(object sender, EventArgs e)
        {

        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuario para eliminar.");
                return;
            }

            var usuarioSeleccionado = (Usuario)dataGridView2.SelectedRows[0].DataBoundItem;

            var confirm = MessageBox.Show(
                $"¿Estás seguro de eliminar a {usuarioSeleccionado.NombreCompleto}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                var response = await httpClient.DeleteAsync(API_BASE_URL + usuarioSeleccionado.Id);

                if (response.IsSuccessStatusCode)
                {
                    listaUsuariosOriginal.Remove(usuarioSeleccionado);
                    FiltrarUsuarios();
                    MessageBox.Show("Usuario eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al eliminar usuario: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }


        private void lblHome_Click_1(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            Close();
        }

        private void lblServicios_Click_1(object sender, EventArgs e)
        {
            Servicios servicios = new Servicios();
            servicios.Show();
            Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Grupos servicios = new Grupos();
            servicios.Show();
            Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Admins servicios = new Admins();
            servicios.Show();
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
