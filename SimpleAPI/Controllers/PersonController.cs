using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Data;
using SimpleAPI.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using SimpleAPI.Services;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService personService)
        {
            _service = personService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonDto>> GetAllPeople()
        {
            var people = _service.GetAll();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public ActionResult<PersonDto> GetPerson(int id)
        {
            var person = _service.GetById(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> AddPerson([FromBody] CreatePersonDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _service.Create(dto);

            return Created($"api/Person/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Person>> DeletePerson([FromRoute] int id)
        {
            var isDeleted = _service.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult<List<Person>> EditPerson([FromBody] UpdatePersonDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var isUpdated = _service.Update(id, dto);

            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
