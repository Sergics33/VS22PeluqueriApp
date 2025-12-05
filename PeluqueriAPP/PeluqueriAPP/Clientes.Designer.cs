using System;
using System.Drawing;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    partial class Clientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clientes));
            panel2 = new Panel();
            panel3 = new Panel();
            comboBox1 = new ComboBox();
            btnBorrar = new Button();
            btnEditar = new Button();
            textBox1 = new TextBox();
            lblBuscar = new Label();
            btnAnyadir = new Button();
            panel4 = new Panel();
            dataGridView2 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Telefono = new DataGridViewTextBoxColumn();
            Alérgenos = new DataGridViewTextBoxColumn();
            Observaciones = new DataGridViewTextBoxColumn();
            label4 = new Label();
            lblTitulo = new Label();
            label2 = new Label();
            lblUbi = new Label();
            lblBernatS = new Label();
            panel1 = new Panel();
            label7 = new Label();
            label6 = new Label();
            IconoPerfil = new PictureBox();
            lblCerrarSesion = new Label();
            lblAdmin = new Label();
            label1 = new Label();
            label9 = new Label();
            lblPersonal = new Label();
            lblServicios = new Label();
            lblCitas = new Label();
            lblHome = new Label();
            lblGestion = new Label();
            iconoFP = new PictureBox();
            label3 = new Label();
            lblPanel = new Label();
            lblBernat = new Label();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IconoPerfil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconoFP).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(238, 238, 238);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(lblTitulo);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(lblUbi);
            panel2.Controls.Add(lblBernatS);
            panel2.Location = new Point(231, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1051, 630);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.AppWorkspace;
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(btnBorrar);
            panel3.Controls.Add(btnEditar);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(lblBuscar);
            panel3.Controls.Add(btnAnyadir);
            panel3.Location = new Point(34, 152);
            panel3.Name = "panel3";
            panel3.Size = new Size(788, 83);
            panel3.TabIndex = 44;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(319, 43);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(106, 23);
            comboBox1.TabIndex = 46;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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
            btnEditar.Text = "Editar Usuario";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(17, 42);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(284, 23);
            textBox1.TabIndex = 43;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuscar.Location = new Point(17, 14);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(137, 25);
            lblBuscar.TabIndex = 42;
            lblBuscar.Text = "Buscar Cliente";
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
            btnAnyadir.Click += btnAnyadir_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(dataGridView2);
            panel4.Location = new Point(34, 256);
            panel4.Name = "panel4";
            panel4.Size = new Size(788, 350);
            panel4.TabIndex = 24;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { ID, Nombre, Telefono, Alérgenos, Observaciones });
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(0, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.Size = new Size(788, 350);
            dataGridView2.TabIndex = 1;
            // 
            // ID
            // 
            ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // Nombre
            // 
            Nombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            // 
            // Telefono
            // 
            Telefono.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Telefono.HeaderText = "Teléfono";
            Telefono.Name = "Telefono";
            Telefono.ReadOnly = true;
            // 
            // Alérgenos
            // 
            Alérgenos.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Alérgenos.HeaderText = "Alérgenos";
            Alérgenos.Name = "Alérgenos";
            Alérgenos.ReadOnly = true;
            // 
            // Observaciones
            // 
            Observaciones.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Observaciones.HeaderText = "Observaciones";
            Observaciones.Name = "Observaciones";
            Observaciones.ReadOnly = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDark;
            label4.Location = new Point(39, 98);
            label4.Name = "label4";
            label4.Size = new Size(203, 17);
            label4.TabIndex = 21;
            label4.Text = "Bienvenida de nuevo, Profesora 1";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(34, 61);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(119, 37);
            lblTitulo.TabIndex = 20;
            lblTitulo.Text = "Clientes";
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(177, 177, 177);
            label2.Location = new Point(1, 36);
            label2.Name = "label2";
            label2.Size = new Size(1045, 1);
            label2.TabIndex = 18;
            // 
            // lblUbi
            // 
            lblUbi.AutoSize = true;
            lblUbi.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUbi.ForeColor = SystemColors.ActiveCaptionText;
            lblUbi.Location = new Point(163, 13);
            lblUbi.Name = "lblUbi";
            lblUbi.Size = new Size(64, 20);
            lblUbi.TabIndex = 19;
            lblUbi.Text = "Clientes";
            // 
            // lblBernatS
            // 
            lblBernatS.AutoSize = true;
            lblBernatS.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBernatS.ForeColor = SystemColors.ControlDark;
            lblBernatS.Location = new Point(59, 12);
            lblBernatS.Name = "lblBernatS";
            lblBernatS.Size = new Size(108, 20);
            lblBernatS.TabIndex = 18;
            lblBernatS.Text = "Bernat Sarriá >";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(40, 40, 40);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(IconoPerfil);
            panel1.Controls.Add(lblCerrarSesion);
            panel1.Controls.Add(lblAdmin);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(lblPersonal);
            panel1.Controls.Add(lblServicios);
            panel1.Controls.Add(lblCitas);
            panel1.Controls.Add(lblHome);
            panel1.Controls.Add(lblGestion);
            panel1.Controls.Add(iconoFP);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblPanel);
            panel1.Controls.Add(lblBernat);
            panel1.Location = new Point(3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(228, 633);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(39, 387);
            label7.Name = "label7";
            label7.Size = new Size(77, 25);
            label7.TabIndex = 21;
            label7.Text = "Admins";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(39, 347);
            label6.Name = "label6";
            label6.Size = new Size(73, 25);
            label6.TabIndex = 20;
            label6.Text = "Grupos";
            label6.Click += label6_Click;
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
            // lblPersonal
            // 
            lblPersonal.AutoSize = true;
            lblPersonal.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPersonal.ForeColor = Color.White;
            lblPersonal.Location = new Point(39, 313);
            lblPersonal.Name = "lblPersonal";
            lblPersonal.Size = new Size(80, 25);
            lblPersonal.TabIndex = 8;
            lblPersonal.Text = "Clientes";
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
            lblHome.Click += lblHome_Click_1;
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
            // Clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1095, 641);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Clientes";
            Text = "Usuarios";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IconoPerfil).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconoFP).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label4;
        private Label lblTitulo;
        private Label label2;
        private Label lblUbi;
        private Label lblBernatS;
        private Panel panel1;
        private PictureBox IconoPerfil;
        private Label lblCerrarSesion;
        private Label lblAdmin;
        private Label label1;
        private Label label9;
        private Label lblPersonal;
        private Label lblServicios;
        private Label lblCitas;
        private Label lblHome;
        private Label lblGestion;
        private PictureBox iconoFP;
        private Label label3;
        private Label lblPanel;
        private Label lblBernat;
        private Panel panel4;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Telefono;
        private DataGridViewTextBoxColumn Alérgenos;
        private DataGridViewTextBoxColumn Observaciones;
        private Panel panel3;
        private Button btnBorrar;
        private Button btnEditar;
        private TextBox textBox1;
        private Label lblBuscar;
        private Button btnAnyadir;
        private ComboBox comboBox1;
        private Label label7;
        private Label label6;
    }
}
