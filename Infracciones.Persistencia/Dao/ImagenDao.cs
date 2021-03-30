using Dapper;
using Infracciones.Persistencia.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infracciones.Persistencia.Dao
{
    public class ImagenDao
    {
        public List<ImagenEntity> GetAll(int boletaDeSancionId)
        {
            try
            {
                List<ImagenEntity> entities;
                string query;

                query = $@"SELECT
                    id,
                    boleta_de_sancion_id    BoletaDeSancionId,
                    tipo_de_imagen_id       TipoDeImagenId,
                    is_activo               IsActivo,
                    ruta_del_archivo        RutaDelArchivo,
                    fecha_de_registro       FechaDeRegistro
                FROM imagen
                WHERE boleta_de_sancion_id = {boletaDeSancionId}
                ";
                using (var db = new MySqlConnection())
                {
                    entities = db.Query<ImagenEntity>(query).ToList();
                }

                return entities;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Add(ImagenEntity entity)
        {
            try
            {
                string query;

                query = $@"INSERT INTO imagen
                (
                    boleta_de_sancion_id,
                    tipo_de_imagen_id,
                    is_activo,
                    ruta_del_archivo,
                    fecha_de_registro
                )
                VALUES
                (
                    @BoletaDeSancionId,
                    @TipoDeImagenId,
                    1,
                    @RutaDeArchivo,
                    NOW()
                )
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity.Id = db.Query<int>(query, new
                    {
                        BoletaDeSancionId = entity.BoletaDeSancionId,
                        TipoDeImagenId = entity.TipoDeImagenId,
                        RutaDeArchivo = entity.RutaDeArchivo
                    }).FirstOrDefault();
                }

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}