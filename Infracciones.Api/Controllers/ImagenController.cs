using Infracciones.BusinessLayer;
using Infracciones.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Infracciones.Api.Controllers
{
    public class ImagenController : ApiController
    {
        [HttpPost]
        [Route("Api/Imagen")]
        public IHttpActionResult Post(Imagen item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    item.Id = ImagenBl.Add(item);
                    return Created("", new { Id = item.Id });
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
