using System;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirGrupo : Form
    {
        public Grupo NuevoGrupo { get; private set; }
        private bool esEdicion = false;

        // Constructor para añadir grupo
        public AnyadirGrupo()
        {
            InitializeComponent();
            btnAnyadir.Click += BtnAnyadir_Click;

            // Texto por defecto para añadir
            lbltitulo.Text = "AÑADIR GRUPO";
            btnAnyadir.Text = "AÑADIR GRUPO";
        }

        // Constructor para editar grupo
        public AnyadirGrupo(Grupo grupo) : this()
        {
            if (grupo == null) return;

            esEdicion = true;

            // Cambiar texto de título y botón
            lbltitulo.Text = "EDITAR GRUPO";
            btnAnyadir.Text = "GUARDAR CAMBIOS";

            // Rellenar campos con los datos del grupo
            tbAula.Text = grupo.aula;
            tbClase.Text = grupo.clase;
            tbModulo.Text = grupo.modulo;

            // Guardar ID para enviar al backend
            NuevoGrupo = new Grupo
            {
                id = grupo.id
            };
        }

        private void BtnAnyadir_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (string.IsNullOrWhiteSpace(tbAula.Text) ||
                string.IsNullOrWhiteSpace(tbClase.Text) ||
                string.IsNullOrWhiteSpace(tbModulo.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            // Crear o actualizar grupo
            if (!esEdicion)
            {
                NuevoGrupo = new Grupo
                {
                    aula = tbAula.Text.Trim(),
                    clase = tbClase.Text.Trim(),
                    modulo = tbModulo.Text.Trim()
                };
            }
            else
            {
                NuevoGrupo.aula = tbAula.Text.Trim();
                NuevoGrupo.clase = tbClase.Text.Trim();
                NuevoGrupo.modulo = tbModulo.Text.Trim();
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
