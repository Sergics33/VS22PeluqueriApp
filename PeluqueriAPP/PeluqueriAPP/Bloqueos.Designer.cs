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
            panelBlancoFondo = new Panel();
            dgvBloqueos = new DataGridView();
            btnNuevoBloqueo = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBloqueos).BeginInit();
            panelBlancoFondo.SuspendLayout();
            SuspendLayout();
            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(48, 48, 48);
            lblTitulo.Location = new Point(50, 40);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(320, 41);
            lblTitulo.Text = "Historial de Bloqueos";
            // btnNuevoBloqueo (Igual que el de Citas: Naranja)
            btnNuevoBloqueo.BackColor = Color.FromArgb(255, 128, 0);
            btnNuevoBloqueo.FlatStyle = FlatStyle.Flat;
            btnNuevoBloqueo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevoBloqueo.ForeColor = Color.White;
            btnNuevoBloqueo.Location = new Point(750, 40);
            btnNuevoBloqueo.Name = "btnNuevoBloqueo";
            btnNuevoBloqueo.Size = new Size(200, 45);
            btnNuevoBloqueo.Text = "+ NUEVO BLOQUEO";
            btnNuevoBloqueo.FlatAppearance.BorderSize = 0;
            // panelBlancoFondo
            panelBlancoFondo.BackColor = Color.White;
            panelBlancoFondo.Controls.Add(dgvBloqueos);
            panelBlancoFondo.Location = new Point(50, 110);
            panelBlancoFondo.Name = "panelBlancoFondo";
            panelBlancoFondo.Padding = new Padding(15);
            panelBlancoFondo.Size = new Size(900, 410);
            // dgvBloqueos
            dgvBloqueos.BackgroundColor = Color.White;
            dgvBloqueos.BorderStyle = BorderStyle.None;
            dgvBloqueos.Dock = DockStyle.Fill;
            dgvBloqueos.RowHeadersVisible = false;
            dgvBloqueos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Form Bloqueos
            ClientSize = new Size(1014, 568);
            Controls.Add(panelBlancoFondo);
            Controls.Add(btnNuevoBloqueo);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Bloqueos";
            ((System.ComponentModel.ISupportInitialize)dgvBloqueos).EndInit();
            panelBlancoFondo.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitulo;
        private Panel panelBlancoFondo;
        private DataGridView dgvBloqueos;
        private Button btnNuevoBloqueo;
    }
}