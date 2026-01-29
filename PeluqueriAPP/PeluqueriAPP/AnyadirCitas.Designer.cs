namespace PeluqueriAPP
{
    partial class AnyadirCitas
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelContenedor;

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
            btnGuardar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            cmbServicio = new ComboBox();
            lblServicio = new Label();
            label2 = new Label();
            cmbHoras = new ComboBox();
            panelContenedor = new Panel();
            monthCalendarCitas = new MonthCalendar();
            panelContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // label1 (Título)
            // 
            label1.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(0, 20);
            label1.Name = "label1";
            label1.Size = new Size(492, 50);
            label1.TabIndex = 8;
            label1.Text = "AÑADIR CITA";
            label1.TextAlign = ContentAlignment.MiddleCenter;
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
            panelContenedor.Controls.Add(label2);
            panelContenedor.Controls.Add(cmbHoras);
            panelContenedor.Location = new Point(25, 85);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(440, 285);
            panelContenedor.TabIndex = 14;
            // 
            // lbCliente
            // 
            lbCliente.AutoSize = true;
            lbCliente.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lbCliente.ForeColor = Color.FromArgb(64, 64, 64);
            lbCliente.Location = new Point(15, 15);
            lbCliente.Name = "lbCliente";
            lbCliente.Size = new Size(52, 17);
            lbCliente.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Font = new Font("Segoe UI", 10F);
            cmbCliente.Location = new Point(15, 35);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(185, 25);
            // 
            // lbGrupo
            // 
            lbGrupo.AutoSize = true;
            lbGrupo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lbGrupo.ForeColor = Color.FromArgb(64, 64, 64);
            lbGrupo.Location = new Point(15, 80);
            lbGrupo.Name = "lbGrupo";
            lbGrupo.Size = new Size(49, 17);
            lbGrupo.Text = "Grupo:";
            // 
            // cmbGrupo
            // 
            cmbGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupo.Font = new Font("Segoe UI", 10F);
            cmbGrupo.Location = new Point(15, 100);
            cmbGrupo.Name = "cmbGrupo";
            cmbGrupo.Size = new Size(185, 25);
            // 
            // lblServicio
            // 
            lblServicio.AutoSize = true;
            lblServicio.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblServicio.ForeColor = Color.FromArgb(64, 64, 64);
            lblServicio.Location = new Point(15, 145);
            lblServicio.Name = "lblServicio";
            lblServicio.Size = new Size(58, 17);
            lblServicio.Text = "Servicio:";
            // 
            // cmbServicio
            // 
            cmbServicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServicio.Font = new Font("Segoe UI", 10F);
            cmbServicio.Location = new Point(15, 165);
            cmbServicio.Name = "cmbServicio";
            cmbServicio.Size = new Size(185, 25);
            // 
            // label2 (Hora)
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(15, 210);
            label2.Name = "label2";
            label2.Size = new Size(41, 17);
            label2.Text = "Hora:";
            // 
            // cmbHoras
            // 
            cmbHoras.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHoras.Font = new Font("Segoe UI", 10F);
            cmbHoras.Location = new Point(15, 230);
            cmbHoras.Name = "cmbHoras";
            cmbHoras.Size = new Size(185, 25);
            // 
            // monthCalendarCitas
            // 
            monthCalendarCitas.BackColor = Color.White;
            monthCalendarCitas.ForeColor = Color.FromArgb(33, 37, 41);
            monthCalendarCitas.Location = new Point(225, 35);
            monthCalendarCitas.MaxSelectionCount = 1;
            monthCalendarCitas.Name = "monthCalendarCitas";
            monthCalendarCitas.ShowToday = false;
            monthCalendarCitas.ShowTodayCircle = true;
            monthCalendarCitas.TabIndex = 15;
            monthCalendarCitas.TitleBackColor = Color.ForestGreen;
            monthCalendarCitas.TitleForeColor = Color.White;
            monthCalendarCitas.TrailingForeColor = Color.Silver;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(255, 192, 128);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(60, 390);
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
            btnCancelar.Location = new Point(255, 390);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(175, 45);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // AnyadirCitas (Form Properties)
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(492, 465);
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
        private Button btnGuardar;
        private Button btnCancelar;
        private Label label1;
        private ComboBox cmbServicio;
        private Label lblServicio;
        private Label label2;
        private ComboBox cmbHoras;
        private MonthCalendar monthCalendarCitas;
    }
}