namespace PeluqueriAPP
{
    partial class AnyadirCitas
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
            cmbCliente = new ComboBox();
            cmbGrupo = new ComboBox();
            lbCliente = new Label();
            lbGrupo = new Label();
            lbFecha = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            cmbServicio = new ComboBox();
            lblServicio = new Label();
            label2 = new Label();
            cmbHoras = new ComboBox();
            cmbDias = new ComboBox();
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
            // cmbGrupo
            // 
            cmbGrupo.FormattingEnabled = true;
            cmbGrupo.Location = new Point(144, 177);
            cmbGrupo.Name = "cmbGrupo";
            cmbGrupo.Size = new Size(121, 23);
            cmbGrupo.TabIndex = 1;
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
            // lbGrupo
            // 
            lbGrupo.AutoSize = true;
            lbGrupo.Location = new Point(95, 180);
            lbGrupo.Name = "lbGrupo";
            lbGrupo.Size = new Size(43, 15);
            lbGrupo.TabIndex = 3;
            lbGrupo.Text = "Grupo:";
            // 
            // lbFecha
            // 
            lbFecha.AutoSize = true;
            lbFecha.Location = new Point(97, 266);
            lbFecha.Name = "lbFecha";
            lbFecha.Size = new Size(41, 15);
            lbFecha.TabIndex = 5;
            lbFecha.Text = "Fecha:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(255, 192, 128);
            btnGuardar.Font = new Font("Segoe UI", 15F);
            btnGuardar.Location = new Point(95, 359);
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
            btnCancelar.Location = new Point(212, 359);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(95, 43);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
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
            // cmbServicio
            // 
            cmbServicio.FormattingEnabled = true;
            cmbServicio.Location = new Point(144, 218);
            cmbServicio.Name = "cmbServicio";
            cmbServicio.Size = new Size(121, 23);
            cmbServicio.TabIndex = 9;
            // 
            // lblServicio
            // 
            lblServicio.AutoSize = true;
            lblServicio.Location = new Point(87, 221);
            lblServicio.Name = "lblServicio";
            lblServicio.Size = new Size(51, 15);
            lblServicio.TabIndex = 10;
            lblServicio.Text = "Servicio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(97, 306);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 12;
            label2.Text = "Hora:";
            // 
            // cmbHoras
            // 
            cmbHoras.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHoras.FormattingEnabled = true;
            cmbHoras.Location = new Point(144, 300);
            cmbHoras.Name = "cmbHoras";
            cmbHoras.Size = new Size(121, 23);
            cmbHoras.TabIndex = 11;
            // 
            // cmbDias
            // 
            cmbDias.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDias.FormattingEnabled = true;
            cmbDias.Location = new Point(144, 258);
            cmbDias.Name = "cmbDias";
            cmbDias.Size = new Size(121, 23);
            cmbDias.TabIndex = 13;
            // 
            // AnyadirCitas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 439);
            Controls.Add(cmbDias);
            Controls.Add(label2);
            Controls.Add(cmbHoras);
            Controls.Add(lblServicio);
            Controls.Add(cmbServicio);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lbFecha);
            Controls.Add(lbGrupo);
            Controls.Add(lbCliente);
            Controls.Add(cmbGrupo);
            Controls.Add(cmbCliente);
            Name = "AnyadirCitas";
            Text = "AnyadirCitas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCliente;
        private ComboBox cmbGrupo;
        private Label lbCliente;
        private Label lbGrupo;
        private Label lbFecha;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label label1;
        private ComboBox cmbServicio;
        private Label lblServicio;
        private Label label2;
        private ComboBox cmbHoras; // CAMBIADO A COMBOBOX
        private ComboBox cmbDias;
    }
}