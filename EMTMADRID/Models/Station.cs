using System;

namespace EMTMADRID.Models
{
    public class Station
    {
        public string StopId { get; set; }  // ID de la estación
        public string StopName { get; set; } // Nombre de la estación
        public double Latitude { get; set; }  // Latitud de la estación
        public double Longitude { get; set; } // Longitud de la estación
        public string Direction { get; set; }  // Dirección de la estación
    }

}
