using CoreAPIMYSQLModel;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPIMYSQLData.Repositories
{
    public class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        private MySQLConfiguration _connectionString;
        public DetalleFacturaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<DetalleFactura>> GetAllProductsInFactura(int numero)
        {
            var db = dbConnection();
            var sql = @"
                SELECT *
                FROM detalle_factura df
                INNER JOIN factura f ON f.numero = df.numero_factura
                INNER JOIN cliente c ON c.id = f.id_cliente
                INNER JOIN producto p ON p.id = df.id_producto
                WHERE df.numero_factura = @Numero";

            var parameters = new { Numero = numero };

            var result = await db.QueryAsync<DetalleFactura, Producto, DetalleFactura>(
                sql,
                (detalleFactura, producto) =>
                {      
                    detalleFactura.IdProducto = producto;
                    return detalleFactura;
                },
                splitOn: "Id",
                param: parameters);

            return result;
        }
    }
}
