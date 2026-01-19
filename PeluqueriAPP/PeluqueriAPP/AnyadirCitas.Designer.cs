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
            SuspendLayout();
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(177, 136);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(121, 23);
            cmbCliente.TabIndex = 0;
            // 
            // cmbAgenda
            // 
            cmbAgenda.FormattingEnabled = true;
            cmbAgenda.Location = new Point(177, 186);
            cmbAgenda.Name = "cmbAgenda";
            cmbAgenda.Size = new Size(121, 23);
            cmbAgenda.TabIndex = 1;
            // 
            // lbCliente
            // 
            lbCliente.AutoSize = true;
            lbCliente.Location = new Point(114, 139);
            lbCliente.Name = "lbCliente";
            lbCliente.Size = new Size(47, 15);
            lbCliente.TabIndex = 2;
            lbCliente.Text = "Cliente:";
            // 
            // lbAgenda
            // 
            lbAgenda.AutoSize = true;
            lbAgenda.Location = new Point(114, 190);
            lbAgenda.Name = "lbAgenda";
            lbAgenda.Size = new Size(51, 15);
            lbAgenda.TabIndex = 3;
            lbAgenda.Text = "Agenda:";
            // 
            // dtpFechaHora
            // 
            dtpFechaHora.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFechaHora.Format = DateTimePickerFormat.Custom;
            dtpFechaHora.Location = new Point(177, 230);
            dtpFechaHora.Name = "dtpFechaHora";
            dtpFechaHora.RightToLeft = RightToLeft.Yes;
            dtpFechaHora.ShowUpDown = true;
            dtpFechaHora.Size = new Size(121, 23);
            dtpFechaHora.TabIndex = 4;
            // 
            // lbFecha
            // 
            lbFecha.AutoSize = true;
            lbFecha.Location = new Point(130, 236);
            lbFecha.Name = "lbFecha";
            lbFecha.Size = new Size(41, 15);
            lbFecha.TabIndex = 5;
            lbFecha.Text = "Fecha:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(127, 313);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(238, 313);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // AnyadirCitas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}