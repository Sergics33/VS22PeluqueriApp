namespace PeluqueriAPP
{
    partial class AnyadirServicio
    {
        private System.ComponentModel.IContainer components = null;

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
            lblDescripcion = new Label();
            tbDescripcion = new TextBox();
            lblDuracion = new Label();
            tbDuracion = new TextBox();
            lblPrecio = new Label();
            tbPrecio = new TextBox();
            btnAnyadir = new Button();
            tbTipo = new TextBox();
            lblTipo = new Label();
            SuspendLayout();
            // 
            // lbltitulo
            // 
            lbltitulo.AutoSize = true;
            lbltitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            lbltitulo.Location = new Point(45, 23);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new Size(250, 37);
            lbltitulo.TabIndex = 0;
            lbltitulo.Text = "AÑADIR SERVICIO";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblNombre.Location = new Point(45, 116);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(70, 20);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // tbNombre
            // 
            tbNombre.Location = new Point(138, 116);
            tbNombre.Name = "tbNombre";
            tbNombre.Size = new Size(140, 23);
            tbNombre.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblDescripcion.Location = new Point(22, 209);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(93, 20);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción:";
            // 
            // tbDescripcion
            // 
            tbDescripcion.Location = new Point(138, 206);
            tbDescripcion.Name = "tbDescripcion";
            tbDescripcion.Size = new Size(140, 23);
            tbDescripcion.TabIndex = 4;
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblDuracion.Location = new Point(45, 260);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(76, 20);
            lblDuracion.TabIndex = 5;
            lblDuracion.Text = "Duración:";
            // 
            // tbDuracion
            // 
            tbDuracion.Location = new Point(138, 257);
            tbDuracion.Name = "tbDuracion";
            tbDuracion.Size = new Size(140, 23);
            tbDuracion.TabIndex = 6;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblPrecio.Location = new Point(59, 305);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(56, 20);
            lblPrecio.TabIndex = 7;
            lblPrecio.Text = "Precio:";
            // 
            // tbPrecio
            // 
            tbPrecio.Location = new Point(138, 305);
            tbPrecio.Name = "tbPrecio";
            tbPrecio.Size = new Size(140, 23);
            tbPrecio.TabIndex = 8;
            // 
            // btnAnyadir
            // 
            btnAnyadir.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold | FontStyle.Italic);
            btnAnyadir.Location = new Point(138, 345);
            btnAnyadir.Name = "btnAnyadir";
            btnAnyadir.Size = new Size(144, 23);
            btnAnyadir.TabIndex = 9;
            btnAnyadir.Text = "AÑADIR SERVICIO";
            btnAnyadir.UseVisualStyleBackColor = true;
            // 
            // tbTipo
            // 
            tbTipo.Location = new Point(138, 163);
            tbTipo.Name = "tbTipo";
            tbTipo.Size = new Size(140, 23);
            tbTipo.TabIndex = 10;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblTipo.Location = new Point(72, 162);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(43, 20);
            lblTipo.TabIndex = 11;
            lblTipo.Text = "Tipo:";
            // 
            // AnyadirServicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 436);
            Controls.Add(lblTipo);
            Controls.Add(tbTipo);
            Controls.Add(btnAnyadir);
            Controls.Add(tbPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(tbDuracion);
            Controls.Add(lblDuracion);
            Controls.Add(tbDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(tbNombre);
            Controls.Add(lblNombre);
            Controls.Add(lbltitulo);
            Name = "AnyadirServicio";
            Text = "Añadir Servicio";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.TextBox tbDuracion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox tbPrecio;
        private System.Windows.Forms.Button btnAnyadir;
        private TextBox tbTipo;
        private Label lblTipo;
    }
}
