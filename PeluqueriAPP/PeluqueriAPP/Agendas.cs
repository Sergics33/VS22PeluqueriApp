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
    public partial class Agendas : Form
    {
        public Agendas()
        {
            InitializeComponent();
        }

        private void lblHomeAdmin_Click(object sender, EventArgs e)
        {
            Home anterior = new Home();
            anterior.Show();
            Close();
        }

        private void lblCitas_Click(object sender, EventArgs e)
        {
            Citas anterior = new Citas();
            anterior.Show();
            Close();
        }

        private void lblServicios_Click(object sender, EventArgs e)
        {
            Servicios anterior = new Servicios();
            anterior.Show();
            Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Admins anterior = new Admins();
            anterior.Show();
            Close();
        }
    }
}
