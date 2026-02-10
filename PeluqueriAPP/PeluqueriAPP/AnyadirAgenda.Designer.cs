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
            label1 = new Label();
            tbAula = new TextBox();
            label2 = new Label();
            label3 = new Label();
            cbServicios = new ComboBox();
            cbGrupos = new ComboBox();
            label4 = new Label();
            dtpInicio = new DateTimePicker();
            label5 = new Label();
            dtpFin = new DateTimePicker();
            label6 = new Label();
            numSillas = new NumericUpDown();
            btnGuardar = new Button();
            btnCancelar = new Button();
            label7 = new Label();
            panelContenedor = new Panel();
            monthCalendar1 = new MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)numSillas).BeginInit();
            panelContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // label7 (Título Principal)
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
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
            panelContenedor.BackColor = Color.FromArgb(245, 255, 255, 255);
            panelContenedor.Controls.Add(monthCalendar1);
            panelContenedor.Controls.Add(label1);
            panelContenedor.Controls.Add(tbAula);
            panelContenedor.Controls.Add(label2);
            panelContenedor.Controls.Add(cbServicios);
            panelContenedor.Controls.Add(label3);
            panelContenedor.Controls.Add(cbGrupos);
            panelContenedor.Controls.Add(label4);
            panelContenedor.Controls.Add(dtpInicio);
            panelContenedor.Controls.Add(label5);
            panelContenedor.Controls.Add(dtpFin);
            panelContenedor.Controls.Add(label6);
            panelContenedor.Controls.Add(numSillas);
            panelContenedor.Location = new Point(30, 85);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(590, 310);
            panelContenedor.TabIndex = 1;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(380, 50);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 13;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(31, 31, 31);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.Text = "AULA:";
            // 
            // tbAula
            // 
            tbAula.BorderStyle = BorderStyle.None;
            tbAula.Font = new Font("Segoe UI", 11F);
            tbAula.Location = new Point(20, 45);
            tbAula.Name = "tbAula";
            tbAula.Size = new Size(340, 20);
            tbAula.TabIndex = 2;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(31, 31, 31);
            label2.Location = new Point(20, 90);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.Text = "SERVICIO:";
            // 
            // cbServicios
            // 
            cbServicios.FlatStyle = FlatStyle.Flat;
            cbServicios.Location = new Point(20, 115);
            cbServicios.Name = "cbServicios";
            cbServicios.Size = new Size(160, 23);
            cbServicios.TabIndex = 4;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(31, 31, 31);
            label3.Location = new Point(200, 90);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.Text = "GRUPO:";
            // 
            // cbGrupos
            // 
            cbGrupos.FlatStyle = FlatStyle.Flat;
            cbGrupos.Location = new Point(200, 115);
            cbGrupos.Name = "cbGrupos";
            cbGrupos.Size = new Size(160, 23);
            cbGrupos.TabIndex = 6;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(31, 31, 31);
            label4.Location = new Point(20, 160);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.Text = "HORA INICIO:";
            // 
            // dtpInicio
            // 
            dtpInicio.Location = new Point(20, 185);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(160, 23);
            dtpInicio.TabIndex = 8;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(31, 31, 31);
            label5.Location = new Point(200, 160);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.Text = "HORA FIN:";
            // 
            // dtpFin
            // 
            dtpFin.Location = new Point(200, 185);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(160, 23);
            dtpFin.TabIndex = 10;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(31, 31, 31);
            label6.Location = new Point(20, 230);
            label6.Name = "label6";
            label6.Size = new Size(180, 23);
            label6.Text = "SILLAS DISPONIBLES:";
            // 
            // numSillas
            // 
            numSillas.BorderStyle = BorderStyle.None;
            numSillas.Location = new Point(20, 256);
            numSillas.Name = "numSillas";
            numSillas.Size = new Size(100, 19);
            numSillas.TabIndex = 12;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(30, 130, 70);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(130, 420);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(180, 45);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "AÑADIR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(180, 40, 40);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(340, 420);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // AnyadirAgenda
            // 
            ClientSize = new Size(650, 500);
            Controls.Add(label7);
            Controls.Add(panelContenedor);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "AnyadirAgenda";
            StartPosition = FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)numSillas).EndInit();
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelContenedor;
        private Label label1;
        private TextBox tbAula;
        private Label label2;
        private Label label3;
        private ComboBox cbServicios;
        private ComboBox cbGrupos;
        private Label label4;
        private DateTimePicker dtpInicio;
        private Label label5;
        private DateTimePicker dtpFin;
        private Label label6;
        private NumericUpDown numSillas;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label label7;
        private MonthCalendar monthCalendar1;
    }
}