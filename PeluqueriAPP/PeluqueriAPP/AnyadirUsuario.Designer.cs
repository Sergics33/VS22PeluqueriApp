namespace PeluqueriAPP
{
    partial class AnyadirUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAnyadir = new Button();
            tbPrecio = new TextBox();
            lblObservaciones = new Label();
            tbDuracion = new TextBox();
            lblAlérgenos = new Label();
            tbDescripcion = new TextBox();
            lblTelefono = new Label();
            tbNombre = new TextBox();
            lblNombre = new Label();
            lbltitulo = new Label();
            SuspendLayout();
            // 
            // btnAnyadir
            // 
            btnAnyadir.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnAnyadir.Location = new Point(146, 320);
            btnAnyadir.Name = "btnAnyadir";
            btnAnyadir.Size = new Size(144, 23);
            btnAnyadir.TabIndex = 19;
            btnAnyadir.Text = "AÑADIR USUARIO";
            btnAnyadir.UseVisualStyleBackColor = true;
            // 
            // tbPrecio
            // 
            tbPrecio.Location = new Point(146, 272);
            tbPrecio.Name = "tbPrecio";
            tbPrecio.Size = new Size(140, 23);
            tbPrecio.TabIndex = 18;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblObservaciones.Location = new Point(27, 275);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(113, 20);
            lblObservaciones.TabIndex = 17;
            lblObservaciones.Text = "Observaciones:";
            // 
            // tbDuracion
            // 
            tbDuracion.Location = new Point(146, 224);
            tbDuracion.Name = "tbDuracion";
            tbDuracion.Size = new Size(140, 23);
            tbDuracion.TabIndex = 16;
            // 
            // lblAlérgenos
            // 
            lblAlérgenos.AutoSize = true;
            lblAlérgenos.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAlérgenos.Location = new Point(53, 227);
            lblAlérgenos.Name = "lblAlérgenos";
            lblAlérgenos.Size = new Size(82, 20);
            lblAlérgenos.TabIndex = 15;
            lblAlérgenos.Text = "Alérgenos:";
            // 
            // tbDescripcion
            // 
            tbDescripcion.Location = new Point(146, 173);
            tbDescripcion.Name = "tbDescripcion";
            tbDescripcion.Size = new Size(140, 23);
            tbDescripcion.TabIndex = 14;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTelefono.Location = new Point(53, 174);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(72, 20);
            lblTelefono.TabIndex = 13;
            lblTelefono.Text = "Teléfono:";
            // 
            // tbNombre
            // 
            tbNombre.Location = new Point(146, 123);
            tbNombre.Name = "tbNombre";
            tbNombre.Size = new Size(140, 23);
            tbNombre.TabIndex = 12;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(53, 123);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(70, 20);
            lblNombre.TabIndex = 11;
            lblNombre.Text = "Nombre:";
            // 
            // lbltitulo
            // 
            lbltitulo.AutoSize = true;
            lbltitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltitulo.Location = new Point(53, 30);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new Size(250, 37);
            lbltitulo.TabIndex = 10;
            lbltitulo.Text = "AÑADIR USUARIO";
            // 
            // AnyadirUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 362);
            Controls.Add(btnAnyadir);
            Controls.Add(tbPrecio);
            Controls.Add(lblObservaciones);
            Controls.Add(tbDuracion);
            Controls.Add(lblAlérgenos);
            Controls.Add(tbDescripcion);
            Controls.Add(lblTelefono);
            Controls.Add(tbNombre);
            Controls.Add(lblNombre);
            Controls.Add(lbltitulo);
            Name = "AnyadirUsuario";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAnyadir;
        private TextBox tbPrecio;
        private Label lblObservaciones;
        private TextBox tbDuracion;
        private Label lblAlérgenos;
        private TextBox tbDescripcion;
        private Label lblTelefono;
        private TextBox tbNombre;
        private Label lblNombre;
        private Label lbltitulo;
    }
}