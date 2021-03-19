using Dapper;
using Infracciones.Persistencia.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infracciones.Persistencia.Dao
{
    public class FraccionDao
    {
        public static int Add(FraccionEntity entity)
        {
            try
            {
                string query;

                query = $@"INSERT INTO fraccion
                (
                numero,           
                articulo_id,
                descripcion,
                usuario_id_alta,     
                is_activo,     
                fecha_de_registro                   
                )
                VALUES
                (
                @Numero, 
                @ArticuloId,
                @Descripcion,
                @UsuarioIdAlta,
                1,
                NOW()
                );
                SELECT LAST_INSERT_ID(); 
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity.Id = db.Query<int>(query, new
                    {
                        Numero = entity.Numero,
                        ArticuloId = entity.ArticuloId,
                        Descripcion = entity.Descripcion,
                        UsuarioIdAlta = entity.UsuarioIdAlta
                    }).FirstOrDefault();
                }

                return entity.Id;
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
                string query;

                query = $@"
                UPDATE fraccion
                SET 
                usuario_id_baja     = @UsuarioIdBaja,
                is_activo           = 0,
                fecha_de_baja       = NOW()
                WHERE id = @Id";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    db.Query(query, new
                    {
                        UsuarioIdBaja = usuarioIdBaja,
                        Id = id
                    }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static FraccionEntity Get(int id)
        {
            try
            {
                string query;
                FraccionEntity entity;

                query = $@"
                SELECT 
                id                  Id,
                numero              Numero,
                articulo_id         ArticuloId,
                descripcion         Descripcion,
                usuario_id_alta     UsuarioIdAlta,
                usuario_id_baja     UsuarioIdBaja,
                fecha_de_registro   FechaDeRegistro,
                fecha_de_baja       FechaDeBaja
                FROM fraccion                
                WHERE fraccion.id = {id}
                LIMIT 1";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity = db.Query<FraccionEntity>(query).FirstOrDefault();
                }

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<FraccionEntity> GetAll(bool isActivo = true)
        {
            try
            {
                List<FraccionEntity> entities;
                string query;
                int is_activo;

                is_activo = isActivo ? 1 : 0;
                query = $@"
                SELECT 
                 id                  Id,
                numero              Numero,
                articulo_id         ArticuloId,
                descripcion         Descripcion,
                usuario_id_alta     UsuarioIdAlta,
                usuario_id_baja     UsuarioIdBaja,
                fecha_de_registro   FechaDeRegistro,
                fecha_de_baja       FechaDeBaja
                FROM fraccion
                WHERE fraccion.is_activo = {is_activo}
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<FraccionEntity>(query).ToList();
                }

                return entities;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<FraccionEntity> GetAll(int articuloId, bool isActivo = true)
        {
            try
            {
                List<FraccionEntity> entities;
                string query;
                int is_activo;

                is_activo = isActivo ? 1 : 0;
                query = $@"
                SELECT 
                 id                  Id,
                numero              Numero,
                articulo_id         ArticuloId,
                descripcion         Descripcion,
                usuario_id_alta     UsuarioIdAlta,
                usuario_id_baja     UsuarioIdBaja,
                fecha_de_registro   FechaDeRegistro,
                fecha_de_baja       FechaDeBaja
                FROM fraccion
                WHERE fraccion.is_activo = {is_activo} AND articulo_id = {articuloId}";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<FraccionEntity>(query).ToList();
                }

                return entities;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(FraccionEntity entity)
        {
            try
            {
                string query;

                query = $@"
                UPDATE fraccion
                SET                                  
                descripcion     = @Descripcion              
                WHERE id        = @Id";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    db.Query(query, new
                    {
                        Descripcion = entity.Descripcion,
                        Id = entity.Id
                    }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}