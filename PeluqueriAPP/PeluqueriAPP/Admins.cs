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
            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", Name = "NombreCol", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Apellidos", DataPropertyName = "Apellidos", Name = "ApellidosCol", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = "Email", Name = "EmailCol", Width = 200 });
            dgvAdmins.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Rol", DataPropertyName = "Rol", Name = "RolCol", Width = 100 });
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

            // Usamos ?. y ?? para evitar errores si algún campo viene nulo de la API
            var filtrada = listaUsuariosOriginal.FindAll(u =>
                (u.NombreCompleto?.ToLower().Contains(filtro) ?? false) ||
                (u.Email?.ToLower().Contains(filtro) ?? false) ||
                (u.Rol?.ToLower().Contains(filtro) ?? false) ||
                (u.Clase?.ToLower().Contains(filtro) ?? false) // Añadimos filtro por clase para grupos
            );

            dgvAdmins.DataSource = filtrada.Select(u =>
            {
                string nombreMostrado = "Sin Nombre";
                string apellidosMostrados = "";

                // Si es un grupo, quizás solo tiene NombreCompleto sin apellidos
                if (!string.IsNullOrEmpty(u.NombreCompleto))
                {
                    var partes = u.NombreCompleto.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    nombreMostrado = partes.Length > 0 ? partes[0] : "";
                    apellidosMostrados = partes.Length > 1 ? string.Join(' ', partes, 1, partes.Length - 1) : "";
                }
                else if (!string.IsNullOrEmpty(u.Clase))
                {
                    // Si NombreCompleto es nulo pero es un grupo con clase, lo usamos de nombre
                    nombreMostrado = u.Clase;
                }

                return new
                {
                    u.Id,
                    Nombre = nombreMostrado,
                    Apellidos = apellidosMostrados,
                    u.Email,
                    // Si Rol es nulo, ponemos un texto por defecto para ver qué está pasando
                    Rol = u.Rol?.Replace("ROLE_", "").ToUpper() ?? "S/R"
                };
            }).ToList();
        }

        // --- BOTÓN AÑADIR CORREGIDO PARA USAR TUS FORMS ---
        private async void BtnAnyadir_Click(object sender, EventArgs e)
        {
            using (var selector = new SeleccionarTipoUsuario())
            {
                if (selector.ShowDialog() == DialogResult.OK)
                {
                    string tipo = selector.TipoSeleccionado; // "Admin", "Grupo", "Cliente"

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
                                // AnyadirGrupo ya hace el PostAsJsonAsync internamente según tu código
                                await RefrescarUsuarios();
                            }
                        }
                    }
                    else if (tipo == "Cliente")
                    {
                        // Aquí abrirías AnyadirCliente cuando lo tengas
                        MessageBox.Show("Formulario de cliente en desarrollo.");
                    }
                }
            }
        }

        // Lógica de guardado para Administradores
        private async Task GuardarNuevoAdmin(AnyadirAdmin form)
        {
            var request = new
            {
                nombreCompleto = form.Nombre,
                email = form.Email,
                password = form.Contrasena,
                especialidad = form.Especialidad
            };

            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
                var res = await httpClient.PostAsJsonAsync("http://localhost:8080/api/auth/register/admin", request);

                if (res.IsSuccessStatusCode) MessageBox.Show("Administrador creado con éxito.");
                else MessageBox.Show("Error al crear administrador.");
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // --- BOTÓN EDITAR CORREGIDO ---
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
            else
            {
                MessageBox.Show("La edición para este tipo de usuario aún no está implementada.");
            }
        }

        private async Task ActualizarAdmin(long id, AnyadirAdmin form)
        {
            var request = new
            {
                nombreCompleto = form.Nombre,
                email = form.Email,
                especialidad = form.Especialidad,
                password = string.IsNullOrWhiteSpace(form.Contrasena) ? null : form.Contrasena
            };

            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);
                // Asegúrate de que esta URL PUT coincide con tu backend
                var res = await httpClient.PutAsJsonAsync($"http://localhost:8080/api/admin/{id}", request);

                if (res.IsSuccessStatusCode) MessageBox.Show("Datos actualizados.");
                else MessageBox.Show("Error al actualizar administrador.");
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