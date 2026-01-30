using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirServicio : Form
    {
        public Servicio NuevoServicio { get; private set; }
        private bool esEdicion = false;
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_TIPOS_URL = "http://localhost:8080/api/tipos-servicio/";
        public AnyadirServicio()
        {
            InitializeComponent();
            btnAnyadir.Click += BtnAnyadir_Click;

            lbltitulo.Text = "AÑADIR SERVICIO";
            btnAnyadir.Text = "AÑADIR SERVICIO";

            Load += AnyadirServicio_Load;
        }

        public AnyadirServicio(Servicio servicio) : this()
        {
            if (servicio == null) return;

            esEdicion = true;
            lbltitulo.Text = "EDITAR SERVICIO";
            btnAnyadir.Text = "GUARDAR CAMBIOS";

            tbNombre.Text = servicio.Nombre;
            tbDescripcion.Text = servicio.descripcion;
            tbDuracion.Text = servicio.duracion.ToString();
            tbPrecio.Text = servicio.precio.ToString();

            NuevoServicio = new Servicio
            {
                id = servicio.id,
                tipoServicio = servicio.tipoServicio
            };
        }

        private async void AnyadirServicio_Load(object sender, EventArgs e)
        {
            await CargarTiposServicio();
        }

        private async Task CargarTiposServicio()
        {
            try
            {
                comboBoxTipos.Items.Clear();

                if (Session.IsLoggedIn)
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                    var response = await httpClient.GetAsync(API_TIPOS_URL);
                    if (response.IsSuccessStatusCode)
                    {
                        var tipos = await response.Content.ReadFromJsonAsync<List<TipoServicio>>();
                        comboBoxTipos.DataSource = tipos;
                        comboBoxTipos.DisplayMember = "nombre";
                        comboBoxTipos.ValueMember = "id";

                        if (esEdicion && NuevoServicio?.tipoServicio != null)
                        {
                            comboBoxTipos.SelectedValue = NuevoServicio.tipoServicio.id;
                        }

                        return;
                    }
                    else
                    {
                        MessageBox.Show($"Error al cargar tipos de servicio: {response.StatusCode}");
                    }
                }

                var dummyTipos = new List<TipoServicio>
                {
                    new TipoServicio { id = 1, nombre = "Corte" },
                    new TipoServicio { id = 2, nombre = "Color" },
                    new TipoServicio { id = 3, nombre = "Peinado" }
                };

                comboBoxTipos.DataSource = dummyTipos;
                comboBoxTipos.DisplayMember = "nombre";
                comboBoxTipos.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de servicio: " + ex.Message);
            }
        }

        private void BtnAnyadir_Click(object sender, EventArgs e)
        {
            // Validación
            if (string.IsNullOrWhiteSpace(tbNombre.Text) ||
                string.IsNullOrWhiteSpace(tbDescripcion.Text) ||
                string.IsNullOrWhiteSpace(tbDuracion.Text) ||
                string.IsNullOrWhiteSpace(tbPrecio.Text) ||
                comboBoxTipos.SelectedItem == null)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (!int.TryParse(tbDuracion.Text, out int duracion))
            {
                MessageBox.Show("Duración debe ser un número entero.");
                return;
            }

            if (!decimal.TryParse(tbPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Precio debe ser un número decimal.");
                return;
            }

            var tipoSeleccionado = (TipoServicio)comboBoxTipos.SelectedItem;

            if (!esEdicion)
            {
                NuevoServicio = new Servicio
                {
                    Nombre = tbNombre.Text.Trim(),
                    descripcion = tbDescripcion.Text.Trim(),
                    duracion = duracion,
                    precio = precio,
                    tipoServicio = tipoSeleccionado
                };
            }
            else
            {
                NuevoServicio.Nombre = tbNombre.Text.Trim();
                NuevoServicio.descripcion = tbDescripcion.Text.Trim();
                NuevoServicio.duracion = duracion;
                NuevoServicio.precio = precio;
                NuevoServicio.tipoServicio = tipoSeleccionado;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
