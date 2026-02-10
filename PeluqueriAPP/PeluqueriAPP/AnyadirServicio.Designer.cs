namespace PeluqueriAPP
{
    partial class AnyadirServicio
    {
        private System.ComponentModel.IContainer components = null;

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
        private System.Windows.Forms.ComboBox comboBoxTipos;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Panel panelContenedor;

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
            lblDescripcion = new Label();
            tbDescripcion = new TextBox();
            lblDuracion = new Label();
            tbDuracion = new TextBox();
            lblPrecio = new Label();
            tbPrecio = new TextBox();
            btnAnyadir = new Button();
            comboBoxTipos = new ComboBox();
            lblTipo = new Label();
            panelContenedor = new Panel();
            panelContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // lbltitulo
            // 
            lbltitulo.BackColor = Color.Transparent;
            lbltitulo.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            lbltitulo.ForeColor = Color.White;
            lbltitulo.Location = new Point(0, 5);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new Size(420, 75);
            lbltitulo.TabIndex = 0;
            lbltitulo.Text = "Añadir Servicio";
            lbltitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.FromArgb(180, 240, 240, 240); // GRIS CON OPACIDAD
            panelContenedor.Controls.Add(lblNombre);
            panelContenedor.Controls.Add(tbNombre);
            panelContenedor.Controls.Add(lblTipo);
            panelContenedor.Controls.Add(comboBoxTipos);
            panelContenedor.Controls.Add(lblDescripcion);
            panelContenedor.Controls.Add(tbDescripcion);
            panelContenedor.Controls.Add(lblDuracion);
            panelContenedor.Controls.Add(tbDuracion);
            panelContenedor.Controls.Add(lblPrecio);
            panelContenedor.Controls.Add(tbPrecio);
            panelContenedor.Location = new Point(30, 80);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(360, 370);
            panelContenedor.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Font = new Font("Segoe UI Bold", 9.5F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(50, 50, 50);
            lblNombre.Location = new Point(20, 15);
            lblNombre.Text = "NOMBRE:";
            // 
            // tbNombre
            // 
            tbNombre.BackColor = Color.White;
            tbNombre.BorderStyle = BorderStyle.None;
            tbNombre.Font = new Font("Segoe UI", 12F);
            tbNombre.Location = new Point(20, 38);
            tbNombre.Size = new Size(320, 30);
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.BackColor = Color.Transparent;
            lblTipo.Font = new Font("Segoe UI Bold", 9.5F, FontStyle.Bold);
            lblTipo.ForeColor = Color.FromArgb(50, 50, 50);
            lblTipo.Location = new Point(20, 80);
            lblTipo.Text = "TIPO:";
            // 
            // comboBoxTipos
            // 
            comboBoxTipos.BackColor = Color.White;
            comboBoxTipos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipos.FlatStyle = FlatStyle.Flat;
            comboBoxTipos.Font = new Font("Segoe UI", 11F);
            comboBoxTipos.Location = new Point(20, 103);
            comboBoxTipos.Size = new Size(320, 32);
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.BackColor = Color.Transparent;
            lblDescripcion.Font = new Font("Segoe UI Bold", 9.5F, FontStyle.Bold);
            lblDescripcion.ForeColor = Color.FromArgb(50, 50, 50);
            lblDescripcion.Location = new Point(20, 150);
            lblDescripcion.Text = "DESCRIPCIÓN:";
            // 
            // tbDescripcion
            // 
            tbDescripcion.BackColor = Color.White;
            tbDescripcion.BorderStyle = BorderStyle.None;
            tbDescripcion.Font = new Font("Segoe UI", 12F);
            tbDescripcion.Location = new Point(20, 173);
            tbDescripcion.Size = new Size(320, 30);
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.BackColor = Color.Transparent;
            lblDuracion.Font = new Font("Segoe UI Bold", 9.5F, FontStyle.Bold);
            lblDuracion.ForeColor = Color.FromArgb(50, 50, 50);
            lblDuracion.Location = new Point(20, 220);
            lblDuracion.Text = "DURACIÓN (MIN):";
            // 
            // tbDuracion
            // 
            tbDuracion.BackColor = Color.White;
            tbDuracion.BorderStyle = BorderStyle.None;
            tbDuracion.Font = new Font("Segoe UI", 12F);
            tbDuracion.Location = new Point(20, 243);
            tbDuracion.Size = new Size(320, 30);
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.BackColor = Color.Transparent;
            lblPrecio.Font = new Font("Segoe UI Bold", 9.5F, FontStyle.Bold);
            lblPrecio.ForeColor = Color.FromArgb(50, 50, 50);
            lblPrecio.Location = new Point(20, 290);
            lblPrecio.Text = "PRECIO (€):";
            // 
            // tbPrecio
            // 
            tbPrecio.BackColor = Color.White;
            tbPrecio.BorderStyle = BorderStyle.None;
            tbPrecio.Font = new Font("Segoe UI", 12F);
            tbPrecio.Location = new Point(20, 313);
            tbPrecio.Size = new Size(320, 30);
            // 
            // btnAnyadir
            // 
            btnAnyadir.BackColor = Color.SeaGreen;
            btnAnyadir.Cursor = Cursors.Hand;
            btnAnyadir.FlatAppearance.BorderSize = 0;
            btnAnyadir.FlatStyle = FlatStyle.Flat;
            btnAnyadir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAnyadir.ForeColor = Color.White;
            btnAnyadir.Location = new Point(30, 470);
            btnAnyadir.Name = "btnAnyadir";
            btnAnyadir.Size = new Size(360, 45);
            btnAnyadir.TabIndex = 7;
            btnAnyadir.Text = "GUARDAR SERVICIO";
            btnAnyadir.UseVisualStyleBackColor = false;
            // 
            // AnyadirServicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 540);
            Controls.Add(panelContenedor);
            Controls.Add(btnAnyadir);
            Controls.Add(lbltitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AnyadirServicio";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Servicios";
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
        }
    }
}