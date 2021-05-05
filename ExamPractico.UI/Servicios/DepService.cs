using BlazorPractica.Model;
using BlazorPractica.Data.Dapper.repositorios;
using ExamPractico.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using ExamPractico.UI.Data;
using System.Threading.Tasks;

namespace ExamPractico.UI.Servicios
{
    public class DepService : IDepService
    {
        private readonly SqlConfiguration _configuration;
        private IDepRepositorio _depRepositorio;
        public DepService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _depRepositorio = new DepRepositorio(configuration.ConnectionString);
        }
        public Task<bool> DeleteDepartamento(int idDep)
        {
            return _depRepositorio.DeleteDepartamento(idDep: idDep);
        }

        public Task<IEnumerable<Dep>> GetAllDeps()
        {
            return _depRepositorio.GetAllDeps();
        }

        public Task<Dep> GetDepartamento(int idDep)
        {
            return _depRepositorio.GetDepartamento(idDep);
        }

        public Task<bool> GuardarDepartamento(Dep departamento)
        {
            if (departamento.idDep == 0)
            {
                return _depRepositorio.InsertDepartamento(departamento);
            }
            else
            {
                return _depRepositorio.UpdateDepartamento(departamento);
            }
        }
    }
}
