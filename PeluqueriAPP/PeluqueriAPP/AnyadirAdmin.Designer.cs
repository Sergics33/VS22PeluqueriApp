using System.Windows.Forms;
using System.Drawing;

namespace PeluqueriAPP
{
    partial class AnyadirAdmin
    {
        private System.ComponentModel.IContainer components = null;
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

            // Estilos comunes
            Font fuenteLabels = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            Font fuenteInputs = new Font("Segoe UI", 10F);
            Color colorTexto = Color.FromArgb(64, 64, 64);

            // lblTitulo
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 156, 219);
            lblTitulo.Location = new Point(0, 20);
            lblTitulo.Size = new Size(400, 35);
            lblTitulo.Text = "Nuevo Administrador";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // lblNombre
            lblNombre.AutoSize = true;
            lblNombre.Font = fuenteLabels;
            lblNombre.ForeColor = colorTexto;
            lblNombre.Location = new Point(45, 75);
            lblNombre.Text = "Nombre completo:";

            // tbNombre
            tbNombre.Font = fuenteInputs;
            tbNombre.Location = new Point(45, 95);
            tbNombre.Size = new Size(310, 25);

            // lblEmail
            lblEmail.AutoSize = true;
            lblEmail.Font = fuenteLabels;
            lblEmail.ForeColor = colorTexto;
            lblEmail.Location = new Point(45, 130);
            lblEmail.Text = "Correo electrónico:";

            // tbEmail
            tbEmail.Font = fuenteInputs;
            tbEmail.Location = new Point(45, 150);
            tbEmail.Size = new Size(310, 25);

            // lblPassword
            lblPassword.AutoSize = true;
            lblPassword.Font = fuenteLabels;
            lblPassword.ForeColor = colorTexto;
            lblPassword.Location = new Point(45, 185);
            lblPassword.Text = "Contraseña:";

            // tbPassword
            tbPassword.Font = fuenteInputs;
            tbPassword.Location = new Point(45, 205);
            tbPassword.Size = new Size(310, 25);
            tbPassword.PasswordChar = '●'; // Carácter más elegante que '*'

            // lblEspecialidad
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Font = fuenteLabels;
            lblEspecialidad.ForeColor = colorTexto;
            lblEspecialidad.Location = new Point(45, 240);
            lblEspecialidad.Text = "Especialidad (opcional):";

            // tbEspecialidad
            tbEspecialidad.Font = fuenteInputs;
            tbEspecialidad.Location = new Point(45, 260);
            tbEspecialidad.Size = new Size(310, 25);

            // btnAnyadir
            btnAnyadir.BackColor = Color.FromArgb(45, 156, 219);
            btnAnyadir.Cursor = Cursors.Hand;
            btnAnyadir.FlatAppearance.BorderSize = 0;
            btnAnyadir.FlatStyle = FlatStyle.Flat;
            btnAnyadir.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnAnyadir.ForeColor = Color.White;
            btnAnyadir.Location = new Point(45, 315);
            btnAnyadir.Size = new Size(310, 45);
            btnAnyadir.Text = "Registrar Administrador";
            btnAnyadir.UseVisualStyleBackColor = false;

            // AnyadirAdmin Form
            ClientSize = new Size(400, 400);
            BackColor = Color.White;
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

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AnyadirAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Personal";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}