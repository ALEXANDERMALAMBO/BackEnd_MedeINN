using Dapper;
using MySql.Data.MySqlClient;
using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Data.Repertorio
{
    public class SensorRepo : IsensorRepo
    {
        private MySQLConfiguration _connectionString;
        public SensorRepo(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
       

        public async Task<IEnumerable<DataSensor>> GetAllDataSensor()
        {
            var db = dbConnection();
            var sql = @"SELECT id, humedad,temperatura,calidad_aire,indice_benzeno,fecha
            FROM sensor2";
            return await db.QueryAsync<DataSensor>(sql, new {});
        }

        public async Task<DataSensor> GetDataSensorDetails(int id)
        {
            var db = dbConnection();
            var sql = @"
            SELECT id, humedad,temperatura,calidad_aire,indice_benzeno,fecha
            FROM sensor2
            WHERE id=@Id";
            return await db.QueryFirstOrDefaultAsync<DataSensor>(sql, new {Id=id });
        }

        public async Task<bool> InsertDataSensor(DataSensor DataSensor)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO sensor2 (humedad,temperatura,calidad_aire,indice_benzeno,fecha)
             VALUES (@Humedad,@Temperatura,@Calidad_Aire,@Indice_Benzeno,@Fecha)";
            var result = await db.ExecuteAsync(sql, new { DataSensor.Humedad, DataSensor.Temperatura, DataSensor.Calidad_Aire, DataSensor.Indice_Benzeno, DataSensor.Fecha });
            return result > 0;

        }

        public async Task<bool> UpdateDataSensor(DataSensor DataSensor)
        {
            var db = dbConnection();
            var sql = @"
             UPDATE sensor2
              SET humedad=@Humedad,temperatura=@Temperatura,calidad_aire=@Calidad_Aire,indice_benzeno=@Indice_Benzeno,fecha=@Fecha
            
            WHERE id=@Id";
            var result = await db.ExecuteAsync(sql, new { DataSensor.Humedad, DataSensor.Temperatura, DataSensor.Calidad_Aire, DataSensor.Indice_Benzeno, DataSensor.Fecha , DataSensor.Id});
            return result > 0;
        }

        public async Task<bool> DeleteDataSensor(DataSensor DataSensor)
        {
            var db = dbConnection();
            var sql = @"DELETE 
            FROM sensor2
            WHERE id=@Id";
            var result = await db.ExecuteAsync(sql, new { Id = DataSensor.Id });
            return result > 0;
        }
    }
}
