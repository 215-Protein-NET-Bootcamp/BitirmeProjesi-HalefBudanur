using BitirmeProjesi.Model;
using BitirmeProjesi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitirmeProjesi
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        [HttpGet("GetCountry/{id}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            Person person = await _personRepository.GetPerson(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpGet("GetCountries")]
        public async Task<IActionResult> GetAllCountries()
        {
            IEnumerable<Person> countries = await _personRepository.GetAllCountries();
            return Ok(countries);
        }

        [HttpPut("UpdatePerson")]
        public async Task<IActionResult> UpdatePerson([FromQuery] Person person)
        {
            _personRepository.UpdatePerson(person);
            return Ok(person);
        }

        [HttpPost("AddNewPerson")]
        public async Task<IActionResult> AddNewPerson(Person person)
        {
            _personRepository.AddPerson(person);
            return Ok(person);
        }

        [HttpDelete("DeletePerson/{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            Person person = await _personRepository.GetPerson(id);
            _personRepository.DeletePerson(id);
            return Ok(person);
        }
    }
}
