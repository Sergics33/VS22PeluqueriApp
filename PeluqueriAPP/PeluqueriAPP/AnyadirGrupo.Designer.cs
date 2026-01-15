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
            lbltitulo.AutoSize = true;
            lbltitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lbltitulo.Location = new Point(45, 20);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new Size(0, 37);
            lbltitulo.TabIndex = 0;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(45, 80);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // tbNombre
            // 
            tbNombre.Location = new Point(150, 80);
            tbNombre.Name = "tbNombre";
            tbNombre.Size = new Size(100, 23);
            tbNombre.TabIndex = 2;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(45, 120);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(150, 120);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(100, 23);
            tbEmail.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(45, 160);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(150, 160);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(100, 23);
            tbPassword.TabIndex = 6;
            // 
            // lblClase
            // 
            lblClase.AutoSize = true;
            lblClase.Location = new Point(45, 200);
            lblClase.Name = "lblClase";
            lblClase.Size = new Size(38, 15);
            lblClase.TabIndex = 7;
            lblClase.Text = "Clase:";
            // 
            // tbClase
            // 
            tbClase.Location = new Point(150, 200);
            tbClase.Name = "tbClase";
            tbClase.Size = new Size(100, 23);
            tbClase.TabIndex = 8;
            tbClase.TextChanged += tbClase_TextChanged;
            // 
            // btnAnyadir
            // 
            btnAnyadir.Location = new Point(150, 240);
            btnAnyadir.Name = "btnAnyadir";
            btnAnyadir.Size = new Size(150, 30);
            btnAnyadir.TabIndex = 9;
            btnAnyadir.Text = "AÑADIR GRUPO";
            // 
            // AnyadirGrupo
            // 
            ClientSize = new Size(360, 300);
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
            Name = "AnyadirGrupo";
            Text = "Añadir Grupo";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
