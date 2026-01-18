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

        private List<Servicio> listaServiciosOriginal = new List<Servicio>();

        public Servicios()
        {
            InitializeComponent();
            Load += Servicios_Load;

            dgvServicios.AutoGenerateColumns = false; // Controlamos las columnas
            dgvServicios.ReadOnly = true;
            dgvServicios.AllowUserToAddRows = false;
            dgvServicios.AllowUserToDeleteRows = false;
            dgvServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicios.MultiSelect = false;

            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            dgvServicios.Columns.Clear();

            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "id",
                Name = "IdCol"
            });

            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "nombre",
                Name = "NombreCol"
            });

            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Descripción",
                DataPropertyName = "descripcion",
                Name = "DescripcionCol"
            });

            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Duración (min)",
                DataPropertyName = "duracion",
                Name = "DuracionCol"
            });

            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Precio (€)",
                DataPropertyName = "precio",
                Name = "PrecioCol"
            });

            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tipo de Servicio",
                DataPropertyName = "tipoServicioNombre",
                Name = "TipoServicioCol"
            });
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

                listaServiciosOriginal = servicios; // Guardamos la lista original
                ActualizarGrid(listaServiciosOriginal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los servicios: " + ex.Message);
            }
        }

        private void ActualizarGrid(List<Servicio> lista)
        {
            var listaParaGrid = new List<object>();
            foreach (var s in lista)
            {
                listaParaGrid.Add(new
                {
                    s.id,
                    s.Nombre,
                    s.descripcion,
                    s.duracion,
                    s.precio,
                    tipoServicioNombre = s.tipoServicio?.nombre ?? ""
                });
            }

            dgvServicios.DataSource = listaParaGrid;
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            string filtro = tbBusqueda.Text.Trim().ToLower();

            var filtrados = listaServiciosOriginal
                .FindAll(s => s.Nombre.ToLower().StartsWith(filtro));

            ActualizarGrid(filtrados);
        }


        private async void btnAnyadir_Click(object sender, EventArgs e)
        {
            AnyadirServicio formAnyadir = new AnyadirServicio();
            if (formAnyadir.ShowDialog() == DialogResult.OK)
            {
                var nuevoServicio = formAnyadir.NuevoServicio;

                // Preparamos objeto sin el ID para el backend
                var nuevoServicioParaEnviar = new
                {
                    nombre = nuevoServicio.Nombre,
                    descripcion = nuevoServicio.descripcion,
                    duracion = nuevoServicio.duracion,
                    precio = nuevoServicio.precio,
                    tipoServicio = new { id = nuevoServicio.tipoServicio.id }
                };

                try
                {
                    // Limpiar headers y añadir token
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                    // Hacemos POST
                    var response = await httpClient.PostAsJsonAsync(API_BASE_URL, nuevoServicioParaEnviar);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Servicio añadido correctamente.");
                        await CargarServicios(); // Recargamos grid
                    }
                    else
                    {
                        // Mostrar mensaje del backend
                        var contenido = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error al añadir servicio: {response.StatusCode}\n{contenido}");
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

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un servicio para borrar.");
                return;
            }

            // Obtener el ID del servicio seleccionado
            var row = dgvServicios.SelectedRows[0];
            int idServicio = Convert.ToInt32(row.Cells["IdCol"].Value);

            // Confirmar borrado
            var confirm = MessageBox.Show("¿Seguro que quieres borrar este servicio?", "Confirmar borrado", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                var response = await httpClient.DeleteAsync(API_BASE_URL + idServicio);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Servicio borrado correctamente.");
                    await CargarServicios(); // Actualizar el grid
                }
                else
                {
                    MessageBox.Show("Error al borrar servicio: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar servicio: " + ex.Message);
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un servicio para editar.");
                return;
            }

            // Obtener el servicio seleccionado
            var row = dgvServicios.SelectedRows[0];
            int idServicio = Convert.ToInt32(row.Cells["IdCol"].Value);
            var servicioSeleccionado = listaServiciosOriginal.Find(s => s.id == idServicio);

            // Abrir formulario AnyadirServicio en modo edición
            AnyadirServicio formEditar = new AnyadirServicio(servicioSeleccionado);
            if (formEditar.ShowDialog() == DialogResult.OK)
            {
                var servicioEditado = formEditar.NuevoServicio;

                // Preparar objeto para enviar al backend
                var servicioParaEnviar = new
                {
                    nombre = servicioEditado.Nombre,
                    descripcion = servicioEditado.descripcion,
                    duracion = servicioEditado.duracion,
                    precio = servicioEditado.precio,
                    tipoServicio = new { id = servicioEditado.tipoServicio.id }
                };

                try
                {
                    // Limpiar headers y añadir token
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                    // Hacer PUT al backend
                    var response = await httpClient.PutAsJsonAsync(API_BASE_URL + idServicio, servicioParaEnviar);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Servicio editado correctamente.");
                        await CargarServicios(); // Recargar grid
                    }
                    else
                    {
                        var contenido = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error al editar servicio: {response.StatusCode}\n{contenido}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar servicio: " + ex.Message);
                }
            }
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            Home anterior = new Home();
            anterior.Show();
            Close();
        }



        private void label7_Click(object sender, EventArgs e)
        {
            Admins anterior = new Admins();
            anterior.Show();
            Close();
        }
    }
}
