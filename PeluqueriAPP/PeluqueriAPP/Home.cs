using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class Home : Form
    {
        // Variable para guardar qué formulario está abierto encima
        private Form formularioActivo = null;

        public Home()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // --- MÉTODO CORREGIDO PARA ABRIR FORMULARIOS ---
        private void AbrirFormEnPanel(Form formularioHijo)
        {
            // 1. Si ya hay un formulario abierto (ej. estamos en Citas y vamos a Servicios), lo cerramos primero
            if (formularioActivo != null)
            {
                formularioActivo.Close();
                panel2.Controls.Remove(formularioActivo); // Lo quitamos visualmente
            }

            // 2. Configuramos el nuevo formulario
            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill; // Que ocupe todo el espacio
            formularioHijo.BackColor = panel2.BackColor; // Que coja el color de fondo

            // 3. ¡OJO! NO usamos Clear(). Añadimos el form y lo traemos al frente.
            panel2.Controls.Add(formularioHijo);
            panel2.Tag = formularioHijo;

            // Esto es la clave: Ponemos el formulario ENCIMA de tus botones originales
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        // --- BOTÓN HOME (VOLVER AL INICIO) ---
        private void lblHome_Click(object sender, EventArgs e)
        {
            // Simplemente cerramos el formulario hijo. 
            // Al desaparecer, se verán tus botones originales que estaban debajo.
            if (formularioActivo != null)
            {
                formularioActivo.Close();
                panel2.Controls.Remove(formularioActivo);
                formularioActivo = null;
            }
        }

        // --- NAVEGACIÓN ---
        private void lblCitas_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Citas());
        }

        private void lblServicios_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Servicios());
        }

        private void label7_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Admins());
        }

        private void lblAgenda_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Agendas());
        }

        private void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // --- EVENTOS DEL DESIGNER (NO BORRAR) ---
        // Déjalos tal cual para que no falle el diseñador
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