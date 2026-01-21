using System.Windows.Forms;
using System.Drawing;

namespace PeluqueriAPP
{
    partial class SeleccionarTipoUsuario
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnAdmin;
        private Button btnGrupo;
        private Button btnCliente;
        private Label lblTitulo;

        private void InitializeComponent()
        {
            this.btnAdmin = new Button();
            this.btnGrupo = new Button();
            this.btnCliente = new Button();
            this.lblTitulo = new Label();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Text = "Seleccione Perfil";
            this.lblTitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(64, 64, 64);
            this.lblTitulo.Location = new Point(20, 15);
            this.lblTitulo.Size = new Size(210, 30);
            this.lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // Estilo común para los botones
            Font fuenteBotones = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            Size tamañoBoton = new Size(210, 45);

            // btnAdmin (Azul)
            this.btnAdmin.BackColor = Color.FromArgb(45, 156, 219);
            this.btnAdmin.FlatStyle = FlatStyle.Flat;
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.Font = fuenteBotones;
            this.btnAdmin.ForeColor = Color.White;
            this.btnAdmin.Location = new Point(20, 60);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = tamañoBoton;
            this.btnAdmin.Text = "👤  Administrador";
            this.btnAdmin.Cursor = Cursors.Hand;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);

            // btnGrupo (Verde)
            this.btnGrupo.BackColor = Color.FromArgb(33, 150, 83);
            this.btnGrupo.FlatStyle = FlatStyle.Flat;
            this.btnGrupo.FlatAppearance.BorderSize = 0;
            this.btnGrupo.Font = fuenteBotones;
            this.btnGrupo.ForeColor = Color.White;
            this.btnGrupo.Location = new Point(20, 115);
            this.btnGrupo.Name = "btnGrupo";
            this.btnGrupo.Size = tamañoBoton;
            this.btnGrupo.Text = "👥  Grupo / Clase";
            this.btnGrupo.Cursor = Cursors.Hand;
            this.btnGrupo.Click += new System.EventHandler(this.btnGrupo_Click);

            // btnCliente (Naranja/Amarillo)
            this.btnCliente.BackColor = Color.FromArgb(242, 153, 74);
            this.btnCliente.FlatStyle = FlatStyle.Flat;
            this.btnCliente.FlatAppearance.BorderSize = 0;
            this.btnCliente.Font = fuenteBotones;
            this.btnCliente.ForeColor = Color.White;
            this.btnCliente.Location = new Point(20, 170);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = tamañoBoton;
            this.btnCliente.Text = "⭐  Cliente Individual";
            this.btnCliente.Cursor = Cursors.Hand;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);

            // Form (Configuración general)
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(250, 240);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnGrupo);
            this.Controls.Add(this.btnCliente);

            this.FormBorderStyle = FormBorderStyle.FixedDialog; // No redimensionable
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeleccionarTipoUsuario";
            this.StartPosition = FormStartPosition.CenterScreen; // Centro de la pantalla
            this.Text = "Nuevo Registro";

            this.ResumeLayout(false);
        }
    }
}