using BitirmeProjesi.Model;
using BitirmeProjesi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpGet("GetCountry/{id}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            Account account = await _accountRepository.GetAccount(id);
            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpGet("GetCountries")]
        public async Task<IActionResult> GetAllCountries()
        {
            IEnumerable<Account> countries = await _accountRepository.GetAllCountries();
            return Ok(countries);
        }

        [HttpPut("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount([FromQuery] Account account)
        {
            _accountRepository.UpdateAccount(account);
            return Ok(account);
        }

        [HttpPost("AddNewAccount")]
        public async Task<IActionResult> AddNewAccount(Account account)
        {
            _accountRepository.AddAccount(account);
            return Ok(account);
        }

        [HttpDelete("DeleteAccount/{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            Account account  = await _accountRepository.GetAccount(id);
            _accountRepository.DeleteAccount(id);
            return Ok(account);
        }
    }
}
