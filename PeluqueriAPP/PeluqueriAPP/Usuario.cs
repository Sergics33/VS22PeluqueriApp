using System.Text.Json.Serialization;

namespace PeluqueriAPP
{
    public class Usuario
    {
        public long Id { get; set; }

        [JsonPropertyName("nombreCompleto")]
        public string NombreCompleto { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("role")] // Asegúrate de que coincida con "role" o "rol" en tu JSON
        public string Rol { get; set; }

        [JsonPropertyName("password")]
        public string Contrasena { get; set; }

        // Campos específicos que vienen de la API según el tipo
        [JsonPropertyName("especialidad")]
        public string Especialidad { get; set; } // <--- ESTO SOLUCIONA EL ERROR

        [JsonPropertyName("telefono")]
        public string Telefono { get; set; }

        [JsonPropertyName("observaciones")]
        public string Observaciones { get; set; }   

        [JsonPropertyName("alergenos")]
        public string Alergenos { get; set; }

        [JsonPropertyName("clase")]
        public string Clase { get; set; }
    }
}