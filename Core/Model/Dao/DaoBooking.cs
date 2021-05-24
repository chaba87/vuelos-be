using Core.Utilities;
using System;
using System.Linq;
using System.Data.Entity;
using Core.Model.Dao.Filters;

namespace Core.Model.Dao
{
    public class DaoBooking
    {
        public static bool Save(Booking booking)
        {
            try
            {
                using (var db = Configuration.Instance().ContextDB())
                {
                    booking.Flight = null;
                    if (booking.Passenger != null) {
                        booking.Passenger = db.Passengers.Add(booking.Passenger);
                        db.SaveChanges();
                        booking.PassengerId = booking.Passenger.Id;
                        booking.Passenger = null;
                    }
                    db.Bookings.Add(booking);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static Booking GetByBookingNumber(BookingFilter filter)
        {
            try
            {
                using (var db = Configuration.Instance().ContextDB())
                {
                    return db.Bookings.Include(x => x.Passenger).Include(x => x.Flight).FirstOrDefault(x => x.BookingNumber.ToUpper() == filter.BookingNumber.ToUpper() 
                                                                        && x.Passenger.Lastname.ToUpper() == filter.LastName.ToUpper());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static Booking GetById(int id)
        {
            try
            {
                using (var db = Configuration.Instance().ContextDB())
                {
                    return db.Bookings.Include(x => x.Passenger).FirstOrDefault(x => x.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool Update(Booking booking)
        {
            try
            {
                using (var db = Configuration.Instance().ContextDB())
                {
                    Passenger passenger = null;
                    if(booking.Passenger != null && booking.Passenger.Id != 0)
                    {
                        passenger = db.Passengers.FirstOrDefault(x => x.Id == booking.Passenger.Id);
                        passenger.Email = booking.Passenger.Email;
                        passenger.CellNumber = booking.Passenger.CellNumber;
                        passenger.Lastname = booking.Passenger.Lastname;
                        passenger.Name = booking.Passenger.Name;

                        db.Passengers.Attach(passenger);
                        db.Entry(passenger).State = EntityState.Modified;
                    }
                    booking.Passenger = null;
                    db.Bookings.Attach(booking);
                    db.Entry(booking).State = EntityState.Modified;
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
