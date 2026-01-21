namespace PeluqueriAPP
{
    partial class iniciar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iniciar));
            iconoFP = new PictureBox();
            txtUsuario = new TextBox();
            lblUsuario = new Label();
            lblContrasenya = new Label();
            txtContrasenya = new TextBox();
            btnIniciar = new Button();
            ((System.ComponentModel.ISupportInitialize)iconoFP).BeginInit();
            SuspendLayout();
            // 
            // iconoFP
            // 
            iconoFP.Image = (Image)resources.GetObject("iconoFP.Image");
            iconoFP.Location = new Point(12, 45);
            iconoFP.Name = "iconoFP";
            iconoFP.Size = new Size(116, 119);
            iconoFP.SizeMode = PictureBoxSizeMode.Zoom;
            iconoFP.TabIndex = 4;
            iconoFP.TabStop = false;
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.White;
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 10F);
            txtUsuario.Location = new Point(152, 65);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(160, 25);
            txtUsuario.TabIndex = 0;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.FromArgb(64, 64, 64);
            lblUsuario.Location = new Point(152, 45);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(57, 17);
            lblUsuario.TabIndex = 6;
            lblUsuario.Text = "Usuario:";
            // 
            // lblContrasenya
            // 
            lblContrasenya.AutoSize = true;
            lblContrasenya.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblContrasenya.ForeColor = Color.FromArgb(64, 64, 64);
            lblContrasenya.Location = new Point(152, 105);
            lblContrasenya.Name = "lblContrasenya";
            lblContrasenya.Size = new Size(80, 17);
            lblContrasenya.TabIndex = 7;
            lblContrasenya.Text = "Contraseña:";
            // 
            // txtContrasenya
            // 
            txtContrasenya.BackColor = Color.White;
            txtContrasenya.BorderStyle = BorderStyle.FixedSingle;
            txtContrasenya.Font = new Font("Segoe UI", 10F);
            txtContrasenya.Location = new Point(152, 125);
            txtContrasenya.Name = "txtContrasenya";
            txtContrasenya.Size = new Size(160, 25);
            txtContrasenya.TabIndex = 1;
            txtContrasenya.UseSystemPasswordChar = true;
            // 
            // btnIniciar
            // 
            btnIniciar.BackColor = Color.FromArgb(45, 45, 48);
            btnIniciar.Cursor = Cursors.Hand;
            btnIniciar.FlatAppearance.BorderSize = 0;
            btnIniciar.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            btnIniciar.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 63, 65);
            btnIniciar.FlatStyle = FlatStyle.Flat;
            btnIniciar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnIniciar.ForeColor = Color.White;
            btnIniciar.Location = new Point(152, 170);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(160, 35);
            btnIniciar.TabIndex = 2;
            btnIniciar.Text = "Iniciar Sesión";
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // iniciar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240); // Fondo grisáceo claro
            ClientSize = new Size(343, 235);
            Controls.Add(btnIniciar);
            Controls.Add(txtContrasenya);
            Controls.Add(lblContrasenya);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(iconoFP);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "iniciar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PeluqueriAPP - Acceso";
            ((System.ComponentModel.ISupportInitialize)iconoFP).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox iconoFP;
        private TextBox txtUsuario;
        private Label lblUsuario;
        private Label lblContrasenya;
        private TextBox txtContrasenya;
        private Button btnIniciar;
    }
}