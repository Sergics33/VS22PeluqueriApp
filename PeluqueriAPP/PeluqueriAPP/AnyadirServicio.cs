using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

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
            // 1. Botón redondeado (Manteniendo funcionalidad)
            btnAnyadir.Paint += (s, e) => DibujarBordeRedondeado(btnAnyadir, e.Graphics, 38);

            // 2. Redondeo del panel gris principal
            panelContenedor.SizeChanged += (s, e) => DibujarBordeRedondeado(panelContenedor, null, 25);
            DibujarBordeRedondeado(panelContenedor, null, 25);

            // 3. Crear Cápsulas para inputs (X, Y deben coincidir con tus labels en el Designer)
            // Usamos las posiciones aproximadas de tu InitializeComponent
            ConfigurarCapsulaInput(tbNombre, 20, 38);
            ConfigurarCapsulaInput(comboBoxTipos, 20, 103);
            ConfigurarCapsulaInput(tbDescripcion, 20, 173);
            ConfigurarCapsulaInput(tbDuracion, 20, 243);
            ConfigurarCapsulaInput(tbPrecio, 20, 313);
        }

        private void ConfigurarCapsulaInput(Control ctrl, int x, int y)
        {
            // Crear el fondo blanco redondeado
            Panel pnlFondo = new Panel();
            pnlFondo.BackColor = Color.White;
            pnlFondo.Size = new Size(320, 36);
            pnlFondo.Location = new Point(x, y);

            // Meter el control dentro
            ctrl.Parent = pnlFondo;
            ctrl.BackColor = Color.White;
            ctrl.Width = pnlFondo.Width - 20;

            // Ajuste fino de posición según el tipo de control
            if (ctrl is ComboBox)
                ctrl.Location = new Point(10, 4);
            else
                ctrl.Location = new Point(10, 8);

            panelContenedor.Controls.Add(pnlFondo);
            pnlFondo.BringToFront();

            // Dibujar el borde de la cápsula
            pnlFondo.Paint += (s, e) => DibujarBordeRedondeado(pnlFondo, e.Graphics, 15);
        }

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

        // --- LÓGICA DE DATOS ---

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

                // Fallback si falla la API
                var dummyTipos = new List<TipoServicio> {
                    new TipoServicio { id = 1, nombre = "Corte" },
                    new TipoServicio { id = 2, nombre = "Color" }
                };
                comboBoxTipos.DataSource = dummyTipos;
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void BtnAnyadir_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(tbNombre.Text) || comboBoxTipos.SelectedItem == null)
            {
                MessageBox.Show("Rellene los campos obligatorios.");
                return;
            }

            if (!int.TryParse(tbDuracion.Text, out int duracion) || !decimal.TryParse(tbPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Verifique los valores numéricos.");
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