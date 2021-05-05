using BlazorPractica.Data.Dapper.repositorios;
using BlazorPractica.Model;
using ExamPractico.UI.Data;
using ExamPractico.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamPractico.UI.Servicios
{
    public class ClienteService : IClienteService
    {
        private readonly SqlConfiguration _configuration;
        private ClienteRepositorio _clienteRepositorio;
        public ClienteService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _clienteRepositorio = new ClienteRepositorio(configuration.ConnectionString);
        }
        public Task<bool> DeleteCliente(int idCliente)
        {
            return _clienteRepositorio.DeleteCliente(idCliente);
        }

        public Task<IEnumerable<Cliente>> GetAllClientes()
        {
            return _clienteRepositorio.GetAllClientes();
        }

        public Task<IEnumerable<Cliente>> GetAllClientesVentas()
        {
            return _clienteRepositorio.GetAllClientesVentas();
        }

        public Task<Cliente> GetCliente(int idCliente)
        {
            return _clienteRepositorio.GetCliente(idCliente);
        }

        public Task<bool> GuardarCliente(Cliente cliente)
        {
            if(cliente.idCliente == 0)
            {
                return _clienteRepositorio.InsertCliente(cliente);
            }
            else
            {
                return _clienteRepositorio.UpdateCliente(cliente);
            }
        }
    }
}
