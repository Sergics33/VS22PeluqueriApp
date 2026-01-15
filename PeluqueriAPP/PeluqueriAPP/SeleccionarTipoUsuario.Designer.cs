using System.Windows.Forms;

namespace PeluqueriAPP
{
    partial class SeleccionarTipoUsuario
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnAdmin;
        private Button btnGrupo;
        private Button btnCliente;

        private void InitializeComponent()
        {
            this.btnAdmin = new Button();
            this.btnGrupo = new Button();
            this.btnCliente = new Button();
            this.SuspendLayout();

            // btnAdmin
            this.btnAdmin.Location = new System.Drawing.Point(30, 30);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(100, 40);
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);

            // btnGrupo
            this.btnGrupo.Location = new System.Drawing.Point(30, 90);
            this.btnGrupo.Name = "btnGrupo";
            this.btnGrupo.Size = new System.Drawing.Size(100, 40);
            this.btnGrupo.Text = "Grupo";
            this.btnGrupo.Click += new System.EventHandler(this.btnGrupo_Click);

            // btnCliente
            this.btnCliente.Location = new System.Drawing.Point(30, 150);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(100, 40);
            this.btnCliente.Text = "Clase";
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(160, 220);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnGrupo);
            this.Controls.Add(this.btnCliente);
            this.Name = "SeleccionarTipoUsuario";
            this.Text = "Seleccionar tipo";
            this.ResumeLayout(false);
        }
    }
}
