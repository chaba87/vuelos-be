using System;

namespace Core.Model
{
    
    public class Flight
    {
        public int Id { get; set; }
        public string DepartureStation { get; set; }
        public City DepartureCity { get; set; }
        public int DepartureStationId { get; set; }
        public string ArrivalStation { get; set; }
        public City ArrivalCity { get; set; }
        public int ArrivalStationId { get; set; }
        public DateTime DepartureDate { get; set; }
        public string FlightNumber { get; set; }
        public float Price { get; set; }
        public string Currency { get; set; }
        public float DurationHour { get; set; }

    }

}
