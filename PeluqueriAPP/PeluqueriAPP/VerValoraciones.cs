using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PeluqueriAPP
{
    public partial class VerValoraciones : Form
    {
        private HttpClient httpClient = new HttpClient();
        private FlowLayoutPanel flowContenedor;
        private Label lblRuta;
        private Label lblTituloSeccion;
        private Label lblSubtitulo;
        private Panel panelBlancoFondo;

        public VerValoraciones()
        {
            InitializeComponent();
            ConfigurarDisenoEstiloPrincipal();
        }

        private void ConfigurarDisenoEstiloPrincipal()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Dock = DockStyle.Fill;

            lblRuta = new Label { Text = "Bernat Sarriá > Valoraciones", Font = new Font("Segoe UI", 9F), ForeColor = Color.Gray, Location = new Point(30, 20), AutoSize = true };
            lblTituloSeccion = new Label { Text = "Valoraciones", Font = new Font("Segoe UI", 24F, FontStyle.Bold), ForeColor = Color.Black, Location = new Point(25, 45), AutoSize = true };
            lblSubtitulo = new Label { Text = "Opiniones detalladas sobre la calidad del servicio", Font = new Font("Segoe UI", 10F), ForeColor = Color.Gray, Location = new Point(30, 90), AutoSize = true };

            panelBlancoFondo = new Panel
            {
                BackColor = Color.White,
                Location = new Point(30, 130),
                Size = new Size(this.Width - 60, this.Height - 180),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            flowContenedor = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(15), BackColor = Color.Transparent };

            panelBlancoFondo.Controls.Add(flowContenedor);
            this.Controls.AddRange(new Control[] { lblRuta, lblTituloSeccion, lblSubtitulo, panelBlancoFondo });
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await CargarValoraciones();
        }

        private async Task CargarValoraciones()
        {
            try
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.AccessToken);

                var response = await httpClient.GetAsync("http://localhost:8080/api/valoraciones/");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    // IMPORTANTE: Esto deserializa usando las reglas de Newtonsoft
                    var lista = JsonConvert.DeserializeObject<List<ValoracionDTO>>(json);

                    flowContenedor.Controls.Clear();
                    if (lista != null)
                    {
                        foreach (var val in lista)
                        {
                            flowContenedor.Controls.Add(CrearTarjetaEstiloApp(val));
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
        }

        private Panel CrearTarjetaEstiloApp(ValoracionDTO v)
        {
            Panel card = new Panel { Size = new Size(flowContenedor.Width - 50, 120), BackColor = Color.White, Margin = new Padding(0, 0, 0, 1), Padding = new Padding(10) };

            // Cálculo de media (incluyendo el factor General por si acaso)
            double media = (v.trato_personal + v.limpieza + v.desarrollo_servicio + v.claridad_comunicacion + v.general) / 5.0;
            if (media == 0 && v.general > 0) media = v.general; // Fallback

            int estrellas = (int)Math.Round(media);
            estrellas = Math.Max(1, Math.Min(5, estrellas)); // Asegurar entre 1 y 5

            Label stars = new Label { Text = new string('★', estrellas) + new string('☆', 5 - estrellas), ForeColor = Color.Orange, Font = new Font("Segoe UI", 12, FontStyle.Bold), Location = new Point(15, 10), AutoSize = true };
            Label comentario = new Label { Text = string.IsNullOrEmpty(v.comentario) ? "Sin comentario" : $"\"{v.comentario}\"", Font = new Font("Segoe UI", 10, FontStyle.Regular), ForeColor = Color.FromArgb(33, 37, 41), Location = new Point(15, 40), Size = new Size(card.Width - 40, 35), TextAlign = ContentAlignment.MiddleLeft };

            // Aquí se muestran los datos (si salen en 0 es porque el JsonProperty no coincide con el JSON del servidor)
            Label detalles = new Label { Text = $"TRATO: {v.trato_personal}/5  |  LIMPIEZA: {v.limpieza}/5  |  SERVICIO: {v.desarrollo_servicio}/5  |  COMUNICACIÓN: {v.claridad_comunicacion}/5", Font = new Font("Segoe UI", 8, FontStyle.Bold), ForeColor = Color.FromArgb(108, 117, 125), Location = new Point(15, 85), AutoSize = true };

            Panel linea = new Panel { BackColor = Color.FromArgb(230, 230, 230), Height = 1, Dock = DockStyle.Bottom };

            card.Controls.AddRange(new Control[] { stars, comentario, detalles, linea });
            return card;
        }
    }
}