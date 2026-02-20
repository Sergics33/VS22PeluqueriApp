using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PeluqueriAPP
{
    public class AgendaResponseDTO
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("aula")]
        public string Aula { get; set; }

        [JsonProperty("horaInicio")]
        public DateTime HoraInicio { get; set; }

        [JsonProperty("horaFin")]
        public DateTime HoraFin { get; set; }

        [JsonProperty("sillas")]
        public int Sillas { get; set; }

        [JsonProperty("bloqueada")]
        public bool Bloqueada { get; set; }

        // Este es el campo que acabas de activar en Java
        [JsonProperty("motivoBloqueo")]
        public string MotivoBloqueo { get; set; }

        [JsonProperty("servicio")]
        public ServicioDTO Servicio { get; set; }

        [JsonProperty("grupo")]
        public GrupoDTO Grupo { get; set; }

        [JsonProperty("horasDisponiblesEstado")]
        public Dictionary<string, bool> HorasDisponiblesEstado { get; set; } = new Dictionary<string, bool>();
    }

    public class ServicioDTO
    {
        [JsonProperty("id")]
        public long id { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
    }

    public class GrupoDTO
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("nombreCompleto")]
        public string NombreCompleto { get; set; }
    }
}