using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Data;
using SimpleAPI.Models;
using Microsoft.EntityFrameworkCore;
using SimpleAPI.Services;
using SimpleAPI.Dtos.UpdateDtos;
using SimpleAPI.Dtos.CreateDtos;
using SimpleAPI.AllDtos.Dtos;

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
        public ActionResult<IEnumerable<PersonDto>> GetAllPeople([FromQuery] PersonQuery query)
        {
            var people = _service.GetAll(query);

            if (people == null)
                return NotFound();

            return Ok(people);
        }

        [HttpGet("{id}")]
        public ActionResult<PersonDto> GetPerson(int id)
        {
            var person = _service.GetById(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public ActionResult<List<Person>> AddPerson([FromBody] CreatePersonDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _service.Create(dto);

            return Created($"api/Person/{id}", null);
        }

        [HttpPut("{id}")]
        public ActionResult<List<Person>> EditPerson([FromBody] UpdatePersonDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var isUpdated = _service.Update(id, dto);

            if (isUpdated == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Person>> DeletePerson([FromRoute] int id)
        {
            var isDeleted = _service.Delete(id);

            if (isDeleted == null)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
