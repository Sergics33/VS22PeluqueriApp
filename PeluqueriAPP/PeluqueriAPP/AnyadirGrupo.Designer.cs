using System.Windows.Forms;
using System.Drawing;

namespace PeluqueriAPP
{
    partial class AnyadirGrupo
    {
        private System.ComponentModel.IContainer components = null;
        private Label lbltitulo;
        private Label lblNombre, lblEmail, lblPassword, lblClase;
        private TextBox tbNombre, tbEmail, tbPassword, tbClase;
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
            panelSeparador = new Panel();

            SuspendLayout();

            // --- Estilos comunes (Consistentes con el resto de la App) ---
            Font fuenteLabels = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            Font fuenteInputs = new Font("Segoe UI", 12F);
            Color colorTextoLabels = Color.FromArgb(120, 120, 120);
            Color colorFondoInput = Color.FromArgb(242, 242, 242);

            // lbltitulo
            lbltitulo.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            lbltitulo.ForeColor = Color.FromArgb(45, 45, 48);
            lbltitulo.Location = new Point(0, 10);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new Size(580, 65);
            lbltitulo.Text = "Nuevo Grupo / Clase";
            lbltitulo.TextAlign = ContentAlignment.MiddleCenter;

            // --- COLUMNA IZQUIERDA ---

            // lblNombre
            lblNombre.AutoSize = true;
            lblNombre.Font = fuenteLabels;
            lblNombre.ForeColor = colorTextoLabels;
            lblNombre.Location = new Point(50, 85);
            lblNombre.Text = "NOMBRE DEL GRUPO";

            // tbNombre
            tbNombre.BackColor = colorFondoInput;
            tbNombre.BorderStyle = BorderStyle.None;
            tbNombre.Font = fuenteInputs;
            tbNombre.Location = new Point(50, 110);
            tbNombre.Size = new Size(220, 28);

            // lblEmail
            lblEmail.AutoSize = true;
            lblEmail.Font = fuenteLabels;
            lblEmail.ForeColor = colorTextoLabels;
            lblEmail.Location = new Point(50, 160);
            lblEmail.Text = "EMAIL DE CONTACTO";

            // tbEmail
            tbEmail.BackColor = colorFondoInput;
            tbEmail.BorderStyle = BorderStyle.None;
            tbEmail.Font = fuenteInputs;
            tbEmail.Location = new Point(50, 185);
            tbEmail.Size = new Size(220, 28);

            // --- COLUMNA DERECHA ---

            // lblPassword
            lblPassword.AutoSize = true;
            lblPassword.Font = fuenteLabels;
            lblPassword.ForeColor = colorTextoLabels;
            lblPassword.Location = new Point(310, 85);
            lblPassword.Text = "CONTRASEÑA ACCESO";

            // tbPassword
            tbPassword.BackColor = colorFondoInput;
            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.Font = fuenteInputs;
            tbPassword.Location = new Point(310, 110);
            tbPassword.PasswordChar = '●';
            tbPassword.Size = new Size(220, 28);

            // lblClase
            lblClase.AutoSize = true;
            lblClase.Font = fuenteLabels;
            lblClase.ForeColor = colorTextoLabels;
            lblClase.Location = new Point(310, 160);
            lblClase.Text = "CATEGORÍA / CLASE";

            // tbClase
            tbClase.BackColor = colorFondoInput;
            tbClase.BorderStyle = BorderStyle.None;
            tbClase.Font = fuenteInputs;
            tbClase.Location = new Point(310, 185);
            tbClase.Size = new Size(220, 28);

            // panelSeparador (Línea estética)
            panelSeparador.BackColor = Color.FromArgb(230, 230, 230);
            panelSeparador.Location = new Point(50, 250);
            panelSeparador.Size = new Size(480, 1);

            // --- BOTONES ---

            // btnAnyadir
            btnAnyadir.BackColor = Color.FromArgb(45, 45, 48);
            btnAnyadir.Cursor = Cursors.Hand;
            btnAnyadir.FlatAppearance.BorderSize = 0;
            btnAnyadir.FlatStyle = FlatStyle.Flat;
            btnAnyadir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAnyadir.ForeColor = Color.White;
            btnAnyadir.Location = new Point(100, 290);
            btnAnyadir.Size = new Size(180, 45);
            btnAnyadir.Text = "AÑADIR GRUPO";
            btnAnyadir.UseVisualStyleBackColor = false;

            // btnCancelar
            btnCancelar.BackColor = Color.FromArgb(210, 210, 210);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(60, 60, 60);
            btnCancelar.Location = new Point(300, 290);
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += (s, e) => this.Close();

            // Configuración del Formulario AnyadirGrupo
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(580, 380);
            Controls.Add(lbltitulo);
            Controls.Add(lblNombre);
            Controls.Add(tbNombre);
            Controls.Add(lblEmail);
            Controls.Add(tbEmail);
            Controls.Add(lblPassword);
            Controls.Add(tbPassword);
            Controls.Add(lblClase);
            Controls.Add(tbClase);
            Controls.Add(panelSeparador);
            Controls.Add(btnCancelar);
            Controls.Add(btnAnyadir);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AnyadirGrupo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Grupos";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}