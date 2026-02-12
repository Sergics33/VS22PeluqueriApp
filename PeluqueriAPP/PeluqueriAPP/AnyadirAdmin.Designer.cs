namespace PeluqueriAPP
{
    partial class AnyadirAdmin
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Label lblNombre, lblEmail, lblPassword, lblEspecialidad;
        private TextBox tbNombre, tbEmail, tbPassword, tbEspecialidad;
        private Button btnAnyadir, btnCancelar;
        private Panel panelContenedor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

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
            btnCancelar = new Button();
            panelContenedor = new Panel();
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
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Nuevo Administrador";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(50, 50, 50);
            lblNombre.Location = new Point(25, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Text = "NOMBRE COMPLETO:";
            // 
            // tbNombre
            // 
            tbNombre.BorderStyle = BorderStyle.None;
            tbNombre.Font = new Font("Segoe UI", 11F);
            tbNombre.Location = new Point(25, 45); // Esta pos cambiará dinámicamente
            tbNombre.Name = "tbNombre";
            tbNombre.Size = new Size(220, 20);
            tbNombre.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(50, 50, 50);
            lblEmail.Location = new Point(25, 90);
            lblEmail.Name = "lblEmail";
            lblEmail.Text = "CORREO ELECTRÓNICO:";
            // 
            // tbEmail
            // 
            tbEmail.BorderStyle = BorderStyle.None;
            tbEmail.Font = new Font("Segoe UI", 11F);
            tbEmail.Location = new Point(25, 115);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(220, 20);
            tbEmail.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(50, 50, 50);
            lblPassword.Location = new Point(275, 20);
            lblPassword.Name = "lblPassword";
            lblPassword.Text = "CONTRASEÑA:";
            // 
            // tbPassword
            // 
            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.Font = new Font("Segoe UI", 11F);
            tbPassword.Location = new Point(275, 45);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '●';
            tbPassword.Size = new Size(220, 20);
            tbPassword.TabIndex = 3;
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.BackColor = Color.Transparent;
            lblEspecialidad.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEspecialidad.ForeColor = Color.FromArgb(50, 50, 50);
            lblEspecialidad.Location = new Point(275, 90);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Text = "ESPECIALIDAD:";
            // 
            // tbEspecialidad
            // 
            tbEspecialidad.BorderStyle = BorderStyle.None;
            tbEspecialidad.Font = new Font("Segoe UI", 11F);
            tbEspecialidad.Location = new Point(275, 115);
            tbEspecialidad.Name = "tbEspecialidad";
            tbEspecialidad.Size = new Size(220, 20);
            tbEspecialidad.TabIndex = 4;
            // 
            // btnAnyadir
            // 
            btnAnyadir.BackColor = Color.SeaGreen;
            btnAnyadir.Cursor = Cursors.Hand;
            btnAnyadir.FlatAppearance.BorderSize = 0;
            btnAnyadir.FlatStyle = FlatStyle.Flat;
            btnAnyadir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAnyadir.ForeColor = Color.White;
            btnAnyadir.Location = new Point(100, 275);
            btnAnyadir.Name = "btnAnyadir";
            btnAnyadir.Size = new Size(180, 45);
            btnAnyadir.TabIndex = 5;
            btnAnyadir.Text = "AÑADIR ADMIN";
            btnAnyadir.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Crimson;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(300, 275);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.FromArgb(180, 240, 240, 240);
            panelContenedor.Controls.Add(lblNombre);
            panelContenedor.Controls.Add(lblEmail);
            panelContenedor.Controls.Add(lblPassword);
            panelContenedor.Controls.Add(lblEspecialidad);
            panelContenedor.Location = new Point(30, 85);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(520, 175);
            panelContenedor.TabIndex = 0;
            // 
            // AnyadirAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 350);
            Controls.Add(panelContenedor);
            Controls.Add(lblTitulo);
            Controls.Add(btnCancelar);
            Controls.Add(btnAnyadir);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AnyadirAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Personal";
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
        }
    }
}