using Dapper;
using Infracciones.Persistencia.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infracciones.Persistencia.Dao
{
    public class BoletaDeSancionDao
    {
        public static int Add(BoletaDeSancionEntity entity)
        {
            try
            {
                string query;

                query = $@"INSERT boleta_de_sancion
                (
                    usuario_id,
                    reglamento_id,
                    estatus_de_boleta_de_sancion_id,
                    numero_de_licencia,
                    nombre_del_conductor,
                    placa,
                    coordenadas_gps,
                    correo,
                    telefono,
                    observaciones,
                    referencia_de_banco,
                    fecha_de_registro
                )
                VALUES(
                    @UsuarioId,
                    @ReglamentoId,
                    @EstatusDeBoletaDeSancion,
                    @NumeroDeLicencia,
                    @NombreDelConductor,
                    @Placa,
                    @CoordenadasGps,
                    @Correo,
                    @Telefono,
                    @Observaciones,
                    @ReferenciaDeBanco,
                    NOW()
                );
                SELECT LAST_INSERT_ID(); ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity.Id = db.Query<int>(query, new
                    {
                        UsuarioId = entity.UsuarioId,
                        ReglamentoId = entity.ReglamentoId,
                        EstatusDeBoletaDeSancion = entity.EstatusDeBoletaDeSancion,
                        NumeroDeLicencia = entity.NumeroDeLicencia,
                        NombreDelConductor = entity.NombreDelConductor,
                        Placa = entity.Placa,
                        CoordenadasGps = entity.CoordenadasGps,
                        Correo = entity.Correo,
                        Telefono = entity.Telefono,
                        Observaciones = entity.Observaciones,
                        ReferenciaDeBanco = entity.ReferenciaDeBanco
                    }).FirstOrDefault();
                }

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static BoletaDeSancionEntity Get(int id)
        {
            try
            {
                string query;
                BoletaDeSancionEntity entity;

                query = $@"SELECT
                    id,
                    usuario_id                      UsuarioId,
                    reglamento_id                   ReglamentoId,
                    estatus_de_boleta_de_sancion_id EstatusDeBoletaDeSancion,
                    numero_de_licencia              NumeroDeLicencia,
                    nombre_del_conductor            NombreDelConductor,
                    placa,
                    coordenadas_gps                 CoordenadasGps,
                    correo,
                    telefono,
                    observaciones,
                    referencia_de_banco             ReferenciaDeBanco,
                    fecha_de_registro               FechaDeRegistro
                FROM boleta_de_sancion
                WHERE id = @Id
                ORDER BY id DESC;
                ";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity = db.Query<BoletaDeSancionEntity>(query, new { Id = id }).FirstOrDefault();
                }

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<BoletaDeSancionEntity> Get(string placa)
        {
            try
            {
                string query;
                List<BoletaDeSancionEntity> entities;

                query = $@"SELECT
                    id,
                    usuario_id                      UsuarioId,
                    reglamento_id                   ReglamentoId,
                    estatus_de_boleta_de_sancion_id EstatusDeBoletaDeSancion,
                    numero_de_licencia              NumeroDeLicencia,
                    nombre_del_conductor            NombreDelConductor,
                    placa,
                    coordenadas_gps                 CoordenadasGps,
                    correo,
                    telefono,
                    observaciones,
                    referencia_de_banco             ReferenciaDeBanco,
                    fecha_de_registro               FechaDeRegistro
                FROM boleta_de_sancion
                WHERE placa = @Placa
                ORDER BY id DESC;
                ";
                //placa = $"'%{placa}%'";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entities = db.Query<BoletaDeSancionEntity>(query, new { Placa = placa }).ToList();
                }

                return entities;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
