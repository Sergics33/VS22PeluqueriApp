using System.Text.Json.Serialization;

namespace PeluqueriAPP
{
    public class UsuarioBase
    {
        public long Id { get; set; }

        [JsonPropertyName("nombreCompleto")]
        public string NombreCompleto { get; set; }

        public string Email { get; set; }

        [JsonPropertyName("role")]
        public string Rol { get; set; }

        // Solo para los grupos
        public string Clase { get; set; }
    }
}
