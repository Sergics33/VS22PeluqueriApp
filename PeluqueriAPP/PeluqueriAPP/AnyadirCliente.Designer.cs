using System.Drawing;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    partial class AnyadirCliente
    {
        private System.ComponentModel.IContainer components = null;
        private Label lbltitulo;
        private Label lblNombre;
        private TextBox tbNombre;
        private Label lblTelefono;
        private TextBox tbTelefono;
        private Label lblEmail;
        private TextBox tbEmail;
        private Button btnAnyadir;
        private Panel panelContenedor;

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
            lblTelefono = new Label();
            tbTelefono = new TextBox();
            lblEmail = new Label();
            tbEmail = new TextBox();
            btnAnyadir = new Button();
            panelContenedor = new Panel();
            panelContenedor.SuspendLayout();
            SuspendLayout();

            // Título
            lbltitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lbltitulo.ForeColor = Color.ForestGreen;
            lbltitulo.Location = new Point(0, 20);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new Size(380, 45);
            lbltitulo.Text = "AÑADIR CLIENTE";
            lbltitulo.TextAlign = ContentAlignment.MiddleCenter;

            // Panel Blanco
            panelContenedor.BackColor = Color.White;
            panelContenedor.BorderStyle = BorderStyle.FixedSingle;
            panelContenedor.Controls.Add(lblNombre);
            panelContenedor.Controls.Add(tbNombre);
            panelContenedor.Controls.Add(lblTelefono);
            panelContenedor.Controls.Add(tbTelefono);
            panelContenedor.Controls.Add(lblEmail);
            panelContenedor.Controls.Add(tbEmail);
            panelContenedor.Location = new Point(25, 80);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(330, 230);

            // Nombre
            lblNombre.Text = "Nombre Completo:";
            lblNombre.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblNombre.Location = new Point(20, 15);
            lblNombre.AutoSize = true;
            tbNombre.Location = new Point(20, 37);
            tbNombre.Size = new Size(285, 25);

            // Telefono
            lblTelefono.Text = "Teléfono:";
            lblTelefono.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTelefono.Location = new Point(20, 85);
            lblTelefono.AutoSize = true;
            tbTelefono.Location = new Point(20, 107);
            tbTelefono.Size = new Size(285, 25);

            // Email
            lblEmail.Text = "Email:";
            lblEmail.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblEmail.Location = new Point(20, 155);
            lblEmail.AutoSize = true;
            tbEmail.Location = new Point(20, 177);
            tbEmail.Size = new Size(285, 25);

            // Botón
            btnAnyadir.BackColor = Color.FromArgb(255, 192, 128);
            btnAnyadir.FlatStyle = FlatStyle.Flat;
            btnAnyadir.FlatAppearance.BorderSize = 0;
            btnAnyadir.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnAnyadir.ForeColor = Color.White;
            btnAnyadir.Location = new Point(25, 330);
            btnAnyadir.Size = new Size(330, 45);
            btnAnyadir.Text = "GUARDAR CLIENTE";

            // Formulario
            ClientSize = new Size(380, 400);
            BackColor = Color.FromArgb(245, 245, 245);
            Controls.Add(panelContenedor);
            Controls.Add(btnAnyadir);
            Controls.Add(lbltitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
        }
    }
}