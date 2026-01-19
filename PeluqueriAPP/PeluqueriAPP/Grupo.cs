using Newtonsoft.Json;

public class Grupo
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("nombreCompleto")]
    public string NombreCompleto { get; set; }
}