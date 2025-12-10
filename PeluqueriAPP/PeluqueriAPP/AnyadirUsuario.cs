using System;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirUsuario : Form
    {
        public Usuario NuevoUsuario { get; private set; }
        private string tipoUsuario;

        // Constructor para CREAR usuario
        public AnyadirUsuario(string tipo)
        {
            InitializeComponent();
            tipoUsuario = tipo;

            lblTitulo.Text = $"AÑADIR {tipo.ToUpper()}";
            btnAnyadir.Text = $"AÑADIR {tipo.ToUpper()}";

            ConfigurarCampos(tipo);

            btnAnyadir.Click += BtnAnyadir_Click;
        }

        // Nuevo constructor para CREAR usuario genérico sin tipo (por defecto Admin)
        public AnyadirUsuario() : this("Admin") { }

        // Nuevo constructor para EDITAR usuario
        public AnyadirUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            InitializeComponent();

            tipoUsuario = usuario.Rol == "ROLE_CLIENTE" ? "Cliente" :
                          usuario.Rol == "ROLE_ADMIN" ? "Admin" : "Grupo";

            lblTitulo.Text = $"EDITAR {tipoUsuario.ToUpper()}";
            btnAnyadir.Text = $"GUARDAR {tipoUsuario.ToUpper()}";

            ConfigurarCampos(tipoUsuario);

            // Rellenar campos con datos existentes
            tbNombre.Text = usuario.NombreCliente;
            tbEmail.Text = usuario.Email;
            if (tbContrasena.Visible) tbContrasena.Text = usuario.Contrasena;
            if (tbTelefono.Visible) tbTelefono.Text = usuario.Telefono;
            if (tbAlergenos.Visible) tbAlergenos.Text = usuario.Alergenos;
            if (tbObservaciones.Visible) tbObservaciones.Text = usuario.Observaciones;

            // Mantener referencia para enviar a API
            NuevoUsuario = usuario;

            btnAnyadir.Click += BtnAnyadir_Click;
        }

        private void ConfigurarCampos(string tipo)
        {
            // Mostrar todos los campos por defecto
            tbNombre.Visible = lblNombre.Visible = true;
            tbEmail.Visible = lblEmail.Visible = true;
            tbContrasena.Visible = lblContrasena.Visible = true;
            tbTelefono.Visible = lblTelefono.Visible = true;
            tbAlergenos.Visible = lblAlergenos.Visible = true;
            tbObservaciones.Visible = lblObservaciones.Visible = true;

            switch (tipo)
            {
                case "Cliente":
                    // Cliente necesita todo
                    break;

                case "Admin":
                    tbTelefono.Visible = lblTelefono.Visible = false;
                    tbAlergenos.Visible = lblAlergenos.Visible = false;
                    tbObservaciones.Visible = lblObservaciones.Visible = false;
                    break;

                case "Grupo":
                    tbContrasena.Visible = lblContrasena.Visible = false;
                    tbTelefono.Visible = lblTelefono.Visible = false;
                    tbAlergenos.Visible = lblAlergenos.Visible = false;
                    tbObservaciones.Visible = lblObservaciones.Visible = false;
                    break;
            }
        }

        private void BtnAnyadir_Click(object sender, EventArgs e)
        {
            // Validar campos según tipo
            if (string.IsNullOrWhiteSpace(tbNombre.Text) || string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("Nombre y Email son obligatorios.");
                return;
            }

            // Actualizar o crear Usuario
            if (NuevoUsuario == null) NuevoUsuario = new Usuario();

            NuevoUsuario.NombreCliente = tbNombre.Text.Trim();
            NuevoUsuario.Email = tbEmail.Text.Trim();
            NuevoUsuario.Rol = tipoUsuario == "Cliente" ? "ROLE_CLIENTE" :
                               tipoUsuario == "Admin" ? "ROLE_ADMIN" : "ROLE_GRUPO";
            NuevoUsuario.Contrasena = tbContrasena.Visible ? tbContrasena.Text.Trim() : null;
            NuevoUsuario.Telefono = tbTelefono.Visible ? tbTelefono.Text.Trim() : null;
            NuevoUsuario.Alergenos = tbAlergenos.Visible ? tbAlergenos.Text.Trim() : null;
            NuevoUsuario.Observaciones = tbObservaciones.Visible ? tbObservaciones.Text.Trim() : null;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
