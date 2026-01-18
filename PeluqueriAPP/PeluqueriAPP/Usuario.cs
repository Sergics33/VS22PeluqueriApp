using System.Text.Json.Serialization;

public class Usuario
{
    public long Id { get; set; }

    [JsonPropertyName("nombreCompleto")]
    public string NombreCompleto { get; set; }

    public string Email { get; set; }

    [JsonPropertyName("role")]
    public string Rol { get; set; }

    public string Contrasena { get; set; }
    public string Telefono { get; set; }
    public string Observaciones { get; set; }
    public string Alergenos { get; set; }

    public string Clase { get; set; }

}
