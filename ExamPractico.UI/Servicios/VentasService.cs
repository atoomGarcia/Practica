using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorPractica.Data.Dapper.repositorios;
using BlazorPractica.Model;
using ExamPractico.UI.Data;
using ExamPractico.UI.Interfaces;

namespace ExamPractico.UI.Servicios
{
    public class VentasService : IVentasService
    {
        private readonly SqlConfiguration _configuration;
        private VentasRepositorio _ventasRepositorio;
        public VentasService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _ventasRepositorio = new VentasRepositorio(configuration.ConnectionString);
        }
        public Task<IEnumerable<Ventas>> GetAllVentas()
        {
            return _ventasRepositorio.GetAllVentas();
        }
        public Task<bool> GuardarVenta(Ventas ventas)
        {
            return _ventasRepositorio.GuardarVenta(ventas);
        }
    }
}
