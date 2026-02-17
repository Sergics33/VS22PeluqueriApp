using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;

namespace PeluqueriAPP
{
    public partial class Bloqueos : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/bloqueos/";

        // Colores de la App
        private Color colorNaranja = Color.FromArgb(255, 128, 0);
        private Color colorGrisBorde = Color.FromArgb(224, 224, 224);

        public Bloqueos()
        {
            InitializeComponent();
            ConfigurarEstilos();

            // Suscripción a eventos de dibujo
            panelContenedor.Paint += panelContenedor_Paint;
            btnGuardarBloqueo.Paint += btnRedondeado_Paint;
        }

        private void ConfigurarEstilos()
        {
            this.BackColor = Color.FromArgb(245, 245, 245);

            // Configuramos formato de horas (HH:mm)
            dtpHoraInicio.Format = DateTimePickerFormat.Custom;
            dtpHoraInicio.CustomFormat = "HH:mm";
            dtpHoraInicio.ShowUpDown = true;

            dtpHoraFin.Format = DateTimePickerFormat.Custom;
            dtpHoraFin.CustomFormat = "HH:mm";
            dtpHoraFin.ShowUpDown = true;

            // Para el TextBox de motivo, si quieres que no tenga bordes feos:
            txtMotivo.BorderStyle = BorderStyle.FixedSingle;

            this.Text = "Bloqueo de Horarios";
        }

        private async void btnGuardarBloqueo_Click(object sender, EventArgs e)
        {
            DateTime diaSeleccionado = calendarioBloqueo.SelectionStart;

            DateTime inicio = new DateTime(
                diaSeleccionado.Year, diaSeleccionado.Month, diaSeleccionado.Day,
                dtpHoraInicio.Value.Hour, dtpHoraInicio.Value.Minute, 0);

            DateTime fin = new DateTime(
                diaSeleccionado.Year, diaSeleccionado.Month, diaSeleccionado.Day,
                dtpHoraFin.Value.Hour, dtpHoraFin.Value.Minute, 0);

            if (fin <= inicio)
            {
                MessageBox.Show("La hora de fin debe ser posterior a la de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevoBloqueo = new
            {
                fechaInicio = inicio.ToString("yyyy-MM-ddTHH:mm:ss"),
                fechaFin = fin.ToString("yyyy-MM-ddTHH:mm:ss"),
                motivo = txtMotivo.Text.Trim()
            };

            try
            {
                // Solo si Session está disponible:
                // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                var response = await httpClient.PostAsJsonAsync(API_BASE_URL, nuevoBloqueo);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Bloqueo guardado correctamente.", "Éxito");
                    txtMotivo.Clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error de conexión: " + ex.Message); }
        }

        // --- MÉTODOS DE DIBUJO ---

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {
            // Dibujamos el borde redondeado del panel blanco principal
            DibujarBordeRedondeado(panelContenedor, e.Graphics, 20, 2, colorGrisBorde);

            // Opcional: Dibujar rectángulos grises suaves alrededor de los DateTimePickers 
            // para dar sensación de input moderno sin usar paneles extra
            using (Pen p = new Pen(Color.LightGray, 1))
            {
                // Alrededor de Hora Inicio
                e.Graphics.DrawRectangle(p, dtpHoraInicio.Bounds.X - 2, dtpHoraInicio.Bounds.Y - 2, dtpHoraInicio.Width + 4, dtpHoraInicio.Height + 4);
                // Alrededor de Hora Fin
                e.Graphics.DrawRectangle(p, dtpHoraFin.Bounds.X - 2, dtpHoraFin.Bounds.Y - 2, dtpHoraFin.Width + 4, dtpHoraFin.Height + 4);
            }
        }

        private void btnRedondeado_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedPath(btn.ClientRectangle, 15))
            {
                btn.Region = new Region(path);
                using (SolidBrush brush = new SolidBrush(btn.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle,
                    btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void DibujarBordeRedondeado(Control control, Graphics g, int radius, int thickness, Color color)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = GetRoundedPath(control.ClientRectangle, radius))
            {
                control.Region = new Region(path); // Esto hace que el panel sea físicamente redondeado
                using (Pen pen = new Pen(color, thickness))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r = radius;
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Width - r - 1, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Width - r - 1, rect.Height - r - 1, r, r, 0, 90);
            path.AddArc(rect.X, rect.Height - r - 1, r, r, 90, 90);
            path.CloseAllFigures();
            return path;
        }
    }
}