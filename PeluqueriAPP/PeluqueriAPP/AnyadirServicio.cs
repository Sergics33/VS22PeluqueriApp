using System;
using System.Text.Json;
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

            NuevoServicio = new Servicio
            {
                nombre = tbNombre.Text,
                descripcion = tbDescripcion.Text,
                duracion = duracion,
                precio = precio,
                tipoServicio = new TipoServicio { id = tipoServicioId }
            };

            // Mostrar JSON antes de cerrar
            string json = JsonSerializer.Serialize(NuevoServicio, new JsonSerializerOptions { WriteIndented = true });
            MessageBox.Show("JSON a enviar al servidor:\n" + json, "Depuración");

            DialogResult = DialogResult.OK;
            Close();
        }

        private void tbTipo_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
