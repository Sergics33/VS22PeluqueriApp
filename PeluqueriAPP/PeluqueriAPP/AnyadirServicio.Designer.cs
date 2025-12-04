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
            lbltitulo = new System.Windows.Forms.Label();
            lblNombre = new System.Windows.Forms.Label();
            tbNombre = new System.Windows.Forms.TextBox();
            lblDescripcion = new System.Windows.Forms.Label();
            tbDescripcion = new System.Windows.Forms.TextBox();
            lblDuracion = new System.Windows.Forms.Label();
            tbDuracion = new System.Windows.Forms.TextBox();
            lblPrecio = new System.Windows.Forms.Label();
            tbPrecio = new System.Windows.Forms.TextBox();
            btnAnyadir = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lbltitulo
            // 
            lbltitulo.AutoSize = true;
            lbltitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            lbltitulo.Location = new System.Drawing.Point(45, 23);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new System.Drawing.Size(250, 37);
            lbltitulo.TabIndex = 0;
            lbltitulo.Text = "AÑADIR SERVICIO";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            lblNombre.Location = new System.Drawing.Point(45, 116);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new System.Drawing.Size(70, 20);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // tbNombre
            // 
            tbNombre.Location = new System.Drawing.Point(138, 116);
            tbNombre.Name = "tbNombre";
            tbNombre.Size = new System.Drawing.Size(140, 23);
            tbNombre.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            lblDescripcion.Location = new System.Drawing.Point(45, 167);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new System.Drawing.Size(93, 20);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción:";
            // 
            // tbDescripcion
            // 
            tbDescripcion.Location = new System.Drawing.Point(138, 166);
            tbDescripcion.Name = "tbDescripcion";
            tbDescripcion.Size = new System.Drawing.Size(140, 23);
            tbDescripcion.TabIndex = 4;
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            lblDuracion.Location = new System.Drawing.Point(45, 220);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new System.Drawing.Size(76, 20);
            lblDuracion.TabIndex = 5;
            lblDuracion.Text = "Duración:";
            // 
            // tbDuracion
            // 
            tbDuracion.Location = new System.Drawing.Point(138, 217);
            tbDuracion.Name = "tbDuracion";
            tbDuracion.Size = new System.Drawing.Size(140, 23);
            tbDuracion.TabIndex = 6;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            lblPrecio.Location = new System.Drawing.Point(45, 268);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new System.Drawing.Size(56, 20);
            lblPrecio.TabIndex = 7;
            lblPrecio.Text = "Precio:";
            // 
            // tbPrecio
            // 
            tbPrecio.Location = new System.Drawing.Point(138, 265);
            tbPrecio.Name = "tbPrecio";
            tbPrecio.Size = new System.Drawing.Size(140, 23);
            tbPrecio.TabIndex = 8;
            // 
            // btnAnyadir
            // 
            btnAnyadir.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
            btnAnyadir.Location = new System.Drawing.Point(138, 313);
            btnAnyadir.Name = "btnAnyadir";
            btnAnyadir.Size = new System.Drawing.Size(144, 23);
            btnAnyadir.TabIndex = 9;
            btnAnyadir.Text = "AÑADIR SERVICIO";
            btnAnyadir.UseVisualStyleBackColor = true;
            // 
            // AnyadirServicio
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(336, 363);
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
    }
}
