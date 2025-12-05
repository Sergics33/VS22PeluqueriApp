namespace PeluqueriAPP
{
    public class Servicio
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; } // añadida descripción
        public int duracion { get; set; }
        public double precio { get; set; }

        // Solo mantenemos la referencia al tipo de servicio para mostrar su nombre
        public TipoServicio tipoServicio { get; set; }

        // Propiedad calculada para facilitar la visualización en el DataGridView
        public string tipoServicioNombre => tipoServicio?.nombre ?? "";
    }

    public class TipoServicio
    {
        public int id { get; set; }
        public string nombre { get; set; }  // Esto es lo que queremos mostrar
    }
}
