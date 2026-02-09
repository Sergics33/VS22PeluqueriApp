using System;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirCliente : Form
    {
        private Usuario _usuarioParaEditar;

        public string Nombre => tbNombre.Text.Trim();
        public string Telefono => tbTelefono.Text.Trim();
        public string Email => tbEmail.Text.Trim();
        public string Password => tbPassword.Text.Trim();

        // Constructor actualizado: acepta un usuario opcional
        public AnyadirCliente(Usuario usuario = null)
        {
            InitializeComponent();
            _usuarioParaEditar = usuario;

            // Suscribimos los eventos
            btnAnyadir.Click += BtnAnyadir_Click;
            btnCancelar.Click += (s, e) => this.Close();

            if (_usuarioParaEditar != null)
            {
                ConfigurarModoEdicion();
            }
        }

        private void ConfigurarModoEdicion()
        {
            this.Text = "Editar Cliente";
            lblTitulo.Text = "EDITAR CLIENTE";
            btnAnyadir.Text = "ACTUALIZAR";

            // Rellenar campos
            tbNombre.Text = _usuarioParaEditar.NombreCompleto;
            tbEmail.Text = _usuarioParaEditar.Email;
            tbTelefono.Text = _usuarioParaEditar.Telefono;
            // La contraseña se deja vacía por seguridad
        }

        private void BtnAnyadir_Click(object sender, EventArgs e)
        {
            // Si estamos editando, la contraseña puede estar vacía
            bool esNuevo = _usuarioParaEditar == null;
            if (string.IsNullOrWhiteSpace(Nombre) || (esNuevo && string.IsNullOrWhiteSpace(Password)))
            {
                MessageBox.Show("El nombre es obligatorio (y la contraseña si es un nuevo registro).", "Validación");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}