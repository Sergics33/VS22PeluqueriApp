using System;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirServicio : Form
    {
        public Servicio NuevoServicio { get; private set; }

        public AnyadirServicio()
        {
            InitializeComponent();
            btnAnyadir.Click += BtnAnyadir_Click;
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

            // Creamos el servicio **sin asignar ID**
            NuevoServicio = new Servicio
            {
                // id = 0, <-- NO se asigna
                nombre = tbNombre.Text.Trim(),
                descripcion = tbDescripcion.Text.Trim(),
                duracion = duracion,
                precio = precio,
                tipoServicio = new TipoServicio
                {
                    id = tipoServicioId
                }
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
