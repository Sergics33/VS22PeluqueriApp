namespace PeluqueriAPP
{
    partial class AnyadirCliente
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Label lblNombre, lblTelefono, lblEmail, lblPassword;
        private TextBox tbNombre, tbTelefono, tbEmail, tbPassword;
        private Button btnAnyadir, btnCancelar;
        private Panel panelContenedor; // Reemplaza al panelSeparador

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
            lblTelefono = new Label();
            tbTelefono = new TextBox();
            lblEmail = new Label();
            tbEmail = new TextBox();
            lblPassword = new Label();
            tbPassword = new TextBox();
            btnAnyadir = new Button();
            btnCancelar = new Button();
            panelContenedor = new Panel();
            panelContenedor.SuspendLayout();
            SuspendLayout();

            // lblTitulo
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 5);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(580, 75);
            lblTitulo.Text = "Nuevo Cliente";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // lblNombre
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(50, 50, 50);
            lblNombre.Location = new Point(25, 15);
            lblNombre.Text = "NOMBRE COMPLETO:";

            // tbNombre (Hijo de cápsula)
            tbNombre.BorderStyle = BorderStyle.None;
            tbNombre.Font = new Font("Segoe UI", 11F);

            // lblTelefono
            lblTelefono.AutoSize = true;
            lblTelefono.BackColor = Color.Transparent;
            lblTelefono.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTelefono.ForeColor = Color.FromArgb(50, 50, 50);
            lblTelefono.Location = new Point(25, 80);
            lblTelefono.Text = "TELÉFONO:";

            // tbTelefono (Hijo de cápsula)
            tbTelefono.BorderStyle = BorderStyle.None;
            tbTelefono.Font = new Font("Segoe UI", 11F);

            // lblEmail
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(50, 50, 50);
            lblEmail.Location = new Point(275, 80);
            lblEmail.Text = "EMAIL:";

            // tbEmail (Hijo de cápsula)
            tbEmail.BorderStyle = BorderStyle.None;
            tbEmail.Font = new Font("Segoe UI", 11F);

            // lblPassword
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(50, 50, 50);
            lblPassword.Location = new Point(25, 145);
            lblPassword.Text = "CONTRASEÑA:";

            // tbPassword (Hijo de cápsula)
            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.Font = new Font("Segoe UI", 11F);
            tbPassword.PasswordChar = '●';

            // btnAnyadir
            btnAnyadir.BackColor = Color.SeaGreen;
            btnAnyadir.Cursor = Cursors.Hand;
            btnAnyadir.FlatAppearance.BorderSize = 0;
            btnAnyadir.FlatStyle = FlatStyle.Flat;
            btnAnyadir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAnyadir.ForeColor = Color.White;
            btnAnyadir.Location = new Point(100, 315);
            btnAnyadir.Size = new Size(180, 45);
            btnAnyadir.Text = "GUARDAR";
            btnAnyadir.UseVisualStyleBackColor = false;

            // btnCancelar
            btnCancelar.BackColor = Color.Crimson;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(300, 315);
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;

            // panelContenedor
            panelContenedor.BackColor = Color.FromArgb(180, 240, 240, 240);
            panelContenedor.Controls.Add(lblNombre);
            panelContenedor.Controls.Add(lblTelefono);
            panelContenedor.Controls.Add(lblEmail);
            panelContenedor.Controls.Add(lblPassword);
            panelContenedor.Location = new Point(30, 85);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(520, 215);

            // AnyadirCliente Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 385);
            Controls.Add(panelContenedor);
            Controls.Add(lblTitulo);
            Controls.Add(btnCancelar);
            Controls.Add(btnAnyadir);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AnyadirCliente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registro de Cliente";
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
        }
    }
}