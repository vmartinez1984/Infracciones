using Infracciones.Dto;
using Infracciones.Persistencia.Dao;
using Infracciones.Persistencia.Entity;
using Infracciones.Repositorio;
using System;

namespace Infracciones.BusinessLayer
{
    public class ImagenBl
    {
        public static int Add(Imagen imagen)
        {
            try
            {
                string rutaDelArchivo;
                ImagenEntity entity;

                rutaDelArchivo = ImagenRepository.Add(imagen.NombreDelArchivo, imagen.BoletaDeSancionId, imagen.ImagenEnBase64);

                entity = new ImagenEntity
                {
                    BoletaDeSancionId = imagen.BoletaDeSancionId,
                    FechaDeRegistro = DateTime.Now,
                    IsActivo = true,
                    RutaDeArchivo = rutaDelArchivo,
                    TipoDeImagenId = imagen.TipoDeImagenId
                };
                imagen.Id =  ImagenDao.Add(entity);

                return imagen.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
