using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitTestDemo.DataAccess;
using UnitTestDemo.DataAccess.Models;

namespace UnitTestDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IRepository _repository;

        public PeopleController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        { 
            var people = await _repository.GetAll<Person>();

            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await _repository.GetById<Person>(id);
            if (person is null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Person person)
        { 
            await _repository.Add(person);
            return CreatedAtAction(nameof(Get), new {id = person.Id}, person);
        }
    }
}
