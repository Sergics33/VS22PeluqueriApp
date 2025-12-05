using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;

namespace PeluqueriAPP
{
    public partial class Admins : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/admins/";
        private List<Admin> listaAdminsOriginal = new List<Admin>();

        public Admins()
        {
            InitializeComponent();
            Load += Admins_Load;

            dgvAdmins.AutoGenerateColumns = false;
            dgvAdmins.ReadOnly = true;
            dgvAdmins.AllowUserToAddRows = false;
            dgvAdmins.AllowUserToDeleteRows = false;
            dgvAdmins.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdmins.MultiSelect = false;

            ConfigurarColumnas();

            tbBusqueda.TextChanged += TbBusqueda_TextChanged;
            btnAnyadir.Click += BtnAnyadir_Click;
            btnEditar.Click += BtnEditar_Click;
            btnBorrar.Click += BtnBorrar_Click;
        }

        private void ConfigurarColumnas()
        {
            dgvAdmins.Columns.Clear();

            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "id",
                Name = "IdCol"
            });
            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "nombreCompleto",
                Name = "NombreCol"
            });
            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Especialidad",
                DataPropertyName = "especialidad",
                Name = "EspecialidadCol"
            });
        }

        private async void Admins_Load(object sender, EventArgs e)
        {
            await CargarAdmins();
        }

        private async Task CargarAdmins()
        {
            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                var response = await httpClient.GetAsync(API_BASE_URL);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Error al cargar admins: {response.StatusCode}");
                    return;
                }

                listaAdminsOriginal = await response.Content.ReadFromJsonAsync<List<Admin>>();
                ActualizarGrid(listaAdminsOriginal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ActualizarGrid(List<Admin> lista)
        {
            var listaParaGrid = new List<object>();
            foreach (var a in lista)
            {
                listaParaGrid.Add(new
                {
                    a.id,
                    a.nombreCompleto,
                    a.especialidad
                });
            }
            dgvAdmins.DataSource = listaParaGrid;
        }

        private void TbBusqueda_TextChanged(object sender, EventArgs e)
        {
            string filtro = tbBusqueda.Text.Trim().ToLower();
            var filtrados = listaAdminsOriginal.FindAll(a =>
                (a.nombreCompleto?.ToLower().Contains(filtro) ?? false) ||
                (a.especialidad?.ToLower().Contains(filtro) ?? false)
            );
            ActualizarGrid(filtrados);
        }

        private async void BtnAnyadir_Click(object sender, EventArgs e)
        {
            string nombre = Microsoft.VisualBasic.Interaction.InputBox("Nombre del admin:", "Añadir Admin");
            if (string.IsNullOrWhiteSpace(nombre)) return;

            string especialidad = Microsoft.VisualBasic.Interaction.InputBox("Especialidad:", "Añadir Admin");

            var nuevoAdmin = new { nombreCompleto = nombre, especialidad = especialidad };

            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                var response = await httpClient.PostAsJsonAsync(API_BASE_URL, nuevoAdmin);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Admin añadido correctamente.");
                    await CargarAdmins();
                }
                else
                {
                    MessageBox.Show("Error al añadir admin: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir admin: " + ex.Message);
            }
        }

        private async void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAdmins.SelectedRows.Count == 0) return;

            var row = dgvAdmins.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["IdCol"].Value);
            var admin = listaAdminsOriginal.Find(a => a.id == id);

            string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox("Editar nombre:", "Editar Admin", admin.nombreCompleto);
            if (string.IsNullOrWhiteSpace(nuevoNombre)) return;

            string nuevaEspecialidad = Microsoft.VisualBasic.Interaction.InputBox("Editar especialidad:", "Editar Admin", admin.especialidad);

            var adminEditado = new { nombreCompleto = nuevoNombre, especialidad = nuevaEspecialidad };

            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                var response = await httpClient.PutAsJsonAsync(API_BASE_URL + id, adminEditado);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Admin editado correctamente.");
                    await CargarAdmins();
                }
                else
                {
                    MessageBox.Show("Error al editar admin: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar admin: " + ex.Message);
            }
        }

        private async void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvAdmins.SelectedRows.Count == 0) return;

            var row = dgvAdmins.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["IdCol"].Value);

            var confirm = MessageBox.Show("¿Eliminar este admin?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                var response = await httpClient.DeleteAsync(API_BASE_URL + id);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Admin eliminado correctamente.");
                    await CargarAdmins();
                }
                else
                {
                    MessageBox.Show("Error al eliminar admin: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar admin: " + ex.Message);
            }
        }

        private void lblHomeAdmin_Click(object sender, EventArgs e)
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

        private void lblClientes_Click(object sender, EventArgs e)
        {
            Clientes servicios = new Clientes();
            servicios.Show();
            Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Grupos nuevaVentana = new Grupos();
            nuevaVentana.Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }

    public class Admin
    {
        public int id { get; set; }
        public string nombreCompleto { get; set; }
        public string especialidad { get; set; }
    }
}
