using Core.Model.Dao;
using Core.Model.Dao.Filters;
using System;
using System.Web.Http;

namespace Services.Controllers
{
    [RoutePrefix("City")]
    [Authorize]
    public class CityController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var result = DaoCity.GetAll();

                var respuesta = new
                {
                    errorCode = 0,
                    messageError = "Consulta correcta.",
                    cities = result
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
        public IHttpActionResult Search(CityFilter filter)
        {
            try
            {
                var result = DaoCity.Search(filter.Search);

                var respuesta = new
                {
                    errorCode = 0,
                    messageError = "Consulta correcta.",
                    cities = result
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
        [Route("GetByCode")]
        public IHttpActionResult GetByCode(CityFilter filter)
        {
            try
            {
                var result = DaoCity.GetByCode(filter.IATACode);

                var respuesta = new
                {
                    errorCode = 0,
                    messageError = "Consulta correcta.",
                    city = result
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