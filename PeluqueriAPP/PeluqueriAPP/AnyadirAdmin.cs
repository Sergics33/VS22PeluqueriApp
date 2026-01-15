using System;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirAdmin : Form
    {
        public AnyadirAdmin()
        {
            InitializeComponent();

            lblTitulo.Text = "AÑADIR ADMIN";
            btnAnyadir.Text = "AÑADIR ADMIN";

            btnAnyadir.Click += BtnAnyadir_Click;
        }

        private void BtnAnyadir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Nombre) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Contrasena) ||
                string.IsNullOrWhiteSpace(Especialidad))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        // ===========================
        // Propiedades públicas para Admins.cs
        // ===========================
        public string Nombre => tbNombre.Text.Trim();
        public string Email => tbEmail.Text.Trim();
        public string Contrasena => tbPassword.Text.Trim();
        public string Especialidad => tbEspecialidad.Text.Trim();
    }
}
