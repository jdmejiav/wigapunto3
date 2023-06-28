using CoreAPIMYSQLModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPIMYSQLData.Repositories
{
    public interface IFacturaRepository
    {
        Task<IEnumerable<Factura>> GetAllFacturas();
        Task<IEnumerable<Factura>> GetAllFacturasUser(int id);
        Task<Factura> GetFacturaDetails(int numero);

        Task<bool> InsertFactura(Factura cliente);
        Task<bool> updateFactura(Factura cliente);
        Task<bool> DeleteFactura(int numero);
    }
}
