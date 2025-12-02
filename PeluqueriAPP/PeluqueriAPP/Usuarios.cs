using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void lblServicios_Click(object sender, EventArgs e)
        {
            Servicios nuevaVentana = new Servicios();
            nuevaVentana.Show();
            this.Close();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            Home nuevaVentana = new Home();
            nuevaVentana.Show();
            this.Close();
        }
    }
}
