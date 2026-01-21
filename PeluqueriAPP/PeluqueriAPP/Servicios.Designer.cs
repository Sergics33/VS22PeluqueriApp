namespace PeluqueriAPP
{
    partial class Servicios
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label2 = new Label();
            lblUbi = new Label();
            lblBernatS = new Label();
            label4 = new Label();
            lblTitulo = new Label();
            panel2 = new Panel();
            dgvServicios = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            Duración = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            btnBorrar = new Button();
            btnEditar = new Button();
            tbBusqueda = new TextBox();
            lblBuscar = new Label();
            btnAnyadir = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServicios).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(177, 177, 177);
            label2.Location = new Point(0, 47);
            label2.Name = "label2";
            label2.Size = new Size(1093, 1);
            label2.TabIndex = 20;
            // 
            // lblUbi
            // 
            lblUbi.AutoSize = true;
            lblUbi.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblUbi.ForeColor = SystemColors.ActiveCaptionText;
            lblUbi.Location = new Point(154, 27);
            lblUbi.Name = "lblUbi";
            lblUbi.Size = new Size(71, 20);
            lblUbi.TabIndex = 22;
            lblUbi.Text = "Servicios";
            // 
            // lblBernatS
            // 
            lblBernatS.AutoSize = true;
            lblBernatS.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular);
            lblBernatS.ForeColor = SystemColors.ControlDark;
            lblBernatS.Location = new Point(50, 26);
            lblBernatS.Name = "lblBernatS";
            lblBernatS.Size = new Size(108, 20);
            lblBernatS.TabIndex = 21;
            lblBernatS.Text = "Bernat Sarriá >";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            label4.ForeColor = SystemColors.ControlDark;
            label4.Location = new Point(60, 99);
            label4.Name = "label4";
            label4.Size = new Size(167, 17);
            label4.TabIndex = 24;
            label4.Text = "Administración de servicios";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            lblTitulo.Location = new Point(60, 62);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(132, 37);
            lblTitulo.TabIndex = 23;
            lblTitulo.Text = "Servicios";
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvServicios);
            panel2.Location = new Point(50, 234);
            panel2.Name = "panel2";
            panel2.Size = new Size(903, 379);
            panel2.TabIndex = 42;
            // 
            // dgvServicios
            // 
            dgvServicios.AllowUserToAddRows = false;
            dgvServicios.AllowUserToDeleteRows = false;
            dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicios.BackgroundColor = Color.White;
            dgvServicios.BorderStyle = BorderStyle.None;
            dgvServicios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvServicios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvServicios.ColumnHeadersHeight = 45;
            dgvServicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvServicios.Columns.AddRange(new DataGridViewColumn[] { ID, Nombre, Descripcion, Duración, Precio });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle2.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(235, 245, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(0, 120, 215);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvServicios.DefaultCellStyle = dataGridViewCellStyle2;
            dgvServicios.Dock = DockStyle.Fill;
            dgvServicios.EnableHeadersVisualStyles = false;
            dgvServicios.GridColor = Color.FromArgb(230, 230, 230);
            dgvServicios.Location = new Point(0, 0);
            dgvServicios.MultiSelect = false;
            dgvServicios.Name = "dgvServicios";
            dgvServicios.ReadOnly = true;
            dgvServicios.RowHeadersVisible = false;
            dgvServicios.RowTemplate.Height = 40;
            dgvServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicios.Size = new Size(903, 379);
            dgvServicios.TabIndex = 0;
            // 
            // ID
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ID.DefaultCellStyle = dataGridViewCellStyle4;
            ID.FillWeight = 40F;
            ID.HeaderText = "ID";
            ID.Name = "ID";
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            // 
            // Descripcion
            // 
            Descripcion.HeaderText = "Descripción";
            Descripcion.Name = "Descripcion";
            // 
            // Duración
            // 
            Duración.HeaderText = "Duración";
            Duración.Name = "Duración";
            // 
            // Precio
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Padding = new Padding(0, 0, 20, 0);
            Precio.DefaultCellStyle = dataGridViewCellStyle3;
            Precio.HeaderText = "Precio";
            Precio.Name = "Precio";
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
            panel3.TabIndex = 43;
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
            btnAnyadir.TabIndex = 41;
            btnAnyadir.Text = "✚  Nuevo";
            btnAnyadir.UseVisualStyleBackColor = false;
            btnAnyadir.Click += btnAnyadir_Click; // FUNCIONALIDAD RECUPERADA
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
            btnEditar.TabIndex = 44;
            btnEditar.Text = "✎  Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click; // FUNCIONALIDAD RECUPERADA
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
            btnBorrar.TabIndex = 45;
            btnBorrar.Text = "🗑  Borrar";
            btnBorrar.UseVisualStyleBackColor = false;
            btnBorrar.Click += btnBorrar_Click; // FUNCIONALIDAD RECUPERADA
            // 
            // tbBusqueda
            // 
            tbBusqueda.Font = new Font("Segoe UI", 10F);
            tbBusqueda.Location = new Point(17, 41);
            tbBusqueda.Name = "tbBusqueda";
            tbBusqueda.PlaceholderText = "Buscar por nombre...";
            tbBusqueda.Size = new Size(388, 25);
            tbBusqueda.TabIndex = 43;
            tbBusqueda.TextChanged += tbBusqueda_TextChanged; // FUNCIONALIDAD RECUPERADA
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblBuscar.Location = new Point(17, 14);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(147, 25);
            lblBuscar.TabIndex = 42;
            lblBuscar.Text = "Buscar Servicio";
            // 
            // Servicios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1052, 633);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label4);
            Controls.Add(lblTitulo);
            Controls.Add(label2);
            Controls.Add(lblUbi);
            Controls.Add(lblBernatS);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Servicios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administración de Servicios";
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvServicios).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label lblUbi;
        private Label lblBernatS;
        private Label label4;
        private Label lblTitulo;
        private Panel panel2;
        private DataGridView dgvServicios;
        private Panel panel3;
        private Label lblBuscar;
        private Button btnBorrar;
        private Button btnEditar;
        private TextBox tbBusqueda;
        private Button btnAnyadir;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn Duración;
        private DataGridViewTextBoxColumn Precio;
    }
}