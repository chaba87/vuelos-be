using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Core.Model.Dao.Filters;

namespace Core.Model.Dao
{
    public class DaoFlight
    {
        public static List<Flight> GetAll()
        {
            try
            {
                using (var db = Configuration.Instance().ContextDB())
                {
                    return db.Flights.Include(x => x.ArrivalCity).Include(x => x.DepartureCity).ToList();
                }
            }
            catch (Exception ex)
            {
                CatchError.Log4Net("ERROR", ex);
                return null;
            }

        }

        public static List<Flight> GetByFilter(FlightFilter filter)
        {
            try
            {
                using (var db = Configuration.Instance().ContextDB())
                {
                    var departureDate = filter.DepartureDate.Date;
                    return db.Flights.Include(x => x.ArrivalCity).Include(x => x.DepartureCity)
                                        .Where(x => x.ArrivalStationId == filter.ArrivalStationId &&
                                                x.DepartureStationId == filter.DepartureStationId &&
                                                DbFunctions.TruncateTime(x.DepartureDate) == departureDate).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static Flight GetById(int id)
        {
            try
            {
                using (var db = Configuration.Instance().ContextDB())
                {
                    return db.Flights.Include(x => x.ArrivalCity).Include(x => x.DepartureCity)
                                        .FirstOrDefault(x => x.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static List<Flight> GetByHour(FlightFilter filter)
        {
            try
            {
                using (var db = Configuration.Instance().ContextDB())
                {
                    return db.Flights.Include(x => x.ArrivalCity).Include(x => x.DepartureCity)
                                        .Where(x => x.ArrivalStationId == filter.ArrivalStationId &&
                                                x.DepartureStationId == filter.DepartureStationId &&
                                                x.DepartureDate == filter.DepartureDate).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool Save(Flight flight)
        {
            try
            {
                using (var db = Configuration.Instance().ContextDB())
                {
                    flight.ArrivalCity = null;
                    flight.DepartureCity = null;
                    db.Flights.Add(flight);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}