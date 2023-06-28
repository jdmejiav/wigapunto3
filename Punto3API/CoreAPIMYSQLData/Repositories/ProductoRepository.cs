using CoreAPIMYSQLModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPIMYSQLData.Repositories
{
    internal class ProductoRepository : IProductoRepository
    {
        private MySQLConfiguration _connectionString;
        public ProductoRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<bool> DeleteProducto(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> GetAllProductos()
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetProductoDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> updateProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }



    }
}
