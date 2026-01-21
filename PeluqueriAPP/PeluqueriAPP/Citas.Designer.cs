namespace PeluqueriAPP
{
    partial class Citas
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            panel3 = new Panel();
            btnBorrar = new Button();
            btnEditar = new Button();
            tbBusqueda = new TextBox();
            lblBuscar = new Label();
            btnAnyadir = new Button();
            dgvCitas = new DataGridView();
            label2 = new Label();
            lblUbi = new Label();
            lblBernatS = new Label();
            label4 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            lblTitulo.Location = new Point(60, 62);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(80, 37);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Citas";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(btnBorrar);
            panel3.Controls.Add(btnEditar);
            panel3.Controls.Add(tbBusqueda);
            panel3.Controls.Add(lblBuscar);
            panel3.Controls.Add(btnAnyadir);
            panel3.Location = new Point(50, 131);
            panel3.Name = "panel3";
            panel3.Size = new Size(903, 83);
            panel3.TabIndex = 0;
            // 
            // btnAnyadir
            // 
            btnAnyadir.BackColor = Color.FromArgb(33, 150, 83);
            btnAnyadir.Cursor = Cursors.Hand;
            btnAnyadir.FlatAppearance.BorderSize = 0;
            btnAnyadir.FlatStyle = FlatStyle.Flat;
            btnAnyadir.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnAnyadir.ForeColor = Color.White;
            btnAnyadir.Location = new Point(431, 35);
            btnAnyadir.Name = "btnAnyadir";
            btnAnyadir.Size = new Size(125, 35);
            btnAnyadir.TabIndex = 4;
            btnAnyadir.Text = "✚  Nueva";
            btnAnyadir.UseVisualStyleBackColor = false;
            btnAnyadir.Click += btnAnyadir_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(45, 156, 219);
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(570, 35);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(115, 35);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "✎  Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.BackColor = Color.FromArgb(235, 87, 87);
            btnBorrar.Cursor = Cursors.Hand;
            btnBorrar.FlatAppearance.BorderSize = 0;
            btnBorrar.FlatStyle = FlatStyle.Flat;
            btnBorrar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnBorrar.ForeColor = Color.White;
            btnBorrar.Location = new Point(700, 35);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(115, 35);
            btnBorrar.TabIndex = 0;
            btnBorrar.Text = "🗑  Borrar";
            btnBorrar.UseVisualStyleBackColor = false;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // tbBusqueda
            // 
            tbBusqueda.Font = new Font("Segoe UI", 10F);
            tbBusqueda.Location = new Point(17, 41);
            tbBusqueda.Name = "tbBusqueda";
            tbBusqueda.PlaceholderText = "Escribe para buscar...";
            tbBusqueda.Size = new Size(388, 25);
            tbBusqueda.TabIndex = 2;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblBuscar.Location = new Point(17, 14);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(118, 25);
            lblBuscar.TabIndex = 3;
            lblBuscar.Text = "Buscar Citas";
            // 
            // dgvCitas
            // 
            dgvCitas.AllowUserToAddRows = false;
            dgvCitas.AllowUserToDeleteRows = false;
            dgvCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCitas.BackgroundColor = Color.White;
            dgvCitas.BorderStyle = BorderStyle.None;
            dgvCitas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCitas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCitas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCitas.ColumnHeadersHeight = 45;
            dgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle2.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(235, 245, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(0, 120, 215);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCitas.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCitas.EnableHeadersVisualStyles = false;
            dgvCitas.GridColor = Color.FromArgb(230, 230, 230);
            dgvCitas.Location = new Point(50, 234);
            dgvCitas.MultiSelect = false;
            dgvCitas.Name = "dgvCitas";
            dgvCitas.ReadOnly = true;
            dgvCitas.RowHeadersVisible = false;
            dgvCitas.RowTemplate.Height = 40;
            dgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCitas.Size = new Size(903, 379);
            dgvCitas.TabIndex = 1;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(177, 177, 177);
            label2.Location = new Point(0, 47);
            label2.Name = "label2";
            label2.Size = new Size(1093, 1);
            label2.TabIndex = 23;
            // 
            // lblUbi
            // 
            lblUbi.AutoSize = true;
            lblUbi.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUbi.ForeColor = SystemColors.ActiveCaptionText;
            lblUbi.Location = new Point(154, 27);
            lblUbi.Name = "lblUbi";
            lblUbi.Size = new Size(43, 20);
            lblUbi.TabIndex = 25;
            lblUbi.Text = "Citas";
            // 
            // lblBernatS
            // 
            lblBernatS.AutoSize = true;
            lblBernatS.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBernatS.ForeColor = SystemColors.ControlDark;
            lblBernatS.Location = new Point(50, 26);
            lblBernatS.Name = "lblBernatS";
            lblBernatS.Size = new Size(108, 20);
            lblBernatS.TabIndex = 24;
            lblBernatS.Text = "Bernat Sarriá >";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDark;
            label4.Location = new Point(60, 99);
            label4.Name = "label4";
            label4.Size = new Size(143, 17);
            label4.TabIndex = 26;
            label4.Text = "Administración de citas";
            // 
            // Citas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1052, 633);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(lblUbi);
            Controls.Add(lblBernatS);
            Controls.Add(panel3);
            Controls.Add(dgvCitas);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Citas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Citas";
            Load += Citas_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel panel3;
        private Button btnBorrar;
        private Button btnEditar;
        private TextBox tbBusqueda;
        private Label lblBuscar;
        private Button btnAnyadir;
        private DataGridView dgvCitas;
        private Label label2;
        private Label lblUbi;
        private Label lblBernatS;
        private Label label4;
    }
}