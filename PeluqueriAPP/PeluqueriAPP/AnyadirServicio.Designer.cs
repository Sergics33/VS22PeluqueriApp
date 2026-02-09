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
            // lbltitulo (Estilo Home/Login)
            // 
            lbltitulo.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            lbltitulo.ForeColor = Color.FromArgb(45, 45, 48); // Antracita
            lbltitulo.Location = new Point(0, 15);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new Size(420, 50);
            lbltitulo.TabIndex = 0;
            lbltitulo.Text = "Añadir Servicio";
            lbltitulo.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.White;
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
            // Estilo Común para Labels y Inputs
            // 
            Color colorLabelSutil = Color.FromArgb(120, 120, 120);
            Font fuenteLabel = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            Color colorFondoInput = Color.FromArgb(242, 242, 242);
            Font fuenteInput = new Font("Segoe UI", 12.5F);
            int anchoInput = 320;

            // Nombre
            lblNombre.AutoSize = true;
            lblNombre.Font = fuenteLabel;
            lblNombre.ForeColor = colorLabelSutil;
            lblNombre.Location = new Point(20, 15);
            lblNombre.Text = "NOMBRE";

            tbNombre.BackColor = colorFondoInput;
            tbNombre.BorderStyle = BorderStyle.None;
            tbNombre.Font = fuenteInput;
            tbNombre.Location = new Point(20, 38);
            tbNombre.Size = new Size(anchoInput, 23);

            // Tipo (ComboBox)
            lblTipo.AutoSize = true;
            lblTipo.Font = fuenteLabel;
            lblTipo.ForeColor = colorLabelSutil;
            lblTipo.Location = new Point(20, 80);
            lblTipo.Text = "TIPO";

            comboBoxTipos.BackColor = colorFondoInput;
            comboBoxTipos.FlatStyle = FlatStyle.Flat;
            comboBoxTipos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipos.Font = fuenteInput;
            comboBoxTipos.Location = new Point(20, 103);
            comboBoxTipos.Size = new Size(anchoInput, 31);

            // Descripción
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = fuenteLabel;
            lblDescripcion.ForeColor = colorLabelSutil;
            lblDescripcion.Location = new Point(20, 150);
            lblDescripcion.Text = "DESCRIPCIÓN";

            tbDescripcion.BackColor = colorFondoInput;
            tbDescripcion.BorderStyle = BorderStyle.None;
            tbDescripcion.Font = fuenteInput;
            tbDescripcion.Location = new Point(20, 173);
            tbDescripcion.Size = new Size(anchoInput, 23);

            // Duración
            lblDuracion.AutoSize = true;
            lblDuracion.Font = fuenteLabel;
            lblDuracion.ForeColor = colorLabelSutil;
            lblDuracion.Location = new Point(20, 220);
            lblDuracion.Text = "DURACIÓN (MIN)";

            tbDuracion.BackColor = colorFondoInput;
            tbDuracion.BorderStyle = BorderStyle.None;
            tbDuracion.Font = fuenteInput;
            tbDuracion.Location = new Point(20, 243);
            tbDuracion.Size = new Size(anchoInput, 23);

            // Precio
            lblPrecio.AutoSize = true;
            lblPrecio.Font = fuenteLabel;
            lblPrecio.ForeColor = colorLabelSutil;
            lblPrecio.Location = new Point(20, 290);
            lblPrecio.Text = "PRECIO (€)";

            tbPrecio.BackColor = colorFondoInput;
            tbPrecio.BorderStyle = BorderStyle.None;
            tbPrecio.Font = fuenteInput;
            tbPrecio.Location = new Point(20, 313);
            tbPrecio.Size = new Size(anchoInput, 23);

            // 
            // btnAnyadir (Estilo Botón Principal)
            // 
            btnAnyadir.BackColor = Color.FromArgb(45, 45, 48); // Antracita
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
            // AnyadirServicio (Configuración Form)
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
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