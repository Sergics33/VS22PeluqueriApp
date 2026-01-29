namespace PeluqueriAPP
{
    partial class AnyadirCitas
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelContenedor; // Panel para agrupar la info

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
            panelContenedor = new Panel();
            monthCalendarCitas = new MonthCalendar();
            panelContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Font = new Font("Segoe UI", 10F);
            cmbCliente.Location = new Point(20, 35);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(300, 25);
            cmbCliente.TabIndex = 0;
            // 
            // cmbGrupo
            // 
            cmbGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupo.Font = new Font("Segoe UI", 10F);
            cmbGrupo.Location = new Point(20, 100);
            cmbGrupo.Name = "cmbGrupo";
            cmbGrupo.Size = new Size(300, 25);
            cmbGrupo.TabIndex = 1;
            // 
            // lbCliente
            // 
            lbCliente.AutoSize = true;
            lbCliente.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lbCliente.ForeColor = Color.FromArgb(64, 64, 64);
            lbCliente.Location = new Point(20, 15);
            lbCliente.Name = "lbCliente";
            lbCliente.Size = new Size(52, 17);
            lbCliente.TabIndex = 0;
            lbCliente.Text = "Cliente:";
            // 
            // lbGrupo
            // 
            lbGrupo.AutoSize = true;
            lbGrupo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lbGrupo.ForeColor = Color.FromArgb(64, 64, 64);
            lbGrupo.Location = new Point(20, 80);
            lbGrupo.Name = "lbGrupo";
            lbGrupo.Size = new Size(49, 17);
            lbGrupo.TabIndex = 1;
            lbGrupo.Text = "Grupo:";
            // 
            // lbFecha
            // 
            lbFecha.AutoSize = true;
            lbFecha.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lbFecha.ForeColor = Color.FromArgb(64, 64, 64);
            lbFecha.Location = new Point(20, 210);
            lbFecha.Name = "lbFecha";
            lbFecha.Size = new Size(46, 17);
            lbFecha.TabIndex = 10;
            lbFecha.Text = "Fecha:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(255, 192, 128);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(171, 385);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(175, 45);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "GUARDAR CITA";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(230, 230, 230);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(64, 64, 64);
            btnCancelar.Location = new Point(386, 385);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(160, 45);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(0, 20);
            label1.Name = "label1";
            label1.Size = new Size(400, 50);
            label1.TabIndex = 8;
            label1.Text = "AÑADIR CITA";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbServicio
            // 
            cmbServicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServicio.Font = new Font("Segoe UI", 10F);
            cmbServicio.Location = new Point(20, 165);
            cmbServicio.Name = "cmbServicio";
            cmbServicio.Size = new Size(300, 25);
            cmbServicio.TabIndex = 9;
            // 
            // lblServicio
            // 
            lblServicio.AutoSize = true;
            lblServicio.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblServicio.ForeColor = Color.FromArgb(64, 64, 64);
            lblServicio.Location = new Point(20, 145);
            lblServicio.Name = "lblServicio";
            lblServicio.Size = new Size(58, 17);
            lblServicio.TabIndex = 2;
            lblServicio.Text = "Servicio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(180, 210);
            label2.Name = "label2";
            label2.Size = new Size(41, 17);
            label2.TabIndex = 14;
            label2.Text = "Hora:";
            // 
            // cmbHoras
            // 
            cmbHoras.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHoras.Font = new Font("Segoe UI", 10F);
            cmbHoras.Location = new Point(180, 230);
            cmbHoras.Name = "cmbHoras";
            cmbHoras.Size = new Size(140, 25);
            cmbHoras.TabIndex = 11;
            // 
            // cmbDias
            // 
            cmbDias.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDias.Font = new Font("Segoe UI", 10F);
            cmbDias.Location = new Point(20, 230);
            cmbDias.Name = "cmbDias";
            cmbDias.Size = new Size(140, 25);
            cmbDias.TabIndex = 13;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.White;
            panelContenedor.BorderStyle = BorderStyle.FixedSingle;
            panelContenedor.Controls.Add(monthCalendarCitas);
            panelContenedor.Controls.Add(lbCliente);
            panelContenedor.Controls.Add(cmbCliente);
            panelContenedor.Controls.Add(lbGrupo);
            panelContenedor.Controls.Add(cmbGrupo);
            panelContenedor.Controls.Add(lblServicio);
            panelContenedor.Controls.Add(cmbServicio);
            panelContenedor.Controls.Add(lbFecha);
            panelContenedor.Controls.Add(cmbDias);
            panelContenedor.Controls.Add(label2);
            panelContenedor.Controls.Add(cmbHoras);
            panelContenedor.Location = new Point(25, 85);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(592, 280);
            panelContenedor.TabIndex = 14;
            // 
            // monthCalendarCitas
            // 
            monthCalendarCitas.Location = new Point(360, 65);
            monthCalendarCitas.Name = "monthCalendarCitas";
            monthCalendarCitas.TabIndex = 15;
            // 
            // AnyadirCitas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(673, 460);
            Controls.Add(panelContenedor);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AnyadirCitas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Citas";
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
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
        private ComboBox cmbHoras;
        private ComboBox cmbDias;
        private MonthCalendar monthCalendarCitas;
    }
}