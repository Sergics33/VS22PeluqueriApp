using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Load += Admins_Load;

            // Configuración DataGridView
            dgvAdmins.AutoGenerateColumns = false;
            dgvAdmins.ReadOnly = true;
            dgvAdmins.AllowUserToAddRows = false;
            dgvAdmins.AllowUserToDeleteRows = false;
            dgvAdmins.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdmins.MultiSelect = false;

            ConfigurarColumnas();

            // Eventos
            tbBusqueda.TextChanged += TbBusqueda_TextChanged;
            btnAnyadir.Click += BtnAnyadir_Click;
            btnEditar.Click += BtnEditar_Click;
            btnBorrar.Click += BtnBorrar_Click;

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

                // ==========================
                // Traer Admins
                // ==========================
                try
                {
                    var responseAdmins = await httpClient.GetAsync("http://localhost:8080/api/admin/");
                    if (responseAdmins.IsSuccessStatusCode)
                    {
                        var admins = await responseAdmins.Content.ReadFromJsonAsync<List<Usuario>>();
                        if (admins != null) nuevaLista.AddRange(admins);
                    }
                    else
                    {
                        MessageBox.Show($"Error cargando admins: {responseAdmins.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener admins: {ex.Message}");
                }

                // ==========================
                // Traer Clientes
                // ==========================
                try
                {
                    var responseClientes = await httpClient.GetAsync("http://localhost:8080/api/clientes/");
                    if (responseClientes.IsSuccessStatusCode)
                    {
                        var clientes = await responseClientes.Content.ReadFromJsonAsync<List<Usuario>>();
                        if (clientes != null) nuevaLista.AddRange(clientes);
                    }
                    else
                    {
                        MessageBox.Show($"Error cargando clientes: {responseClientes.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener clientes: {ex.Message}");
                }

                // ==========================
                // Traer Grupos
                // ==========================
                // ==========================
                // Traer Grupos
                // ==========================
                try
                {
                    var responseGrupos = await httpClient.GetAsync("http://localhost:8080/api/grupos/");
                    if (responseGrupos.IsSuccessStatusCode)
                    {
                        // Deserializamos como Usuario, Clase viene incluida en la clase Usuario
                        var grupos = await responseGrupos.Content.ReadFromJsonAsync<List<Usuario>>();
                        if (grupos != null) nuevaLista.AddRange(grupos);
                    }
                    // No mostrar MessageBox en caso de error
                }
                catch
                {
                    // Ignorar errores temporales de grupos
                }


                // ==========================
                // Actualizar DataGridView
                // ==========================
                bool listaIgual = nuevaLista.Count == listaUsuariosOriginal.Count &&
                                  !nuevaLista.Except(listaUsuariosOriginal).Any();

                if (!listaIgual)
                {
                    long? idSeleccionado = null;
                    if (dgvAdmins.SelectedRows.Count > 0)
                        idSeleccionado = Convert.ToInt64(dgvAdmins.SelectedRows[0].Cells["Id"].Value);

                    listaUsuariosOriginal = nuevaLista;
                    AplicarFiltroYActualizarGrid();

                    if (idSeleccionado.HasValue)
                    {
                        foreach (DataGridViewRow row in dgvAdmins.Rows)
                        {
                            if (Convert.ToInt64(row.Cells["Id"].Value) == idSeleccionado.Value)
                            {
                                row.Selected = true;
                                dgvAdmins.CurrentCell = row.Cells[1];
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al refrescar usuarios: {ex.Message}");
            }
        }


        private void AplicarFiltroYActualizarGrid()
        {
            string filtro = tbBusqueda.Text.Trim().ToLower();
            var listaFiltrada = string.IsNullOrEmpty(filtro)
                ? listaUsuariosOriginal
                : listaUsuariosOriginal.FindAll(u =>
                    (u.NombreCompleto?.ToLower().Contains(filtro) ?? false) ||
                    (u.Email?.ToLower().Contains(filtro) ?? false) ||
                    (u.Rol?.ToLower().Contains(filtro) ?? false)
                );
            ActualizarGrid(listaFiltrada);
        }

        private void ActualizarGrid(List<Usuario> lista)
        {
            dgvAdmins.DataSource = null;

            var listaParaGrid = lista.ConvertAll(u =>
            {
                string nombre = "", apellidos = "";
                if (!string.IsNullOrEmpty(u.NombreCompleto))
                {
                    var partes = u.NombreCompleto.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (partes.Length > 0) nombre = partes[0];
                    if (partes.Length > 1) apellidos = string.Join(' ', partes, 1, partes.Length - 1);
                }

                string rol = u.Rol?.Replace("ROLE_", "").ToUpper() ?? "DESCONOCIDO";

                return new { u.Id, Nombre = nombre, Apellidos = apellidos, u.Email, Rol = rol };
            });

            dgvAdmins.DataSource = listaParaGrid;
        }

        private void TbBusqueda_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroYActualizarGrid();
        }

        // ============================
        // CRUD: AÑADIR
        // ============================
        private async void BtnAnyadir_Click(object sender, EventArgs e)
        {
            using var selector = new SeleccionarTipoUsuario();
            if (selector.ShowDialog() != DialogResult.OK) return;

            try
            {
                switch (selector.TipoSeleccionado)
                {
                    case "Grupo":
                        using (var formGrupo = new AnyadirGrupo())
                        {
                            if (formGrupo.ShowDialog() != DialogResult.OK) return;
                        }
                        break;

                    case "Cliente":
                    case "Admin":
                        {
                            using var form = new AnyadirAdmin();
                            if (form.ShowDialog() != DialogResult.OK) return;

                            var nuevoAdmin = new
                            {
                                nombreCompleto = form.Nombre,
                                email = form.Email,
                                password = form.Contrasena,
                                especialidad = form.Especialidad
                            };


                            var response = await httpClient.PostAsJsonAsync(
                                "http://localhost:8080/api/auth/register/admin",
                                nuevoAdmin
                            );

                            if (response.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Admin añadido correctamente.");
                                await RefrescarUsuarios();
                            }
                            else
                            {
                                string contenido = await response.Content.ReadAsStringAsync();
                                MessageBox.Show($"Error al añadir Admin: {response.StatusCode}\n{contenido}");
                            }

                            break;
                        }
                        break;
                }

                await RefrescarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        // ============================
        // CRUD: EDITAR
        // ============================
        private async void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAdmins.SelectedRows.Count == 0) return;

            var row = dgvAdmins.SelectedRows[0];
            long id = Convert.ToInt64(row.Cells["Id"].Value);
            var usuario = listaUsuariosOriginal.Find(u => u.Id == id);
            if (usuario == null) return;

            using var form = new AnyadirUsuario(usuario);
            if (form.ShowDialog() != DialogResult.OK) return;

            var request = new
            {
                nombreCompleto = form.Nombre,
                email = form.Email,
                password = form.Contrasena,
                telefono = form.Telefono,
                alergenos = form.Alergenos,
                observaciones = form.Observaciones
            };

            string url = usuario.Rol switch
            {
                "ROLE_ADMIN" => $"http://localhost:8080/api/admin/{id}",
                "ROLE_CLIENTE" => $"http://localhost:8080/api/clientes/{id}",
                "ROLE_GRUPO" => $"http://localhost:8080/api/grupos/{id}",
                _ => throw new Exception("Rol no válido")
            };

            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var response = await httpClient.PutAsJsonAsync(url, request);

                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error {response.StatusCode}\n{error}");
                    return;
                }

                MessageBox.Show("Usuario editado correctamente.");
                await RefrescarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        // ============================
        // CRUD: BORRAR
        // ============================
        private async void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvAdmins.SelectedRows.Count == 0) return;

            var row = dgvAdmins.SelectedRows[0];
            long id = Convert.ToInt64(row.Cells["Id"].Value);
            var usuario = listaUsuariosOriginal.Find(u => u.Id == id);

            var confirm = MessageBox.Show("¿Eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            string url = usuario.Rol switch
            {
                "ROLE_ADMIN" => $"http://localhost:8080/api/admin/{id}",
                "ROLE_CLIENTE" => $"http://localhost:8080/api/clientes/{id}",
                "ROLE_GRUPO" => $"http://localhost:8080/api/grupos/{id}",
                _ => throw new Exception("Rol no válido")
            };

            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var response = await httpClient.DeleteAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error {response.StatusCode}\n{error}");
                    return;
                }

                MessageBox.Show("Usuario eliminado correctamente.");
                await RefrescarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void lblServicios_Click(object sender, EventArgs e)
        {
            Servicios nuevaVentana = new Servicios();
            nuevaVentana.Show();
            this.Close();
        }

        private void lblHomeAdmin_Click(object sender, EventArgs e)
        {
            Home nuevaVentana = new Home();
            nuevaVentana.Show();
            this.Close();
        }

        private void dgvAdmins_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblAgenda_Click(object sender, EventArgs e)
        {
            Admins nuevaVentana = new Admins();
            nuevaVentana.Show();
            this.Close();
        }
    }
}
