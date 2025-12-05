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
            // Por ahora no hace nada
        }
    }
}
