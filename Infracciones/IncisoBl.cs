using Infracciones.Dto;
using Infracciones.Mappers;
using Infracciones.Persistencia.Dao;
using Infracciones.Persistencia.Entity;
using System;
using System.Collections.Generic;

namespace Infracciones
{
  public  class IncisoBl
    {
        public static void Add(Inciso item)
        {
            try
            {
                IncisoEntity entity;

                entity = IncisoMapper.Get(item);

                IncisoDao.Add(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Delete(int id, int usuarioIdBaja)
        {
            try
            {
                IncisoDao.Delete(id, usuarioIdBaja);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Inciso Get(int id)
        {
            Inciso item;
            IncisoEntity entity;

            entity = IncisoDao.Get(id);
            item = IncisoMapper.Get(entity);

            return item;
        }

        public static List<Inciso> GetAll(int? fraccionId )
        {
            try
            {
                List<Inciso> lista;
                List<IncisoEntity> entities;

                entities = IncisoDao.GetAll((int)fraccionId);
                lista = IncisoMapper.GetAll(entities);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Inciso> GetAll()
        {
            try
            {
                List<Inciso> lista;
                List<IncisoEntity> entities;

                entities = IncisoDao.GetAll();
                lista = IncisoMapper.GetAll(entities);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(Inciso item)
        {
            try
            {
                IncisoEntity entity;

                entity = IncisoMapper.Get(item);

                IncisoDao.Update(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
