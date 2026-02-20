using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PeluqueriAPP
{
    public partial class Bloqueos : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/agendas/";

        // Lista maestra para el buscador
        private List<dynamic> listaOriginalBloqueos = new List<dynamic>();

        public Bloqueos()
        {
            InitializeComponent();

            // Configuración de ventana (Pestaña)
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            // IMPORTANTE: Para que el filtro no cree columnas nuevas
            dgvBloqueos.AutoGenerateColumns = false;

            ConfigurarTabla();

            // Suscripción de eventos
            btnNuevoBloqueo.Click -= btnNuevoBloqueo_Click;
            btnNuevoBloqueo.Click += btnNuevoBloqueo_Click;
            btnBorrarBloqueo.Click -= btnBorrarBloqueo_Click;
            btnBorrarBloqueo.Click += btnBorrarBloqueo_Click;

            // Evento para filtrar mientras escribes
            tbBusqueda.TextChanged -= tbBusqueda_TextChanged;
            tbBusqueda.TextChanged += tbBusqueda_TextChanged;

            this.Load += async (s, e) => await CargarHistorial();
        }

        private void ConfigurarTabla()
        {
            // --- TUS ESTILOS VISUALES ORIGINALES ---
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(45, 45, 48);
            headerStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            headerStyle.ForeColor = Color.White;
            headerStyle.Padding = new Padding(10, 0, 0, 0);
            headerStyle.SelectionBackColor = Color.FromArgb(45, 45, 48);
            headerStyle.SelectionForeColor = Color.White;
            headerStyle.WrapMode = DataGridViewTriState.True;

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 9.5F);
            cellStyle.ForeColor = Color.FromArgb(70, 70, 70);
            cellStyle.Padding = new Padding(10, 0, 0, 0);
            cellStyle.SelectionBackColor = Color.FromArgb(235, 245, 255);
            cellStyle.SelectionForeColor = Color.FromArgb(0, 120, 215);
            cellStyle.WrapMode = DataGridViewTriState.False;

            // --- APLICAR PROPIEDADES AL DGV ---
            dgvBloqueos.AllowUserToAddRows = false;
            dgvBloqueos.AllowUserToDeleteRows = false;
            dgvBloqueos.BackgroundColor = Color.White;
            dgvBloqueos.BorderStyle = BorderStyle.None;
            dgvBloqueos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBloqueos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBloqueos.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvBloqueos.ColumnHeadersHeight = 45;
            dgvBloqueos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBloqueos.DefaultCellStyle = cellStyle;
            dgvBloqueos.EnableHeadersVisualStyles = false;
            dgvBloqueos.GridColor = Color.FromArgb(230, 230, 230);
            dgvBloqueos.RowTemplate.Height = 40;
            dgvBloqueos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBloqueos.MultiSelect = false;
            dgvBloqueos.ReadOnly = true;
            dgvBloqueos.RowHeadersVisible = false;
            dgvBloqueos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // --- CONFIGURACIÓN DE COLUMNAS (Manual para evitar cambios al filtrar) ---
            dgvBloqueos.Columns.Clear();

            dgvBloqueos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "id",
                Name = "IdCol",
                Visible = false
            });

            dgvBloqueos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Grupo",
                DataPropertyName = "grupoNombre",
                FillWeight = 100
            });

            dgvBloqueos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Inicio",
                DataPropertyName = "fechaInicioStr",
                FillWeight = 110
            });

            dgvBloqueos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fin",
                DataPropertyName = "horaFinStr",
                FillWeight = 60
            });

            dgvBloqueos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Motivo del Bloqueo",
                DataPropertyName = "motivo",
                FillWeight = 180
            });
        }

        private async Task CargarHistorial()
        {
            try
            {
                if (string.IsNullOrEmpty(Session.AccessToken)) return;

                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var response = await httpClient.GetAsync(API_BASE_URL);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var todas = JsonConvert.DeserializeObject<List<AgendaResponseDTO>>(json) ?? new List<AgendaResponseDTO>();

                    listaOriginalBloqueos = todas
                        .Where(a => a.Bloqueada)
                        .Select(a => (dynamic)new
                        {
                            id = a.Id,
                            grupoNombre = a.Grupo?.NombreCompleto ?? "Sin Grupo",
                            aula = a.Aula ?? "N/A",
                            fechaInicioStr = a.HoraInicio.ToString("dd/MM/yyyy HH:mm"),
                            horaFinStr = a.HoraFin.ToString("HH:mm"),
                            motivo = !string.IsNullOrWhiteSpace(a.MotivoBloqueo) ? a.MotivoBloqueo : "Bloqueo Administrativo"
                        })
                        .OrderByDescending(a => a.id)
                        .ToList<dynamic>();

                    AplicarFiltro();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al refrescar la lista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltro()
        {
            string busqueda = tbBusqueda.Text.Trim().ToLower();

            var filtrados = listaOriginalBloqueos.Where(a =>
                a.grupoNombre.ToLower().Contains(busqueda) ||
                a.motivo.ToLower().Contains(busqueda) ||
                a.aula.ToLower().Contains(busqueda) ||
                a.fechaInicioStr.ToLower().Contains(busqueda)
            ).ToList();

            // Cambiamos el DataSource sin destruir el diseño
            dgvBloqueos.DataSource = null;
            dgvBloqueos.DataSource = filtrados;
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private async void btnNuevoBloqueo_Click(object sender, EventArgs e)
        {
            using (AnyadirBloqueo form = new AnyadirBloqueo())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await Task.Delay(300);
                    await CargarHistorial();
                }
            }
        }

        private async void btnBorrarBloqueo_Click(object sender, EventArgs e)
        {
            if (dgvBloqueos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un bloqueo de la tabla para eliminar.", "Aviso");
                return;
            }

            var id = dgvBloqueos.SelectedRows[0].Cells["IdCol"].Value;
            var confirm = MessageBox.Show("¿Desea eliminar este bloqueo? Las horas volverán a estar disponibles.",
                                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
                    var response = await httpClient.DeleteAsync(API_BASE_URL + id);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Bloqueo eliminado correctamente.");
                        await CargarHistorial();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar: " + response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de red: " + ex.Message);
                }
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e) { }
    }
}