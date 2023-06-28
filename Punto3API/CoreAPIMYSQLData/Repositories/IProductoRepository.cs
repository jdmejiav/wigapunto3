using CoreAPIMYSQLModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPIMYSQLData.Repositories
{
    internal interface IProductoRepository
    {
        Task<IEnumerable<Cliente>> GetAllProductos();
        Task<Cliente> GetProductoDetails(int id);
        Task<bool> InsertProducto(Producto producto);
        Task<bool> updateProducto(Producto producto);
        Task<bool> DeleteProducto(int id);

    }
}
