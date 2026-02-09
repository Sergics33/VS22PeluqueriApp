using System.Windows.Forms;
using System.Drawing;

namespace PeluqueriAPP
{
    partial class AnyadirCliente
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Label lblNombre, lblTelefono, lblEmail, lblPassword;
        private TextBox tbNombre, tbTelefono, tbEmail, tbPassword;
        private Button btnAnyadir, btnCancelar;
        private Panel panelSeparador;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
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
            panelSeparador = new Panel();

            SuspendLayout();

            // Estilos comunes (Mismo estilo que AnyadirAdmin)
            Font fuenteLabels = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            Font fuenteInputs = new Font("Segoe UI", 12F);
            Color colorTextoLabels = Color.FromArgb(120, 120, 120);
            Color colorFondoInput = Color.FromArgb(242, 242, 242);

            // lblTitulo
            lblTitulo.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(45, 45, 48);
            lblTitulo.Location = new Point(0, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(580, 65);
            lblTitulo.Text = "Nuevo Cliente";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // --- FILA 1: NOMBRE COMPLETO (ANCHO TOTAL) ---
            lblNombre.AutoSize = true;
            lblNombre.Font = fuenteLabels;
            lblNombre.ForeColor = colorTextoLabels;
            lblNombre.Location = new Point(50, 85);
            lblNombre.Text = "NOMBRE COMPLETO";

            tbNombre.BackColor = colorFondoInput;
            tbNombre.BorderStyle = BorderStyle.None;
            tbNombre.Font = fuenteInputs;
            tbNombre.Location = new Point(50, 110);
            tbNombre.Size = new Size(480, 28);

            // --- FILA 2: TELÉFONO Y EMAIL (DOS COLUMNAS) ---
            lblTelefono.AutoSize = true;
            lblTelefono.Font = fuenteLabels;
            lblTelefono.ForeColor = colorTextoLabels;
            lblTelefono.Location = new Point(50, 160);
            lblTelefono.Text = "TELÉFONO";

            tbTelefono.BackColor = colorFondoInput;
            tbTelefono.BorderStyle = BorderStyle.None;
            tbTelefono.Font = fuenteInputs;
            tbTelefono.Location = new Point(50, 185);
            tbTelefono.Size = new Size(220, 28);

            lblEmail.AutoSize = true;
            lblEmail.Font = fuenteLabels;
            lblEmail.ForeColor = colorTextoLabels;
            lblEmail.Location = new Point(310, 160);
            lblEmail.Text = "CORREO ELECTRÓNICO";

            tbEmail.BackColor = colorFondoInput;
            tbEmail.BorderStyle = BorderStyle.None;
            tbEmail.Font = fuenteInputs;
            tbEmail.Location = new Point(310, 185);
            tbEmail.Size = new Size(220, 28);

            // --- FILA 3: CONTRASEÑA (ANCHO TOTAL) ---
            lblPassword.AutoSize = true;
            lblPassword.Font = fuenteLabels;
            lblPassword.ForeColor = colorTextoLabels;
            lblPassword.Location = new Point(50, 235);
            lblPassword.Text = "CONTRASEÑA";

            tbPassword.BackColor = colorFondoInput;
            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.Font = fuenteInputs;
            tbPassword.Location = new Point(50, 260);
            tbPassword.PasswordChar = '●';
            tbPassword.Size = new Size(480, 28);

            // panelSeparador
            panelSeparador.BackColor = Color.FromArgb(230, 230, 230);
            panelSeparador.Location = new Point(50, 310);
            panelSeparador.Size = new Size(480, 1);

            // --- BOTONES ---
            btnAnyadir.BackColor = Color.FromArgb(45, 45, 48);
            btnAnyadir.Cursor = Cursors.Hand;
            btnAnyadir.FlatAppearance.BorderSize = 0;
            btnAnyadir.FlatStyle = FlatStyle.Flat;
            btnAnyadir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAnyadir.ForeColor = Color.White;
            btnAnyadir.Location = new Point(100, 335);
            btnAnyadir.Size = new Size(180, 45);
            btnAnyadir.Text = "GUARDAR";
            btnAnyadir.UseVisualStyleBackColor = false;

            btnCancelar.BackColor = Color.FromArgb(210, 210, 210);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(60, 60, 60);
            btnCancelar.Location = new Point(300, 335);
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;

            // Configuración del Formulario
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(580, 410);
            Controls.Add(lblTitulo);
            Controls.Add(lblNombre);
            Controls.Add(tbNombre);
            Controls.Add(lblTelefono);
            Controls.Add(tbTelefono);
            Controls.Add(lblEmail);
            Controls.Add(tbEmail);
            Controls.Add(lblPassword);
            Controls.Add(tbPassword);
            Controls.Add(panelSeparador);
            Controls.Add(btnCancelar);
            Controls.Add(btnAnyadir);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AnyadirCliente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registro de Cliente";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}