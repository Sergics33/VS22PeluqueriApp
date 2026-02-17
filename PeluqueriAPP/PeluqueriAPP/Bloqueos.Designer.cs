namespace PeluqueriAPP
{
    partial class Bloqueos
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label4 = new Label();
            lblTitulo = new Label();
            label2 = new Label();
            lblUbi = new Label();
            lblBernatS = new Label();
            calendarioBloqueo = new MonthCalendar();
            label1 = new Label();
            dtpHoraInicio = new DateTimePicker();
            label3 = new Label();
            dtpHoraFin = new DateTimePicker();
            label5 = new Label();
            txtMotivo = new TextBox();
            panelContenedor = new Panel();
            btnGuardarBloqueo = new Button();
            panelContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(59, 96);
            label4.Name = "label4";
            label4.Size = new Size(214, 17);
            label4.TabIndex = 80;
            label4.Text = "Administración de Bloqueo Horario";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(45, 45, 48);
            lblTitulo.Location = new Point(53, 52);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(272, 45);
            lblTitulo.TabIndex = 81;
            lblTitulo.Text = "Bloqueo Horario";
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(230, 230, 230);
            label2.Location = new Point(-1, 44);
            label2.Name = "label2";
            label2.Size = new Size(1045, 1);
            label2.TabIndex = 82;
            // 
            // lblUbi
            // 
            lblUbi.AutoSize = true;
            lblUbi.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUbi.ForeColor = Color.FromArgb(255, 128, 0);
            lblUbi.Location = new Point(153, 24);
            lblUbi.Name = "lblUbi";
            lblUbi.Size = new Size(67, 20);
            lblUbi.TabIndex = 83;
            lblUbi.Text = "Bloqueo";
            // 
            // lblBernatS
            // 
            lblBernatS.AutoSize = true;
            lblBernatS.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBernatS.ForeColor = SystemColors.ControlDark;
            lblBernatS.Location = new Point(49, 23);
            lblBernatS.Name = "lblBernatS";
            lblBernatS.Size = new Size(108, 20);
            lblBernatS.TabIndex = 84;
            lblBernatS.Text = "Bernat Sarriá >";
            // 
            // calendarioBloqueo
            // 
            calendarioBloqueo.BackColor = Color.White;
            calendarioBloqueo.Location = new Point(347, 17);
            calendarioBloqueo.Name = "calendarioBloqueo";
            calendarioBloqueo.TabIndex = 1;
            calendarioBloqueo.TitleBackColor = Color.FromArgb(255, 128, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(77, 17);
            label1.TabIndex = 6;
            label1.Text = "Hora Inicio:";
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(110, 17);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Size = new Size(95, 23);
            dtpHoraInicio.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.Location = new Point(20, 60);
            label3.Name = "label3";
            label3.Size = new Size(63, 17);
            label3.TabIndex = 4;
            label3.Text = "Hora Fin:";
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(110, 57);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.Size = new Size(95, 23);
            dtpHoraFin.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.Location = new Point(20, 100);
            label5.Name = "label5";
            label5.Size = new Size(54, 17);
            label5.TabIndex = 2;
            label5.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            txtMotivo.BorderStyle = BorderStyle.FixedSingle;
            txtMotivo.Location = new Point(110, 97);
            txtMotivo.Multiline = true;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.PlaceholderText = "Escriba el motivo del bloqueo...";
            txtMotivo.Size = new Size(200, 60);
            txtMotivo.TabIndex = 1;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.White;
            panelContenedor.Controls.Add(btnGuardarBloqueo);
            panelContenedor.Controls.Add(calendarioBloqueo);
            panelContenedor.Controls.Add(txtMotivo);
            panelContenedor.Controls.Add(label5);
            panelContenedor.Controls.Add(dtpHoraFin);
            panelContenedor.Controls.Add(label3);
            panelContenedor.Controls.Add(dtpHoraInicio);
            panelContenedor.Controls.Add(label1);
            panelContenedor.Location = new Point(59, 170);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(565, 233);
            panelContenedor.TabIndex = 79;
            // 
            // btnGuardarBloqueo
            // 
            btnGuardarBloqueo.BackColor = Color.FromArgb(255, 128, 0);
            btnGuardarBloqueo.Cursor = Cursors.Hand;
            btnGuardarBloqueo.FlatAppearance.BorderSize = 0;
            btnGuardarBloqueo.FlatStyle = FlatStyle.Flat;
            btnGuardarBloqueo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardarBloqueo.ForeColor = Color.White;
            btnGuardarBloqueo.Location = new Point(77, 173);
            btnGuardarBloqueo.Name = "btnGuardarBloqueo";
            btnGuardarBloqueo.Size = new Size(200, 40);
            btnGuardarBloqueo.TabIndex = 0;
            btnGuardarBloqueo.Text = "APLICAR BLOQUEO";
            btnGuardarBloqueo.UseVisualStyleBackColor = false;
            // 
            // Bloqueos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1014, 568);
            Controls.Add(panelContenedor);
            Controls.Add(label4);
            Controls.Add(lblTitulo);
            Controls.Add(label2);
            Controls.Add(lblUbi);
            Controls.Add(lblBernatS);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Bloqueos";
            Text = "Bloqueos";
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label lblTitulo;
        private Label label2;
        private Label lblUbi;
        private Label lblBernatS;
        private MonthCalendar calendarioBloqueo;
        private Label label1;
        private DateTimePicker dtpHoraInicio;
        private Label label3;
        private DateTimePicker dtpHoraFin;
        private Label label5;
        private TextBox txtMotivo;
        private Panel panelContenedor;
        private Button btnGuardarBloqueo;
    }
}