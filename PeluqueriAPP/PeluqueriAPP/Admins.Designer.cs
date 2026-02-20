namespace PeluqueriAPP
{
    partial class Admins
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
            panel3 = new Panel();
            btnBorrar = new Button();
            btnEditar = new Button();
            tbBusqueda = new TextBox();
            lblBuscar = new Label();
            btnAnyadir = new Button();
            panel2 = new Panel();
            dgvAdmins = new DataGridView();
            label4 = new Label();
            lblTitulo = new Label();
            label2 = new Label();
            lblUbi = new Label();
            lblBernatS = new Label();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdmins).BeginInit();
            SuspendLayout();
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
            panel3.TabIndex = 50;
            // 
            // btnBorrar
            // 
            btnBorrar.BackColor = Color.FromArgb(235, 87, 87);
            btnBorrar.FlatAppearance.BorderSize = 0;
            btnBorrar.FlatStyle = FlatStyle.Flat;
            btnBorrar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnBorrar.ForeColor = Color.White;
            btnBorrar.Location = new Point(700, 35);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(115, 35);
            btnBorrar.TabIndex = 45;
            btnBorrar.Text = "🗑  Borrar";
            btnBorrar.UseVisualStyleBackColor = false;
            btnBorrar.Click += BtnBorrar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(45, 156, 219);
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(570, 35);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(115, 35);
            btnEditar.TabIndex = 44;
            btnEditar.Text = "✎  Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += BtnEditar_Click;
            // 
            // tbBusqueda
            // 
            tbBusqueda.Font = new Font("Segoe UI", 10F);
            tbBusqueda.Location = new Point(17, 41);
            tbBusqueda.Name = "tbBusqueda";
            tbBusqueda.Size = new Size(388, 25);
            tbBusqueda.TabIndex = 43;
            tbBusqueda.TextChanged += tbBusqueda_TextChanged;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblBuscar.Location = new Point(17, 14);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(153, 25);
            lblBuscar.TabIndex = 42;
            lblBuscar.Text = "Buscar Usuarios";
            // 
            // btnAnyadir
            // 
            btnAnyadir.BackColor = Color.FromArgb(33, 150, 83);
            btnAnyadir.FlatAppearance.BorderSize = 0;
            btnAnyadir.FlatStyle = FlatStyle.Flat;
            btnAnyadir.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnAnyadir.ForeColor = Color.White;
            btnAnyadir.Location = new Point(431, 35);
            btnAnyadir.Name = "btnAnyadir";
            btnAnyadir.Size = new Size(125, 35);
            btnAnyadir.TabIndex = 41;
            btnAnyadir.Text = "✚  Añadir";
            btnAnyadir.UseVisualStyleBackColor = false;
            btnAnyadir.Click += BtnAnyadir_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvAdmins);
            panel2.Location = new Point(50, 234);
            panel2.Name = "panel2";
            panel2.Size = new Size(903, 379);
            panel2.TabIndex = 49;
            // 
            // dgvAdmins
            // 
            dgvAdmins.AllowUserToAddRows = false;
            dgvAdmins.AllowUserToDeleteRows = false;
            dgvAdmins.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAdmins.BackgroundColor = Color.White;
            dgvAdmins.BorderStyle = BorderStyle.None;
            dgvAdmins.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAdmins.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dgvAdmins.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAdmins.ColumnHeadersHeight = 45;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(235, 245, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(0, 120, 215);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAdmins.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAdmins.Dock = DockStyle.Fill;
            dgvAdmins.EnableHeadersVisualStyles = false;
            dgvAdmins.GridColor = Color.FromArgb(230, 230, 230);
            dgvAdmins.Location = new Point(0, 0);
            dgvAdmins.MultiSelect = false;
            dgvAdmins.Name = "dgvAdmins";
            dgvAdmins.ReadOnly = true;
            dgvAdmins.RowHeadersVisible = false;
            dgvAdmins.RowTemplate.Height = 40;
            dgvAdmins.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdmins.Size = new Size(903, 379);
            dgvAdmins.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDark;
            label4.Location = new Point(60, 99);
            label4.Name = "label4";
            label4.Size = new Size(168, 17);
            label4.TabIndex = 56;
            label4.Text = "Administración de Usuarios";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(60, 62);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(128, 37);
            lblTitulo.TabIndex = 55;
            lblTitulo.Text = "Usuarios";
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(177, 177, 177);
            label2.Location = new Point(0, 47);
            label2.Name = "label2";
            label2.Size = new Size(1045, 1);
            label2.TabIndex = 52;
            // 
            // lblUbi
            // 
            lblUbi.AutoSize = true;
            lblUbi.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUbi.ForeColor = SystemColors.ActiveCaptionText;
            lblUbi.Location = new Point(154, 27);
            lblUbi.Name = "lblUbi";
            lblUbi.Size = new Size(70, 20);
            lblUbi.TabIndex = 54;
            lblUbi.Text = "Usuarios";
            // 
            // lblBernatS
            // 
            lblBernatS.AutoSize = true;
            lblBernatS.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBernatS.ForeColor = SystemColors.ControlDark;
            lblBernatS.Location = new Point(50, 26);
            lblBernatS.Name = "lblBernatS";
            lblBernatS.Size = new Size(108, 20);
            lblBernatS.TabIndex = 53;
            lblBernatS.Text = "Bernat Sarriá >";
            // 
            // Admins
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1052, 633);
            Controls.Add(label4);
            Controls.Add(lblTitulo);
            Controls.Add(label2);
            Controls.Add(lblUbi);
            Controls.Add(lblBernatS);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Name = "Admins";
            Text = "Administradores";
            Load += Admins_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAdmins).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvAdmins;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAnyadir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.TextBox tbBusqueda;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUbi;
        private System.Windows.Forms.Label lblBernatS;
    }
}