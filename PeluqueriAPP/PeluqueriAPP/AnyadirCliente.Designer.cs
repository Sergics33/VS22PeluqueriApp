namespace PeluqueriAPP
{
    partial class AnyadirCliente
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre, lblTelefono, lblEmail, lblPassword;
        private System.Windows.Forms.TextBox tbNombre, tbTelefono, tbEmail, tbPassword;
        private System.Windows.Forms.Button btnAnyadir, btnCancelar;
        private System.Windows.Forms.Panel panelContenedor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            panelContenedor = new Panel();
            lblNombre = new Label();
            tbNombre = new TextBox();
            lblTelefono = new Label();
            tbTelefono = new TextBox();
            lblEmail = new Label();
            tbEmail = new TextBox();
            lblPassword = new Label();
            tbPassword = new TextBox();
            btnAnyadir = new Button();
            btnCancelar = new Button();
            panelContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 5);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(580, 75);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Añadir Nuevo Cliente";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.FromArgb(180, 240, 240, 240);
            panelContenedor.Controls.Add(lblNombre);
            panelContenedor.Controls.Add(tbNombre);
            panelContenedor.Controls.Add(lblTelefono);
            panelContenedor.Controls.Add(tbTelefono);
            panelContenedor.Controls.Add(lblEmail);
            panelContenedor.Controls.Add(tbEmail);
            panelContenedor.Controls.Add(lblPassword);
            panelContenedor.Controls.Add(tbPassword);
            panelContenedor.Location = new Point(30, 85);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(520, 310);
            panelContenedor.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Font = new Font("Segoe UI Bold", 9.5F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(50, 50, 50);
            lblNombre.Location = new Point(20, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(137, 17);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "NOMBRE COMPLETO:";
            // 
            // tbNombre
            // 
            tbNombre.BorderStyle = BorderStyle.None;
            tbNombre.Font = new Font("Segoe UI", 12F);
            tbNombre.Location = new Point(20, 45);
            tbNombre.Multiline = false;
            tbNombre.Name = "tbNombre";
            tbNombre.Size = new Size(480, 30);
            tbNombre.TabIndex = 1;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.BackColor = Color.Transparent;
            lblTelefono.Font = new Font("Segoe UI Bold", 9.5F, FontStyle.Bold);
            lblTelefono.Location = new Point(20, 95);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(76, 17);
            lblTelefono.TabIndex = 2;
            lblTelefono.Text = "TELÉFONO:";
            // 
            // tbTelefono
            // 
            tbTelefono.BorderStyle = BorderStyle.None;
            tbTelefono.Font = new Font("Segoe UI", 12F);
            tbTelefono.Location = new Point(20, 120);
            tbTelefono.Name = "tbTelefono";
            tbTelefono.Size = new Size(220, 30);
            tbTelefono.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI Bold", 9.5F, FontStyle.Bold);
            lblEmail.Location = new Point(280, 95);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 17);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "EMAIL:";
            // 
            // tbEmail
            // 
            tbEmail.BorderStyle = BorderStyle.None;
            tbEmail.Font = new Font("Segoe UI", 12F);
            tbEmail.Location = new Point(280, 120);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(220, 30);
            tbEmail.TabIndex = 5;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI Bold", 9.5F, FontStyle.Bold);
            lblPassword.Location = new Point(20, 170);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(98, 17);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "CONTRASEÑA:";
            // 
            // tbPassword
            // 
            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.Font = new Font("Segoe UI", 12F);
            tbPassword.Location = new Point(20, 195);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '●';
            tbPassword.Size = new Size(480, 30);
            tbPassword.TabIndex = 7;
            // 
            // btnAnyadir
            // 
            btnAnyadir.BackColor = Color.SeaGreen;
            btnAnyadir.FlatAppearance.BorderSize = 0;
            btnAnyadir.FlatStyle = FlatStyle.Flat;
            btnAnyadir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAnyadir.ForeColor = Color.White;
            btnAnyadir.Location = new Point(100, 420);
            btnAnyadir.Name = "btnAnyadir";
            btnAnyadir.Size = new Size(180, 45);
            btnAnyadir.TabIndex = 2;
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
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // AnyadirCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 500);
            Controls.Add(btnCancelar);
            Controls.Add(btnAnyadir);
            Controls.Add(panelContenedor);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AnyadirCliente";
            StartPosition = FormStartPosition.CenterParent;
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
        }
    }
}