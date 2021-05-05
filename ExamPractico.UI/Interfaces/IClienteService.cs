using BlazorPractica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamPractico.UI.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllClientes();

        Task<IEnumerable<Cliente>> GetAllClientesVentas();
        Task<Cliente> GetCliente( int id);

        Task<bool> DeleteCliente(int id);

        Task<bool> GuardarCliente(Cliente cliente);
    }
}
