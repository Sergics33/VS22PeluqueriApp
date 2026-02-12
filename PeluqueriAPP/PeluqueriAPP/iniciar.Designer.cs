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
            pnlLateral = new Panel();
            iconoFP = new PictureBox();
            txtUsuario = new TextBox();
            lblUsuario = new Label();
            lblContrasenya = new Label();
            txtContrasenya = new TextBox();
            btnIniciar = new Button();
            lblBienvenida = new Label();
            pnlLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconoFP).BeginInit();
            SuspendLayout();
            // 
            // pnlLateral
            // 
            pnlLateral.Controls.Add(iconoFP);
            pnlLateral.Dock = DockStyle.Left;
            pnlLateral.Location = new Point(0, 0);
            pnlLateral.Name = "pnlLateral";
            pnlLateral.Size = new Size(140, 260);
            pnlLateral.TabIndex = 7;
            // 
            // iconoFP
            // 
            iconoFP.BackColor = Color.Transparent;
            iconoFP.Image = (Image)resources.GetObject("iconoFP.Image");
            iconoFP.Location = new Point(15, 75);
            iconoFP.Name = "iconoFP";
            iconoFP.Size = new Size(110, 110);
            iconoFP.TabIndex = 4;
            iconoFP.TabStop = false;
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.FromArgb(30, 30, 30);
            lblBienvenida.Location = new Point(165, 12);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(184, 37);
            lblBienvenida.TabIndex = 6;
            lblBienvenida.Text = "PeluqueriAPP";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(31, 31, 31); // Color oscuro destacado
            lblUsuario.Location = new Point(165, 62);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(70, 17);
            lblUsuario.TabIndex = 5;
            lblUsuario.Text = "USUARIO:";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.LightGray;
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("Segoe UI", 12F); // Fuente un poco más grande
            txtUsuario.Location = new Point(165, 83);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(215, 29);
            txtUsuario.TabIndex = 0;
            // 
            // lblContrasenya
            // 
            lblContrasenya.AutoSize = true;
            lblContrasenya.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblContrasenya.ForeColor = Color.FromArgb(31, 31, 31); // Color oscuro destacado
            lblContrasenya.Location = new Point(165, 122);
            lblContrasenya.Name = "lblContrasenya";
            lblContrasenya.Size = new Size(100, 17);
            lblContrasenya.TabIndex = 4;
            lblContrasenya.Text = "CONTRASEÑA:";
            // 
            // txtContrasenya
            // 
            txtContrasenya.BackColor = Color.LightGray;
            txtContrasenya.BorderStyle = BorderStyle.None;
            txtContrasenya.Font = new Font("Segoe UI", 12F);
            txtContrasenya.Location = new Point(165, 143);
            txtContrasenya.Name = "txtContrasenya";
            txtContrasenya.PasswordChar = '●';
            txtContrasenya.Size = new Size(215, 29);
            txtContrasenya.TabIndex = 1;
            // 
            // btnIniciar
            // 
            btnIniciar.BackColor = Color.FromArgb(255, 110, 0);
            btnIniciar.Cursor = Cursors.Hand;
            btnIniciar.FlatAppearance.BorderSize = 0;
            btnIniciar.FlatStyle = FlatStyle.Flat;
            btnIniciar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnIniciar.ForeColor = Color.White;
            btnIniciar.Location = new Point(165, 195);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(215, 45);
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
            ClientSize = new Size(410, 265);
            Controls.Add(pnlLateral);
            Controls.Add(lblBienvenida);
            Controls.Add(btnIniciar);
            Controls.Add(txtContrasenya);
            Controls.Add(lblContrasenya);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "iniciar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acceso PeluqueriAPP";
            pnlLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconoFP).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlLateral;
        private PictureBox iconoFP;
        private TextBox txtUsuario;
        private Label lblUsuario;
        private Label lblContrasenya;
        private TextBox txtContrasenya;
        private Button btnIniciar;
        private Label lblBienvenida;
    }
}