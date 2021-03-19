using Dapper;
using Infracciones.Persistencia.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infracciones.Persistencia.Dao
{
    public class IncisoDao
    {
        public static int Add(IncisoEntity entity)
        {
            try
            {
                string query;

                query = $@"INSERT INTO inciso
                (
                multa,           
                is_descuento,
                is_deposito,                     
                is_activo,
                usuario_id_alta,    
                fraccion_id,
                motivo,
                fecha_de_registro
                )
                VALUES
                (
                @Multa, 
                @IsDescuenta,
                @IsDeposito,
                1,
                @UsuarioIdAlta,
                @FraccionId,
                @Motivo,
                NOW()
                );
                SELECT LAST_INSERT_ID(); 
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity.Id = db.Query<int>(query, new
                    {
                        Multa = entity.Multa,
                        IsDescuenta = entity.IsDescuento,
                        IsDeposito = entity.IsDeposito,
                        UsuarioIdAlta = entity.UsuarioIdAlta,
                        FraccionId = entity.FraccionId,
                        Motivo = entity.Motivo
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
                UPDATE inciso
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

        public static IncisoEntity Get(int id)
        {
            try
            {
                string query;
                IncisoEntity entity;

                query = $@"
                SELECT 
                id                  Id,
                multa               Multa,
                is_descuento        IsDescuento,
                is_deposito         IsDeposito,
                is_activo           IsActivo,
                usuario_id_alta     UsuarioIdAlta,
                usuario_id_baja     UsuarioIdBaja,
                fraccion_id         FraccionId,
                motivo              Motivo,
                fecha_de_registro   FechaDeRegistro,
                fecha_de_baja       FechaDeBaja
                FROM inciso                
                WHERE id = {id}
                LIMIT 1";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity = db.Query<IncisoEntity>(query).FirstOrDefault();
                }

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<IncisoEntity> GetAll(bool isActivo = true)
        {
            try
            {
                List<IncisoEntity> entities;
                string query;
                int is_activo;

                is_activo = isActivo ? 1 : 0;
                query = $@"
                SELECT 
                id                  Id,
                multa               Multa,
                is_descuento        IsDescuento,
                is_deposito         IsDeposito,
                is_activo           IsActivo,
                usuario_id_alta     UsuarioIdAlta,
                usuario_id_baja     UsuarioIdBaja,
                fraccion_id         FraccionId,
                motivo              Motivo,
                fecha_de_registro   FechaDeRegistro,
                fecha_de_baja       FechaDeBaja
                FROM inciso  
                WHERE is_activo = {is_activo}
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<IncisoEntity>(query).ToList();
                }

                return entities;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<IncisoEntity> GetAll(int fraccionId, bool isActivo = true)
        {
            try
            {
                List<IncisoEntity> entities;
                string query;
                int is_activo;

                is_activo = isActivo ? 1 : 0;
                query = $@"
                SELECT 
                id                  Id,
                multa               Multa,
                is_descuento        IsDescuento,
                is_deposito         IsDeposito,
                is_activo           IsActivo,
                usuario_id_alta     UsuarioIdAlta,
                usuario_id_baja     UsuarioIdBaja,
                fraccion_id         FraccionId,
                motivo              Motivo,
                fecha_de_registro   FechaDeRegistro,
                fecha_de_baja       FechaDeBaja
                FROM inciso  
                WHERE is_activo = {is_activo} AND fraccion_id = {fraccionId}";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<IncisoEntity>(query).ToList();
                }

                return entities;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Update(IncisoEntity entity)
        {
            try
            {
                string query;

                query = $@"
                UPDATE inciso
                SET                                  
                multa               = @Multa,
                is_descuento        = @IsDescuento,
                is_deposito         = @IsDeposito,                
                fraccion_id         = @FraccionId,
                motivo              = @Motivo            
                WHERE id        = @Id";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    db.Query(query, new
                    {
                        Multa = entity.Multa,
                        IsDescuento = entity.IsDescuento,
                        IsDeposito = entity.IsDescuento,
                        FraccionId = entity.FraccionId,
                        Motivo = entity.Motivo,
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