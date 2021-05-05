using BlazorPractica.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace BlazorPractica.Data.Dapper.repositorios
{
    public class ArticuloRepositorio : IArticuloRepositorio
    {
        private string ConnectionString;
        public ArticuloRepositorio(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public async Task<bool> DeleteArt(Art idArticulo)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM [dbo].[Articulo] WHERE idArticulo=@idArticulo";

            var result = await db.ExecuteAsync(sql.ToString(), new { idArticulo = idArticulo });
            return result > 0;
        }

        public async Task<IEnumerable<Art>> GetAllArts()
        {
            var db = dbConnection();
            var sql = @" SELECT  a.[idArticulo], a.[codigo], a.[nombre], a.[descripcion], d.[nombreDep], a.[stock], a.[costo], a.[precio], p.[razonSocial], a.[estatus], a.[fechaAlta]  FROM [dbo].[Articulos] as a
                        INNER JOIN [dbo].[Departamentos] as d ON a.idDep = d.idDep
                        INNER JOIN [dbo].[Proveedores] as p ON a.idProveedor=p.idProveedor";
            return await db.QueryAsync<Art>(sql.ToString(), new { });
        }


        public async Task<IEnumerable<Art>> GetAllArtsVentas()
        {
            var db = dbConnection();
            var sql = @" SELECT  a.[idArticulo], a.[codigo], a.[nombre], a.[descripcion], d.[nombreDep], a.[stock], a.[costo], a.[precio], p.[razonSocial], a.[estatus], a.[fechaAlta]  FROM [dbo].[Articulos] as a
                        INNER JOIN [dbo].[Departamentos] as d ON a.idDep = d.idDep
                        INNER JOIN [dbo].[Proveedores] as p ON a.idProveedor=p.idProveedor";
            return await db.QueryAsync<Art>(sql.ToString(), new { });
        }

        public async Task<Art> GetArt(int idArticulo)
        {
            var db = dbConnection();
            var sql = @" SELECT  [idArticulo], [codigo], [nombre], [descripcion], [idDep], [stock], [costo], [precio], [idProveedor], [estatus], [fechaAlta]  FROM [dbo].[Articulos]WHERE idArticulo=@idArticulo";

            return await db.QueryFirstOrDefaultAsync<Art>(sql.ToString(), new { idArticulo = idArticulo });
        }

        public async Task<bool> InsertArt(Art articulo)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO Articulos  ([codigo], [nombre], [descripcion], [idDep], [stock], [costo], [precio], [idProveedor])
                    VALUES (@codigo, @nombre, @descripcion, @idDep, @stock, @costo, @precio, @idProveedor)";

            var result = await db.ExecuteAsync(sql.ToString(),
                new { articulo.codigo, articulo.nombre, articulo.descripcion, articulo.idDep, articulo.stock, articulo.costo, articulo.precio, articulo.idProveedor });

            return result > 0;

        }

        public async Task<bool> UpdateArt(Art articulo)
        {
            var db = dbConnection();
            var sql = @" UPDATE Articulos  
                        SET codigo = @codigo, nombre=@nombre, descripcion=@descripcion, idDep=@idDep, stock = @stock, costo=@costo, precio=@precio, idProveedor=@idProveedor
                    WHERE idArticulo=@idArticulo";
            var result = await db.ExecuteAsync(sql.ToString(), new { articulo.codigo, articulo.nombre, articulo.descripcion, articulo.idDep, articulo.stock, articulo.costo, articulo.precio, articulo.idProveedor, articulo.idArticulo });
            return result > 0;
        }
    }
}
