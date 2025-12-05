namespace PeluqueriAPP
{
    partial class AnyadirUsuario
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitulo;
        private Label lblNombre, lblEmail, lblContrasena, lblTelefono, lblAlergenos, lblObservaciones;
        private TextBox tbNombre, tbEmail, tbContrasena, tbTelefono, tbAlergenos, tbObservaciones;
        private Button btnAnyadir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new Label();
            this.lblNombre = new Label();
            this.tbNombre = new TextBox();
            this.lblEmail = new Label();
            this.tbEmail = new TextBox();
            this.lblContrasena = new Label();
            this.tbContrasena = new TextBox();
            this.lblTelefono = new Label();
            this.tbTelefono = new TextBox();
            this.lblAlergenos = new Label();
            this.tbAlergenos = new TextBox();
            this.lblObservaciones = new Label();
            this.tbObservaciones = new TextBox();
            this.btnAnyadir = new Button();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(100, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 32);
            this.lblTitulo.Text = "AÑADIR USUARIO";

            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(30, 70);
            this.lblNombre.Text = "Nombre:";
            // tbNombre
            this.tbNombre.Location = new System.Drawing.Point(150, 70);
            this.tbNombre.Width = 200;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(30, 110);
            this.lblEmail.Text = "Email:";
            // tbEmail
            this.tbEmail.Location = new System.Drawing.Point(150, 110);
            this.tbEmail.Width = 200;

            // lblContrasena
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(30, 150);
            this.lblContrasena.Text = "Contraseña:";
            // tbContrasena
            this.tbContrasena.Location = new System.Drawing.Point(150, 150);
            this.tbContrasena.Width = 200;
            this.tbContrasena.PasswordChar = '*';

            // lblTelefono
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(30, 190);
            this.lblTelefono.Text = "Teléfono:";
            // tbTelefono
            this.tbTelefono.Location = new System.Drawing.Point(150, 190);
            this.tbTelefono.Width = 200;

            // lblAlergenos
            this.lblAlergenos.AutoSize = true;
            this.lblAlergenos.Location = new System.Drawing.Point(30, 230);
            this.lblAlergenos.Text = "Alérgenos:";
            // tbAlergenos
            this.tbAlergenos.Location = new System.Drawing.Point(150, 230);
            this.tbAlergenos.Width = 200;

            // lblObservaciones
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Location = new System.Drawing.Point(30, 270);
            this.lblObservaciones.Text = "Observaciones:";
            // tbObservaciones
            this.tbObservaciones.Location = new System.Drawing.Point(150, 270);
            this.tbObservaciones.Width = 200;

            // btnAnyadir
            this.btnAnyadir.Location = new System.Drawing.Point(150, 320);
            this.btnAnyadir.Size = new System.Drawing.Size(200, 30);
            this.btnAnyadir.Text = "AÑADIR USUARIO";

            // AnyadirUsuario
            this.ClientSize = new System.Drawing.Size(400, 380);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.tbContrasena);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.tbTelefono);
            this.Controls.Add(this.lblAlergenos);
            this.Controls.Add(this.tbAlergenos);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.tbObservaciones);
            this.Controls.Add(this.btnAnyadir);

            this.Text = "Añadir Usuario";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
