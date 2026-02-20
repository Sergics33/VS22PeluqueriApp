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
            // 
            // btnGuardarBloqueo
            // 
            btnGuardarBloqueo.BackColor = Color.SeaGreen;
            btnGuardarBloqueo.Cursor = Cursors.Hand;
            btnGuardarBloqueo.FlatAppearance.BorderSize = 0;
            btnGuardarBloqueo.FlatStyle = FlatStyle.Flat;
            btnGuardarBloqueo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardarBloqueo.ForeColor = Color.White;
            btnGuardarBloqueo.Location = new Point(100, 425);
            btnGuardarBloqueo.Name = "btnGuardarBloqueo";
            btnGuardarBloqueo.Size = new Size(180, 45);
            btnGuardarBloqueo.TabIndex = 2;
            btnGuardarBloqueo.Text = "APLICAR BLOQUEO";
            btnGuardarBloqueo.UseVisualStyleBackColor = false;
            btnGuardarBloqueo.ClientSizeChanged += btnGuardarBloqueo_Click;
            btnGuardarBloqueo.Click += btnGuardarBloqueo_Click;
            // 
            // calendarioBloqueo
            // 
            calendarioBloqueo.Location = new Point(265, 30);
            calendarioBloqueo.MaxSelectionCount = 1;
            calendarioBloqueo.Name = "calendarioBloqueo";
            calendarioBloqueo.TabIndex = 3;
            // 
            // txtMotivo
            // 
            txtMotivo.Font = new Font("Segoe UI", 10F);
            txtMotivo.Location = new Point(20, 195);
            txtMotivo.Multiline = true;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(220, 100);
            txtMotivo.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(50, 50, 50);
            label5.Location = new Point(20, 170);
            label5.Name = "label5";
            label5.Size = new Size(64, 17);
            label5.TabIndex = 9;
            label5.Text = "MOTIVO:";
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(20, 125);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.Size = new Size(220, 23);
            dtpHoraFin.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(50, 50, 50);
            label3.Location = new Point(20, 100);
            label3.Name = "label3";
            label3.Size = new Size(74, 17);
            label3.TabIndex = 8;
            label3.Text = "HORA FIN:";
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(20, 55);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Size = new Size(220, 23);
            dtpHoraInicio.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(50, 50, 50);
            label1.Location = new Point(20, 30);
            label1.Name = "label1";
            label1.Size = new Size(93, 17);
            label1.TabIndex = 7;
            label1.Text = "HORA INICIO:";
            // 
            // labelTitulo
            // 
            labelTitulo.BackColor = Color.Transparent;
            labelTitulo.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(0, 5);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(580, 75);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Bloqueo Horario";
            labelTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.FromArgb(180, 240, 240, 240);
            panelContenedor.Controls.Add(txtMotivo);
            panelContenedor.Controls.Add(dtpHoraFin);
            panelContenedor.Controls.Add(dtpHoraInicio);
            panelContenedor.Controls.Add(calendarioBloqueo);
            panelContenedor.Controls.Add(label1);
            panelContenedor.Controls.Add(label3);
            panelContenedor.Controls.Add(label5);
            panelContenedor.Location = new Point(30, 85);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(520, 320);
            panelContenedor.TabIndex = 1;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Crimson;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(300, 425);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // AnyadirBloqueo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(580, 500);
            Controls.Add(panelContenedor);
            Controls.Add(labelTitulo);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardarBloqueo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AnyadirBloqueo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Bloqueos";
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