using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace PeluqueriAPP
{
    public partial class Admins : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private List<Usuario> listaUsuariosOriginal = new List<Usuario>();
        private System.Windows.Forms.Timer timerRefrescar;

        public Admins()
        {
            InitializeComponent();

            this.Load += Admins_Load;

            // Configuración DataGridView
            dgvAdmins.AutoGenerateColumns = false;
            dgvAdmins.ReadOnly = true;
            dgvAdmins.AllowUserToAddRows = false;
            dgvAdmins.AllowUserToDeleteRows = false;
            dgvAdmins.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdmins.MultiSelect = false;

            ConfigurarColumnas();

            // Timer refresco cada 5 segundos
            timerRefrescar = new System.Windows.Forms.Timer { Interval = 5000 };
            timerRefrescar.Tick += async (s, e) => await RefrescarUsuarios();
            timerRefrescar.Start();
        }

        private void ConfigurarColumnas()
        {
            dgvAdmins.Columns.Clear();
            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Id", DataPropertyName = "Id", Name = "Id", Visible = false });
            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", Name = "NombreCol" });
            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Apellidos", DataPropertyName = "Apellidos", Name = "ApellidosCol" });
            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = "Email", Name = "EmailCol" });
            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Rol", DataPropertyName = "Rol", Name = "RolCol" });
        }

        private async void Admins_Load(object sender, EventArgs e)
        {
            await RefrescarUsuarios();
        }

        private async Task RefrescarUsuarios()
        {
            if (string.IsNullOrEmpty(Session.AccessToken)) return;

            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var nuevaLista = new List<Usuario>();

                // LLAMADAS A LA API
                string[] endpoints = { "admin", "clientes", "grupos" };
                foreach (var endpoint in endpoints)
                {
                    try
                    {
                        var res = await httpClient.GetAsync($"http://localhost:8080/api/{endpoint}/");
                        if (res.IsSuccessStatusCode)
                        {
                            var lista = await res.Content.ReadFromJsonAsync<List<Usuario>>();
                            if (lista != null) nuevaLista.AddRange(lista);
                        }
                    }
                    catch { /* Error silencioso en refresco */ }
                }

                // Actualizar solo si hay cambios
                bool listaIgual = nuevaLista.Count == listaUsuariosOriginal.Count &&
                                 !nuevaLista.Except(listaUsuariosOriginal).Any();

                if (!listaIgual)
                {
                    listaUsuariosOriginal = nuevaLista;
                    AplicarFiltroYActualizarGrid();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void AplicarFiltroYActualizarGrid()
        {
            string filtro = tbBusqueda.Text.Trim().ToLower();
            var filtrada = listaUsuariosOriginal.FindAll(u =>
                (u.NombreCompleto?.ToLower().Contains(filtro) ?? false) ||
                (u.Email?.ToLower().Contains(filtro) ?? false) ||
                (u.Rol?.ToLower().Contains(filtro) ?? false)
            );

            dgvAdmins.DataSource = filtrada.ConvertAll(u =>
            {
                string nombre = "", apellidos = "";
                if (!string.IsNullOrEmpty(u.NombreCompleto))
                {
                    var partes = u.NombreCompleto.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    nombre = partes.Length > 0 ? partes[0] : "";
                    apellidos = partes.Length > 1 ? string.Join(' ', partes, 1, partes.Length - 1) : "";
                }
                return new
                {
                    u.Id,
                    Nombre = nombre,
                    Apellidos = apellidos,
                    u.Email,
                    Rol = u.Rol?.Replace("ROLE_", "").ToUpper()
                };
            });
        }

        // --- BOTÓN AÑADIR CORREGIDO ---
        private void BtnAnyadir_Click(object sender, EventArgs e)
        {
            using (var selector = new SeleccionarTipoUsuario())
            {
                if (selector.ShowDialog() == DialogResult.OK)
                {
                    // Usamos la NUEVA clase AnyadirUsuario y le pasamos el tipo (Cliente, Admin, Grupo)
                    using (var form = new AnyadirUsuario(selector.TipoSeleccionado))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            _ = RefrescarUsuarios(); // Recargar tras añadir
                        }
                    }
                }
            }
        }

        // --- BOTÓN EDITAR CORREGIDO ---
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAdmins.SelectedRows.Count == 0) return;

            var row = dgvAdmins.SelectedRows[0];
            long id = Convert.ToInt64(row.Cells["Id"].Value);
            var usuario = listaUsuariosOriginal.Find(u => u.Id == id);

            if (usuario != null)
            {
                // Usamos la clase AnyadirUsuario pasándole el objeto completo para editar
                using (var form = new AnyadirUsuario(usuario))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _ = RefrescarUsuarios();
                    }
                }
            }
        }

        private async void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvAdmins.SelectedRows.Count == 0) return;

            var row = dgvAdmins.SelectedRows[0];
            long id = Convert.ToInt64(row.Cells["Id"].Value);
            var usuario = listaUsuariosOriginal.Find(u => u.Id == id);
            if (usuario == null) return;

            var confirm = MessageBox.Show($"¿Eliminar a {usuario.NombreCompleto}?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            string path = usuario.Rol == "ROLE_ADMIN" ? "admin" :
                          usuario.Rol == "ROLE_CLIENTE" ? "clientes" : "grupos";

            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
                var res = await httpClient.DeleteAsync($"http://localhost:8080/api/{path}/{id}");

                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Eliminado con éxito.");
                    await RefrescarUsuarios();
                }
                else MessageBox.Show("Error al eliminar.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void TbBusqueda_TextChanged(object sender, EventArgs e) => AplicarFiltroYActualizarGrid();

        // Navegación
        private void lblServicios_Click(object sender, EventArgs e) { new Servicios().Show(); this.Close(); }
        private void lblHomeAdmin_Click(object sender, EventArgs e) { new Home().Show(); this.Close(); }
        private void lblAgenda_Click(object sender, EventArgs e) { new Agendas().Show(); this.Close(); }
    }
}