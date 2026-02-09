using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class Home : Form
    {
        private Form formularioActivo = null;

        public Home()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Definimos el color oscuro suave (Antracita)
            panel1.BackColor = Color.FromArgb(45, 45, 48);

            // Aseguramos transparencia para que no salgan recuadros grises en los textos
            foreach (Control c in panel1.Controls)
            {
                c.BackColor = Color.Transparent;
            }

            ConfigurarEfectosMenu();
        }

        private void ConfigurarEfectosMenu()
        {
            // Efecto de iluminación suave al pasar el ratón
            Label[] menuItems = { lblHome, lblCitas, lblServicios, label7, lblAgenda, lblCerrarSesion };

            foreach (var lbl in menuItems)
            {
                lbl.MouseEnter += (s, e) => { ((Label)s).ForeColor = Color.Silver; ((Label)s).Cursor = Cursors.Hand; };
                lbl.MouseLeave += (s, e) => { ((Label)s).ForeColor = Color.White; ((Label)s).Cursor = Cursors.Default; };
            }
        }

        private void AbrirFormEnPanel(Form formularioHijo)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
                panel2.Controls.Remove(formularioActivo);
            }

            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            formularioHijo.BackColor = panel2.BackColor;

            panel2.Controls.Add(formularioHijo);
            panel2.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();

            lblUbi.Text = formularioHijo.Text;
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
                panel2.Controls.Remove(formularioActivo);
                formularioActivo = null;
                lblUbi.Text = "Home";
            }
        }

        private void lblCitas_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Citas());
        private void lblServicios_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Servicios());
        private void label7_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Admins());
        private void lblAgenda_Click(object sender, EventArgs e) => AbrirFormEnPanel(new Agendas());
        private void lblCerrarSesion_Click(object sender, EventArgs e) => Application.Exit();

        // Eventos del designer (No tocamos nada)
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void panelCitas_Paint(object sender, PaintEventArgs e) { }
        private void panelPorServi_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void panel4_Paint(object sender, PaintEventArgs e) { }
        private void lblTitulo_Click(object sender, EventArgs e) { }
        private void lblUbi_Click(object sender, EventArgs e) { }
        private void lblBernatS_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void lblBernat_Click(object sender, EventArgs e) { }
        private void lblPanel_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void iconoFP_Click(object sender, EventArgs e) { }
        private void lblGestion_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void lblAdmin_Click(object sender, EventArgs e) { }
        private void IconoPerfil_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click_1(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
    }
}