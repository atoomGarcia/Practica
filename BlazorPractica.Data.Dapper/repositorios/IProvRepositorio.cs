using System;
using System.Collections.Generic;
using System.Text;
using BlazorPractica.Model;
using System.Threading.Tasks;


namespace BlazorPractica.Data.Dapper.repositorios
{
    public interface IProvRepositorio
    {
        Task<IEnumerable<Prov>> GetAllProvs();
        Task<Prov> GetProv(int idProveedor);
        Task<bool> InsertProv(Prov proveedor);
        Task<bool> UpdateProv(Prov proveedor);
        Task<bool> DeleteProv(Prov idProveedor);
        Task<bool> DeleteProv(int idProveedor);
    }
}
