using BlazorPractica.Data.Dapper.repositorios;
using BlazorPractica.Model;
using ExamPractico.UI.Data;
using ExamPractico.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamPractico.UI.Servicios
{
    public class ArticuloService : IArticuloService
    {
        private readonly SqlConfiguration _configuration;
        private ArticuloRepositorio _articuloRepositorio;
        public ArticuloService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _articuloRepositorio = new ArticuloRepositorio(configuration.ConnectionString);
        }
        public Task<bool> DeleteArt(Art idArticulo)
        {
            return _articuloRepositorio.DeleteArt(idArticulo);
        }

        public Task<IEnumerable<Art>> GetAllArts()
        {
            return _articuloRepositorio.GetAllArts();
        }

        public Task<IEnumerable<Art>> GetAllArtsVentas()
        {
            return _articuloRepositorio.GetAllArtsVentas();
        }

        public Task<Art> GetArt(int idCliente)
        {
            return _articuloRepositorio.GetArt(idCliente);
        }

        public Task<bool> GuardarArt(Art articulo)
        {
            if (articulo.idArticulo == 0)
            {
                return _articuloRepositorio.InsertArt(articulo);
            }
            else
            {
                return _articuloRepositorio.UpdateArt(articulo);
            }
        }
    }
}
