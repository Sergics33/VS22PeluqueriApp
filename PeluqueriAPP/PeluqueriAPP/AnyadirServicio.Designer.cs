using System.Drawing;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    partial class AnyadirServicio
    {
        private System.ComponentModel.IContainer components = null;

        // Definición de controles
        private Label lbltitulo;
        private Label lblNombre;
        private TextBox tbNombre;
        private Label lblDescripcion;
        private TextBox tbDescripcion;
        private Label lblDuracion;
        private TextBox tbDuracion;
        private Label lblPrecio;
        private TextBox tbPrecio;
        private Button btnAnyadir;
        private ComboBox comboBoxTipos;
        private Label lblTipo;
        private Panel panelContenedor;

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
            comboBoxTipos = new ComboBox();
            lblTipo = new Label();
            panelContenedor = new Panel();
            panelContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // lbltitulo
            // 
            lbltitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            lbltitulo.ForeColor = Color.ForestGreen;
            lbltitulo.Location = new Point(0, 20);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new Size(380, 45);
            lbltitulo.TabIndex = 0;
            lbltitulo.Text = "AÑADIR SERVICIO";
            lbltitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.White;
            panelContenedor.BorderStyle = BorderStyle.FixedSingle;
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
            panelContenedor.Location = new Point(25, 80);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(330, 310);
            panelContenedor.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(64, 64, 64);
            lblNombre.Location = new Point(20, 15);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(63, 19);
            lblNombre.Text = "Nombre:";
            // 
            // tbNombre
            // 
            tbNombre.Font = new Font("Segoe UI", 10F);
            tbNombre.Location = new Point(20, 37);
            tbNombre.Name = "tbNombre";
            tbNombre.Size = new Size(285, 25);
            tbNombre.TabIndex = 2;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTipo.ForeColor = Color.FromArgb(64, 64, 64);
            lblTipo.Location = new Point(20, 72);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(39, 19);
            lblTipo.Text = "Tipo:";
            // 
            // comboBoxTipos
            // 
            comboBoxTipos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipos.Font = new Font("Segoe UI", 10F);
            comboBoxTipos.Location = new Point(20, 94);
            comboBoxTipos.Name = "comboBoxTipos";
            comboBoxTipos.Size = new Size(285, 25);
            comboBoxTipos.TabIndex = 3;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblDescripcion.ForeColor = Color.FromArgb(64, 64, 64);
            lblDescripcion.Location = new Point(20, 129);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(86, 19);
            lblDescripcion.Text = "Descripción:";
            // 
            // tbDescripcion
            // 
            tbDescripcion.Font = new Font("Segoe UI", 10F);
            tbDescripcion.Location = new Point(20, 151);
            tbDescripcion.Name = "tbDescripcion";
            tbDescripcion.Size = new Size(285, 25);
            tbDescripcion.TabIndex = 4;
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblDuracion.ForeColor = Color.FromArgb(64, 64, 64);
            lblDuracion.Location = new Point(20, 186);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(68, 19);
            lblDuracion.Text = "Duración:";
            // 
            // tbDuracion
            // 
            tbDuracion.Font = new Font("Segoe UI", 10F);
            tbDuracion.Location = new Point(20, 208);
            tbDuracion.Name = "tbDuracion";
            tbDuracion.Size = new Size(285, 25);
            tbDuracion.TabIndex = 5;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblPrecio.ForeColor = Color.FromArgb(64, 64, 64);
            lblPrecio.Location = new Point(20, 243);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(50, 19);
            lblPrecio.Text = "Precio:";
            // 
            // tbPrecio
            // 
            tbPrecio.Font = new Font("Segoe UI", 10F);
            tbPrecio.Location = new Point(20, 265);
            tbPrecio.Name = "tbPrecio";
            tbPrecio.Size = new Size(285, 25);
            tbPrecio.TabIndex = 6;
            // 
            // btnAnyadir
            // 
            btnAnyadir.BackColor = Color.FromArgb(255, 192, 128);
            btnAnyadir.FlatAppearance.BorderSize = 0;
            btnAnyadir.FlatStyle = FlatStyle.Flat;
            btnAnyadir.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnAnyadir.ForeColor = Color.White;
            btnAnyadir.Location = new Point(25, 405);
            btnAnyadir.Name = "btnAnyadir";
            btnAnyadir.Size = new Size(330, 45);
            btnAnyadir.TabIndex = 7;
            btnAnyadir.Text = "AÑADIR SERVICIO";
            btnAnyadir.UseVisualStyleBackColor = false;
            // 
            // AnyadirServicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(380, 475);
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
            PerformLayout();
        }
    }
}