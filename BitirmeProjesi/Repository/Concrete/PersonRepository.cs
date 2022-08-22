using BitirmeProjesi.DbProvider;
using BitirmeProjesi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitirmeProjesi.Repository
{
    public class PersonRepository
    {
        private readonly IDapperDbProvider _dapperDbProvider;

        private const string SelectPersonSqlStatement = @"SELECT * FROM Person WHERE AccountId = @Id";
        private const string SelectAllCountriesSqlStatement = @"SELECT * FROM Person";

        public PersonRepository(IDapperDbProvider dapperDbProvider)
        {
            _dapperDbProvider = dapperDbProvider;
        }

        public async Task<Person> GetPerson(int id)
        {
            using var connection = _dapperDbProvider.GetConnection();

            return await _dapperDbProvider.QueryFirstOrDefaultAsync<Person>(connection, SelectPersonSqlStatement, new { AccountId = id });
        }

        public async Task<IEnumerable<Person>> GetAllCountries()
        {
            using var connection = _dapperDbProvider.GetConnection();

            return await _dapperDbProvider.QueryAsync<Person>(connection, SelectAllCountriesSqlStatement);
        }

        public async Task AddPerson(Person Person)
        {
            string InsertPersonSqlStatement = $"INSERT INTO public.Person(FirsName, LastName, Email, Password, Description, Phone, DateOfBirth) VALUES ('{Person.FirsName}', '{Person.LastName}', '{Person.Email}', '{Person.Password}', '{Person.Description}', '{Person.Phone}', '{Person.DateOfBirth}');";

            using var connection = _dapperDbProvider.GetConnection();

            await _dapperDbProvider.ExecuteAsync(connection, InsertPersonSqlStatement);
        }

        public async Task<Person> UpdatePerson(Person Person)
        {
            string UpdatePersonSqlStatement = $"UPDATE Person SET FirsName = '{Person.FirsName}', LastName = '{Person.LastName}', Email = '{Person.Email}', Password = '{Person.Password}', Description = '{Person.Description}', Phone = '{Person.Phone}', DateOfBirth = '{Person.DateOfBirth}' WHERE Id = {Person.AccountId}";

            using var connection = _dapperDbProvider.GetConnection();

            return await _dapperDbProvider.QueryFirstOrDefaultAsync<Person>(connection, UpdatePersonSqlStatement);
        }

        public async Task<Person> DeletePerson(int id)
        {
            string DeletePersonSqlStatement = $"DELETE FROM public.Person WHERE Personid = {id};";
            using var connection = _dapperDbProvider.GetConnection();
            await _dapperDbProvider.QueryFirstOrDefaultAsync<Person>(connection, DeletePersonSqlStatement);
            return await _dapperDbProvider.QueryFirstOrDefaultAsync<Person>(connection, SelectPersonSqlStatement, new { AccountId = id });
        }
    }
}
