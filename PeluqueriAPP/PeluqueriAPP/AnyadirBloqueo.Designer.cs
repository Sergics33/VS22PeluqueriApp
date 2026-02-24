namespace PeluqueriAPP
{
    partial class AnyadirBloqueo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnGuardarBloqueo = new Button();
            calendarioBloqueo = new MonthCalendar();
            txtMotivo = new TextBox();
            label5 = new Label();
            dtpHoraFin = new DateTimePicker();
            label3 = new Label();
            dtpHoraInicio = new DateTimePicker();
            label1 = new Label();
            labelTitulo = new Label();
            panelContenedor = new Panel();
            cmbGrupo = new ComboBox();
            lblGrupo = new Label();
            btnCancelar = new Button();
            panelContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // btnGuardarBloqueo
            // 
            btnGuardarBloqueo.BackColor = Color.SeaGreen;
            btnGuardarBloqueo.Cursor = Cursors.Hand;
            btnGuardarBloqueo.FlatAppearance.BorderSize = 0;
            btnGuardarBloqueo.FlatStyle = FlatStyle.Flat;
            btnGuardarBloqueo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardarBloqueo.ForeColor = Color.White;
            btnGuardarBloqueo.Location = new Point(100, 425);
            btnGuardarBloqueo.Name = "btnGuardarBloqueo";
            btnGuardarBloqueo.Size = new Size(180, 45);
            btnGuardarBloqueo.TabIndex = 2;
            btnGuardarBloqueo.Text = "APLICAR BLOQUEO";
            btnGuardarBloqueo.UseVisualStyleBackColor = false;
            // 
            // labelTitulo
            // 
            labelTitulo.BackColor = Color.Transparent;
            labelTitulo.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(0, 5);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(580, 75);
            labelTitulo.Text = "Bloqueo Horario";
            labelTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.FromArgb(180, 240, 240, 240);
            panelContenedor.Controls.Add(cmbGrupo);
            panelContenedor.Controls.Add(lblGrupo);
            panelContenedor.Controls.Add(txtMotivo);
            panelContenedor.Controls.Add(dtpHoraFin);
            panelContenedor.Controls.Add(dtpHoraInicio);
            panelContenedor.Controls.Add(calendarioBloqueo);
            panelContenedor.Controls.Add(label1);
            panelContenedor.Controls.Add(label3);
            panelContenedor.Controls.Add(label5);
            panelContenedor.Location = new Point(30, 85);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(520, 320);
            // 
            // cmbGrupo (Dentro del panel)
            // 
            cmbGrupo.Location = new Point(20, 34);
            cmbGrupo.Name = "cmbGrupo";
            cmbGrupo.Size = new Size(220, 23);
            // 
            // lblGrupo (Dentro del panel)
            // 
            lblGrupo.AutoSize = true;
            lblGrupo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblGrupo.Location = new Point(20, 14);
            lblGrupo.Text = "GRUPO:";
            // 
            // calendarioBloqueo (Dentro del panel)
            // 
            calendarioBloqueo.Location = new Point(265, 30);
            calendarioBloqueo.MaxSelectionCount = 1;
            calendarioBloqueo.Name = "calendarioBloqueo";
            // 
            // txtMotivo (Dentro del panel)
            // 
            txtMotivo.Location = new Point(20, 233);
            txtMotivo.Multiline = true;
            txtMotivo.Size = new Size(220, 69);
            // 
            // label5 (Motivo)
            // 
            label5.Location = new Point(20, 207);
            label5.Text = "MOTIVO:";
            label5.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            // 
            // dtpHoraInicio / dtpHoraFin (Dentro del panel)
            // 
            dtpHoraInicio.Location = new Point(20, 97);
            dtpHoraInicio.Size = new Size(220, 23);
            dtpHoraFin.Location = new Point(20, 169);
            dtpHoraFin.Size = new Size(220, 23);
            // 
            // label1 / label3 (Horas)
            // 
            label1.Location = new Point(20, 66);
            label1.Text = "HORA INICIO:";
            label1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            label3.Location = new Point(20, 138);
            label3.Text = "HORA FIN:";
            label3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Crimson;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(300, 425);
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.Text = "CANCELAR";
            // 
            // AnyadirBloqueo
            // 
            ClientSize = new Size(580, 500);
            Controls.Add(panelContenedor);
            Controls.Add(labelTitulo);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardarBloqueo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Bloqueos";
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelContenedor;
        private Button btnGuardarBloqueo;
        private Button btnCancelar;
        private MonthCalendar calendarioBloqueo;
        private TextBox txtMotivo;
        private Label label5;
        private DateTimePicker dtpHoraFin;
        private Label label3;
        private DateTimePicker dtpHoraInicio;
        private Label label1;
        private Label labelTitulo;
        private Label lblGrupo;
        private ComboBox cmbGrupo;
    }
}