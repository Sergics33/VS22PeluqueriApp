public class Usuario
{
    public long Id { get; set; }
    public string NombreCliente { get; set; }  // antes NombreCompleto
    public string Email { get; set; }
    public string Contrasena { get; set; }
    public string Rol { get; set; }  // antes Role
    public string Telefono { get; set; }
    public string Observaciones { get; set; }
    public string Alergenos { get; set; }
}
