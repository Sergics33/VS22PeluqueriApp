using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

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
            ConfigurarEstilosPersonalizados();
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

        private void ConfigurarEstilosPersonalizados()
        {
            // Botón redondeado
            btnAnyadir.Paint += (s, e) => DibujarBordeRedondeado(btnAnyadir, e.Graphics, 38);

            // Inputs redondeados y blancos
            Control[] controlesBlancos = { tbNombre, tbDescripcion, tbDuracion, tbPrecio, comboBoxTipos };
            foreach (var ctrl in controlesBlancos)
            {
                ctrl.SizeChanged += (s, e) => DibujarBordeRedondeado(ctrl, null, 15);
                DibujarBordeRedondeado(ctrl, null, 15);
            }
        }

        // Degradado Naranja de fondo
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                       Color.FromArgb(255, 140, 0),
                                                                       Color.FromArgb(255, 220, 150),
                                                                       LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void DibujarBordeRedondeado(Control control, Graphics g, int radio)
        {
            Graphics graphics = g ?? control.CreateGraphics();
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radio, radio, 180, 90);
                path.AddArc(control.Width - radio, 0, radio, radio, 270, 90);
                path.AddArc(control.Width - radio, control.Height - radio, radio, radio, 0, 90);
                path.AddArc(0, control.Height - radio, radio, radio, 90, 90);
                path.CloseAllFigures();
                control.Region = new Region(path);
            }
        }

        private async void AnyadirServicio_Load(object sender, EventArgs e)
        {
            await CargarTiposServicio();
        }

        private async Task CargarTiposServicio()
        {
            try
            {
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
                }

                // Fallback / Dummy
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
            if (string.IsNullOrWhiteSpace(tbNombre.Text) || string.IsNullOrWhiteSpace(tbDescripcion.Text) ||
                string.IsNullOrWhiteSpace(tbDuracion.Text) || string.IsNullOrWhiteSpace(tbPrecio.Text) ||
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