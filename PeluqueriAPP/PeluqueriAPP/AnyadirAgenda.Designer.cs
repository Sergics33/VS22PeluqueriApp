namespace PeluqueriAPP
{
    partial class AnyadirAgenda
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
            ((System.ComponentModel.ISupportInitialize)numSillas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 86);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 0;
            label1.Text = "Aula:";
            // 
            // tbAula
            // 
            tbAula.Location = new Point(138, 86);
            tbAula.Name = "tbAula";
            tbAula.Size = new Size(100, 23);
            tbAula.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 134);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Servicio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 182);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 4;
            label3.Text = "Grupo:";
            // 
            // cbServicios
            // 
            cbServicios.DropDownStyle = ComboBoxStyle.DropDownList;
            cbServicios.FormattingEnabled = true;
            cbServicios.Location = new Point(138, 131);
            cbServicios.Name = "cbServicios";
            cbServicios.Size = new Size(121, 23);
            cbServicios.TabIndex = 5;
            // 
            // cbGrupos
            // 
            cbGrupos.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGrupos.FormattingEnabled = true;
            cbGrupos.Location = new Point(136, 182);
            cbGrupos.Name = "cbGrupos";
            cbGrupos.Size = new Size(121, 23);
            cbGrupos.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 224);
            label4.Name = "label4";
            label4.Size = new Size(111, 15);
            label4.TabIndex = 7;
            label4.Text = "Fecha y Hora Inicio:";
            // 
            // dtpInicio
            // 
            dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpInicio.Format = DateTimePickerFormat.Custom;
            dtpInicio.Location = new Point(138, 220);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(121, 23);
            dtpInicio.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(77, 261);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 9;
            label5.Text = "Hora Fin:";
            // 
            // dtpFin
            // 
            dtpFin.CustomFormat = "HH:mm";
            dtpFin.Format = DateTimePickerFormat.Custom;
            dtpFin.Location = new Point(138, 255);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(121, 23);
            dtpFin.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(96, 301);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 11;
            label6.Text = "Sillas:";
            // 
            // numSillas
            // 
            numSillas.Location = new Point(139, 299);
            numSillas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSillas.Name = "numSillas";
            numSillas.Size = new Size(120, 23);
            numSillas.TabIndex = 12;
            numSillas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(255, 192, 128);
            btnGuardar.Location = new Point(108, 408);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.White;
            btnCancelar.Location = new Point(202, 408);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.BottomCenter;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // AnyadirAgenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 470);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(numSillas);
            Controls.Add(label6);
            Controls.Add(dtpFin);
            Controls.Add(label5);
            Controls.Add(dtpInicio);
            Controls.Add(label4);
            Controls.Add(cbGrupos);
            Controls.Add(cbServicios);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tbAula);
            Controls.Add(label1);
            Name = "AnyadirAgenda";
            Text = "AnyadirAgenda";
            Load += AnyadirAgenda_Load;
            ((System.ComponentModel.ISupportInitialize)numSillas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
    }
}