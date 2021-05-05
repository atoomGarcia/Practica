using BlazorPractica.Model;
using Dapper;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPractica.Data.Dapper.repositorios
{
    public class ProvRepositorio : IProvRepositorio
    {
        private string ConnectionString;
        public ProvRepositorio(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(ConnectionString);
        }
        public async Task<bool> DeleteProv(Prov idProveedor)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM [dbo].[Proveedores] WHERE idProveedor=@idProveedor";

            var result = await db.ExecuteAsync(sql.ToString(), new { idProveedor = idProveedor });
            return result > 0;
        }

        public async Task<IEnumerable<Prov>> GetAllProvs()
        {
            var db = dbConnection();
            var sql = @" SELECT [idProveedor], [razonSocial], [rfc], [estado], [ciudad], [colonia], [cp], [estatus], [fechaAlta] FROM [dbo].[Proveedores]";
            return await db.QueryAsync<Prov>(sql.ToString(), new { });
        }

        public async Task<Prov> GetProv(int idProveedor)
        {
            var db = dbConnection();
            var sql = @" SELECT [idProveedor], [razonSocial], [rfc], [estado], [ciudad], [colonia], [cp], [estatus], [fechaAlta] FROM [dbo].[Proveedores] WHERE idProveedor=@idProveedor";

            return await db.QueryFirstOrDefaultAsync<Prov>(sql.ToString(), new { idProveedor = idProveedor });
        }

        public async Task<bool> InsertProv(Prov proveedor)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO [dbo].[Proveedores] ([razonSocial], [rfc], [estado], [ciudad], [colonia], [cp]) 
                        VALUES (@razonSocial,@rfc,@estado,@ciudad,@colonia,@cp)";
            var result = await db.ExecuteAsync(sql.ToString(), new { proveedor.razonSocial, proveedor.rfc, proveedor.estado, proveedor.ciudad, proveedor.colonia, proveedor.cp });
            return result > 0;
        }

        public async Task<bool> UpdateProv(Prov proveedor)
        {
            var db = dbConnection();
            var sql = @" UPDATE [dbo].[Proveedores] 
                        SET razonSocial = @razonSocial,rfc = @rfc,estado = @estado,ciudad = @ciudad,colonia = @colonia,cp = @cp
                    WHERE idProveedor=@idProveedor";
            var result = await db.ExecuteAsync(sql.ToString(), new { proveedor.razonSocial, proveedor.rfc, proveedor.estado, proveedor.ciudad, proveedor.colonia, proveedor.cp, proveedor.idProveedor});
            return result > 0;
        }

        public async Task<bool> DeleteProv(int idProveedor)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM [dbo].[Proveedores] WHERE idProveedor=@idProveedor";

            var result = await db.ExecuteAsync(sql.ToString(), new { idProveedor = idProveedor });
            return result > 0;
        }
    }
}
