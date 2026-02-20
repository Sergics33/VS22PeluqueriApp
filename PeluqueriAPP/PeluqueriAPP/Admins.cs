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

            // Configuración del DataGridView
            dgvAdmins.AutoGenerateColumns = false;
            dgvAdmins.ReadOnly = true;
            dgvAdmins.AllowUserToAddRows = false;
            dgvAdmins.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdmins.MultiSelect = false;

            ConfigurarColumnas();

            // Timer para refrescar datos automáticamente cada 5 segundos
            timerRefrescar = new System.Windows.Forms.Timer { Interval = 5000 };
            timerRefrescar.Tick += async (s, e) => await RefrescarUsuarios();
            timerRefrescar.Start();
        }

        private void ConfigurarColumnas()
        {
            dgvAdmins.Columns.Clear();
            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Id", DataPropertyName = "Id", Name = "Id", Visible = false });
            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", Name = "NombreCol", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Apellidos/Info", DataPropertyName = "Apellidos", Name = "ApellidosCol", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = "Email", Name = "EmailCol", Width = 200 });
            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Rol", DataPropertyName = "Rol", Name = "RolCol", Width = 100 });
        }

        private async void Admins_Load(object sender, EventArgs e) => await RefrescarUsuarios();

        private async Task RefrescarUsuarios()
        {
            if (string.IsNullOrEmpty(Session.AccessToken)) return;

            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var nuevaLista = new List<Usuario>();
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
                    catch { /* Error silencioso por endpoint */ }
                }

                bool huboCambios = nuevaLista.Count != listaUsuariosOriginal.Count ||
                                  nuevaLista.Any(n => !listaUsuariosOriginal.Any(o => o.Id == n.Id));

                if (huboCambios)
                {
                    listaUsuariosOriginal = nuevaLista;
                    if (this.IsHandleCreated)
                    {
                        this.Invoke((MethodInvoker)delegate { AplicarFiltroYActualizarGrid(); });
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("Error refrescando: " + ex.Message); }
        }

        private void AplicarFiltroYActualizarGrid()
        {
            string filtro = tbBusqueda.Text.Trim().ToLower();

            // 1. Primero mapeamos los datos a la estructura final (la que el usuario ve)
            var listaMapeada = listaUsuariosOriginal.Select(u =>
            {
                string nombreMostrado = "Sin Nombre";
                string apellidosMostrados = "";
                string rolMostrado = u.Rol?.Replace("ROLE_", "").ToUpper() ?? "S/R";

                if (!string.IsNullOrEmpty(u.NombreCompleto))
                {
                    var partes = u.NombreCompleto.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    nombreMostrado = partes.Length > 0 ? partes[0] : "";
                    apellidosMostrados = partes.Length > 1 ? string.Join(' ', partes, 1, partes.Length - 1) : "";
                }
                else if (!string.IsNullOrEmpty(u.Clase))
                {
                    nombreMostrado = u.Clase;
                    apellidosMostrados = "(Grupo)";
                }

                return new
                {
                    u.Id,
                    Nombre = nombreMostrado,
                    Apellidos = apellidosMostrados,
                    Email = u.Email ?? "",
                    Rol = rolMostrado
                };
            }).ToList();

            // 2. Aplicamos el filtro sobre la lista mapeada (busca en todas las columnas visibles)
            var filtrada = listaMapeada.Where(x =>
                x.Nombre.ToLower().Contains(filtro) ||
                x.Apellidos.ToLower().Contains(filtro) ||
                x.Email.ToLower().Contains(filtro) ||
                x.Rol.ToLower().Contains(filtro)
            ).ToList();

            dgvAdmins.DataSource = null;
            dgvAdmins.DataSource = filtrada;
        }

        private async void BtnAnyadir_Click(object sender, EventArgs e)
        {
            using (var selector = new SeleccionarTipoUsuario())
            {
                if (selector.ShowDialog() == DialogResult.OK)
                {
                    string tipo = selector.TipoSeleccionado;

                    if (tipo == "Admin")
                    {
                        using (var form = new AnyadirAdmin())
                        {
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                await GuardarNuevoAdmin(form);
                                await RefrescarUsuarios();
                            }
                        }
                    }
                    else if (tipo == "Grupo")
                    {
                        using (var form = new AnyadirGrupo())
                        {
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                await Task.Delay(500);
                                await RefrescarUsuarios();
                            }
                        }
                    }
                    else if (tipo == "Cliente")
                    {
                        using (var form = new AnyadirCliente())
                        {
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                await GuardarNuevoCliente(form);
                                await RefrescarUsuarios();
                            }
                        }
                    }
                }
            }
        }

        private async Task GuardarNuevoAdmin(AnyadirAdmin form)
        {
            var request = new { nombreCompleto = form.Nombre, email = form.Email, password = form.Contrasena, especialidad = form.Especialidad };
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
                var res = await httpClient.PostAsJsonAsync("http://localhost:8080/api/auth/register/admin", request);
                if (res.IsSuccessStatusCode) MessageBox.Show("Administrador creado con éxito.");
                else MessageBox.Show("Error al crear administrador.");
            }
            catch (Exception ex) { MessageBox.Show("Error de red: " + ex.Message); }
        }

        private async Task GuardarNuevoCliente(AnyadirCliente form)
        {
            var request = new { nombreCompleto = form.Nombre, telefono = form.Telefono, email = form.Email, password = form.Password };
            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
                var res = await httpClient.PostAsJsonAsync("http://localhost:8080/api/auth/register/cliente", request);
                if (res.IsSuccessStatusCode) MessageBox.Show("Cliente registrado correctamente.");
                else MessageBox.Show("Error al registrar cliente.");
            }
            catch (Exception ex) { MessageBox.Show("Error de conexión: " + ex.Message); }
        }

        private async void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAdmins.SelectedRows.Count == 0) return;
            var row = dgvAdmins.SelectedRows[0];
            long id = Convert.ToInt64(row.Cells["Id"].Value);
            var usuario = listaUsuariosOriginal.Find(u => u.Id == id);

            if (usuario == null) return;

            if (usuario.Rol == "ROLE_ADMIN")
            {
                using (var form = new AnyadirAdmin(usuario))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        await ActualizarAdmin(id, form);
                        await RefrescarUsuarios();
                    }
                }
            }
            else if (usuario.Rol == "ROLE_CLIENTE")
            {
                using (var form = new AnyadirCliente(usuario))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        await ActualizarCliente(id, form);
                        await RefrescarUsuarios();
                    }
                }
            }
            else if (usuario.Rol == "ROLE_GRUPO")
            {
                using (var form = new AnyadirGrupo(usuario))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        await RefrescarUsuarios();
                    }
                }
            }
        }

        private async Task ActualizarAdmin(long id, AnyadirAdmin form)
        {
            var request = new { nombreCompleto = form.Nombre, email = form.Email, especialidad = form.Especialidad, password = string.IsNullOrWhiteSpace(form.Contrasena) ? null : form.Contrasena };
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
                var res = await httpClient.PutAsJsonAsync($"http://localhost:8080/api/admin/{id}", request);
                if (res.IsSuccessStatusCode) MessageBox.Show("Administrador actualizado.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async Task ActualizarCliente(long id, AnyadirCliente form)
        {
            var request = new
            {
                nombreCompleto = form.Nombre,
                telefono = form.Telefono,
                email = form.Email,
                password = string.IsNullOrWhiteSpace(form.Password) ? null : form.Password
            };
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
                var res = await httpClient.PutAsJsonAsync($"http://localhost:8080/api/clientes/{id}", request);
                if (res.IsSuccessStatusCode) MessageBox.Show("Cliente actualizado con éxito.");
                else MessageBox.Show("No se pudo actualizar el cliente.");
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private async void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvAdmins.SelectedRows.Count == 0) return;
            var row = dgvAdmins.SelectedRows[0];
            long id = Convert.ToInt64(row.Cells["Id"].Value);
            var usuario = listaUsuariosOriginal.Find(u => u.Id == id);
            if (usuario == null) return;

            if (MessageBox.Show($"¿Estás seguro de eliminar a {usuario.NombreCompleto ?? usuario.Clase}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string path = usuario.Rol == "ROLE_ADMIN" ? "admin" : usuario.Rol == "ROLE_CLIENTE" ? "clientes" : "grupos";
                try
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
                    var res = await httpClient.DeleteAsync($"http://localhost:8080/api/{path}/{id}");
                    if (res.IsSuccessStatusCode) await RefrescarUsuarios();
                    else MessageBox.Show("No se pudo eliminar el registro.");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void tbBusqueda_TextChanged(object sender, EventArgs e) => AplicarFiltroYActualizarGrid();

        private void lblServicios_Click(object sender, EventArgs e) { new Servicios().Show(); this.Close(); }
        private void lblHomeAdmin_Click(object sender, EventArgs e) { new Home().Show(); this.Close(); }
        private void lblAgenda_Click(object sender, EventArgs e) { new Agendas().Show(); this.Close(); }
    }
}