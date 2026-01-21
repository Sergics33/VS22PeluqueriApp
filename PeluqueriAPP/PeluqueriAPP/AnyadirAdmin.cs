using System;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirAdmin : Form
    {
        // Variable para saber si estamos editando
        private bool esEdicion = false;

        // Constructor normal (Añadir)
        public AnyadirAdmin()
        {
            InitializeComponent();
            ConfigurarEstilo(null);
        }

        // Constructor para Editar (recibe el objeto Usuario)
        public AnyadirAdmin(Usuario usuario)
        {
            InitializeComponent();
            esEdicion = true;
            ConfigurarEstilo(usuario);
        }

        private void ConfigurarEstilo(Usuario usuario)
        {
            if (esEdicion && usuario != null)
            {
                lblTitulo.Text = "EDITAR ADMINISTRADOR";
                btnAnyadir.Text = "GUARDAR CAMBIOS";

                // Rellenar campos con datos existentes
                tbNombre.Text = usuario.NombreCompleto;
                tbEmail.Text = usuario.Email;
                tbEspecialidad.Text = usuario.Especialidad;

                // En edición, avisamos que la pass es opcional
                tbPassword.PlaceholderText = "Dejar en blanco para no cambiar";
            }
            else
            {
                lblTitulo.Text = "AÑADIR ADMIN";
                btnAnyadir.Text = "AÑADIR ADMIN";
            }

            btnAnyadir.Click += BtnAnyadir_Click;
        }

        private void BtnAnyadir_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("El nombre y el email son obligatorios.");
                return;
            }

            // Si es nuevo (no edición), la contraseña es obligatoria
            if (!esEdicion && string.IsNullOrWhiteSpace(Contrasena))
            {
                MessageBox.Show("Debes asignar una contraseña al nuevo administrador.");
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