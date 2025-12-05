using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;

namespace PeluqueriAPP
{
    public partial class Grupos : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/grupos/";

        private List<Grupo> listaGruposOriginal = new List<Grupo>();

        public Grupos()
        {
            InitializeComponent();
            Load += Grupos_Load;

            dgvGrupos.AutoGenerateColumns = false;
            dgvGrupos.ReadOnly = true;
            dgvGrupos.AllowUserToAddRows = false;
            dgvGrupos.AllowUserToDeleteRows = false;
            dgvGrupos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGrupos.MultiSelect = false;

            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            dgvGrupos.Columns.Clear();

            dgvGrupos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "id",
                Name = "IdCol"
            });

            dgvGrupos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Aula",
                DataPropertyName = "aula",
                Name = "AulaCol"
            });

            dgvGrupos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Clase",
                DataPropertyName = "clase",
                Name = "ClaseCol"
            });

            dgvGrupos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Módulo",
                DataPropertyName = "modulo",
                Name = "ModuloCol"
            });
        }

        private async void Grupos_Load(object sender, EventArgs e)
        {
            await CargarGrupos();
        }

        private async Task CargarGrupos()
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
                    var contenido = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al cargar grupos: {response.StatusCode}\n{contenido}");
                    return;
                }

                var grupos = await response.Content.ReadFromJsonAsync<List<Grupo>>();
                listaGruposOriginal = grupos;
                ActualizarGrid(listaGruposOriginal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar grupos: " + ex.Message);
            }
        }

        private void ActualizarGrid(List<Grupo> lista)
        {
            dgvGrupos.DataSource = null;
            dgvGrupos.DataSource = lista;
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            string filtro = tbBusqueda.Text.Trim().ToLower();
            var filtrados = listaGruposOriginal.FindAll(g =>
                (g.aula?.ToLower().Contains(filtro) ?? false) ||
                (g.clase?.ToLower().Contains(filtro) ?? false) ||
                (g.modulo?.ToLower().Contains(filtro) ?? false)
            );
            ActualizarGrid(filtrados);
        }

        private async void btnAnyadir_Click(object sender, EventArgs e)
        {
            using (var form = new AnyadirGrupo())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var nuevoGrupo = form.NuevoGrupo;

                    try
                    {
                        httpClient.DefaultRequestHeaders.Clear();
                        httpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                        var response = await httpClient.PostAsJsonAsync(API_BASE_URL, nuevoGrupo);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Grupo añadido correctamente.");
                            await CargarGrupos();
                        }
                        else
                        {
                            var contenido = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Error al añadir grupo: {response.StatusCode}\n{contenido}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al añadir grupo: " + ex.Message);
                    }
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvGrupos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un grupo para editar.");
                return;
            }

            var row = dgvGrupos.SelectedRows[0];
            int idGrupo = Convert.ToInt32(row.Cells["IdCol"].Value);
            var grupoSeleccionado = listaGruposOriginal.Find(g => g.id == idGrupo);

            using (var form = new AnyadirGrupo(grupoSeleccionado))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var grupoEditado = form.NuevoGrupo;

                    try
                    {
                        httpClient.DefaultRequestHeaders.Clear();
                        httpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                        var response = await httpClient.PutAsJsonAsync(API_BASE_URL + idGrupo, grupoEditado);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Grupo editado correctamente.");
                            await CargarGrupos();
                        }
                        else
                        {
                            var contenido = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Error al editar grupo: {response.StatusCode}\n{contenido}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al editar grupo: " + ex.Message);
                    }
                }
            }
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvGrupos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un grupo para borrar.");
                return;
            }

            var row = dgvGrupos.SelectedRows[0];
            int idGrupo = Convert.ToInt32(row.Cells["IdCol"].Value);

            // Confirmación de borrado
            var confirm = MessageBox.Show("¿Seguro que quieres borrar este grupo?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                var response = await httpClient.DeleteAsync(API_BASE_URL + idGrupo);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Grupo borrado correctamente.");
                    await CargarGrupos();
                }
                else
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al borrar grupo: {response.StatusCode}\n{contenido}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar grupo: " + ex.Message);
            }
        }

        private void lblServicios_Click(object sender, EventArgs e)
        {
            Admins nuevaVentana = new Admins();
            nuevaVentana.Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Admins nuevaVentana = new Admins();
            nuevaVentana.Show();
            this.Close();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            Home nuevaVentana = new Home();
            nuevaVentana.Show();
            this.Close();
        }


        private void lblCliente_Click(object sender, EventArgs e)
        {

        }

        private void lblServicios_Click_1(object sender, EventArgs e)
        {
            Servicios nuevaVentana = new Servicios();
            nuevaVentana.Show();
            this.Close();
        }
    }

    public class Grupo
    {
        public int id { get; set; }
        public string aula { get; set; }
        public string clase { get; set; }
        public string modulo { get; set; }
    }
}
