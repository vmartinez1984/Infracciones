using Infracciones.Dto;
using Infracciones.Mappers;
using Infracciones.Persistencia.Dao;
using Infracciones.Persistencia.Entity;
using System;

namespace Infracciones.BusinessLayer
{
    public class BoletaDeSancionBl
    {
        public static int Add(BoletaDeSancion boletaDeSancion)
        {
            try
            {
                BoletaDeSancionEntity entity;

                entity = BoletaDeSancionMapper.Get(boletaDeSancion);
                entity.Id = BoletaDeSancionDao.Add(entity);

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}