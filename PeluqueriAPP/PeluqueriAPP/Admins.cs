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

            // Suscripción al evento Load
            this.Load += Admins_Load;

            // Configuración DataGridView
            dgvAdmins.AutoGenerateColumns = false;
            dgvAdmins.ReadOnly = true;
            dgvAdmins.AllowUserToAddRows = false;
            dgvAdmins.AllowUserToDeleteRows = false;
            dgvAdmins.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdmins.MultiSelect = false;

            ConfigurarColumnas();

            // --- CORRECCIÓN ---
            // Se han eliminado las líneas de tbBusqueda.TextChanged, btnAnyadir.Click, etc.
            // porque ya están en el InitializeComponent() del archivo Designer.
            // Esto evita que las ventanas se abran dos veces.

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

                // Traer Admins
                try
                {
                    var responseAdmins = await httpClient.GetAsync("http://localhost:8080/api/admin/");
                    if (responseAdmins.IsSuccessStatusCode)
                    {
                        var admins = await responseAdmins.Content.ReadFromJsonAsync<List<Usuario>>();
                        if (admins != null) nuevaLista.AddRange(admins);
                    }
                }
                catch { /* Manejo silencioso en timer */ }

                // Traer Clientes
                try
                {
                    var responseClientes = await httpClient.GetAsync("http://localhost:8080/api/clientes/");
                    if (responseClientes.IsSuccessStatusCode)
                    {
                        var clientes = await responseClientes.Content.ReadFromJsonAsync<List<Usuario>>();
                        if (clientes != null) nuevaLista.AddRange(clientes);
                    }
                }
                catch { /* Manejo silencioso en timer */ }

                // Traer Grupos
                try
                {
                    var responseGrupos = await httpClient.GetAsync("http://localhost:8080/api/grupos/");
                    if (responseGrupos.IsSuccessStatusCode)
                    {
                        var grupos = await responseGrupos.Content.ReadFromJsonAsync<List<Usuario>>();
                        if (grupos != null) nuevaLista.AddRange(grupos);
                    }
                }
                catch { /* Manejo silencioso en timer */ }

                // Comparar para evitar parpadeos en el grid
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
                // Solo mostrar error si no es una operación de fondo (opcional)
                Console.WriteLine($"Error al refrescar: {ex.Message}");
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
                                MessageBox.Show("Usuario añadido correctamente.");
                            }
                            else
                            {
                                string contenido = await response.Content.ReadAsStringAsync();
                                MessageBox.Show($"Error al añadir: {response.StatusCode}\n{contenido}");
                            }
                            break;
                        }
                }
                await RefrescarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private async void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAdmins.SelectedRows.Count == 0) return;

            var row = dgvAdmins.SelectedRows[0];
            long id = Convert.ToInt64(row.Cells["Id"].Value);

            // Buscamos el usuario en la lista cargada
            var usuario = listaUsuariosOriginal.Find(u => u.Id == id);
            if (usuario == null) return;

            // Solo abrimos AnyadirAdmin si el rol es Admin
            if (usuario.Rol == "ROLE_ADMIN")
            {
                using var form = new AnyadirAdmin(usuario); // Pasamos el usuario al constructor
                if (form.ShowDialog() != DialogResult.OK) return;

                // Construimos el objeto para enviar a la API
                var request = new
                {
                    nombreCompleto = form.Nombre,
                    email = form.Email,
                    password = string.IsNullOrWhiteSpace(form.Contrasena) ? null : form.Contrasena,
                    especialidad = form.Especialidad
                };

                await EnviarActualizacion($"http://localhost:8080/api/admin/{id}", request);
            }
            else
            {
                MessageBox.Show("Por ahora solo se puede editar el perfil de Administrador desde aquí.");
            }
        }

        // Método auxiliar para no repetir código de red
        private async Task EnviarActualizacion(string url, object data)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
                var response = await httpClient.PutAsJsonAsync(url, data);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Actualizado correctamente.");
                    await RefrescarUsuarios();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {error}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}");
            }
        }

        private async void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvAdmins.SelectedRows.Count == 0) return;

            var row = dgvAdmins.SelectedRows[0];
            long id = Convert.ToInt64(row.Cells["Id"].Value);
            var usuario = listaUsuariosOriginal.Find(u => u.Id == id);
            if (usuario == null) return;

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

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario eliminado correctamente.");
                    await RefrescarUsuarios();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error {response.StatusCode}\n{error}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void lblServicios_Click(object sender, EventArgs e)
        {
            new Servicios().Show();
            this.Close();
        }

        private void lblHomeAdmin_Click(object sender, EventArgs e)
        {
            new Home().Show();
            this.Close();
        }

        private void lblAgenda_Click(object sender, EventArgs e)
        {
            new Agendas().Show();
            this.Close();
        }

        private void dgvAdmins_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}