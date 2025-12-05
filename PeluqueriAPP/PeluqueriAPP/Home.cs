namespace PeluqueriAPP
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }



        private void lblServicios_Click(object sender, EventArgs e)
        {
            Servicios nuevaVentana = new Servicios();
            nuevaVentana.Show();
            this.Close();
        }

        private void lblUsuarios_Click(object sender, EventArgs e)
        {
            Clientes nuevaVentana = new Clientes();
            nuevaVentana.Show();
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Grupos nuevaVentana = new Grupos();
            nuevaVentana.Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Admins nuevaVentana = new Admins();
            nuevaVentana.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
