using System;
using Newtonsoft.Json;

namespace PeluqueriAPP
{
    public class ValoracionDTO
    {
        [JsonProperty("id")]
        public long id { get; set; }

        // Mapeamos al nombre más probable que envía Java (camelCase)
        [JsonProperty("claridadComunicacion")]
        public int claridad_comunicacion { get; set; }

        [JsonProperty("comentario")]
        public string comentario { get; set; }

        [JsonProperty("desarrolloServicio")]
        public int desarrollo_servicio { get; set; }

        [JsonProperty("fotoUrl")]
        public string foto_url { get; set; }

        [JsonProperty("general")]
        public int general { get; set; }

        [JsonProperty("limpieza")]
        public int limpieza { get; set; }

        [JsonProperty("tratoPersonal")]
        public int trato_personal { get; set; }

        [JsonProperty("citaId")]
        public long cita_id { get; set; }
    }
}