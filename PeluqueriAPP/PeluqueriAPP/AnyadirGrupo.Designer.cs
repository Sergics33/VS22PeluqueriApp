namespace PeluqueriAPP
{
    partial class AnyadirGrupo
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
            lbltitulo = new Label();
            lblAula = new Label();
            tbAula = new TextBox();
            lblClase = new Label();
            tbClase = new TextBox();
            lblModulo = new Label();
            tbModulo = new TextBox();
            btnAnyadir = new Button();

            SuspendLayout();

            // 
            // lbltitulo
            // 
            lbltitulo.AutoSize = true;
            lbltitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            lbltitulo.Location = new Point(45, 23);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new Size(200, 37);
            lbltitulo.TabIndex = 0;
            lbltitulo.Text = "AÑADIR GRUPO";

            // 
            // lblAula
            // 
            lblAula.AutoSize = true;
            lblAula.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblAula.Location = new Point(45, 100);
            lblAula.Name = "lblAula";
            lblAula.Size = new Size(40, 20);
            lblAula.TabIndex = 1;
            lblAula.Text = "Aula:";

            // 
            // tbAula
            // 
            tbAula.Location = new Point(138, 100);
            tbAula.Name = "tbAula";
            tbAula.Size = new Size(140, 23);
            tbAula.TabIndex = 2;

            // 
            // lblClase
            // 
            lblClase.AutoSize = true;
            lblClase.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblClase.Location = new Point(45, 150);
            lblClase.Name = "lblClase";
            lblClase.Size = new Size(48, 20);
            lblClase.TabIndex = 3;
            lblClase.Text = "Clase:";

            // 
            // tbClase
            // 
            tbClase.Location = new Point(138, 150);
            tbClase.Name = "tbClase";
            tbClase.Size = new Size(140, 23);
            tbClase.TabIndex = 4;

            // 
            // lblModulo
            // 
            lblModulo.AutoSize = true;
            lblModulo.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            lblModulo.Location = new Point(45, 200);
            lblModulo.Name = "lblModulo";
            lblModulo.Size = new Size(61, 20);
            lblModulo.TabIndex = 5;
            lblModulo.Text = "Módulo:";

            // 
            // tbModulo
            // 
            tbModulo.Location = new Point(138, 200);
            tbModulo.Name = "tbModulo";
            tbModulo.Size = new Size(140, 23);
            tbModulo.TabIndex = 6;

            // 
            // btnAnyadir
            // 
            btnAnyadir.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold | FontStyle.Italic);
            btnAnyadir.Location = new Point(138, 250);
            btnAnyadir.Name = "btnAnyadir";
            btnAnyadir.Size = new Size(144, 23);
            btnAnyadir.TabIndex = 7;
            btnAnyadir.Text = "AÑADIR GRUPO";
            btnAnyadir.UseVisualStyleBackColor = true;

            // 
            // AnyadirGrupo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 336);
            Controls.Add(btnAnyadir);
            Controls.Add(tbModulo);
            Controls.Add(lblModulo);
            Controls.Add(tbClase);
            Controls.Add(lblClase);
            Controls.Add(tbAula);
            Controls.Add(lblAula);
            Controls.Add(lbltitulo);
            Name = "AnyadirGrupo";
            Text = "Añadir Grupo";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lbltitulo;
        private Label lblAula;
        private TextBox tbAula;
        private Label lblClase;
        private TextBox tbClase;
        private Label lblModulo;
        private TextBox tbModulo;
        private Button btnAnyadir;
    }
}
