using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PeluqueriAPP
{
    public class AgendaServiceClient
    {
        public async Task<List<AgendaResponseDTO>> GetAgendasAsync(string url, string token)
        {
            using (var client = new HttpClient())
            {
                // 1. Limpieza de seguridad: eliminamos espacios y la palabra "Bearer" si ya viniera incluida
                string tokenLimpio = token.Replace("Bearer ", "").Trim();

                // 2. VERIFICACIÓN: Si esto sale sin puntos, el problema viene de donde obtienes el token
                if (!tokenLimpio.Contains("."))
                {
                    System.Windows.Forms.MessageBox.Show("¡ALERTA! El token que C# está intentando enviar no tiene formato JWT:\n\n" + tokenLimpio);
                }

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenLimpio);

                try
                {
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<AgendaResponseDTO>>(json);
                    }
                    else
                    {
                        // Si el servidor responde con error (401, 403), lo capturamos aquí
                        string errorBody = await response.Content.ReadAsStringAsync();
                        System.Windows.Forms.MessageBox.Show($"Error del servidor: {(int)response.StatusCode}\nCuerpo: {errorBody}");
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Excepción: " + ex.Message);
                }

                return new List<AgendaResponseDTO>();
            }
        }
    }
}