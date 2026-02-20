using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class Servicios : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/servicios/";

        private List<Servicio> listaServiciosOriginal = new List<Servicio>();
        // Lista para el manejo del filtrado en tiempo real
        private List<dynamic> listaFiltrable = new List<dynamic>();

        public Servicios()
        {
            InitializeComponent();

            // --- AJUSTES PARA SER FORMULARIO HIJO ---
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(242, 242, 242);

            // IMPORTANTE: Evita que la tabla cree columnas nuevas al filtrar
            dgvServicios.AutoGenerateColumns = false;
            dgvServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicios.MultiSelect = false;
            dgvServicios.ReadOnly = true;
            dgvServicios.AllowUserToAddRows = false;

            ConfigurarColumnas();

            // Suscripción de eventos
            tbBusqueda.TextChanged -= tbBusqueda_TextChanged;
            tbBusqueda.TextChanged += tbBusqueda_TextChanged;

            this.Load += async (s, e) => await CargarServicios();
        }

        private void ConfigurarColumnas()
        {
            // Estilos visuales consistentes con Citas y Bloqueos
            dgvServicios.EnableHeadersVisualStyles = false;
            dgvServicios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvServicios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvServicios.ColumnHeadersHeight = 45;
            dgvServicios.RowTemplate.Height = 40;
            dgvServicios.BackgroundColor = Color.White;
            dgvServicios.BorderStyle = BorderStyle.None;
            dgvServicios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvServicios.RowHeadersVisible = false;
            dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvServicios.Columns.Clear();
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "id", Name = "IdCol", Visible = false });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "nombre", Name = "NombreCol", FillWeight = 120 });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Descripción", DataPropertyName = "descripcion", Name = "DescripcionCol", FillWeight = 180 });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Duración (min)", DataPropertyName = "duracion", Name = "DuracionCol", Width = 110 });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio (€)", DataPropertyName = "precio", Name = "PrecioCol", Width = 90 });
            dgvServicios.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tipo de Servicio", DataPropertyName = "tipoServicioNombre", Name = "TipoServicioCol", FillWeight = 100 });
        }

        private async Task CargarServicios()
        {
            try
            {
                if (!Session.IsLoggedIn) return;

                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                var response = await httpClient.GetAsync(API_BASE_URL);

                if (response.IsSuccessStatusCode)
                {
                    var servicios = await response.Content.ReadFromJsonAsync<List<Servicio>>();
                    listaServiciosOriginal = servicios ?? new List<Servicio>();

                    // Preparamos la lista filtrable con objetos anónimos
                    listaFiltrable = listaServiciosOriginal.Select(s => (dynamic)new
                    {
                        s.id,
                        nombre = s.Nombre, // Asegúrate que el DTO use 'Nombre' o 'nombre'
                        s.descripcion,
                        s.duracion,
                        s.precio,
                        tipoServicioNombre = s.tipoServicio?.nombre ?? "N/A"
                    }).ToList<dynamic>();

                    AplicarFiltro();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los servicios: " + ex.Message);
            }
        }

        private void AplicarFiltro()
        {
            string busqueda = tbBusqueda.Text.Trim().ToLower();

            var filtrados = listaFiltrable.Where(s =>
                s.nombre.ToLower().Contains(busqueda) ||
                s.descripcion.ToLower().Contains(busqueda) ||
                s.tipoServicioNombre.ToLower().Contains(busqueda)
            ).ToList();

            dgvServicios.DataSource = null;
            dgvServicios.DataSource = filtrados;
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        // --- ACCIONES (Añadir, Editar, Borrar) ---

        private async void btnAnyadir_Click(object sender, EventArgs e)
        {
            using (AnyadirServicio formAnyadir = new AnyadirServicio())
            {
                if (formAnyadir.ShowDialog() == DialogResult.OK)
                {
                    var n = formAnyadir.NuevoServicio;
                    var payload = new
                    {
                        nombre = n.Nombre,
                        descripcion = n.descripcion,
                        duracion = n.duracion,
                        precio = n.precio,
                        tipoServicio = new { id = n.tipoServicio.id }
                    };

                    await EjecutarOperacion(HttpMethod.Post, API_BASE_URL, payload);
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count == 0) return;

            int idServicio = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["IdCol"].Value);
            var seleccionado = listaServiciosOriginal.Find(s => s.id == idServicio);

            using (AnyadirServicio formEditar = new AnyadirServicio(seleccionado))
            {
                if (formEditar.ShowDialog() == DialogResult.OK)
                {
                    var n = formEditar.NuevoServicio;
                    var payload = new
                    {
                        nombre = n.Nombre,
                        descripcion = n.descripcion,
                        duracion = n.duracion,
                        precio = n.precio,
                        tipoServicio = new { id = n.tipoServicio.id }
                    };

                    await EjecutarOperacion(HttpMethod.Put, API_BASE_URL + idServicio, payload);
                }
            }
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count == 0) return;

            int idServicio = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["IdCol"].Value);

            if (MessageBox.Show("¿Seguro que quieres borrar este servicio?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await EjecutarOperacion(HttpMethod.Delete, API_BASE_URL + idServicio, null);
            }
        }

        // Método auxiliar para evitar repetición de código en llamadas API
        private async Task EjecutarOperacion(HttpMethod metodo, string url, object data)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                HttpResponseMessage response;
                if (metodo == HttpMethod.Post) response = await httpClient.PostAsJsonAsync(url, data);
                else if (metodo == HttpMethod.Put) response = await httpClient.PutAsJsonAsync(url, data);
                else if (metodo == HttpMethod.Delete) response = await httpClient.DeleteAsync(url);
                else return;

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Operación realizada con éxito.");
                    await CargarServicios();
                }
                else
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {response.StatusCode}\n{contenido}");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error de red: " + ex.Message); }
        }

        // --- NAVEGACIÓN ---
        private void lblHome_Click(object sender, EventArgs e) { /* Tu lógica de navegación */ }
        private void lblAgenda_Click(object sender, EventArgs e) { /* Tu lógica de navegación */ }
    }
}