using BitirmeProjesi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitirmeProjesi.Repository
{
    public interface IAccountRepository
    {
        Task<Account> GetAccount(int id);
        Task<IEnumerable<Account>> GetAllCountries();
        Task AddAccount(Account account);
        Task<Account> UpdateAccount(Account account);
        Task<Account> DeleteAccount(int id);
    }
}
