using System;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirUsuario : Form
    {
        private string tipoUsuario;

        // Constructor para CREAR usuario genérico (Admin por defecto)
        public AnyadirUsuario() : this("Usuario") { }

        // Constructor para CREAR usuario de tipo específico
        public AnyadirUsuario(string tipo)
        {
            InitializeComponent();
            tipoUsuario = tipo;

            lblTitulo.Text = $"AÑADIR {tipo.ToUpper()}";
            btnAnyadir.Text = $"AÑADIR {tipo.ToUpper()}";

            ConfigurarCampos(tipo);

            btnAnyadir.Click += BtnAnyadir_Click;
        }

        // Constructor para EDITAR usuario existente
        public AnyadirUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            InitializeComponent();

            tipoUsuario = usuario.Rol == "ROLE_CLIENTE" ? "Cliente" :
                          usuario.Rol == "ROLE_ADMIN" ? "Admin" : "Grupo";

            lblTitulo.Text = $"EDITAR {tipoUsuario.ToUpper()}";
            btnAnyadir.Text = $"GUARDAR {tipoUsuario.ToUpper()}";

            ConfigurarCampos(tipoUsuario);

            // Rellenar campos existentes
            tbNombre.Text = usuario.NombreCompleto;
            tbEmail.Text = usuario.Email;
            if (tbContrasena.Visible) tbContrasena.Text = usuario.Contrasena;
            if (tbTelefono.Visible) tbTelefono.Text = usuario.Telefono;
            if (tbAlergenos.Visible) tbAlergenos.Text = usuario.Alergenos;
            if (tbObservaciones.Visible) tbObservaciones.Text = usuario.Observaciones;

            btnAnyadir.Click += BtnAnyadir_Click;
        }

        private void ConfigurarCampos(string tipo)
        {
            // Todos visibles por defecto
            tbNombre.Visible = lblNombre.Visible = true;
            tbEmail.Visible = lblEmail.Visible = true;
            tbContrasena.Visible = lblContrasena.Visible = true;
            tbTelefono.Visible = lblTelefono.Visible = true;
            tbAlergenos.Visible = lblAlergenos.Visible = true;
            tbObservaciones.Visible = lblObservaciones.Visible = true;

            switch (tipo)
            {
                case "Cliente":
                    break; // todo visible
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
            if (string.IsNullOrWhiteSpace(tbNombre.Text) || string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("Nombre y Email son obligatorios.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        // ===========================
        // PROPIEDADES PÚBLICAS PARA Admins.cs
        // ===========================

        public string Nombre => tbNombre.Text.Trim();

        public string Apellidos
        {
            get
            {
                var partes = tbNombre.Text.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                return partes.Length > 1 ? string.Join(' ', partes, 1, partes.Length - 1) : "";
            }
        }

        public string Email => tbEmail.Text.Trim();

        public string Username => tbNombre.Text.Trim(); // puedes cambiar si tienes un TextBox específico

        public string Rol => tipoUsuario == "Cliente" ? "ROLE_CLIENTE" :
                             tipoUsuario == "Admin" ? "ROLE_ADMIN" : "ROLE_GRUPO";

        public string Contrasena => tbContrasena.Visible ? tbContrasena.Text.Trim() : null;

        public string Telefono => tbTelefono.Visible ? tbTelefono.Text.Trim() : null;

        public string Alergenos => tbAlergenos.Visible ? tbAlergenos.Text.Trim() : null;

        public string Observaciones => tbObservaciones.Visible ? tbObservaciones.Text.Trim() : null;
    }
}
