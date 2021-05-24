using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model.Dao.Filters
{
    public class FlightFilter
    {
        public int ArrivalStationId { get; set; }
        public int DepartureStationId { get; set; }
        public DateTime DepartureDate { get; set; }

    }

}
