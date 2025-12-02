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
    public partial class Servicios : Form
    {
        public Servicios()
        {
            InitializeComponent();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            Home anterior = new Home();
            anterior.Show();
            this.Close();
        }


        private void lblClientes_Click(object sender, EventArgs e)
        {
            Usuarios anterior = new Usuarios();
            anterior.Show();
            this.Close();
        }
    }
}
