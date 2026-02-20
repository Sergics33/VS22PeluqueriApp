using System;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using System.Net.Http.Headers;

namespace PeluqueriAPP
{
    public partial class AnyadirBloqueo : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/agendas/bloquear";

        public AnyadirBloqueo()
        {
            InitializeComponent();
            ConfigurarControlesManuales();
        }

        private void ConfigurarControlesManuales()
        {
            // Creamos y configuramos los Pickers para que encajen en el panel
            dtpHoraInicio.Format = DateTimePickerFormat.Custom;
            dtpHoraInicio.CustomFormat = "HH:mm";
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Font = new Font("Segoe UI", 11F);
            dtpHoraInicio.Location = new Point(20, 55);
            dtpHoraInicio.Size = new Size(200, 30);

            dtpHoraFin.Format = DateTimePickerFormat.Custom;
            dtpHoraFin.CustomFormat = "HH:mm";
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.Font = new Font("Segoe UI", 11F);
            dtpHoraFin.Location = new Point(20, 125);
            dtpHoraFin.Size = new Size(200, 30);

            txtMotivo.Font = new Font("Segoe UI", 11F);
            txtMotivo.Location = new Point(20, 195);
            txtMotivo.Size = new Size(200, 80);
            txtMotivo.Multiline = true;
            txtMotivo.BorderStyle = BorderStyle.None;

            // Añadirlos al panel contenedor
            panelContenedor.Controls.Add(dtpHoraInicio);
            panelContenedor.Controls.Add(dtpHoraFin);
            panelContenedor.Controls.Add(txtMotivo);
        }

        private async void btnGuardarBloqueo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Por favor, introduce un motivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime dia = calendarioBloqueo.SelectionStart;
            DateTime inicio = dia.Date.Add(dtpHoraInicio.Value.TimeOfDay);
            DateTime fin = dia.Date.Add(dtpHoraFin.Value.TimeOfDay);

            if (fin <= inicio)
            {
                MessageBox.Show("La hora de fin debe ser posterior a la de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var request = new
            {
                fechaInicio = inicio.ToString("yyyy-MM-ddTHH:mm:ss"),
                fechaFin = fin.ToString("yyyy-MM-ddTHH:mm:ss"),
                motivo = txtMotivo.Text.Trim()
            };

            try
            {
                btnGuardarBloqueo.Enabled = false;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var res = await httpClient.PostAsJsonAsync(API_BASE_URL, request);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Bloqueo aplicado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al aplicar el bloqueo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error de conexión: " + ex.Message); }
            finally { btnGuardarBloqueo.Enabled = true; }
        }
    }
}