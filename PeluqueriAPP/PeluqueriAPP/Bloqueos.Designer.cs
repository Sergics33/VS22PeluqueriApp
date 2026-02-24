namespace PeluqueriAPP
{
    partial class Bloqueos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            panelSuperior = new Panel();
            dgvBloqueos = new DataGridView();
            btnNuevoBloqueo = new Button();
            btnBorrarBloqueo = new Button();
            label2 = new Label();
            lblUbi = new Label();
            lblBernatS = new Label();
            label4 = new Label();
            panel3 = new Panel();
            tbBusqueda = new TextBox();
            lblBuscar = new Label();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBloqueos).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(48, 48, 48);
            lblTitulo.Location = new Point(43, 58);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(148, 41);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Bloqueos";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(dgvBloqueos);
            panelSuperior.Location = new Point(50, 230);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Padding = new Padding(15);
            panelSuperior.Size = new Size(900, 334);
            panelSuperior.TabIndex = 0;
            // 
            // dgvBloqueos
            // 
            dgvBloqueos.BackgroundColor = Color.White;
            dgvBloqueos.BorderStyle = BorderStyle.None;
            dgvBloqueos.Location = new Point(0, 0);
            dgvBloqueos.Name = "dgvBloqueos";
            dgvBloqueos.RowHeadersVisible = false;
            dgvBloqueos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBloqueos.Size = new Size(900, 414);
            dgvBloqueos.TabIndex = 0;
            // 
            // btnNuevoBloqueo
            // 
            btnNuevoBloqueo.BackColor = Color.FromArgb(33, 150, 83);
            btnNuevoBloqueo.FlatAppearance.BorderSize = 0;
            btnNuevoBloqueo.FlatStyle = FlatStyle.Flat;
            btnNuevoBloqueo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNuevoBloqueo.ForeColor = Color.White;
            btnNuevoBloqueo.Location = new Point(454, 21);
            btnNuevoBloqueo.Name = "btnNuevoBloqueo";
            btnNuevoBloqueo.Size = new Size(151, 45);
            btnNuevoBloqueo.TabIndex = 1;
            btnNuevoBloqueo.Text = "✚ NUEVO BLOQUEO";
            btnNuevoBloqueo.UseVisualStyleBackColor = false;
            // 
            // btnBorrarBloqueo
            // 
            btnBorrarBloqueo.BackColor = Color.FromArgb(235, 87, 87);
            btnBorrarBloqueo.FlatAppearance.BorderSize = 0;
            btnBorrarBloqueo.FlatStyle = FlatStyle.Flat;
            btnBorrarBloqueo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBorrarBloqueo.ForeColor = Color.White;
            btnBorrarBloqueo.Location = new Point(637, 21);
            btnBorrarBloqueo.Name = "btnBorrarBloqueo";
            btnBorrarBloqueo.Size = new Size(155, 45);
            btnBorrarBloqueo.TabIndex = 3;
            btnBorrarBloqueo.Text = "🗑  ELIMINAR BLOQUEO";
            btnBorrarBloqueo.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(177, 177, 177);
            label2.Location = new Point(0, 41);
            label2.Name = "label2";
            label2.Size = new Size(1093, 1);
            label2.TabIndex = 26;
            // 
            // lblUbi
            // 
            lblUbi.AutoSize = true;
            lblUbi.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUbi.ForeColor = SystemColors.ActiveCaptionText;
            lblUbi.Location = new Point(154, 21);
            lblUbi.Name = "lblUbi";
            lblUbi.Size = new Size(74, 20);
            lblUbi.TabIndex = 28;
            lblUbi.Text = "Bloqueos";
            // 
            // lblBernatS
            // 
            lblBernatS.AutoSize = true;
            lblBernatS.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBernatS.ForeColor = SystemColors.ControlDark;
            lblBernatS.Location = new Point(50, 20);
            lblBernatS.Name = "lblBernatS";
            lblBernatS.Size = new Size(108, 20);
            lblBernatS.TabIndex = 27;
            lblBernatS.Text = "Bernat Sarriá >";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDark;
            label4.Location = new Point(50, 98);
            label4.Name = "label4";
            label4.Size = new Size(172, 17);
            label4.TabIndex = 29;
            label4.Text = "Administración de bloqueos";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(tbBusqueda);
            panel3.Controls.Add(lblBuscar);
            panel3.Controls.Add(btnNuevoBloqueo);
            panel3.Controls.Add(btnBorrarBloqueo);
            panel3.Location = new Point(50, 128);
            panel3.Name = "panel3";
            panel3.Size = new Size(903, 83);
            panel3.TabIndex = 30;
            // 
            // tbBusqueda
            // 
            tbBusqueda.Font = new Font("Segoe UI", 10F);
            tbBusqueda.Location = new Point(17, 41);
            tbBusqueda.Name = "tbBusqueda";
            tbBusqueda.PlaceholderText = "Escribe para buscar...";
            tbBusqueda.Size = new Size(388, 25);
            tbBusqueda.TabIndex = 2;
            tbBusqueda.TextChanged += tbBusqueda_TextChanged;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblBuscar.Location = new Point(13, 13);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(159, 25);
            lblBuscar.TabIndex = 3;
            lblBuscar.Text = "Buscar Bloqueos";
            // 
            // Bloqueos
            // 
            ClientSize = new Size(1014, 577);
            Controls.Add(panel3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(lblUbi);
            Controls.Add(lblBernatS);
            Controls.Add(panelSuperior);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Bloqueos";
            panelSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBloqueos).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitulo;
        private Panel panelSuperior;
        private DataGridView dgvBloqueos;
        private Button btnNuevoBloqueo;
        private Button btnBorrarBloqueo;
        private Label label2;
        private Label lblUbi;
        private Label lblBernatS;
        private Label label4;
        private Panel panel3;
        private TextBox tbBusqueda;
        private Label lblBuscar;
    }
}