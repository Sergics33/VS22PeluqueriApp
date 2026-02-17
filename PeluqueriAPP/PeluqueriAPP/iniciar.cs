using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Http.Headers;

namespace PeluqueriAPP
{
    public partial class iniciar : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:8080/api/auth/login";

        public iniciar()
        {
            InitializeComponent();
            ConfigurarEstilos();

            pnlLateral.Paint += PnlLateral_Paint;
            iconoFP.Paint += IconoFP_Paint;

            // 1. Foco automático al abrir
            this.Load += Iniciar_Load;

            // 2. Detectar Enter en los campos
            txtUsuario.KeyDown += Login_KeyDown;
            txtContrasenya.KeyDown += Login_KeyDown;
        }

        private void Iniciar_Load(object sender, EventArgs e)
        {
            // Ponemos el foco en el usuario al arrancar
            this.ActiveControl = txtUsuario;
            txtUsuario.Focus();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            // 3. Si pulsa Enter, ejecuta el clic del botón iniciar
            if (e.KeyCode == Keys.Enter)
            {
                // Evita el sonido de "beep" de Windows al dar Enter en un TextBox
                e.SuppressKeyPress = true;
                btnIniciar_Click(sender, e);
            }
        }

        private void ConfigurarEstilos()
        {
            // Configuramos las cápsulas grises redondeadas para los inputs
            ConfigurarCapsulaLogin(txtUsuario, 165, 85, 0); // TabIndex 0
            ConfigurarCapsulaLogin(txtContrasenya, 165, 148, 1); // TabIndex 1

            btnIniciar.TabIndex = 2; // El botón será el siguiente en el Tab
        }

        private void ConfigurarCapsulaLogin(TextBox txt, int x, int y, int tabIdx)
        {
            Color grisSutil = Color.FromArgb(245, 245, 245);

            Panel pnlFondo = new Panel();
            pnlFondo.BackColor = grisSutil;
            pnlFondo.Size = new Size(215, 36);
            pnlFondo.Location = new Point(x, y);

            // Ajuste del TextBox
            txt.Parent = pnlFondo;
            txt.BackColor = grisSutil;
            txt.BorderStyle = BorderStyle.None;
            txt.Multiline = false;
            txt.Width = pnlFondo.Width - 20;
            txt.Location = new Point(10, 10);

            // Configurar el orden de tabulación
            txt.TabIndex = tabIdx;

            this.Controls.Add(pnlFondo);
            pnlFondo.BringToFront();

            pnlFondo.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = CrearPathRedondeado(pnlFondo.ClientRectangle, 15))
                {
                    pnlFondo.Region = new Region(path);
                    using (Pen pen = new Pen(Color.FromArgb(225, 225, 225), 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };
        }

        private GraphicsPath CrearPathRedondeado(Rectangle rect, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            int diametro = radio * 2;
            path.AddArc(rect.X, rect.Y, diametro, diametro, 180, 90);
            path.AddArc(rect.Right - diametro, rect.Y, diametro, diametro, 270, 90);
            path.AddArc(rect.Right - diametro, rect.Bottom - diametro, diametro, diametro, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diametro, diametro, diametro, 90, 90);
            path.CloseAllFigures();
            return path;
        }

        // --- MÉTODOS DE DISEÑO LATERAL ---

        private void IconoFP_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.FillEllipse(brush, 1, 1, iconoFP.Width - 2, iconoFP.Height - 2);
            }
            if (iconoFP.Image != null)
            {
                int p = 12;
                e.Graphics.DrawImage(iconoFP.Image, new Rectangle(p, p + 8, iconoFP.Width - (p * 2), iconoFP.Height - (p * 2)));
            }
        }

        private void PnlLateral_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(pnlLateral.ClientRectangle,
                Color.FromArgb(255, 110, 0), Color.FromArgb(255, 170, 40), LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, pnlLateral.ClientRectangle);
            }
        }

        // --- LÓGICA DE LOGIN ---

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContrasenya.Text))
            {
                MessageBox.Show("Por favor, rellene los campos.");
                return;
            }

            btnIniciar.Enabled = false;
            try
            {
                var response = await httpClient.PostAsJsonAsync(API_BASE_URL, new { email = txtUsuario.Text.Trim(), password = txtContrasenya.Text.Trim() });
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    Session.AccessToken = data.AccessToken;
                    Session.TokenType = data.TokenType;
                    Session.Username = data.Username;

                    new Home().Show();
                    this.Hide();
                }
                else { MessageBox.Show("Credenciales incorrectas."); }
            }
            catch { MessageBox.Show("Error de red."); }
            finally { btnIniciar.Enabled = true; }
        }

        private class LoginResponse
        {
            public string AccessToken { get; set; }
            public string TokenType { get; set; }
            public string Username { get; set; }
        }
    }
}