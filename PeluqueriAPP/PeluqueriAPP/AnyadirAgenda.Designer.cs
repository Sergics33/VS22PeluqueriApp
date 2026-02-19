namespace PeluqueriAPP
{
    partial class AnyadirAgenda
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label7 = new Label();
            panelContenedor = new Panel();
            monthCalendar1 = new MonthCalendar();
            label1 = new Label();
            tbAula = new TextBox();
            label2 = new Label();
            cbServicios = new ComboBox();
            label3 = new Label();
            cbGrupos = new ComboBox();
            label4 = new Label();
            dtpInicio = new DateTimePicker();
            label5 = new Label();
            dtpFin = new DateTimePicker();
            label6 = new Label();
            numSillas = new NumericUpDown();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)numSillas).BeginInit();
            panelContenedor.SuspendLayout();
            SuspendLayout();

            // Título label7
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(0, 5);
            label7.Size = new Size(650, 75);
            label7.Text = "Añadir al Horario";
            label7.TextAlign = ContentAlignment.MiddleCenter;

            // panelContenedor
            panelContenedor.BackColor = Color.FromArgb(180, 240, 240, 240);
            panelContenedor.Controls.Add(monthCalendar1);
            panelContenedor.Controls.Add(label1);
            panelContenedor.Controls.Add(label2);
            panelContenedor.Controls.Add(label3);
            panelContenedor.Controls.Add(label4);
            panelContenedor.Controls.Add(label5);
            panelContenedor.Controls.Add(label6);
            panelContenedor.Location = new Point(30, 85);
            panelContenedor.Size = new Size(590, 310);

            // Estilo Labels (Gris oscuro, Negrita, 9.5pt)
            Color darkGray = Color.FromArgb(50, 50, 50);
            Font labelFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            label1.Text = "AULA:"; label1.AutoSize = true;
            label1.Location = new Point(20, 15);
            label1.BackColor = Color.Transparent; label1.ForeColor = darkGray;
            label1.Font = labelFont;

            label2.Text = "SERVICIO:"; label2.AutoSize = true;
            label2.Location = new Point(20, 85);
            label2.BackColor = Color.Transparent; label2.ForeColor = darkGray;
            label2.Font = labelFont;

            label3.Text = "GRUPO:"; label3.AutoSize = true;
            label3.Location = new Point(200, 85);
            label3.BackColor = Color.Transparent; label3.ForeColor = darkGray;
            label3.Font = labelFont;

            label4.Text = "H. INICIO:"; label4.AutoSize = true;
            label4.Location = new Point(20, 155);
            label4.BackColor = Color.Transparent; label4.ForeColor = darkGray;
            label4.Font = labelFont;

            label5.Text = "H. FIN:"; label5.AutoSize = true;
            label5.Location = new Point(200, 155);
            label5.BackColor = Color.Transparent; label5.ForeColor = darkGray;
            label5.Font = labelFont;

            label6.Text = "SILLAS:"; label6.AutoSize = true;
            label6.Location = new Point(20, 225);
            label6.BackColor = Color.Transparent; label6.ForeColor = darkGray;
            label6.Font = labelFont;

            // monthCalendar1
            monthCalendar1.Location = new Point(385, 40);
            monthCalendar1.MaxSelectionCount = 1;

            // btnGuardar
            btnGuardar.BackColor = Color.SeaGreen;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(130, 420);
            btnGuardar.Size = new Size(180, 45);
            btnGuardar.Text = "AÑADIR";
            btnGuardar.Click += btnGuardar_Click; // FUNCIONALIDAD RESTAURADA

            // btnCancelar
            btnCancelar.BackColor = Color.Crimson;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(340, 420);
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Click += btnCancelar_Click; // FUNCIONALIDAD RESTAURADA

            // Form
            ClientSize = new Size(650, 500);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(panelContenedor);
            Controls.Add(label7);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Horario";

            ((System.ComponentModel.ISupportInitialize)numSillas).EndInit();
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
        }

        private Label label7;
        private Panel panelContenedor;
        private MonthCalendar monthCalendar1;
        private Label label1;
        private TextBox tbAula;
        private Label label2;
        private ComboBox cbServicios;
        private Label label3;
        private ComboBox cbGrupos;
        private Label label4;
        private DateTimePicker dtpInicio;
        private Label label5;
        private DateTimePicker dtpFin;
        private Label label6;
        private NumericUpDown numSillas;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}