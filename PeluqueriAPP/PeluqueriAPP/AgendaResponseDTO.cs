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

        [JsonProperty("servicio")]
        public ServicioDTO Servicio { get; set; }

        [JsonProperty("grupo")]
        public GrupoDTO Grupo { get; set; }

        [JsonProperty("horasDisponiblesEstado")]
        public Dictionary<string, bool> HorasDisponiblesEstado { get; set; }
    }

    // Clases auxiliares para evitar errores de referencia
    public class ServicioDTO
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
    }

    public class GrupoDTO
    {
        [JsonProperty("nombreCompleto")]
        public string NombreCompleto { get; set; }
    }
}