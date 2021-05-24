using System;
using System.Web.Http;
using Core.Model;
using Core.Model.Dao;
using Core.Model.Dao.Filters;
using Core.Utilities;

namespace Services.Controllers
{
    [RoutePrefix("Flights")]
    [Authorize]
    public class UploadController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var result = DaoFlight.GetAll();

                var respuesta = new
                {
                    errorCode = 0,
                    messageError = "Consulta correcta.",
                    flights = result
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
        [Route("Filter")]
        public IHttpActionResult GetByFilter(FlightFilter filter)
        {
            try
            {
                var result = DaoFlight.GetByFilter(filter);

                var respuesta = new
                {
                    errorCode = 0,
                    messageError = "Consulta correcta.",
                    flights = result
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
                var result = DaoFlight.GetById(id);

                var respuesta = new
                {
                    errorCode = 0,
                    messageError = "Consulta correcta.",
                    flight = result
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
        [Route("HourFilter")]
        public IHttpActionResult GetByHourFilter(FlightFilter filter)
        {
            try
            {
                var result = DaoFlight.GetByHour(filter);

                var respuesta = new
                {
                    errorCode = 0,
                    messageError = "Consulta correcta.",
                    flights = result
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
        [Route("Search")]
        public IHttpActionResult Search(FlightFilter filter)
        {
            try
            {
                var result = SearchFlight.GetFlights(filter);

                var respuesta = new
                {
                    errorCode = 0,
                    messageError = "Consulta correcta.",
                    flights = result
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
        public IHttpActionResult Save(Flight flight)
        {
            try
            {
                var departureCity = flight.DepartureCity;
                var arrivalCity = flight.ArrivalCity;
                DaoFlight.Save(flight);

                var respuesta = new
                {
                    errorCode = 0,
                    messageError = $"Se guardo correctamente el vuelo {flight.FlightNumber} de {departureCity.IATACode} a {arrivalCity.IATACode}.",
                    flight = flight
                };

                return Ok(respuesta);

            }
            catch (Exception ex)
            {
                CatchError.Log4Net("ERROR", ex);
                return BadRequest(ex.Message);
            }
        }

    }

}
