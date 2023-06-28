using CoreAPIMYSQLModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPIMYSQLData.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> GetClienteDetails(int id);
        Task<bool> InsertCliente(Cliente cliente);
        Task<bool> updateCliente(Cliente cliente);
        Task<bool> DeleteClient(int id);


    }
}
