using CoreAPIMYSQLModel;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPIMYSQLData.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private MySQLConfiguration _connectionString;
        public FacturaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteFactura(int numero)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM factura WHERE numero = @Numero";
            var result = await db.ExecuteAsync(sql, new { Numero = numero });
            return result > 0;
        }

        public async Task<IEnumerable<Factura>> GetAllFacturas()
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM factura INNER JOIN cliente ON factura.id_cliente = cliente.id";
            return await db.QueryAsync<Factura,Cliente,Factura>(sql, (factura, cliente) => {
                factura.IdCliente = cliente;
                return factura;
            }, splitOn:"Id");
        }

        public async Task<Factura> GetFacturaDetails(int numero)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM factura WHERE numero = @Numero";
            return await db.QueryFirstOrDefaultAsync<Factura>(sql, new { Numero = numero });
        }

        public async Task<bool> InsertFactura(Factura factura)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO factura (numero, fecha, id_cliente)
                        VALUES (@Numero, @Fecha, SELECT id FROM cliente WHERE id = @IdCliente)";
            var result = await db.ExecuteAsync(sql, new { factura.Numero, factura.Fecha, factura.IdCliente.Id });
            return result > 0;
        }

        public async Task<bool> updateFactura(Factura cliente)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Factura>> GetAllProductsInFactura()
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM factura INNER JOIN cliente ON factura.id_cliente = cliente.id";
            return await db.QueryAsync<Factura, Cliente, Factura>(sql, (factura, cliente) => {
                factura.IdCliente = cliente;
                return factura;
            }, splitOn: "Id");

        }

        public async Task<IEnumerable<Factura>> GetAllFacturasUser(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM factura INNER JOIN cliente ON factura.id_cliente = @Id AND cliente.id = @Id";
            return await db.QueryAsync<Factura, Cliente, Factura>(sql, (factura, cliente) => {
                factura.IdCliente = cliente;
                return factura;
            }, splitOn: "Id", param: new { Id = id});
        }
    }
}
