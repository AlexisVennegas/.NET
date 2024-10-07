using System.Collections.Generic;
using EMTMADRID.Models;


namespace EMTMADRID.Models
{
    public class BusInputModel
    {
        public string StopId { get; set; }  // ID de la parada
        public string LineArrive { get; set; }  // Línea de autobús

        // Agrega una lista para almacenar los datos de llegada del autobús
         public List<Arrival> Arrive { get; set; }

    }
}
