using CoreAPIMYSQLModel;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace CoreAPIMYSQLData.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private MySQLConfiguration _connectionString;
        public ClienteRepository(MySQLConfiguration connectionString) 
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection() 
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteClient(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM cliente WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = id});
            return result > 0;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM cliente";
            return await db.QueryAsync<Cliente>(sql, new { });
        }

        public async Task<Cliente> GetClienteDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM cliente WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Cliente>(sql, new { Id = id });
            
        }

        public async Task<bool> InsertCliente(Cliente cliente)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO cliente (id, nombre)
                        VALUES (@Id, @Nombre)";

            var result = await db.ExecuteAsync(sql, new { cliente.Id, cliente.Nombre });

            return result > 0;
        }

        public async Task<bool> updateCliente(Cliente cliente)
        {
            var db = dbConnection();
            var sql = @"UPDATE cliente 
                        SET nombre = @Nombre 
                        WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { cliente.Id, cliente.Nombre });

            return result > 0;
        }
    }
}
