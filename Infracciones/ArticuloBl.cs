using Infracciones.Dto;
using Infracciones.Mappers;
using Infracciones.Persistencia.Dao;
using Infracciones.Persistencia.Entity;
using System;
using System.Collections.Generic;

namespace Infracciones
{
    public class ArticuloBl
    {
        public static void Add(Articulo item)
        {
            try
            {
                ArticuloEntity entity;

                entity = ArticuloMapper.Get(item);

                ArticuloDao.Add(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Delete(int id, int ArticuloIdBaja)
        {
            try
            {
                ArticuloDao.Delete(id, ArticuloIdBaja);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Articulo Get(int id)
        {
            Articulo item;
            ArticuloEntity entity;

            entity = ArticuloDao.Get(id);
            item = ArticuloMapper.Get(entity);

            return item;
        }

        public static List<Articulo> GetAll(int? id = null)
        {
            try
            {
                List<Articulo> lista;
                List<ArticuloEntity> entities;

                if (id == null)
                    entities = ArticuloDao.GetAll();
                else
                    entities = ArticuloDao.GetAll(false);
                lista = ArticuloMapper.GetAll(entities);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(Articulo item)
        {
            try
            {
                ArticuloEntity entity;

                entity = ArticuloMapper.Get(item);

                ArticuloDao.Update(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
