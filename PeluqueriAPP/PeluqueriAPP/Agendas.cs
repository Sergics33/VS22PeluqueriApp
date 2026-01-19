using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PeluqueriAPP
{
    public partial class Agendas : Form
    {
        private AgendaServiceClient agendaClient;

        public Agendas()
        {
            InitializeComponent();
            agendaClient = new AgendaServiceClient();

            // Suscribir el evento Load para que cargue los datos al abrir la ventana
            this.Load += Agendas_Load;
        }

        #region Navegación
        private void lblHomeAdmin_Click(object sender, EventArgs e)
        {
            Home anterior = new Home();
            anterior.Show();
            this.Close();
        }

        private void lblCitas_Click(object sender, EventArgs e)
        {
            Citas anterior = new Citas();
            anterior.Show();
            this.Close();
        }

        private void lblServicios_Click(object sender, EventArgs e)
        {
            Servicios anterior = new Servicios();
            anterior.Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Admins anterior = new Admins();
            anterior.Show();
            this.Close();
        }
        #endregion

        private async void Agendas_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. CONFIGURACIÓN DE SEGURIDAD
                // -------------------------------------------------------------------------------------
                // BORRA la frase de abajo y PEGA el token largo de Postman (el que empieza por eyJ...)
                // DEBE QUEDAR ALGO COMO: string jwtToken = "eyJhbGci...puntos...más_letras";
                // -------------------------------------------------------------------------------------
                string jwtToken = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJhYmMiLCJpYXQiOjE3Njg3NTc1NjcsImV4cCI6MTc2ODg0Mzk2N30.SAf6Ma1ocePpxtSy2Ldvm6HIu2_SSjnHboV0ROZlZ6vrcw2tNDlxHYTdUWD4jWOqJa_tI72uzj0oXH75_bSNQg";

                string apiUrl = "http://localhost:8080/api/agendas/";

                // 2. OBTENER DATOS DESDE EL BACKEND
                // El método GetAgendasAsync ya gestiona la cabecera "Bearer"
                var agendas = await agendaClient.GetAgendasAsync(apiUrl, jwtToken);

                // 3. LIMPIEZA DE LA TABLA
                dgvServicios.Rows.Clear();
                dgvServicios.Columns.Clear();

                // 4. CONFIGURAR COLUMNAS
                dgvServicios.Columns.Add("Id", "ID");
                dgvServicios.Columns.Add("Aula", "Aula");
                dgvServicios.Columns.Add("HoraInicio", "Fecha e Inicio");
                dgvServicios.Columns.Add("HoraFin", "Hora Fin");
                dgvServicios.Columns.Add("Servicio", "Servicio");
                dgvServicios.Columns.Add("Grupo", "Grupo");
                dgvServicios.Columns.Add("Disponibilidad", "Estado de Horas");

                // 5. VALIDAR SI LA LISTA LLEGÓ VACÍA
                if (agendas == null || !agendas.Any())
                {
                    // Si no hay datos, salimos para no procesar el bucle
                    return;
                }

                // 6. CARGAR FILAS EN EL DATAGRIDVIEW
                foreach (var agenda in agendas)
                {
                    // Procesamos el diccionario de horas disponibles (JSON -> String legible)
                    string estadoHoras = "Sin datos";
                    if (agenda.HorasDisponiblesEstado != null && agenda.HorasDisponiblesEstado.Count > 0)
                    {
                        var listaEstados = agenda.HorasDisponiblesEstado
                            .OrderBy(h => h.Key) // Ordenar por hora
                            .Select(h => $"{h.Key:HH:mm}: {(h.Value ? "Libre" : "Ocupado")}");

                        estadoHoras = string.Join(" | ", listaEstados);
                    }

                    // Añadir la fila con los datos mapeados del DTO
                    dgvServicios.Rows.Add(
                        agenda.Id,
                        agenda.Aula,
                        agenda.HoraInicio.ToString("dd/MM/yyyy HH:mm"),
                        agenda.HoraFin.ToString("HH:mm"),
                        agenda.Servicio?.Nombre ?? "N/A",
                        agenda.Grupo?.NombreCompleto ?? "N/A",
                        estadoHoras
                    );
                }

                // 7. APLICAR FORMATO VISUAL
                PersonalizarDisenoTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la interfaz de Agendas: " + ex.Message,
                                "Error de Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PersonalizarDisenoTabla()
        {
            // Ajustes automáticos de tamaño
            dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicios.AllowUserToAddRows = false;
            dgvServicios.ReadOnly = true;
            dgvServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Configuración multi-línea para que el estado de las horas se lea completo
            dgvServicios.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvServicios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Mejora estética de cabeceras
            dgvServicios.EnableHeadersVisualStyles = false;
            dgvServicios.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
        }
    }
}