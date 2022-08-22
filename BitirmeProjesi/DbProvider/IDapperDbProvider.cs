using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BitirmeProjesi.DbProvider
{
    public interface IDapperDbProvider
    {
        IDbConnection GetConnection();
        Task ExecuteAsync(IDbConnection connection, string command, object? param = null);
        Task<T> QueryFirstOrDefaultAsync<T>(IDbConnection connection, string command, object? param = null);
        Task<IEnumerable<T>> QueryAsync<T>(IDbConnection connection, string command, object? param = null);
    }
}