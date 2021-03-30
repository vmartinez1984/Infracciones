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
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("Api/Usuario/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Usuario item;

                item = UsuarioBl.Get(id);
                if (item == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(item);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("Api/Usuario/Login")]
        public IHttpActionResult Login(Usuario usuario)
        {
            try
            {
                Usuario item;

                item = UsuarioBl.Get(usuario.NombreDeUsuario, usuario.Contrasenia);

                return Ok(item);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
