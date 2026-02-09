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
            // label1 (Título Principal) - Un poco más grande
            // 
            label1.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(45, 45, 48);
            label1.Location = new Point(0, 10);
            label1.Name = "label1";
            label1.Size = new Size(580, 65);
            label1.TabIndex = 8;
            label1.Text = "Añadir Nueva Cita";
            label1.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // panelContenedor - Ajustado para dar más espacio
            // 
            panelContenedor.BackColor = Color.White;
            panelContenedor.Controls.Add(monthCalendarCitas);
            panelContenedor.Controls.Add(lbCliente);
            panelContenedor.Controls.Add(cmbCliente);
            panelContenedor.Controls.Add(lbGrupo);
            panelContenedor.Controls.Add(cmbGrupo);
            panelContenedor.Controls.Add(lblServicio);
            panelContenedor.Controls.Add(cmbServicio);
            panelContenedor.Controls.Add(label2);
            panelContenedor.Controls.Add(cmbHoras);
            panelContenedor.Location = new Point(30, 85);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(520, 320);
            panelContenedor.TabIndex = 14;

            // 
            // Estilo de Labels de campo - Fuente subida de 8.5 a 10
            // 
            Color colorLabelSutil = Color.FromArgb(120, 120, 120);
            Font fuenteLabelSutil = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            lbCliente.Font = fuenteLabelSutil;
            lbCliente.ForeColor = colorLabelSutil;
            lbCliente.Location = new Point(20, 15);
            lbCliente.Text = "CLIENTE";
            lbCliente.AutoSize = true;

            lbGrupo.Font = fuenteLabelSutil;
            lbGrupo.ForeColor = colorLabelSutil;
            lbGrupo.Location = new Point(20, 90);
            lbGrupo.Text = "GRUPO";
            lbGrupo.AutoSize = true;

            lblServicio.Font = fuenteLabelSutil;
            lblServicio.ForeColor = colorLabelSutil;
            lblServicio.Location = new Point(20, 165);
            lblServicio.Text = "SERVICIO";
            lblServicio.AutoSize = true;

            label2.Font = fuenteLabelSutil;
            label2.ForeColor = colorLabelSutil;
            label2.Location = new Point(20, 240);
            label2.Text = "HORA";
            label2.AutoSize = true;

            // 
            // Estilo de ComboBox - Fuente subida de 11 a 12.5 y bloques más anchos
            // 
            Color colorFondoInput = Color.FromArgb(242, 242, 242);
            Size tamañoCombo = new Size(220, 32);

            cmbCliente.BackColor = colorFondoInput;
            cmbCliente.FlatStyle = FlatStyle.Flat;
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Font = new Font("Segoe UI", 12.5F);
            cmbCliente.Location = new Point(20, 40);
            cmbCliente.Size = tamañoCombo;

            cmbGrupo.BackColor = colorFondoInput;
            cmbGrupo.FlatStyle = FlatStyle.Flat;
            cmbGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupo.Font = new Font("Segoe UI", 12.5F);
            cmbGrupo.Location = new Point(20, 115);
            cmbGrupo.Size = tamañoCombo;

            cmbServicio.BackColor = colorFondoInput;
            cmbServicio.FlatStyle = FlatStyle.Flat;
            cmbServicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServicio.Font = new Font("Segoe UI", 12.5F);
            cmbServicio.Location = new Point(20, 190);
            cmbServicio.Size = tamañoCombo;

            cmbHoras.BackColor = colorFondoInput;
            cmbHoras.FlatStyle = FlatStyle.Flat;
            cmbHoras.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHoras.Font = new Font("Segoe UI", 12.5F);
            cmbHoras.Location = new Point(20, 265);
            cmbHoras.Size = tamañoCombo;

            // 
            // monthCalendarCitas - Lo movemos ligeramente a la derecha
            // 
            monthCalendarCitas.Location = new Point(265, 40);
            monthCalendarCitas.MaxSelectionCount = 1;

            // 
            // Botones (Mantienen su tamaño y estilo)
            // 
            btnGuardar.BackColor = Color.FromArgb(45, 45, 48);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(100, 420);
            btnGuardar.Size = new Size(180, 45);
            btnGuardar.Text = "GUARDAR CITA";
            btnGuardar.Click += btnGuardar_Click_1;

            btnCancelar.BackColor = Color.FromArgb(210, 210, 210);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(60, 60, 60);
            btnCancelar.Location = new Point(300, 420);
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Click += btnCancelar_Click_1;

            // 
            // Formulario AnyadirCitas - Ajustado el ClientSize total
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(580, 500);
            Controls.Add(panelContenedor);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AnyadirCitas";
            StartPosition = FormStartPosition.CenterParent;
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelContenedor;
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