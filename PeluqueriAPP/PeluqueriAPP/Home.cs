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
            Usuarios nuevaVentana = new Usuarios();
            nuevaVentana.Show();
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
