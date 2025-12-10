using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json.Serialization;

namespace PeluqueriAPP
{
    public partial class Admins : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/usuarios/";
        private List<Usuario> listaUsuariosOriginal = new List<Usuario>();

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
                HeaderText = "Id",
                DataPropertyName = "Id",
                Name = "Id",
                Visible = false
            });

            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Name = "NombreCol"
            });

            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Apellidos",
                DataPropertyName = "Apellidos",
                Name = "ApellidosCol"
            });

            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Email",
                DataPropertyName = "Email",
                Name = "EmailCol"
            });

            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Rol",
                DataPropertyName = "Rol",
                Name = "RolCol"
            });
        }

        private async void Admins_Load(object sender, EventArgs e)
        {
            await CargarUsuarios();
        }

        private async Task CargarUsuarios()
        {
            if (string.IsNullOrEmpty(Session.AccessToken))
            {
                MessageBox.Show("No hay sesión iniciada.");
                return;
            }

            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var response = await httpClient.GetAsync(API_BASE_URL);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Error al cargar usuarios: {response.StatusCode}");
                    return;
                }

                listaUsuariosOriginal = await response.Content.ReadFromJsonAsync<List<Usuario>>();
                ActualizarGrid(listaUsuariosOriginal);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error de conexión con el servidor: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void ActualizarGrid(List<Usuario> lista)
        {
            dgvAdmins.DataSource = null;

            var listaParaGrid = lista.ConvertAll(u =>
            {
                string nombreCompleto = u.NombreCompleto ?? "";

                string nombre = "";
                string apellidos = "";

                if (!string.IsNullOrEmpty(nombreCompleto))
                {
                    var partes = nombreCompleto.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (partes.Length > 0) nombre = partes[0];
                    if (partes.Length > 1)
                        apellidos = string.Join(' ', partes, 1, partes.Length - 1);
                }

                string rol = u.Rol?.Replace("ROLE_", "").ToUpper() ?? "DESCONOCIDO";

                return new
                {
                    u.Id,
                    Nombre = nombre,
                    Apellidos = apellidos,
                    u.Email,
                    Rol = rol
                };
            }).ToList();

            dgvAdmins.DataSource = listaParaGrid;

            if (dgvAdmins.Columns["Id"] != null)
                dgvAdmins.Columns["Id"].Visible = false;
        }

        private void TbBusqueda_TextChanged(object sender, EventArgs e)
        {
            string filtro = tbBusqueda.Text.Trim().ToLower();

            var filtrados = listaUsuariosOriginal.FindAll(u =>
                (u.NombreCompleto?.ToLower().Contains(filtro) ?? false) ||
                (u.Email?.ToLower().Contains(filtro) ?? false) ||
                (u.Rol?.ToLower().Contains(filtro) ?? false)
            );

            ActualizarGrid(filtrados);
        }

        private async void BtnAnyadir_Click(object sender, EventArgs e)
        {
            AnyadirUsuario form = new AnyadirUsuario();

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                    var response = await httpClient.PostAsJsonAsync(API_BASE_URL, form.NuevoUsuario);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Usuario añadido correctamente.");
                        await CargarUsuarios();
                    }
                    else
                    {
                        var contenido = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error al añadir usuario: {response.StatusCode}\n{contenido}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado: " + ex.Message);
                }
            }
        }

        private async void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAdmins.SelectedRows.Count == 0) return;

            var row = dgvAdmins.SelectedRows[0];
            long id = Convert.ToInt64(row.Cells["Id"].Value);

            var usuario = listaUsuariosOriginal.Find(u => u.Id == id);
            if (usuario == null) return;

            AnyadirUsuario form = new AnyadirUsuario(usuario);

            if (form.ShowDialog() != DialogResult.OK) return;

            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var response = await httpClient.PutAsJsonAsync($"{API_BASE_URL}{id}", form.NuevoUsuario);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario editado correctamente.");
                    await CargarUsuarios();
                }
                else
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al editar usuario: {response.StatusCode}\n{contenido}");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private async void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvAdmins.SelectedRows.Count == 0) return;

            var row = dgvAdmins.SelectedRows[0];
            long id = Convert.ToInt64(row.Cells["Id"].Value);

            var confirm = MessageBox.Show("¿Eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var response = await httpClient.DeleteAsync($"{API_BASE_URL}{id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario eliminado correctamente.");
                    await CargarUsuarios();
                }
                else
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al eliminar usuario: {response.StatusCode}\n{contenido}");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void lblHomeAdmin_Click(object sender, EventArgs e)
        {
            Home nuevaVentana = new Home();
            nuevaVentana.Show();
            this.Close();
        }
    }
}
