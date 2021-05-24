using Core.Model;
using Core.Model.Dao;
using Core.Model.Dao.Filters;
using System;
using System.Linq;
using System.Web.Http;

namespace Services.Controllers
{
    [RoutePrefix("Booking")]
    [Authorize]
    public class BookingController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("Filter")]
        public IHttpActionResult GetByFilter(BookingFilter filter)
        {
            try
            {
                var result = DaoBooking.GetByBookingNumber(filter);

                var respuesta = new
                {
                    errorCode = 0,
                    messageError = "Consulta correcta.",
                    booking = result
                };

                return Ok(respuesta);

            }
            catch (Exception ex)
            {
                CatchError.Log4Net("ERROR", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("GetById/{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var result = DaoBooking.GetById(id);

                var respuesta = new
                {
                    errorCode = 0,
                    messageError = "Consulta correcta.",
                    booking = result
                };

                return Ok(respuesta);

            }
            catch (Exception ex)
            {
                CatchError.Log4Net("ERROR", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Update")]
        public IHttpActionResult Update(Booking booking)
        {
            try
            {
                DaoBooking.Update(booking);

                var respuesta = new
                {
                    errorCode = 0,
                    messageError = "Se actualizo correctamente"
                };

                return Ok(respuesta);

            }
            catch (Exception ex)
            {
                CatchError.Log4Net("ERROR", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Save")]
        public IHttpActionResult Save(Booking booking)
        {
            try
            {
                booking.BookingNumber = RandomString(7);
                DaoBooking.Save(booking);

                var respuesta = new
                {
                    errorCode = 0,
                    messageError = "Se guardo correctamente"
                };

                return Ok(respuesta);

            }
            catch (Exception ex)
            {
                CatchError.Log4Net("ERROR", ex);
                return BadRequest(ex.Message);
            }
        }

        private static Random random = new Random();
        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }

}