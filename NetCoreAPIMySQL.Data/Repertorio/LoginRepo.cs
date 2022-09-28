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
    public class LoginRepo : ILoginRepo
    {
        private MySQLConfiguration _connectionString;
        public LoginRepo(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection1()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<DataUsuario>> GetAllDataUsuario()
        {
            var db = dbConnection1();
            var sql = @"SELECT id, nombre,pass,email
            FROM login";
            return await db.QueryAsync<DataUsuario>(sql, new { });
        }

        public async Task<DataUsuario> GetDataUsuarioDetails(int id)
        {
            var db = dbConnection1();
            var sql = @"
            SELECT id, nombre,pass,email
            FROM login
            WHERE id=@Id";
            return await db.QueryFirstOrDefaultAsync<DataUsuario>(sql, new { Id = id });
        }

        public async Task<bool> InsertDataUsuario(DataUsuario DataUsuario)
        {
            var db = dbConnection1();
            var sql = @"INSERT INTO login (nombre,pass,email)
             VALUES (@Nombre,@Pass,@Email)";
            var result = await db.ExecuteAsync(sql, new { DataUsuario.Nombre, DataUsuario.Pass, DataUsuario.Email });
            return result > 0;
        }

        public async Task<bool> UpdateDataUsuario(DataUsuario DataUsuario)
        {
            var db = dbConnection1();
            var sql = @"
             UPDATE login
              SET nombre=@Nombre,pass=@Pass,email=@Email
            
            WHERE id=@Id";
            var result = await db.ExecuteAsync(sql, new { DataUsuario.Nombre, DataUsuario.Pass, DataUsuario.Email, DataUsuario.Id });
            return result > 0;
        }

        public async Task<bool> DeleteDataUsuario(DataUsuario DataUsuario)
        {
            var db = dbConnection1();
            var sql = @"DELETE 
            FROM login
            WHERE id=@Id";
            var result = await db.ExecuteAsync(sql, new { Id = DataUsuario.Id });
            return result > 0;
        }
    }
}
