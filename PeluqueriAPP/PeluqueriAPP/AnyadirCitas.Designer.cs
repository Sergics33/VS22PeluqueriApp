namespace PeluqueriAPP
{
    partial class AnyadirCitas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
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

            // label1 (Título)
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 5);
            label1.Name = "label1";
            label1.Size = new Size(580, 75);
            label1.Text = "Añadir Nueva Cita";
            label1.TextAlign = ContentAlignment.MiddleCenter;

            // lbCliente
            lbCliente.AutoSize = true;
            lbCliente.BackColor = Color.Transparent;
            lbCliente.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbCliente.ForeColor = Color.FromArgb(50, 50, 50);
            lbCliente.Location = new Point(20, 15);
            lbCliente.Text = "CLIENTE:";

            // lbGrupo
            lbGrupo.AutoSize = true;
            lbGrupo.BackColor = Color.Transparent;
            lbGrupo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbGrupo.ForeColor = Color.FromArgb(50, 50, 50);
            lbGrupo.Location = new Point(20, 85);
            lbGrupo.Text = "GRUPO:";

            // lblServicio
            lblServicio.AutoSize = true;
            lblServicio.BackColor = Color.Transparent;
            lblServicio.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblServicio.ForeColor = Color.FromArgb(50, 50, 50);
            lblServicio.Location = new Point(20, 155);
            lblServicio.Text = "SERVICIO:";

            // label2 (Hora)
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(50, 50, 50);
            label2.Location = new Point(20, 225);
            label2.Text = "HORA:";

            // ComboBoxes (Se moverán a cápsulas en el .cs)
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.FlatStyle = FlatStyle.Flat;
            cmbCliente.Font = new Font("Segoe UI", 11F);

            cmbGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupo.FlatStyle = FlatStyle.Flat;
            cmbGrupo.Font = new Font("Segoe UI", 11F);

            cmbServicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServicio.FlatStyle = FlatStyle.Flat;
            cmbServicio.Font = new Font("Segoe UI", 11F);

            cmbHoras.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHoras.FlatStyle = FlatStyle.Flat;
            cmbHoras.Font = new Font("Segoe UI", 11F);

            // monthCalendarCitas
            monthCalendarCitas.Location = new Point(265, 40);
            monthCalendarCitas.MaxSelectionCount = 1;

            // btnGuardar
            btnGuardar.BackColor = Color.SeaGreen;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(100, 425);
            btnGuardar.Size = new Size(180, 45);
            btnGuardar.Text = "GUARDAR CITA";

            // btnCancelar
            btnCancelar.BackColor = Color.Crimson;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(300, 425);
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.Text = "CANCELAR";

            // panelContenedor
            panelContenedor.BackColor = Color.FromArgb(180, 240, 240, 240);
            panelContenedor.Controls.Add(monthCalendarCitas);
            panelContenedor.Controls.Add(lbCliente);
            panelContenedor.Controls.Add(lbGrupo);
            panelContenedor.Controls.Add(lblServicio);
            panelContenedor.Controls.Add(label2);
            panelContenedor.Location = new Point(30, 85);
            panelContenedor.Size = new Size(520, 320);

            // AnyadirCitas Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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