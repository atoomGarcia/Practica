using BlazorPractica.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;


namespace BlazorPractica.Data.Dapper.repositorios
{
    public class DepRepositorio : IDepRepositorio
    {
        private string ConnectionString;
        public DepRepositorio(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public async Task<bool> DeleteDepartamento(Dep idDep)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM [dbo].[Departamentos] WHERE idDep=@idDep";

            var result = await db.ExecuteAsync(sql.ToString(), new { idDep = idDep });
            return result > 0;
        }

        public async Task<IEnumerable<Dep>> GetAllDeps()
        {
            var db = dbConnection();
            var sql = @" SELECT [idDep], [nombreDep], [estatus], [fechaAlta] FROM [Departamentos]";
            return await db.QueryAsync<Dep>(sql.ToString(), new { });
        }

        public async Task<Dep> GetDepartamento(int idDep)
        {
            var db = dbConnection();
            var sql = @" SELECT [idDep], [nombreDep], [estatus], [fechaAlta] FROM [Departamentos] WHERE idDep=@idDep";

            return await db.QueryFirstOrDefaultAsync<Dep>(sql.ToString(), new { idDep = idDep });
        }

        public async Task<bool> InsertDepartamento(Dep departamento)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO [dbo].[Departamentos] ([nombreDep]) VALUES (@nombreDep)";
            var result = await db.ExecuteAsync(sql.ToString(), new { departamento.nombreDep });
            return result > 0;
        }

        public async Task<bool> UpdateDepartamento(Dep departamento)
        {
            var db = dbConnection();
            var sql = @" UPDATE [dbo].[Departamentos] 
                        SET nombreDep = @nombreDep
                    WHERE idDep=@idDep";
            var result = await db.ExecuteAsync(sql.ToString(), new { departamento.nombreDep, departamento.idDep });
            return result > 0;
        }

        public Task<bool> DeleteDepartamento(int idDep)
        {
            throw new NotImplementedException();
        }
    }
}
