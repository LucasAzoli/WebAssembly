using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto.Server.Data.Migrations;
using projeto.Server.Services;
using projeto.Shared.Models;

namespace projeto.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAllPersons()
        {
            return await _personService.GetAllPersons();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var result = await _personService.GetPerson(id);
            if (result is null)
            {
                return NotFound("Person not found!");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> AddPerson(Person person)
        {
            var result = await _personService.AddPerson(person);
            if (result is null)
            {
                return NotFound("Person not found!");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Person>>> UpdatePerson(int id, Person request)
        {
            var result = await _personService.UpdatePerson(id, request);
            if (result is null)
            {
                return NotFound("Person not found!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> DeletePerson(int id)
        {
            var result = await _personService.DeletePerson(id);
            if (result is null)
            {
                return NotFound("Person not found!");
            }
            return Ok(result);
        }
    }
}
