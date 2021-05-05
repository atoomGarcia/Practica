using System;
using System.Collections.Generic;
using System.Text;
using BlazorPractica.Model;
using System.Threading.Tasks;

namespace BlazorPractica.Data.Dapper.repositorios
{
    interface IVentasRepositorio
    {
        Task<IEnumerable<Ventas>> GetAllVentas();
        Task<bool> GuardarVenta(Ventas ventas);
    }
}
