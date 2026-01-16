using System;
using System.Drawing;
using System.Windows.Forms;

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
            panel1 = new Panel();
            lblTitulo = new Label();
            panel3 = new Panel();
            btnBorrar = new Button();
            btnEditar = new Button();
            tbBusqueda = new TextBox();
            lblBuscar = new Label();
            btnAnyadir = new Button();
            dgvCitas = new DataGridView();

            SuspendLayout();

            // ============================
            // panel3
            // ============================
            panel3.BackColor = SystemColors.AppWorkspace;
            panel3.Controls.Add(btnBorrar);
            panel3.Controls.Add(btnEditar);
            panel3.Controls.Add(tbBusqueda);
            panel3.Controls.Add(lblBuscar);
            panel3.Controls.Add(btnAnyadir);
            panel3.Location = new Point(249, 152);
            panel3.Size = new Size(788, 83);

            // ============================
            // btnBorrar
            // ============================
            btnBorrar.Text = "Borrar Cita";
            btnBorrar.Location = new Point(668, 42);
            btnBorrar.Size = new Size(97, 23);

            // ============================
            // btnEditar
            // ============================
            btnEditar.Text = "Editar Cita";
            btnEditar.Location = new Point(554, 42);
            btnEditar.Size = new Size(97, 23);

            // ============================
            // tbBusqueda
            // ============================
            tbBusqueda.Location = new Point(17, 42);
            tbBusqueda.Size = new Size(388, 23);

            // ============================
            // lblBuscar
            // ============================
            lblBuscar.Text = "Buscar Citas";
            lblBuscar.Font = new System.Drawing.Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblBuscar.Location = new Point(17, 14);
            lblBuscar.AutoSize = true;

            // ============================
            // btnAnyadir
            // ============================
            btnAnyadir.Text = "Añadir Cita";
            btnAnyadir.Location = new Point(431, 42);
            btnAnyadir.Size = new Size(105, 23);

            // ============================
            // dgvCitas
            // ============================
            dgvCitas.Location = new Point(249, 255);
            dgvCitas.Size = new Size(788, 379);
            dgvCitas.AllowUserToAddRows = false;
            dgvCitas.AllowUserToDeleteRows = false;
            dgvCitas.ReadOnly = true;
            dgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCitas.MultiSelect = false;
            dgvCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // ============================
            // lblTitulo
            // ============================
            lblTitulo.Text = "Citas";
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, FontStyle.Bold);
            lblTitulo.Location = new Point(283, 66);
            lblTitulo.AutoSize = true;

            // ============================
            // Form Citas
            // ============================
            ClientSize = new Size(1052, 659);
            Controls.Add(panel3);
            Controls.Add(dgvCitas);
            Controls.Add(lblTitulo);
            Text = "Citas";
            Load += Citas_Load;

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblTitulo;
        private Panel panel3;
        private Button btnBorrar;
        private Button btnEditar;
        private TextBox tbBusqueda;
        private Label lblBuscar;
        private Button btnAnyadir;
        private DataGridView dgvCitas;
    }
}
