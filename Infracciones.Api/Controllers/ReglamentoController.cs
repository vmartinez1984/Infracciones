using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Infracciones.Dto;

namespace Infracciones.Api.Controllers
{
    public class ReglamentoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new { Version = 1 });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
