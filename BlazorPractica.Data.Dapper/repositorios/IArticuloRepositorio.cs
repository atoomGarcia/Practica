using System;
using BlazorPractica.Model;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPractica.Data.Dapper.repositorios
{
    interface IArticuloRepositorio
    {
        Task<IEnumerable<Art>> GetAllArts();

        Task<IEnumerable<Art>> GetAllArtsVentas();
        Task<Art> GetArt(int id);
        Task<bool> InsertArt(Art articulo);
        Task<bool> UpdateArt(Art articulo);
        Task<bool> DeleteArt(Art idArticulo);
    }
}
