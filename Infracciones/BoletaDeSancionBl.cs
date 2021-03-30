using Infracciones.Dto;
using Infracciones.Mappers;
using Infracciones.Persistencia.Dao;
using Infracciones.Persistencia.Entity;
using System;
using System.Collections.Generic;

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

        public static List<BoletaDeSancion> Get(string placa)
        {
            try
            {
                List<BoletaDeSancion> lista;
                List<BoletaDeSancionEntity> entities;

                entities = BoletaDeSancionDao.Get(placa);
                lista = BoletaDeSancionMapper.GetAll(entities);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static BoletaDeSancion Get(int id)
        {
            try
            {
                BoletaDeSancion item;
                BoletaDeSancionEntity entity;

                entity = BoletaDeSancionDao.Get(id);
                item = BoletaDeSancionMapper.Get(entity);

                return item;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}