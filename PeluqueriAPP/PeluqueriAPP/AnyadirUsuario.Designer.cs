using System.Drawing;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    partial class AnyadirUsuario
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Label lblNombre, lblEmail, lblContrasena, lblTelefono, lblAlergenos, lblObservaciones;
        private TextBox tbNombre, tbEmail, tbContrasena, tbTelefono, tbAlergenos, tbObservaciones;
        private Button btnAnyadir;
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
            lblContrasena = new Label();
            tbContrasena = new TextBox();
            lblTelefono = new Label();
            tbTelefono = new TextBox();
            lblAlergenos = new Label();
            tbAlergenos = new TextBox();
            lblObservaciones = new Label();
            tbObservaciones = new TextBox();
            btnAnyadir = new Button();
            panelContenedor = new Panel();
            panelContenedor.SuspendLayout();
            SuspendLayout();

            // lblTitulo (Estilo Verde y Centrado)
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.ForestGreen;
            lblTitulo.Location = new Point(0, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(420, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "AÑADIR USUARIO";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // panelContenedor (Caja blanca para los campos)
            panelContenedor.BackColor = Color.White;
            panelContenedor.BorderStyle = BorderStyle.FixedSingle;
            panelContenedor.Location = new Point(25, 75);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(370, 410);
            panelContenedor.TabIndex = 1;

            // --- Configuración de Campos ---
            int yStart = 15;
            int ySpacing = 65;

            ConfigurarCampo(lblNombre, tbNombre, "Nombre Completo:", yStart);
            ConfigurarCampo(lblEmail, tbEmail, "Email:", yStart + ySpacing);
            ConfigurarCampo(lblContrasena, tbContrasena, "Contraseña:", yStart + (ySpacing * 2));
            tbContrasena.PasswordChar = '*';
            ConfigurarCampo(lblTelefono, tbTelefono, "Teléfono:", yStart + (ySpacing * 3));
            ConfigurarCampo(lblAlergenos, tbAlergenos, "Alérgenos:", yStart + (ySpacing * 4));
            ConfigurarCampo(lblObservaciones, tbObservaciones, "Observaciones:", yStart + (ySpacing * 5));

            panelContenedor.Controls.AddRange(new Control[] {
                lblNombre, tbNombre, lblEmail, tbEmail, lblContrasena, tbContrasena,
                lblTelefono, tbTelefono, lblAlergenos, tbAlergenos, lblObservaciones, tbObservaciones
            });

            // btnAnyadir
            btnAnyadir.BackColor = Color.FromArgb(255, 192, 128);
            btnAnyadir.FlatAppearance.BorderSize = 0;
            btnAnyadir.FlatStyle = FlatStyle.Flat;
            btnAnyadir.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnAnyadir.ForeColor = Color.White;
            btnAnyadir.Location = new Point(25, 500);
            btnAnyadir.Name = "btnAnyadir";
            btnAnyadir.Size = new Size(370, 45);
            btnAnyadir.TabIndex = 2;
            btnAnyadir.Text = "AÑADIR USUARIO";
            btnAnyadir.UseVisualStyleBackColor = false;

            // --- ESTA LÍNEA ES LA QUE FALTA ---
            btnAnyadir.Click += new System.EventHandler(this.BtnAnyadir_Click);

            // Formulario
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(420, 570);
            Controls.Add(lblTitulo);
            Controls.Add(panelContenedor);
            Controls.Add(btnAnyadir);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AnyadirUsuario";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Usuario";
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
        }

        private void ConfigurarCampo(Label lbl, TextBox tb, string texto, int y)
        {
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(64, 64, 64);
            lbl.Location = new Point(20, y);
            lbl.Text = texto;
            tb.Font = new Font("Segoe UI", 10F);
            tb.Location = new Point(20, y + 22);
            tb.Size = new Size(325, 25);
        }
    }
}