using System;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirServicio : Form
    {
        public Servicio NuevoServicio { get; private set; }
        private bool esEdicion = false;

        // Constructor para añadir servicio
        public AnyadirServicio()
        {
            InitializeComponent();
            btnAnyadir.Click += BtnAnyadir_Click;

            // Texto por defecto para añadir
            lbltitulo.Text = "AÑADIR SERVICIO";
            btnAnyadir.Text = "AÑADIR SERVICIO";
        }

        // Constructor para editar servicio
        public AnyadirServicio(Servicio servicio) : this()
        {
            if (servicio == null) return;

            esEdicion = true;

            // Cambiar texto de título y botón
            lbltitulo.Text = "EDITAR SERVICIO";
            btnAnyadir.Text = "GUARDAR CAMBIOS";

            // Rellenar campos con los datos del servicio
            tbNombre.Text = servicio.nombre;
            tbDescripcion.Text = servicio.descripcion;
            tbDuracion.Text = servicio.duracion.ToString();
            tbPrecio.Text = servicio.precio.ToString();
            tbTipoServicioId.Text = servicio.tipoServicio?.id.ToString() ?? "";

            // Guardar ID y tipo para enviar al backend
            NuevoServicio = new Servicio
            {
                id = servicio.id,
                tipoServicio = servicio.tipoServicio
            };
        }

        private void BtnAnyadir_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (string.IsNullOrWhiteSpace(tbNombre.Text) ||
                string.IsNullOrWhiteSpace(tbDescripcion.Text) ||
                string.IsNullOrWhiteSpace(tbDuracion.Text) ||
                string.IsNullOrWhiteSpace(tbPrecio.Text) ||
                string.IsNullOrWhiteSpace(tbTipoServicioId.Text))
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

            if (!int.TryParse(tbTipoServicioId.Text, out int tipoServicioId))
            {
                MessageBox.Show("ID del tipo de servicio debe ser un número entero.");
                return;
            }

            // Crear o actualizar servicio
            if (!esEdicion)
            {
                NuevoServicio = new Servicio
                {
                    nombre = tbNombre.Text.Trim(),
                    descripcion = tbDescripcion.Text.Trim(),
                    duracion = duracion,
                    precio = precio,
                    tipoServicio = new TipoServicio { id = tipoServicioId }
                };
            }
            else
            {
                NuevoServicio.nombre = tbNombre.Text.Trim();
                NuevoServicio.descripcion = tbDescripcion.Text.Trim();
                NuevoServicio.duracion = duracion;
                NuevoServicio.precio = precio;
                NuevoServicio.tipoServicio.id = tipoServicioId;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
