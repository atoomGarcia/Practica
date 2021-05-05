using BlazorPractica.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPractica.Data.Dapper.repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private string ConnectionString;
        public ClienteRepositorio(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            var db = dbConnection();
            var sql = @" SELECT [idCliente], [nombre], [apellidoPaterno], [apellidoMaterno], [rfc], [fechaNacimiento], [estado], [ciudad], [colonia], [cp], [estatus], [fechaIngreso] FROM [dbo].[Clientes]";
            return await db.QueryAsync<Cliente>(sql.ToString(), new { });
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesVentas()
        {
            var db = dbConnection();
            var sql = @" SELECT [idCliente], [nombre], [apellidoPaterno], [apellidoMaterno], [rfc], [fechaNacimiento], [estado], [ciudad], [colonia], [cp], [estatus], [fechaIngreso] FROM [dbo].[Clientes]";
            return await db.QueryAsync<Cliente>(sql.ToString(), new { });
        }

        public async Task<Cliente> GetCliente(int idCliente)
        {
            var db = dbConnection();
            var sql = @"SELECT [idCliente], [nombre], [apellidoPaterno], [apellidoMaterno], [rfc], [fechaNacimiento], [estado], [ciudad], [colonia], [cp], [estatus], [fechaIngreso] FROM [dbo].[Clientes] WHERE idCliente=@idCliente";

            return await db.QueryFirstOrDefaultAsync<Cliente>(sql.ToString(), new { idCliente = idCliente });
        }

        public async Task<bool> InsertCliente(Cliente cliente)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO Clientes  ([nombre], [apellidoPaterno], [apellidoMaterno], [rfc], [fechaNacimiento], [estado], [ciudad], [colonia], [cp])
                    VALUES (@nombre, @apellidoPaterno, @apellidoMaterno, @rfc, @fechaNacimiento, @estado, @ciudad, @colonia, @cp)";

            var result = await db.ExecuteAsync(sql.ToString(),
                new { cliente.nombre, cliente.apellidoPaterno, cliente.apellidoMaterno, cliente.rfc, cliente.fechaNacimiento, cliente.estado, cliente.ciudad, cliente.colonia, cliente.cp });

            return result > 0;

        }
        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            var db = dbConnection();
            var sql = @" UPDATE Clientes  
                        SET nombre = @nombre, apellidoPaterno=@apellidoPaterno, apellidoMaterno=@apellidoMaterno, rfc=@rfc, fechaNacimiento=@fechaNacimiento, ciudad = @ciudad, colonia=@colonia, cp=@cp
                    WHERE idCLiente=@idCliente";
            var result = await db.ExecuteAsync(sql.ToString(), new { cliente.nombre, cliente.apellidoPaterno, cliente.rfc, cliente.apellidoMaterno, cliente.fechaNacimiento, cliente.estado, cliente.ciudad, cliente.colonia, cliente.cp, cliente.idCliente });
            return result > 0;
        }

        public async Task<bool> DeleteCliente(int idCliente)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM [dbo].[Clientes] WHERE idCliente=@idCliente";

            var result = await db.ExecuteAsync(sql.ToString(), new { idCliente = idCliente });
            return result > 0;
        }

        public Task<bool> DeleteCliente(Cliente idCliente)
        {
            throw new NotImplementedException();
        }
    }
}
