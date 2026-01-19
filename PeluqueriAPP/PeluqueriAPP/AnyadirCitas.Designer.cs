namespace PeluqueriAPP
{
    partial class AnyadirCitas
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
            cmbCliente = new ComboBox();
            cmbAgenda = new ComboBox();
            lbCliente = new Label();
            lbAgenda = new Label();
            dtpFechaHora = new DateTimePicker();
            lbFecha = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(144, 127);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(121, 23);
            cmbCliente.TabIndex = 0;
            // 
            // cmbAgenda
            // 
            cmbAgenda.FormattingEnabled = true;
            cmbAgenda.Location = new Point(144, 177);
            cmbAgenda.Name = "cmbAgenda";
            cmbAgenda.Size = new Size(121, 23);
            cmbAgenda.TabIndex = 1;
            // 
            // lbCliente
            // 
            lbCliente.AutoSize = true;
            lbCliente.Location = new Point(91, 130);
            lbCliente.Name = "lbCliente";
            lbCliente.Size = new Size(47, 15);
            lbCliente.TabIndex = 2;
            lbCliente.Text = "Cliente:";
            // 
            // lbAgenda
            // 
            lbAgenda.AutoSize = true;
            lbAgenda.Location = new Point(87, 180);
            lbAgenda.Name = "lbAgenda";
            lbAgenda.Size = new Size(51, 15);
            lbAgenda.TabIndex = 3;
            lbAgenda.Text = "Agenda:";
            // 
            // dtpFechaHora
            // 
            dtpFechaHora.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFechaHora.Format = DateTimePickerFormat.Custom;
            dtpFechaHora.Location = new Point(144, 221);
            dtpFechaHora.Name = "dtpFechaHora";
            dtpFechaHora.RightToLeft = RightToLeft.Yes;
            dtpFechaHora.ShowUpDown = true;
            dtpFechaHora.Size = new Size(121, 23);
            dtpFechaHora.TabIndex = 4;
            // 
            // lbFecha
            // 
            lbFecha.AutoSize = true;
            lbFecha.Location = new Point(97, 227);
            lbFecha.Name = "lbFecha";
            lbFecha.Size = new Size(41, 15);
            lbFecha.TabIndex = 5;
            lbFecha.Text = "Fecha:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(255, 192, 128);
            btnGuardar.Font = new Font("Segoe UI", 15F);
            btnGuardar.Location = new Point(97, 290);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(97, 43);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 15F);
            btnCancelar.Location = new Point(214, 290);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(95, 43);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(59, 35);
            label1.Name = "label1";
            label1.Size = new Size(277, 54);
            label1.TabIndex = 8;
            label1.Text = "AÑADIR CITA";
            // 
            // AnyadirCitas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 371);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lbFecha);
            Controls.Add(dtpFechaHora);
            Controls.Add(lbAgenda);
            Controls.Add(lbCliente);
            Controls.Add(cmbAgenda);
            Controls.Add(cmbCliente);
            Name = "AnyadirCitas";
            Text = "AnyadirCitas";
            Load += AnyadirCitas_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCliente;
        private ComboBox cmbAgenda;
        private Label lbCliente;
        private Label lbAgenda;
        private DateTimePicker dtpFechaHora;
        private Label lbFecha;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label label1;
    }
}