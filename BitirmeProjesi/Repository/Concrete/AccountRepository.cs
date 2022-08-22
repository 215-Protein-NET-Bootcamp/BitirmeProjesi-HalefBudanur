using BitirmeProjesi.DbProvider;
using BitirmeProjesi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitirmeProjesi.Repository
{
    public class AccountRepository
    {
        private readonly IDapperDbProvider _dapperDbProvider;

        private const string SelectAccountSqlStatement = @"SELECT * FROM Account WHERE Id = @Id";
        private const string SelectAllCountriesSqlStatement = @"SELECT * FROM Account";

        public AccountRepository(IDapperDbProvider dapperDbProvider)
        {
            _dapperDbProvider = dapperDbProvider;
        }

        public async Task<Account> GetAccount(int id)
        {
            using var connection = _dapperDbProvider.GetConnection();

            return await _dapperDbProvider.QueryFirstOrDefaultAsync<Account>(connection, SelectAccountSqlStatement, new { Id = id });
        }

        public async Task<IEnumerable<Account>> GetAllCountries()
        {
            using var connection = _dapperDbProvider.GetConnection();

            return await _dapperDbProvider.QueryAsync<Account>(connection, SelectAllCountriesSqlStatement);
        }

        public async Task AddAccount(Account Account)
        {
            string InsertAccountSqlStatement = $"INSERT INTO public.Account(UserName, Password, Name, Email, LastActivity) VALUES ('{Account.UserName}', '{Account.Password}', '{Account.Name}', '{Account.Email}', '{Account.LastActivity}');";

            using var connection = _dapperDbProvider.GetConnection();

            await _dapperDbProvider.ExecuteAsync(connection, InsertAccountSqlStatement);
        }

        public async Task<Account> UpdateAccount(Account Account)
        {
            string UpdateAccountSqlStatement = $"UPDATE Account SET UserName = '{Account.UserName}', Password = '{Account.Password}', Name = '{Account.Name}', currency = '{Account.Email}', currency = '{Account.LastActivity}', currency = '{Account.LastActivity}' WHERE Id = {Account.Id}";

            using var connection = _dapperDbProvider.GetConnection();

            return await _dapperDbProvider.QueryFirstOrDefaultAsync<Account>(connection, UpdateAccountSqlStatement);
        }

        public async Task<Account> DeleteAccount(int id)
        {
            string DeleteAccountSqlStatement = $"DELETE FROM public.Account WHERE Accountid = {id};";
            using var connection = _dapperDbProvider.GetConnection();
            await _dapperDbProvider.QueryFirstOrDefaultAsync<Account>(connection, DeleteAccountSqlStatement);
            return await _dapperDbProvider.QueryFirstOrDefaultAsync<Account>(connection, SelectAccountSqlStatement, new { Id = id });
        }
    }
}
