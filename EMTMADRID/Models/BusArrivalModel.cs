using System.Collections.Generic;

namespace EMTMADRID.Models
{
    public class BusArrivalResponse
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Datetime { get; set; }
        public List<BusArrivalData> Data { get; set; } // Cambiar a List<BusArrivalData>
    }

    public class BusArrivalData
    {
        public List<Arrival> Arrive { get; set; }
        public List<StopInfo> StopInfo { get; set; }
        public List<object> ExtraInfo { get; set; }
        public object Incident { get; set; }
    }

    public class Arrival
    {
        public string Line { get; set; }
        public string Stop { get; set; }
        public string Destination { get; set; }
        public int? EstimateArrive { get; set; }
        public int? DistanceBus { get; set; }
    }

    public class StopInfo
    {
        public List<LineInfo> Lines { get; set; }
        public string StopId { get; set; }
        public string StopName { get; set; }
        public Geometry Geometry { get; set; }
        public string Direction { get; set; }
    }

    public class LineInfo
    {
        public string Label { get; set; }
        public string Line { get; set; }
        public string NameA { get; set; }
        public string NameB { get; set; }
        public int MetersFromHeader { get; set; }
        public string To { get; set; }
        public string Color { get; set; }
    }

    public class Geometry
    {
        public string Type { get; set; }
        public List<double> Coordinates { get; set; }
    }
}
