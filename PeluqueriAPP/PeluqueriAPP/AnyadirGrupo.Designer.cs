using System.Windows.Forms;

namespace PeluqueriAPP
{
    partial class AnyadirGrupo
    {
        private Label lbltitulo;
        private Label lblNombre;
        private TextBox tbNombre;
        private Label lblEmail;
        private TextBox tbEmail;
        private Label lblPassword;
        private TextBox tbPassword;
        private Label lblClase;
        private TextBox tbClase;
        private Button btnAnyadir;

        private void InitializeComponent()
        {
            lbltitulo = new Label();
            lblNombre = new Label();
            tbNombre = new TextBox();
            lblEmail = new Label();
            tbEmail = new TextBox();
            lblPassword = new Label();
            tbPassword = new TextBox();
            lblClase = new Label();
            tbClase = new TextBox();
            btnAnyadir = new Button();
            SuspendLayout();
            // 
            // lbltitulo
            // 
            lbltitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lbltitulo.ForeColor = Color.ForestGreen;
            lbltitulo.Location = new Point(0, 20);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new Size(380, 45);
            lbltitulo.TabIndex = 0;
            lbltitulo.Text = "AÑADIR GRUPO/CLASE";
            lbltitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold); // Estilo Semibold
            lblNombre.ForeColor = Color.FromArgb(64, 64, 64); // Gris oscuro profesional
            lblNombre.Location = new Point(35, 90);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(63, 19);
            lblNombre.Text = "Nombre:";
            // 
            // tbNombre
            // 
            tbNombre.Font = new Font("Segoe UI", 10F);
            tbNombre.Location = new Point(140, 87);
            tbNombre.Name = "tbNombre";
            tbNombre.Size = new Size(200, 25);
            tbNombre.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(64, 64, 64);
            lblEmail.Location = new Point(35, 130);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 19);
            lblEmail.Text = "Email:";
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 10F);
            tbEmail.Location = new Point(140, 127);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(200, 25);
            tbEmail.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(64, 64, 64);
            lblPassword.Location = new Point(35, 170);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(71, 19);
            lblPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 10F);
            tbPassword.Location = new Point(140, 167);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(200, 25);
            tbPassword.TabIndex = 4;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // lblClase
            // 
            lblClase.AutoSize = true;
            lblClase.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblClase.ForeColor = Color.FromArgb(64, 64, 64);
            lblClase.Location = new Point(35, 210);
            lblClase.Name = "lblClase";
            lblClase.Size = new Size(45, 19);
            lblClase.Text = "Clase:";
            // 
            // tbClase
            // 
            tbClase.Font = new Font("Segoe UI", 10F);
            tbClase.Location = new Point(140, 207);
            tbClase.Name = "tbClase";
            tbClase.Size = new Size(200, 25);
            tbClase.TabIndex = 6;
            // 
            // btnAnyadir
            // 
            btnAnyadir.BackColor = Color.FromArgb(255, 192, 128);
            btnAnyadir.FlatAppearance.BorderSize = 0;
            btnAnyadir.FlatStyle = FlatStyle.Flat;
            btnAnyadir.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnAnyadir.ForeColor = Color.White;
            btnAnyadir.Location = new Point(35, 260);
            btnAnyadir.Name = "btnAnyadir";
            btnAnyadir.Size = new Size(305, 45);
            btnAnyadir.TabIndex = 7;
            btnAnyadir.Text = "AÑADIR GRUPO/CLASE";
            btnAnyadir.UseVisualStyleBackColor = false;
            // 
            // AnyadirGrupo
            // 
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(380, 340);
            Controls.Add(lbltitulo);
            Controls.Add(lblNombre);
            Controls.Add(tbNombre);
            Controls.Add(lblEmail);
            Controls.Add(tbEmail);
            Controls.Add(lblPassword);
            Controls.Add(tbPassword);
            Controls.Add(lblClase);
            Controls.Add(tbClase);
            Controls.Add(btnAnyadir);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AnyadirGrupo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Añadir Grupo";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}