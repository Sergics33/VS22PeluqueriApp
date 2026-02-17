namespace PeluqueriAPP
{
    partial class Agendas
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label4 = new Label();
            lblTitulo = new Label();
            label2 = new Label();
            lblUbi = new Label();
            lblBernatS = new Label();
            panel3 = new Panel();
            btnBorrar = new Button();
            btnEditar = new Button();
            tbBusqueda = new TextBox();
            lblBuscar = new Label();
            btnAnyadir = new Button();
            panel2 = new Panel();
            dgvServicios = new DataGridView();
            toolTip1 = new ToolTip(components);
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServicios).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDark;
            label4.Location = new Point(60, 99);
            label4.Name = "label4";
            label4.Size = new Size(162, 17);
            label4.TabIndex = 63;
            label4.Text = "Administración de Horario";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(60, 62);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(117, 37);
            lblTitulo.TabIndex = 62;
            lblTitulo.Text = "Horario";
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(177, 177, 177);
            label2.Location = new Point(0, 47);
            label2.Name = "label2";
            label2.Size = new Size(1045, 1);
            label2.TabIndex = 59;
            // 
            // lblUbi
            // 
            lblUbi.AutoSize = true;
            lblUbi.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUbi.ForeColor = SystemColors.ActiveCaptionText;
            lblUbi.Location = new Point(154, 27);
            lblUbi.Name = "lblUbi";
            lblUbi.Size = new Size(62, 20);
            lblUbi.TabIndex = 61;
            lblUbi.Text = "Horario";
            // 
            // lblBernatS
            // 
            lblBernatS.AutoSize = true;
            lblBernatS.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBernatS.ForeColor = SystemColors.ControlDark;
            lblBernatS.Location = new Point(50, 26);
            lblBernatS.Name = "lblBernatS";
            lblBernatS.Size = new Size(108, 20);
            lblBernatS.TabIndex = 60;
            lblBernatS.Text = "Bernat Sarriá >";
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
            panel3.TabIndex = 57;
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
            btnBorrar.Click += btnBorrar_Click;
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
            btnEditar.Click += btnEditar_Click;
            // 
            // tbBusqueda
            // 
            tbBusqueda.Font = new Font("Segoe UI", 10F);
            tbBusqueda.Location = new Point(17, 41);
            tbBusqueda.Name = "tbBusqueda";
            tbBusqueda.Size = new Size(388, 25);
            tbBusqueda.TabIndex = 43;
            toolTip1.SetToolTip(tbBusqueda, "Introduce el aula del grupo");
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblBuscar.Location = new Point(17, 14);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(189, 25);
            lblBuscar.TabIndex = 42;
            lblBuscar.Text = "Buscar en el horario";
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
            btnAnyadir.Text = "✚  Añadir";
            btnAnyadir.UseVisualStyleBackColor = false;
            btnAnyadir.Click += btnAnyadir_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvServicios);
            panel2.Location = new Point(50, 234);
            panel2.Name = "panel2";
            panel2.Size = new Size(903, 379);
            panel2.TabIndex = 64;
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvServicios.ColumnHeadersHeight = 45;
            dgvServicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(70, 70, 70);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(235, 245, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(0, 120, 215);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvServicios.DefaultCellStyle = dataGridViewCellStyle4;
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
            dgvServicios.TabIndex = 1;
            dgvServicios.CellContentClick += dgvServicios_CellContentClick;
            // 
            // Agendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1052, 633);
            Controls.Add(panel2);
            Controls.Add(label4);
            Controls.Add(lblTitulo);
            Controls.Add(label2);
            Controls.Add(lblUbi);
            Controls.Add(lblBernatS);
            Controls.Add(panel3);
            Name = "Agendas";
            Text = "Agendas";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvServicios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUbi;
        private System.Windows.Forms.Label lblBernatS;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox tbBusqueda;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button btnAnyadir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvServicios;
        private ToolTip toolTip1;
    }
}