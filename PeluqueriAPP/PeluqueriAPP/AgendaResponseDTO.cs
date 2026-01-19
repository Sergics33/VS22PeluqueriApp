using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PeluqueriAPP
{
    public class AgendaResponseDTO
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("horaInicio")]
        public DateTime HoraInicio { get; set; }

        [JsonProperty("horaFin")]
        public DateTime HoraFin { get; set; }

        [JsonProperty("aula")]
        public string Aula { get; set; }

        [JsonProperty("sillas")]
        public int Sillas { get; set; }

        // 1. Usamos tus clases REALES en lugar de DTOs genéricos
        [JsonProperty("servicio")]
        public Servicio Servicio { get; set; }

        [JsonProperty("grupo")]
        public Grupo Grupo { get; set; }

        [JsonProperty("horasDisponiblesEstado")]
        public Dictionary<string, bool> HorasDisponiblesEstado { get; set; }
    }
}