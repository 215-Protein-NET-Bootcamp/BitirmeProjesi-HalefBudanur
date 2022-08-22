using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BitirmeProjesi.DbProvider
{
    public class DapperDbProvider : IDapperDbProvider
    {
        private readonly string? _connectionString;

        public DapperDbProvider(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PostgreSqlConnection");
        }

        public IDbConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public async Task ExecuteAsync(IDbConnection connection, string command, object? param = null)
        {
            await connection.ExecuteAsync(command, param);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(IDbConnection connection, string command, object? param = null)
        {
            return await connection.QueryFirstOrDefaultAsync<T>(command, param);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(IDbConnection connection, string command, object? param = null)
        {
            return await connection.QueryAsync<T>(command, param);
        }
    }
}