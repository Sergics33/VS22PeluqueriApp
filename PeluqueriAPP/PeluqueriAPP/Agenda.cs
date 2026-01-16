using System;

namespace PeluqueriAPP
{
    public class Agenda
    {
        public int id { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFin { get; set; }
        public string aula { get; set; }
        public Servicio servicio { get; set; }
        public Grupo grupo { get; set; }
    }
}
