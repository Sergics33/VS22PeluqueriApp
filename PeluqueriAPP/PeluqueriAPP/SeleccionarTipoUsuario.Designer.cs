namespace PeluqueriAPP
{
    partial class SeleccionarTipoUsuario
    {
        private Button btnCliente, btnAdmin, btnGrupo;

        private void InitializeComponent()
        {
            this.btnCliente = new Button();
            this.btnAdmin = new Button();
            this.btnGrupo = new Button();

            this.SuspendLayout();

            // btnCliente
            this.btnCliente.Text = "Cliente";
            this.btnCliente.Location = new System.Drawing.Point(50, 30);
            this.btnCliente.Size = new System.Drawing.Size(100, 50);
            this.btnCliente.Click += btnCliente_Click;

            // btnAdmin
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.Location = new System.Drawing.Point(50, 100);
            this.btnAdmin.Size = new System.Drawing.Size(100, 50);
            this.btnAdmin.Click += btnAdmin_Click;

            // btnGrupo
            this.btnGrupo.Text = "Grupo";
            this.btnGrupo.Location = new System.Drawing.Point(50, 170);
            this.btnGrupo.Size = new System.Drawing.Size(100, 50);
            this.btnGrupo.Click += btnGrupo_Click;

            // Form
            this.ClientSize = new System.Drawing.Size(200, 250);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnGrupo);
            this.Text = "Seleccionar tipo de usuario";

            this.ResumeLayout(false);
        }
    }
}
