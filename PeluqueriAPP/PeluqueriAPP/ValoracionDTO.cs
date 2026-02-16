using System.Text.Json.Serialization;

namespace PeluqueriAPP
{
    // Esta es la clase que recibirá los datos de tu API de Java
    public class ValoracionDTO
    {
        [JsonPropertyName("tratoPersonal")]
        public double tratoPersonal { get; set; }

        [JsonPropertyName("desarrolloServicio")]
        public double desarrolloServicio { get; set; }

        [JsonPropertyName("claridadComunicacion")]
        public double claridadComunicacion { get; set; }

        [JsonPropertyName("limpieza")]
        public double limpieza { get; set; }

        [JsonPropertyName("general")]
        public double general { get; set; }

        // El id de la cita por si lo necesitas
        [JsonPropertyName("citaId")]
        public long citaId { get; set; }
    }
}