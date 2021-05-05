using BlazorPractica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamPractico.UI.Interfaces
{
    public interface IArticuloService
    {
        Task<IEnumerable<Art>> GetAllArts();

        Task<IEnumerable<Art>> GetAllArtsVentas();
        Task<Art> GetArt(int id);
        Task<bool> GuardarArt(Art articulo);
        Task<bool> DeleteArt(Art idArticulo);
    }
}
