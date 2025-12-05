using System;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class SeleccionarTipoUsuario : Form
    {
        public string TipoSeleccionado { get; private set; }

        public SeleccionarTipoUsuario()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            TipoSeleccionado = "Cliente";
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            TipoSeleccionado = "Admin";
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnGrupo_Click(object sender, EventArgs e)
        {
            TipoSeleccionado = "Grupo";
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
