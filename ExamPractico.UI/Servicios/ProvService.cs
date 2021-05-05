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
    public class ProvService : IProvService
    {
        private readonly SqlConfiguration _configuration;
        private IProvRepositorio _provRepositorio;

        public ProvService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _provRepositorio = new ProvRepositorio(configuration.ConnectionString);
        }
        public Task<bool> DeleteProv(int idProveedor)
        {
            return _provRepositorio.DeleteProv(idProveedor);
        }

        public Task<IEnumerable<Prov>> GetAllProvs()
        {
            return _provRepositorio.GetAllProvs();
        }

        public Task<Prov> GetProv(int idProveedor)
        {
            return _provRepositorio.GetProv(idProveedor);
        }

        public Task<bool> GuardarProv(Prov proveedor)
        {
            if (proveedor.idProveedor == 0)
            {
                return _provRepositorio.InsertProv(proveedor);
            }
            else
            {
                return _provRepositorio.UpdateProv(proveedor);
            }
        }
    }
}
