using BlazorPractica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamPractico.UI.Interfaces
{
    public interface IProvService
    {
        Task<IEnumerable<Prov>> GetAllProvs();
        Task<Prov> GetProv(int idProveedor);

        Task<bool> DeleteProv(int idProveedor);

        Task<bool> GuardarProv(Prov proveedor);
    }
}
