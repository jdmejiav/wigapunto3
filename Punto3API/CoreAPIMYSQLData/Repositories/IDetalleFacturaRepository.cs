using CoreAPIMYSQLModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPIMYSQLData.Repositories
{
    public interface IDetalleFacturaRepository
    {
        Task<IEnumerable<DetalleFactura>> GetAllProductsInFactura(int numero);
    }
}
