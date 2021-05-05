using BlazorPractica.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPractica.Data.Dapper.repositorios
{
   public interface IDepRepositorio
   {
        Task<IEnumerable<Dep>> GetAllDeps();
        Task<Dep> GetDepartamento(int idDep);
        Task<bool> InsertDepartamento(Dep departamento);
        Task<bool> UpdateDepartamento(Dep departamento);
        Task<bool> DeleteDepartamento(Dep idDep);
        Task<bool> DeleteDepartamento(int idDep);
    }
}
