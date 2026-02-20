namespace PeluqueriAPP
{
    partial class AnyadirBloqueo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnGuardarBloqueo = new Button();
            calendarioBloqueo = new MonthCalendar();
            txtMotivo = new TextBox();
            label5 = new Label();
            dtpHoraFin = new DateTimePicker();
            label3 = new Label();
            dtpHoraInicio = new DateTimePicker();
            label1 = new Label();
            labelTitulo = new Label();
            panelContenedor = new Panel();
            btnCancelar = new Button();
            panelContenedor.SuspendLayout();
            SuspendLayout();

            // labelTitulo (Mismo estilo que Añadir Cita)
            labelTitulo.BackColor = Color.Transparent;
            labelTitulo.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(0, 5);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(580, 75);
            labelTitulo.Text = "Bloqueo Horario";
            labelTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // panelContenedor (Translúcido)
            panelContenedor.BackColor = Color.FromArgb(180, 240, 240, 240);
            panelContenedor.Controls.Add(calendarioBloqueo);
            panelContenedor.Controls.Add(label1);
            panelContenedor.Controls.Add(label3);
            panelContenedor.Controls.Add(label5);
            panelContenedor.Location = new Point(30, 85);
            panelContenedor.Size = new Size(520, 320);

            // Labels internos
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(50, 50, 50);
            label1.Location = new Point(20, 30);
            label1.Text = "HORA INICIO:";

            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(50, 50, 50);
            label3.Location = new Point(20, 100);
            label3.Text = "HORA FIN:";

            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(50, 50, 50);
            label5.Location = new Point(20, 170);
            label5.Text = "MOTIVO:";

            // calendarioBloqueo
            calendarioBloqueo.Location = new Point(265, 30);
            calendarioBloqueo.MaxSelectionCount = 1;

            // btnGuardarBloqueo (SeaGreen como el de citas)
            btnGuardarBloqueo.BackColor = Color.SeaGreen;
            btnGuardarBloqueo.Cursor = Cursors.Hand;
            btnGuardarBloqueo.FlatAppearance.BorderSize = 0;
            btnGuardarBloqueo.FlatStyle = FlatStyle.Flat;
            btnGuardarBloqueo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardarBloqueo.ForeColor = Color.White;
            btnGuardarBloqueo.Location = new Point(100, 425);
            btnGuardarBloqueo.Size = new Size(180, 45);
            btnGuardarBloqueo.Text = "APLICAR BLOQUEO";

            // btnCancelar (Crimson)
            btnCancelar.BackColor = Color.Crimson;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(300, 425);
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Click += (s, e) => this.Close();

            // AnyadirBloqueo Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch; // Por si usas fondo degradado
            BackColor = Color.FromArgb(45, 45, 48); // Fondo oscuro base
            ClientSize = new Size(580, 500);
            Controls.Add(panelContenedor);
            Controls.Add(labelTitulo);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardarBloqueo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AnyadirBloqueo";
            StartPosition = FormStartPosition.CenterParent;
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelContenedor;
        private Button btnGuardarBloqueo;
        private Button btnCancelar;
        private MonthCalendar calendarioBloqueo;
        private TextBox txtMotivo;
        private Label label5;
        private DateTimePicker dtpHoraFin;
        private Label label3;
        private DateTimePicker dtpHoraInicio;
        private Label label1;
        private Label labelTitulo;
    }
}