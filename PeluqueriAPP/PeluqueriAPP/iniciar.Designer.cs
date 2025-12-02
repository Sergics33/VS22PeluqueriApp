namespace PeluqueriAPP
{
    partial class iniciar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iniciar));
            iconoFP = new PictureBox();
            txtUsuario = new TextBox();
            lblUsuario = new Label();
            lblContrasenya = new Label();
            txtContrasenya = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)iconoFP).BeginInit();
            SuspendLayout();
            // 
            // iconoFP
            // 
            iconoFP.Image = (Image)resources.GetObject("iconoFP.Image");
            iconoFP.Location = new Point(12, 59);
            iconoFP.Name = "iconoFP";
            iconoFP.Size = new Size(116, 119);
            iconoFP.SizeMode = PictureBoxSizeMode.Zoom;
            iconoFP.TabIndex = 4;
            iconoFP.TabStop = false;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(152, 77);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(141, 23);
            txtUsuario.TabIndex = 5;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(152, 59);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(104, 15);
            lblUsuario.TabIndex = 6;
            lblUsuario.Text = "Introducir usuario:";
            lblUsuario.Click += label1_Click;
            // 
            // lblContrasenya
            // 
            lblContrasenya.AutoSize = true;
            lblContrasenya.Location = new Point(152, 124);
            lblContrasenya.Name = "lblContrasenya";
            lblContrasenya.Size = new Size(123, 15);
            lblContrasenya.TabIndex = 7;
            lblContrasenya.Text = "Introducir contraseña:";
            // 
            // txtContrasenya
            // 
            txtContrasenya.Location = new Point(152, 142);
            txtContrasenya.Name = "txtContrasenya";
            txtContrasenya.Size = new Size(141, 23);
            txtContrasenya.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(177, 183);
            button1.Name = "button1";
            button1.Size = new Size(87, 23);
            button1.TabIndex = 9;
            button1.Text = "Iniciar Sesion";
            button1.UseVisualStyleBackColor = true;
            // 
            // iniciar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 229);
            Controls.Add(button1);
            Controls.Add(txtContrasenya);
            Controls.Add(lblContrasenya);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(iconoFP);
            Name = "iniciar";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)iconoFP).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox iconoFP;
        private TextBox txtUsuario;
        private Label lblUsuario;
        private Label lblContrasenya;
        private TextBox txtContrasenya;
        private Button button1;
    }
}