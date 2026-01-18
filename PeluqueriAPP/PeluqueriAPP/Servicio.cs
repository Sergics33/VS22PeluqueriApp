namespace PeluqueriAPP
{
    public class Servicio
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string descripcion { get; set; }
        public int duracion { get; set; }
        public decimal precio { get; set; } // <-- de double a decimal
        public TipoServicio tipoServicio { get; set; }
        public string tipoServicioNombre => tipoServicio?.nombre ?? "";
    }


    public class TipoServicio
    {
        public int id { get; set; }
        public string nombre { get; set; }  // Esto es lo que queremos mostrar
    }
}
