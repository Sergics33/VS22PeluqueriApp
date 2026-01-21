namespace PeluqueriAPP
{
    partial class AnyadirAgenda
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
            ((System.ComponentModel.ISupportInitialize)numSillas).BeginInit();
            panelContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // label7 (Título Principal)
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(45, 45, 45);
            label7.Location = new Point(25, 20);
            label7.Name = "label7";
            label7.Size = new Size(318, 41);
            label7.TabIndex = 15;
            label7.Text = "AÑADIR AL HORARIO";
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.White;
            panelContenedor.BorderStyle = BorderStyle.FixedSingle;
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
            panelContenedor.Location = new Point(25, 80);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(345, 305);
            panelContenedor.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.5F);
            label1.Location = new Point(15, 15);
            label1.Name = "label1";
            label1.Size = new Size(36, 17);
            label1.Text = "Aula:";
            // 
            // tbAula
            // 
            tbAula.Font = new Font("Segoe UI", 10F);
            tbAula.Location = new Point(15, 35);
            tbAula.Name = "tbAula";
            tbAula.Size = new Size(310, 25);
            tbAula.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.5F);
            label2.Location = new Point(15, 75);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.Text = "Servicio:";
            // 
            // cbServicios
            // 
            cbServicios.DropDownStyle = ComboBoxStyle.DropDownList;
            cbServicios.Font = new Font("Segoe UI", 10F);
            cbServicios.Location = new Point(15, 95);
            cbServicios.Name = "cbServicios";
            cbServicios.Size = new Size(145, 25);
            cbServicios.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.5F);
            label3.Location = new Point(180, 75);
            label3.Name = "label3";
            label3.Size = new Size(47, 17);
            label3.Text = "Grupo:";
            // 
            // cbGrupos
            // 
            cbGrupos.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGrupos.Font = new Font("Segoe UI", 10F);
            cbGrupos.Location = new Point(180, 95);
            cbGrupos.Name = "cbGrupos";
            cbGrupos.Size = new Size(145, 25);
            cbGrupos.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.5F);
            label4.Location = new Point(15, 135);
            label4.Name = "label4";
            label4.Size = new Size(121, 17);
            label4.Text = "Fecha y Hora Inicio:";
            // 
            // dtpInicio
            // 
            dtpInicio.Font = new Font("Segoe UI", 10F);
            dtpInicio.Location = new Point(15, 155);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(310, 25);
            dtpInicio.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.5F);
            label5.Location = new Point(15, 195);
            label5.Name = "label5";
            label5.Size = new Size(107, 17);
            label5.Text = "Fecha y Hora Fin:";
            // 
            // dtpFin
            // 
            dtpFin.Font = new Font("Segoe UI", 10F);
            dtpFin.Location = new Point(15, 215);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(310, 25);
            dtpFin.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.5F);
            label6.Location = new Point(15, 255);
            label6.Name = "label6";
            label6.Size = new Size(125, 17);
            label6.Text = "Sillas Disponibles:";
            // 
            // numSillas
            // 
            numSillas.Font = new Font("Segoe UI", 10F);
            numSillas.Location = new Point(160, 253);
            numSillas.Name = "numSillas";
            numSillas.Size = new Size(165, 25);
            numSillas.TabIndex = 12;
            numSillas.TextAlign = HorizontalAlignment.Center;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(255, 192, 128);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(185, 405);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(185, 45);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Añadir Horario";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(230, 230, 230);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(64, 64, 64);
            btnCancelar.Location = new Point(25, 405);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 45);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // AnyadirAgenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(400, 480);
            Controls.Add(panelContenedor);
            Controls.Add(label7);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AnyadirAgenda";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Horario";
            Load += AnyadirAgenda_Load;
            ((System.ComponentModel.ISupportInitialize)numSillas).EndInit();
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
    }
}