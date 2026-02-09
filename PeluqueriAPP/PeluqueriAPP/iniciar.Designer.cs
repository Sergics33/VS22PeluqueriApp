namespace PeluqueriAPP
{
    partial class iniciar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iniciar));
            iconoFP = new PictureBox();
            txtUsuario = new TextBox();
            lblUsuario = new Label();
            lblContrasenya = new Label();
            txtContrasenya = new TextBox();
            btnIniciar = new Button();
            lblBienvenida = new Label();
            ((System.ComponentModel.ISupportInitialize)iconoFP).BeginInit();
            SuspendLayout();
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.FromArgb(60, 60, 60); // Gris muy oscuro sutil
            lblBienvenida.Location = new Point(40, 18);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(166, 32);
            lblBienvenida.Text = "Bienvenido a Bernat Sarrià";
            // 
            // iconoFP
            // 
            iconoFP.Image = (Image)resources.GetObject("iconoFP.Image");
            iconoFP.Location = new Point(30, 70);
            iconoFP.Name = "iconoFP";
            iconoFP.Size = new Size(100, 100);
            iconoFP.SizeMode = PictureBoxSizeMode.Zoom;
            iconoFP.TabIndex = 4;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(120, 120, 120); // Gris sutil
            lblUsuario.Location = new Point(155, 65);
            lblUsuario.Text = "EMAIL O USUARIO";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(242, 242, 242);
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("Segoe UI", 11F);
            txtUsuario.Location = new Point(155, 85);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(185, 20);
            txtUsuario.TabIndex = 0;
            // 
            // lblContrasenya
            // 
            lblContrasenya.AutoSize = true;
            lblContrasenya.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblContrasenya.ForeColor = Color.FromArgb(120, 120, 120); // Gris sutil
            lblContrasenya.Location = new Point(155, 120);
            lblContrasenya.Text = "CONTRASEÑA";
            // 
            // txtContrasenya
            // 
            txtContrasenya.BackColor = Color.FromArgb(242, 242, 242);
            txtContrasenya.BorderStyle = BorderStyle.None;
            txtContrasenya.Font = new Font("Segoe UI", 11F);
            txtContrasenya.Location = new Point(155, 140);
            txtContrasenya.Name = "txtContrasenya";
            txtContrasenya.Size = new Size(185, 20);
            txtContrasenya.TabIndex = 1;
            txtContrasenya.UseSystemPasswordChar = true;
            // 
            // btnIniciar
            // 
            btnIniciar.BackColor = Color.FromArgb(45, 45, 48); // Antracita elegante
            btnIniciar.Cursor = Cursors.Hand;
            btnIniciar.FlatAppearance.BorderSize = 0;
            btnIniciar.FlatStyle = FlatStyle.Flat;
            btnIniciar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIniciar.ForeColor = Color.White;
            btnIniciar.Location = new Point(155, 185);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(185, 45);
            btnIniciar.TabIndex = 2;
            btnIniciar.Text = "INICIAR SESIÓN";
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // iniciar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(380, 260);
            Controls.Add(lblBienvenida);
            Controls.Add(btnIniciar);
            Controls.Add(txtContrasenya);
            Controls.Add(lblContrasenya);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(iconoFP);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "iniciar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)iconoFP).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox iconoFP;
        private TextBox txtUsuario;
        private Label lblUsuario;
        private Label lblContrasenya;
        private TextBox txtContrasenya;
        private Button btnIniciar;
        private Label lblBienvenida;
    }
}