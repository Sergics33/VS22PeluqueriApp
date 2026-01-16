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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Servicios));
            panel1 = new Panel();
            label7 = new Label();
            IconoPerfil = new PictureBox();
            lblCerrarSesion = new Label();
            lblAdmin = new Label();
            label1 = new Label();
            label9 = new Label();
            lblServicios = new Label();
            lblCitas = new Label();
            lblHome = new Label();
            lblGestion = new Label();
            iconoFP = new PictureBox();
            label3 = new Label();
            lblPanel = new Label();
            lblBernat = new Label();
            label2 = new Label();
            lblUbi = new Label();
            lblBernatS = new Label();
            label4 = new Label();
            lblTitulo = new Label();
            btnAnyadir = new Button();
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
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IconoPerfil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconoFP).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServicios).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(40, 40, 40);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(IconoPerfil);
            panel1.Controls.Add(lblCerrarSesion);
            panel1.Controls.Add(lblAdmin);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(lblServicios);
            panel1.Controls.Add(lblCitas);
            panel1.Controls.Add(lblHome);
            panel1.Controls.Add(lblGestion);
            panel1.Controls.Add(iconoFP);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblPanel);
            panel1.Controls.Add(lblBernat);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(228, 633);
            panel1.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(39, 315);
            label7.Name = "label7";
            label7.Size = new Size(85, 25);
            label7.TabIndex = 45;
            label7.Text = "Usuarios";
            label7.Click += label7_Click;
            // 
            // IconoPerfil
            // 
            IconoPerfil.Image = (Image)resources.GetObject("IconoPerfil.Image");
            IconoPerfil.Location = new Point(9, 540);
            IconoPerfil.Name = "IconoPerfil";
            IconoPerfil.Size = new Size(54, 30);
            IconoPerfil.SizeMode = PictureBoxSizeMode.Zoom;
            IconoPerfil.TabIndex = 13;
            IconoPerfil.TabStop = false;
            // 
            // lblCerrarSesion
            // 
            lblCerrarSesion.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCerrarSesion.ForeColor = Color.White;
            lblCerrarSesion.Location = new Point(59, 586);
            lblCerrarSesion.Name = "lblCerrarSesion";
            lblCerrarSesion.Size = new Size(103, 20);
            lblCerrarSesion.TabIndex = 12;
            lblCerrarSesion.Text = "Cerrar Sesión";
            // 
            // lblAdmin
            // 
            lblAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdmin.ForeColor = SystemColors.ControlDark;
            lblAdmin.Location = new Point(59, 557);
            lblAdmin.Name = "lblAdmin";
            lblAdmin.Size = new Size(90, 20);
            lblAdmin.TabIndex = 11;
            lblAdmin.Text = "Administradora";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(59, 537);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 10;
            label1.Text = "Profesora 1";
            // 
            // label9
            // 
            label9.BackColor = Color.White;
            label9.Location = new Point(0, 525);
            label9.Name = "label9";
            label9.Size = new Size(228, 1);
            label9.TabIndex = 9;
            // 
            // lblServicios
            // 
            lblServicios.AutoSize = true;
            lblServicios.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServicios.ForeColor = Color.White;
            lblServicios.Location = new Point(39, 277);
            lblServicios.Name = "lblServicios";
            lblServicios.Size = new Size(88, 25);
            lblServicios.TabIndex = 7;
            lblServicios.Text = "Servicios";
            // 
            // lblCitas
            // 
            lblCitas.AutoSize = true;
            lblCitas.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCitas.ForeColor = Color.White;
            lblCitas.Location = new Point(39, 242);
            lblCitas.Name = "lblCitas";
            lblCitas.Size = new Size(54, 25);
            lblCitas.TabIndex = 6;
            lblCitas.Text = "Citas";
            // 
            // lblHome
            // 
            lblHome.AutoSize = true;
            lblHome.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHome.ForeColor = Color.White;
            lblHome.Location = new Point(39, 207);
            lblHome.Name = "lblHome";
            lblHome.Size = new Size(64, 25);
            lblHome.TabIndex = 5;
            lblHome.Text = "Home";
            lblHome.Click += lblHome_Click;
            // 
            // lblGestion
            // 
            lblGestion.AutoSize = true;
            lblGestion.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGestion.ForeColor = SystemColors.ControlDark;
            lblGestion.Location = new Point(39, 174);
            lblGestion.Name = "lblGestion";
            lblGestion.Size = new Size(59, 20);
            lblGestion.TabIndex = 4;
            lblGestion.Text = "Gestión";
            // 
            // iconoFP
            // 
            iconoFP.Image = (Image)resources.GetObject("iconoFP.Image");
            iconoFP.Location = new Point(25, 12);
            iconoFP.Name = "iconoFP";
            iconoFP.Size = new Size(169, 86);
            iconoFP.SizeMode = PictureBoxSizeMode.Zoom;
            iconoFP.TabIndex = 3;
            iconoFP.TabStop = false;
            // 
            // label3
            // 
            label3.BackColor = Color.White;
            label3.Location = new Point(0, 163);
            label3.Name = "label3";
            label3.Size = new Size(228, 1);
            label3.TabIndex = 2;
            // 
            // lblPanel
            // 
            lblPanel.AutoSize = true;
            lblPanel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPanel.ForeColor = SystemColors.ControlDark;
            lblPanel.Location = new Point(27, 135);
            lblPanel.Name = "lblPanel";
            lblPanel.Size = new Size(169, 20);
            lblPanel.TabIndex = 1;
            lblPanel.Text = "Panel de Administración";
            // 
            // lblBernat
            // 
            lblBernat.AutoSize = true;
            lblBernat.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblBernat.ForeColor = SystemColors.ControlLightLight;
            lblBernat.Location = new Point(25, 101);
            lblBernat.Name = "lblBernat";
            lblBernat.Size = new Size(172, 31);
            lblBernat.TabIndex = 0;
            lblBernat.Text = "Bernat Sarriá";
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(177, 177, 177);
            label2.Location = new Point(234, 38);
            label2.Name = "label2";
            label2.Size = new Size(1045, 1);
            label2.TabIndex = 20;
            // 
            // lblUbi
            // 
            lblUbi.AutoSize = true;
            lblUbi.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUbi.ForeColor = SystemColors.ActiveCaptionText;
            lblUbi.Location = new Point(388, 18);
            lblUbi.Name = "lblUbi";
            lblUbi.Size = new Size(71, 20);
            lblUbi.TabIndex = 22;
            lblUbi.Text = "Servicios";
            // 
            // lblBernatS
            // 
            lblBernatS.AutoSize = true;
            lblBernatS.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBernatS.ForeColor = SystemColors.ControlDark;
            lblBernatS.Location = new Point(284, 17);
            lblBernatS.Name = "lblBernatS";
            lblBernatS.Size = new Size(108, 20);
            lblBernatS.TabIndex = 21;
            lblBernatS.Text = "Bernat Sarriá >";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDark;
            label4.Location = new Point(289, 98);
            label4.Name = "label4";
            label4.Size = new Size(167, 17);
            label4.TabIndex = 24;
            label4.Text = "Administración de servicios";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(284, 61);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(132, 37);
            lblTitulo.TabIndex = 23;
            lblTitulo.Text = "Servicios";
            // 
            // btnAnyadir
            // 
            btnAnyadir.BackColor = Color.White;
            btnAnyadir.FlatStyle = FlatStyle.Flat;
            btnAnyadir.ForeColor = SystemColors.ControlText;
            btnAnyadir.Location = new Point(431, 42);
            btnAnyadir.Name = "btnAnyadir";
            btnAnyadir.Size = new Size(105, 23);
            btnAnyadir.TabIndex = 41;
            btnAnyadir.Text = "Añadir servicio";
            btnAnyadir.UseVisualStyleBackColor = false;
            btnAnyadir.Click += btnAnyadir_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvServicios);
            panel2.Location = new Point(252, 242);
            panel2.Name = "panel2";
            panel2.Size = new Size(788, 379);
            panel2.TabIndex = 42;
            // 
            // dgvServicios
            // 
            dgvServicios.AllowUserToAddRows = false;
            dgvServicios.AllowUserToDeleteRows = false;
            dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServicios.Dock = DockStyle.Fill;
            dgvServicios.Location = new Point(0, 0);
            dgvServicios.MultiSelect = false;
            dgvServicios.Name = "dgvServicios";
            dgvServicios.ReadOnly = true;
            dgvServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicios.Size = new Size(788, 379);
            dgvServicios.TabIndex = 0;
            dgvServicios.CellContentClick += dgvServicios_CellContentClick;
            // 
            // ID
            // 
            ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ID.HeaderText = "ID";
            ID.Name = "ID";
            // 
            // Nombre
            // 
            Nombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            // 
            // Descripcion
            // 
            Descripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Descripcion.HeaderText = "Descripcion";
            Descripcion.Name = "Descripcion";
            // 
            // Duración
            // 
            Duración.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Duración.HeaderText = "Duración";
            Duración.Name = "Duración";
            // 
            // Precio
            // 
            Precio.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Precio.HeaderText = "Precio";
            Precio.Name = "Precio";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.AppWorkspace;
            panel3.Controls.Add(btnBorrar);
            panel3.Controls.Add(btnEditar);
            panel3.Controls.Add(tbBusqueda);
            panel3.Controls.Add(lblBuscar);
            panel3.Controls.Add(btnAnyadir);
            panel3.Location = new Point(252, 149);
            panel3.Name = "panel3";
            panel3.Size = new Size(788, 83);
            panel3.TabIndex = 43;
            // 
            // btnBorrar
            // 
            btnBorrar.BackColor = Color.White;
            btnBorrar.FlatStyle = FlatStyle.Flat;
            btnBorrar.ForeColor = SystemColors.ControlText;
            btnBorrar.Location = new Point(668, 42);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(97, 23);
            btnBorrar.TabIndex = 45;
            btnBorrar.Text = "Borrar servicio";
            btnBorrar.UseVisualStyleBackColor = false;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.White;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.ForeColor = SystemColors.ControlText;
            btnEditar.Location = new Point(554, 42);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(97, 23);
            btnEditar.TabIndex = 44;
            btnEditar.Text = "Editar servicio";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // tbBusqueda
            // 
            tbBusqueda.Location = new Point(17, 42);
            tbBusqueda.Name = "tbBusqueda";
            tbBusqueda.Size = new Size(388, 23);
            tbBusqueda.TabIndex = 43;
            tbBusqueda.TextChanged += tbBusqueda_TextChanged;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            ClientSize = new Size(1093, 633);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label4);
            Controls.Add(lblTitulo);
            Controls.Add(label2);
            Controls.Add(lblUbi);
            Controls.Add(lblBernatS);
            Controls.Add(panel1);
            Name = "Servicios";
            Text = "Form2";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IconoPerfil).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconoFP).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvServicios).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel panel1;
        private PictureBox IconoPerfil;
        private Label lblCerrarSesion;
        private Label lblAdmin;
        private Label label1;
        private Label label9;
        private Label lblServicios;
        private Label lblCitas;
        private Label lblHome;
        private Label lblGestion;
        private PictureBox iconoFP;
        private Label label3;
        private Label lblPanel;
        private Label lblBernat;
        private Label label2;
        private Label lblUbi;
        private Label lblBernatS;
        private Label label4;
        private Label lblTitulo;
        private Button btnAnyadir;
        private Panel panel2;
        private DataGridView dgvServicios;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn Duración;
        private DataGridViewTextBoxColumn Precio;
        private Panel panel3;
        private Label lblBuscar;
        private Button btnBorrar;
        private Button btnEditar;
        private TextBox textBox1;
        private TextBox tbBusqueda;
        private Label label7;
    }
}
