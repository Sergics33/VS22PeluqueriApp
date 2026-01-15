using System.Windows.Forms;

namespace PeluqueriAPP
{
    partial class AnyadirAdmin
    {
        private Label lblTitulo;
        private Label lblNombre, lblEmail, lblPassword, lblEspecialidad;
        private TextBox tbNombre, tbEmail, tbPassword, tbEspecialidad;
        private Button btnAnyadir;

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblNombre = new Label();
            tbNombre = new TextBox();
            lblEmail = new Label();
            tbEmail = new TextBox();
            lblPassword = new Label();
            tbPassword = new TextBox();
            lblEspecialidad = new Label();
            tbEspecialidad = new TextBox();
            btnAnyadir = new Button();

            SuspendLayout();

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(100, 20);
            lblTitulo.Size = new System.Drawing.Size(200, 32);
            lblTitulo.Text = "AÑADIR ADMIN";

            // lblNombre
            lblNombre.AutoSize = true;
            lblNombre.Location = new System.Drawing.Point(30, 70);
            lblNombre.Text = "Nombre:";
            tbNombre.Location = new System.Drawing.Point(150, 70);
            tbNombre.Width = 200;

            // lblEmail
            lblEmail.AutoSize = true;
            lblEmail.Location = new System.Drawing.Point(30, 110);
            lblEmail.Text = "Email:";
            tbEmail.Location = new System.Drawing.Point(150, 110);
            tbEmail.Width = 200;

            // lblPassword
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(30, 150);
            lblPassword.Text = "Contraseña:";
            tbPassword.Location = new System.Drawing.Point(150, 150);
            tbPassword.Width = 200;
            tbPassword.PasswordChar = '*';

            // lblEspecialidad
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Location = new System.Drawing.Point(30, 190);
            lblEspecialidad.Text = "Especialidad:";
            tbEspecialidad.Location = new System.Drawing.Point(150, 190);
            tbEspecialidad.Width = 200;

            // btnAnyadir
            btnAnyadir.Location = new System.Drawing.Point(150, 240);
            btnAnyadir.Size = new System.Drawing.Size(200, 30);
            btnAnyadir.Text = "AÑADIR ADMIN";

            // AnyadirAdmin Form
            ClientSize = new System.Drawing.Size(400, 300);
            Controls.Add(lblTitulo);
            Controls.Add(lblNombre);
            Controls.Add(tbNombre);
            Controls.Add(lblEmail);
            Controls.Add(tbEmail);
            Controls.Add(lblPassword);
            Controls.Add(tbPassword);
            Controls.Add(lblEspecialidad);
            Controls.Add(tbEspecialidad);
            Controls.Add(btnAnyadir);
            Text = "Añadir Admin";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
