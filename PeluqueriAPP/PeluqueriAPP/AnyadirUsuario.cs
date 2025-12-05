using System;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class AnyadirUsuario : Form
    {
        public Usuario NuevoUsuario { get; private set; }
        private string tipoUsuario;

        public AnyadirUsuario(string tipo)
        {
            InitializeComponent();
            tipoUsuario = tipo;

            lblTitulo.Text = $"AÑADIR {tipo.ToUpper()}";
            btnAnyadir.Text = $"AÑADIR {tipo.ToUpper()}";

            ConfigurarCampos(tipo);

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

            NuevoUsuario = new Usuario
            {
                NombreCompleto = tbNombre.Text.Trim(),
                Email = tbEmail.Text.Trim(),
                Role = tipoUsuario == "Cliente" ? "ROLE_CLIENTE" :
                       tipoUsuario == "Admin" ? "ROLE_ADMIN" : "ROLE_GRUPO",
                Contrasena = tbContrasena.Visible ? tbContrasena.Text.Trim() : null,
                Telefono = tbTelefono.Visible ? tbTelefono.Text.Trim() : null,
                Alergenos = tbAlergenos.Visible ? tbAlergenos.Text.Trim() : null,
                Observaciones = tbObservaciones.Visible ? tbObservaciones.Text.Trim() : null
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
