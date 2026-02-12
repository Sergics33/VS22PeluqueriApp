namespace PeluqueriAPP
{
    partial class AnyadirGrupo
    {
        private System.ComponentModel.IContainer components = null;
        private Label lbltitulo;
        private Label lblNombre, lblEmail, lblPassword, lblClase;
        private TextBox tbNombre, tbEmail, tbPassword, tbClase;
        private Button btnAnyadir, btnCancelar;
        private Panel panelContenedor; // Cambiado de panelSeparador a panelContenedor

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

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
            btnCancelar = new Button();
            panelContenedor = new Panel();
            panelContenedor.SuspendLayout();
            SuspendLayout();

            // lbltitulo
            lbltitulo.BackColor = Color.Transparent;
            lbltitulo.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            lbltitulo.ForeColor = Color.White;
            lbltitulo.Location = new Point(0, 5);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new Size(580, 75);
            lbltitulo.Text = "Nuevo Grupo / Clase";
            lbltitulo.TextAlign = ContentAlignment.MiddleCenter;

            // lblNombre
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(50, 50, 50);
            lblNombre.Location = new Point(25, 20);
            lblNombre.Text = "NOMBRE DEL GRUPO:";

            // tbNombre (Se moverá a la cápsula)
            tbNombre.BorderStyle = BorderStyle.None;
            tbNombre.Font = new Font("Segoe UI", 11F);

            // lblEmail
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(50, 50, 50);
            lblEmail.Location = new Point(25, 90);
            lblEmail.Text = "EMAIL DE CONTACTO:";

            // tbEmail (Se moverá a la cápsula)
            tbEmail.BorderStyle = BorderStyle.None;
            tbEmail.Font = new Font("Segoe UI", 11F);

            // lblPassword
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(50, 50, 50);
            lblPassword.Location = new Point(275, 20);
            lblPassword.Text = "CONTRASEÑA ACCESO:";

            // tbPassword (Se moverá a la cápsula)
            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.Font = new Font("Segoe UI", 11F);
            tbPassword.PasswordChar = '●';

            // lblClase
            lblClase.AutoSize = true;
            lblClase.BackColor = Color.Transparent;
            lblClase.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblClase.ForeColor = Color.FromArgb(50, 50, 50);
            lblClase.Location = new Point(275, 90);
            lblClase.Text = "CATEGORÍA / CLASE:";

            // tbClase (Se moverá a la cápsula)
            tbClase.BorderStyle = BorderStyle.None;
            tbClase.Font = new Font("Segoe UI", 11F);

            // btnAnyadir
            btnAnyadir.BackColor = Color.SeaGreen;
            btnAnyadir.Cursor = Cursors.Hand;
            btnAnyadir.FlatAppearance.BorderSize = 0;
            btnAnyadir.FlatStyle = FlatStyle.Flat;
            btnAnyadir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAnyadir.ForeColor = Color.White;
            btnAnyadir.Location = new Point(100, 275);
            btnAnyadir.Size = new Size(180, 45);
            btnAnyadir.Text = "AÑADIR GRUPO";
            btnAnyadir.UseVisualStyleBackColor = false;

            // btnCancelar
            btnCancelar.BackColor = Color.Crimson;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(300, 275);
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;

            // panelContenedor
            panelContenedor.BackColor = Color.FromArgb(180, 240, 240, 240);
            panelContenedor.Controls.Add(lblNombre);
            panelContenedor.Controls.Add(lblEmail);
            panelContenedor.Controls.Add(lblPassword);
            panelContenedor.Controls.Add(lblClase);
            panelContenedor.Location = new Point(30, 85);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(520, 175);

            // AnyadirGrupo Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 350);
            Controls.Add(panelContenedor);
            Controls.Add(lbltitulo);
            Controls.Add(btnCancelar);
            Controls.Add(btnAnyadir);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AnyadirGrupo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Grupos";
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
        }
    }
}