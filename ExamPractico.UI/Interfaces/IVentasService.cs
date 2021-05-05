using BlazorPractica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExamPractico.UI.Interfaces
{
     public interface IVentasService
    {
        Task<IEnumerable<Ventas>> GetAllVentas();
        Task<bool> GuardarVenta(Ventas ventas);

    }
}
