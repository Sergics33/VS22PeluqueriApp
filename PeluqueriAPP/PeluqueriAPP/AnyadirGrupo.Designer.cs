namespace PeluqueriAPP
{
    partial class AnyadirGrupo
    {
        private System.ComponentModel.IContainer components = null;
        private Label lbltitulo;
        private Label lblNombre, lblEmail, lblPassword, lblClase;
        private TextBox tbNombre, tbEmail, tbPassword, tbClase;
        private Button btnAnyadir, btnCancelar;
        private Panel panelContenedor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lbltitulo = new Label();
            panelContenedor = new Panel();
            lblNombre = new Label();
            tbNombre = new TextBox();
            lblEmail = new Label();
            tbEmail = new TextBox();
            lblPassword = new Label();
            tbPassword = new TextBox();
            lblClase = new Label();
            tbClase = new TextBox();
            btnAnyadir = new Button();
            btnCancelar = new Button();
            panelContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // lbltitulo
            // 
            lbltitulo.BackColor = Color.Transparent;
            lbltitulo.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            lbltitulo.ForeColor = Color.White;
            lbltitulo.Location = new Point(0, 5);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new Size(580, 75);
            lbltitulo.TabIndex = 0;
            lbltitulo.Text = "Nuevo Grupo";
            lbltitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.FromArgb(180, 240, 240, 240);
            panelContenedor.Controls.Add(lblNombre);
            panelContenedor.Controls.Add(tbNombre);
            panelContenedor.Controls.Add(lblPassword);
            panelContenedor.Controls.Add(tbPassword);
            panelContenedor.Controls.Add(lblEmail);
            panelContenedor.Controls.Add(tbEmail);
            panelContenedor.Controls.Add(lblClase);
            panelContenedor.Controls.Add(tbClase);
            panelContenedor.Location = new Point(30, 85);
            panelContenedor.Size = new Size(520, 310);
            panelContenedor.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Bold", 9.5F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(50, 50, 50);
            lblNombre.Location = new Point(20, 20);
            lblNombre.Text = "NOMBRE DEL GRUPO:";
            // 
            // tbNombre
            // 
            tbNombre.BorderStyle = BorderStyle.None;
            tbNombre.Font = new Font("Segoe UI", 12F);
            tbNombre.Location = new Point(20, 45);
            tbNombre.Size = new Size(230, 30);
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI Bold", 9.5F, FontStyle.Bold);
            lblPassword.Location = new Point(270, 20);
            lblPassword.Text = "CONTRASEÑA ACCESO:";
            // 
            // tbPassword
            // 
            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.Font = new Font("Segoe UI", 12F);
            tbPassword.Location = new Point(270, 45);
            tbPassword.PasswordChar = '●';
            tbPassword.Size = new Size(230, 30);
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Bold", 9.5F, FontStyle.Bold);
            lblEmail.Location = new Point(20, 100);
            lblEmail.Text = "EMAIL DE CONTACTO:";
            // 
            // tbEmail
            // 
            tbEmail.BorderStyle = BorderStyle.None;
            tbEmail.Font = new Font("Segoe UI", 12F);
            tbEmail.Location = new Point(20, 125);
            tbEmail.Size = new Size(480, 30);
            // 
            // lblClase
            // 
            lblClase.AutoSize = true;
            lblClase.Font = new Font("Segoe UI Bold", 9.5F, FontStyle.Bold);
            lblClase.Location = new Point(20, 180);
            lblClase.Text = "CATEGORÍA / CLASE:";
            // 
            // tbClase
            // 
            tbClase.BorderStyle = BorderStyle.None;
            tbClase.Font = new Font("Segoe UI", 12F);
            tbClase.Location = new Point(20, 205);
            tbClase.Size = new Size(480, 30);
            // 
            // btnAnyadir
            // 
            btnAnyadir.BackColor = Color.SeaGreen;
            btnAnyadir.FlatAppearance.BorderSize = 0;
            btnAnyadir.FlatStyle = FlatStyle.Flat;
            btnAnyadir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAnyadir.ForeColor = Color.White;
            btnAnyadir.Location = new Point(100, 420);
            btnAnyadir.Size = new Size(180, 45);
            btnAnyadir.Text = "GUARDAR";
            btnAnyadir.UseVisualStyleBackColor = false;
            btnAnyadir.Click += BtnAnyadir_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Crimson;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(300, 420);
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += (s, e) => this.Close();
            // 
            // AnyadirGrupo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 500);
            Controls.Add(btnCancelar);
            Controls.Add(btnAnyadir);
            Controls.Add(panelContenedor);
            Controls.Add(lbltitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AnyadirGrupo";
            StartPosition = FormStartPosition.CenterParent;
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
        }
    }
}