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
            // 
            // label7 (Título)
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(0, 5);
            label7.Name = "label7";
            label7.Size = new Size(650, 75);
            label7.TabIndex = 0;
            label7.Text = "Añadir al Horario";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.FromArgb(180, 240, 240, 240);
            panelContenedor.Controls.Add(monthCalendar1);
            panelContenedor.Location = new Point(30, 85);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(590, 310);
            panelContenedor.TabIndex = 1;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(385, 40);
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 10;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(130, 420);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(180, 45);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "AÑADIR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(340, 420);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // AnyadirAgenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 500);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(panelContenedor);
            Controls.Add(label7);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AnyadirAgenda";
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