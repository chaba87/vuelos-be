using System;

namespace Core.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public string BookingNumber { get; set; }
        public Passenger Passenger { get; set; }
        public int PassengerId { get; set; }
        public Flight Flight { get; set; }
        public int FlightId { get; set; }

    }

}
