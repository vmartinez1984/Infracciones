using Infracciones.Dto;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Infracciones.Api.Controllers
{
    public class ArticuloController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Articulo> lista;

                lista = ArticuloBl.GetAll();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
