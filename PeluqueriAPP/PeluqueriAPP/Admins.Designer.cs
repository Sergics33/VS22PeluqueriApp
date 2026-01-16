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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admins));
            panel3 = new Panel();
            btnBorrar = new Button();
            btnEditar = new Button();
            tbBusqueda = new TextBox();
            lblBuscar = new Label();
            btnAnyadir = new Button();
            panel2 = new Panel();
            dgvAdmins = new DataGridView();
            lblBernat = new Label();
            lblPanel = new Label();
            label3 = new Label();
            iconoFP = new PictureBox();
            lblGestion = new Label();
            lblHomeAdmin = new Label();
            lblCitas = new Label();
            lblServicios = new Label();
            label9 = new Label();
            label1 = new Label();
            lblAdmin = new Label();
            lblCerrarSesion = new Label();
            IconoPerfil = new PictureBox();
            label7 = new Label();
            panel1 = new Panel();
            label4 = new Label();
            lblTitulo = new Label();
            label2 = new Label();
            lblUbi = new Label();
            lblBernatS = new Label();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdmins).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconoFP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IconoPerfil).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.AppWorkspace;
            panel3.Controls.Add(btnBorrar);
            panel3.Controls.Add(btnEditar);
            panel3.Controls.Add(tbBusqueda);
            panel3.Controls.Add(lblBuscar);
            panel3.Controls.Add(btnAnyadir);
            panel3.Location = new Point(246, 152);
            panel3.Name = "panel3";
            panel3.Size = new Size(788, 83);
            panel3.TabIndex = 50;
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
            btnBorrar.Text = "Borrar Usuario";
            btnBorrar.UseVisualStyleBackColor = false;
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
            btnEditar.Text = "Editar Usuario";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // tbBusqueda
            // 
            tbBusqueda.Location = new Point(17, 42);
            tbBusqueda.Name = "tbBusqueda";
            tbBusqueda.Size = new Size(388, 23);
            tbBusqueda.TabIndex = 43;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblBuscar.Location = new Point(17, 14);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(135, 25);
            lblBuscar.TabIndex = 42;
            lblBuscar.Text = "Buscar Admin";
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
            btnAnyadir.Text = "Añadir Usuario";
            btnAnyadir.UseVisualStyleBackColor = false;
            btnAnyadir.Click += BtnAnyadir_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvAdmins);
            panel2.Location = new Point(246, 245);
            panel2.Name = "panel2";
            panel2.Size = new Size(788, 379);
            panel2.TabIndex = 49;
            // 
            // dgvAdmins
            // 
            dgvAdmins.AllowUserToAddRows = false;
            dgvAdmins.AllowUserToDeleteRows = false;
            dgvAdmins.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAdmins.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdmins.Dock = DockStyle.Fill;
            dgvAdmins.Location = new Point(0, 0);
            dgvAdmins.MultiSelect = false;
            dgvAdmins.Name = "dgvAdmins";
            dgvAdmins.ReadOnly = true;
            dgvAdmins.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdmins.Size = new Size(788, 379);
            dgvAdmins.TabIndex = 0;
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
            // label3
            // 
            label3.BackColor = Color.White;
            label3.Location = new Point(0, 163);
            label3.Name = "label3";
            label3.Size = new Size(228, 1);
            label3.TabIndex = 2;
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
            // lblHomeAdmin
            // 
            lblHomeAdmin.AutoSize = true;
            lblHomeAdmin.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHomeAdmin.ForeColor = Color.White;
            lblHomeAdmin.Location = new Point(39, 207);
            lblHomeAdmin.Name = "lblHomeAdmin";
            lblHomeAdmin.Size = new Size(64, 25);
            lblHomeAdmin.TabIndex = 5;
            lblHomeAdmin.Text = "Home";
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
            // lblServicios
            // 
            lblServicios.AutoSize = true;
            lblServicios.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServicios.ForeColor = Color.White;
            lblServicios.Location = new Point(39, 276);
            lblServicios.Name = "lblServicios";
            lblServicios.Size = new Size(88, 25);
            lblServicios.TabIndex = 7;
            lblServicios.Text = "Servicios";
            lblServicios.Click += lblServicios_Click;
            // 
            // label9
            // 
            label9.BackColor = Color.White;
            label9.Location = new Point(0, 525);
            label9.Name = "label9";
            label9.Size = new Size(228, 1);
            label9.TabIndex = 9;
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
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(39, 311);
            label7.Name = "label7";
            label7.Size = new Size(85, 25);
            label7.TabIndex = 19;
            label7.Text = "Usuarios";
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
            panel1.Controls.Add(lblHomeAdmin);
            panel1.Controls.Add(lblGestion);
            panel1.Controls.Add(iconoFP);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblPanel);
            panel1.Controls.Add(lblBernat);
            panel1.Location = new Point(2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(228, 633);
            panel1.TabIndex = 51;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDark;
            label4.Location = new Point(285, 103);
            label4.Name = "label4";
            label4.Size = new Size(168, 17);
            label4.TabIndex = 56;
            label4.Text = "Administración de Usuarios";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(280, 66);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(128, 37);
            lblTitulo.TabIndex = 55;
            lblTitulo.Text = "Usuarios";
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(177, 177, 177);
            label2.Location = new Point(230, 43);
            label2.Name = "label2";
            label2.Size = new Size(1045, 1);
            label2.TabIndex = 52;
            // 
            // lblUbi
            // 
            lblUbi.AutoSize = true;
            lblUbi.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUbi.ForeColor = SystemColors.ActiveCaptionText;
            lblUbi.Location = new Point(384, 23);
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
            lblBernatS.Location = new Point(280, 22);
            lblBernatS.Name = "lblBernatS";
            lblBernatS.Size = new Size(108, 20);
            lblBernatS.TabIndex = 53;
            lblBernatS.Text = "Bernat Sarriá >";
            // 
            // Admins
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 633);
            Controls.Add(label4);
            Controls.Add(lblTitulo);
            Controls.Add(label2);
            Controls.Add(lblUbi);
            Controls.Add(lblBernatS);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Name = "Admins";
            Text = "Administradores";
            Load += Admins_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAdmins).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconoFP).EndInit();
            ((System.ComponentModel.ISupportInitialize)IconoPerfil).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView dgvAdmins;
        private Panel panel3;
        private Button btnAnyadir;
        private Button btnEditar;
        private Button btnBorrar;
        private TextBox tbBusqueda;
        private Label lblBuscar;
        private Label label7;
        private PictureBox IconoPersonal;
        private PictureBox IconoServicios;
        private PictureBox IconoCitas;
        private PictureBox IconoHome;
        private PictureBox IconoPerfil;
        private Label lblCerrarSesion;
        private Label lblAdmin;
        private Label label1;
        private Label label9;
        private Label lblServicios;
        private Label lblCitas;
        private Label lblHomeAdmin;
        private Label lblGestion;
        private PictureBox iconoFP;
        private Label label3;
        private Label lblPanel;
        private Label lblBernat;
        private Label label4;
        private Label lblTitulo;
        private Label label2;
        private Label lblUbi;
        private Label lblBernatS;
    }
}
