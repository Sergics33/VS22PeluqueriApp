public class Cita
{
    public long Id { get; set; }
    public DateTime FechaHoraInicio { get; set; }
    public Cliente Cliente { get; set; }
    public Agenda Agenda { get; set; }
}

public class Cliente
{
    public string NombreCompleto { get; set; }
}

public class Agenda
{
    public Servicio Servicio { get; set; }
    public string Aula { get; set; }
}

public class Servicio
{
    public string Nombre { get; set; }
}
