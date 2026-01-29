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

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            TipoSeleccionado = "Admin";
            this.DialogResult = DialogResult.OK;
        }

        private void btnGrupo_Click(object sender, EventArgs e)
        {
            TipoSeleccionado = "Grupo";
            this.DialogResult = DialogResult.OK;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            TipoSeleccionado = "Cliente";
            this.DialogResult = DialogResult.OK;
        }
    }
}