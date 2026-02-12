namespace PeluqueriAPP
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            panel1 = new Panel();
            lblAgenda = new Label();
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
            panel2 = new Panel();
            label4 = new Label();
            lblTitulo = new Label();
            label2 = new Label();
            lblUbi = new Label();
            lblBernatS = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IconoPerfil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconoFP).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(lblAgenda);
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
            panel1.Location = new Point(-3, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(228, 633);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // lblAgenda
            // 
            lblAgenda.AutoSize = true;
            lblAgenda.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAgenda.ForeColor = Color.White;
            lblAgenda.Location = new Point(39, 345);
            lblAgenda.Name = "lblAgenda";
            lblAgenda.Size = new Size(77, 25);
            lblAgenda.TabIndex = 20;
            lblAgenda.Text = "Horario";
            lblAgenda.Click += lblAgenda_Click;
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
            IconoPerfil.Click += IconoPerfil_Click;
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
            lblCerrarSesion.Click += lblCerrarSesion_Click;
            // 
            // lblAdmin
            // 
            lblAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdmin.ForeColor = Color.WhiteSmoke;
            lblAdmin.Location = new Point(59, 557);
            lblAdmin.Name = "lblAdmin";
            lblAdmin.Size = new Size(90, 20);
            lblAdmin.TabIndex = 11;
            lblAdmin.Text = "Administradora";
            lblAdmin.Click += lblAdmin_Click;
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
            label1.Click += label1_Click;
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
            lblCitas.Location = new Point(39, 245);
            lblCitas.Name = "lblCitas";
            lblCitas.Size = new Size(54, 25);
            lblCitas.TabIndex = 6;
            lblCitas.Text = "Citas";
            lblCitas.Click += lblCitas_Click;
            // 
            // lblHome
            // 
            lblHome.AutoSize = true;
            lblHome.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHome.ForeColor = Color.White;
            lblHome.Location = new Point(39, 208);
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
            lblGestion.ForeColor = Color.WhiteSmoke;
            lblGestion.Location = new Point(39, 174);
            lblGestion.Name = "lblGestion";
            lblGestion.Size = new Size(59, 20);
            lblGestion.TabIndex = 4;
            lblGestion.Text = "Gestión";
            lblGestion.Click += lblGestion_Click;
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
            iconoFP.Click += iconoFP_Click;
            // 
            // label3
            // 
            label3.BackColor = Color.White;
            label3.Location = new Point(0, 163);
            label3.Name = "label3";
            label3.Size = new Size(228, 1);
            label3.TabIndex = 2;
            label3.Click += label3_Click;
            // 
            // lblPanel
            // 
            lblPanel.AutoSize = true;
            lblPanel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPanel.ForeColor = Color.WhiteSmoke;
            lblPanel.Location = new Point(27, 135);
            lblPanel.Name = "lblPanel";
            lblPanel.Size = new Size(169, 20);
            lblPanel.TabIndex = 1;
            lblPanel.Text = "Panel de Administración";
            lblPanel.Click += lblPanel_Click;
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
            lblBernat.Click += lblBernat_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(238, 238, 238);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(lblTitulo);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(lblUbi);
            panel2.Controls.Add(lblBernatS);
            panel2.Location = new Point(225, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1048, 630);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
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
            label4.Click += label4_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(34, 61);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(95, 37);
            lblTitulo.TabIndex = 20;
            lblTitulo.Text = "Home";
            lblTitulo.Click += lblTitulo_Click;
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
            lblUbi.Size = new Size(51, 20);
            lblUbi.TabIndex = 19;
            lblUbi.Text = "Home";
            lblUbi.Click += lblUbi_Click;
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
            lblBernatS.Click += lblBernatS_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1272, 628);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Home";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IconoPerfil).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconoFP).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblPanel;
        private Label lblBernat;
        private Label label3;
        private PictureBox iconoFP;
        private Label label9;
        private Label lblServicios;
        private Label lblCitas;
        private Label lblHome;
        private Label lblGestion;
        private PictureBox IconoPerfil;
        private Label lblCerrarSesion;
        private Label lblAdmin;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Label lblUbi;
        private Label lblBernatS;
        private Panel panelCitas;
        private Label label4;
        private Label lblTitulo;
        private Panel panelPorServi;
        private Panel panel3;
        private Label label5;
        private Panel panel4;
        private Label label7;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label lblAgenda;
    }
}