using Dapper;
using Infracciones.Persistencia.Entity;
using MySql.Data.MySqlClient;
using System;
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

                query = $@"";
                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity.Id = db.Query<int>(query).FirstOrDefault();
                }

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static BoletaDeSancionEntity Get(string placa)
        {
            try
            {
                string query;
                BoletaDeSancionEntity entity;

                query = "";

                using (var db = new MySqlConnection(Conexion.CadenaDeConexion))
                {
                    entity = db.Query<BoletaDeSancionEntity>(query).FirstOrDefault();
                }

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
