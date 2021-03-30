using Infracciones.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Infracciones.Api.Controllers
{
    public class IncisoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Inciso> lista;

                lista = IncisoBl.GetAll();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
