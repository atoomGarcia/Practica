using BlazorPractica.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace BlazorPractica.Data.Dapper.repositorios
{
    public class VentasRepositorio : IVentasRepositorio
    {
        private string ConnectionString;
        public VentasRepositorio(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public async Task<IEnumerable<Ventas>> GetAllVentas()
        {
            var db = dbConnection();
            var sql = @" SELECT a.[idVenta], a.[Serie], a.[Numero], a.[idCliente], a.[idVendedor], a.[totalVenta], a.[idTipoPago], a.[estatus], a.[fechaVenta], b.[nombre], b.[apellidoPaterno], b.[apellidoMaterno]FROM [dbo].[Venta] as a
                    INNER JOIN [dbo].[Clientes] as b ON  a.[idCliente]=b.[idCliente]";
            return await db.QueryAsync<Ventas>(sql.ToString(), new { });
        }

        public async Task<bool> GuardarVenta(Ventas ventas)
        {

            var db = dbConnection();
            var sql = @" INSERT INTO [dbo].[Venta] ([Serie], [Numero], [idCliente], [idVendedor], [totalVenta], [idTipoPago])
                    VALUES (@Serie, @Numero,@idCliente,1, @totalVenta,1)";

            var result = await db.ExecuteAsync(sql.ToString(),
                new { ventas.Serie, ventas.Numero, ventas.idCliente, ventas.totalVenta });

            return result > 0;
        }
    }
}
