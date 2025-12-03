namespace PeluqueriAPP
{
    partial class AnyadirServicio
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
            lbltitulo = new Label();
            lblNombre = new Label();
            tbNombre = new TextBox();
            lblDescripcion = new Label();
            tbDescripcion = new TextBox();
            lblDuracion = new Label();
            tbDuracion = new TextBox();
            lblPrecio = new Label();
            tbPrecio = new TextBox();
            SuspendLayout();
            // 
            // lbltitulo
            // 
            lbltitulo.AutoSize = true;
            lbltitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltitulo.Location = new Point(45, 23);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new Size(250, 37);
            lbltitulo.TabIndex = 0;
            lbltitulo.Text = "AÑADIR SERVICIO";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            lblDescripcion.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescripcion.Location = new Point(45, 167);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(93, 20);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción:";
            // 
            // tbDescripcion
            // 
            tbDescripcion.Location = new Point(138, 166);
            tbDescripcion.Name = "tbDescripcion";
            tbDescripcion.Size = new Size(140, 23);
            tbDescripcion.TabIndex = 4;
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDuracion.Location = new Point(45, 220);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(76, 20);
            lblDuracion.TabIndex = 5;
            lblDuracion.Text = "Duración:";
            // 
            // tbDuracion
            // 
            tbDuracion.Location = new Point(138, 217);
            tbDuracion.Name = "tbDuracion";
            tbDuracion.Size = new Size(140, 23);
            tbDuracion.TabIndex = 6;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrecio.Location = new Point(45, 268);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(56, 20);
            lblPrecio.TabIndex = 7;
            lblPrecio.Text = "Precio:";
            // 
            // tbPrecio
            // 
            tbPrecio.Location = new Point(138, 265);
            tbPrecio.Name = "tbPrecio";
            tbPrecio.Size = new Size(140, 23);
            tbPrecio.TabIndex = 8;
            // 
            // AnyadirServicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 363);
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
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbltitulo;
        private Label lblNombre;
        private TextBox tbNombre;
        private Label lblDescripcion;
        private TextBox tbDescripcion;
        private Label lblDuracion;
        private TextBox tbDuracion;
        private Label lblPrecio;
        private TextBox tbPrecio;
    }
}