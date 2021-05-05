using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorPractica.Model;


namespace ExamPractico.UI.Interfaces
{
    public interface IDepService 
    {
        Task<IEnumerable<Dep>> GetAllDeps();
        Task<Dep> GetDepartamento(int idDep);

        Task<bool> DeleteDepartamento(int idDep);
        Task<bool> GuardarDepartamento(Dep departamento);
    }
}
