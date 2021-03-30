using Infracciones.Dto;
using Infracciones.Mappers;
using Infracciones.Persistencia.Dao;
using Infracciones.Persistencia.Entity;
using System;
using System.Collections.Generic;

namespace Infracciones
{
    public class FraccionBl
    {
        public static void Add(Fraccion item)
        {
            try
            {
                FraccionEntity entity;

                entity = FraccionMapper.Get(item);

                FraccionDao.Add(entity);
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
                FraccionDao.Delete(id, usuarioIdBaja);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Fraccion Get(int id)
        {
            Fraccion item;
            FraccionEntity entity;

            entity = FraccionDao.Get(id);
            item = FraccionMapper.Get(entity);

            return item;
        }

        public static List<Fraccion> GetAll(int articuloid)
        {
            try
            {
                List<Fraccion> lista;
                List<FraccionEntity> entities;
                                
                entities = FraccionDao.GetAll(articuloid);
                lista = FraccionMapper.GetAll(entities);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Fraccion> GetAll()
        {
            try
            {
                List<Fraccion> lista;
                List<FraccionEntity> entities;

                entities = FraccionDao.GetAll();
                lista = FraccionMapper.GetAll(entities);

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(Fraccion item)
        {
            try
            {
                FraccionEntity entity;

                entity = FraccionMapper.Get(item);

                FraccionDao.Update(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
