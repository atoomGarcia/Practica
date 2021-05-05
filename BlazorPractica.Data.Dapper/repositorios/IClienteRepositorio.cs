using BlazorPractica.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPractica.Data.Dapper.repositorios
{
    interface IClienteRepositorio
    {
        Task<IEnumerable<Cliente>> GetAllClientes();

        Task<IEnumerable<Cliente>> GetAllClientesVentas();
        Task<Cliente> GetCliente(int id);
        Task<bool> InsertCliente(Cliente cliente);
        Task<bool> UpdateCliente(Cliente cliente);
        Task<bool> DeleteCliente(Cliente idCliente);
    }
}
