using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Data;
using SimpleAPI.Models;
using Microsoft.EntityFrameworkCore;
using SimpleAPI.Services;
using SimpleAPI.Dtos.UpdateDtos;
using SimpleAPI.Dtos.CreateDtos;
using SimpleAPI.AllDtos.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using SimpleAPI.Queries;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService personService)
        {
            _service = personService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<PersonDto>> GetAllPeople([FromQuery] PersonQuery query)
        {
            var people = _service.GetAllPeople(query);

            return Ok(people);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<PersonDto> GetPerson(int id)
        {
            var person = _service.GetPersonById(id);

            return Ok(person);
        }

        [HttpPost]
        public ActionResult<List<Person>> AddPerson([FromBody] CreatePersonDto dto)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var id = _service.AddPersonToDatabase(dto);

            return Created($"api/Person/{id}", null);
        }

        [HttpPut("{id}")]
        public ActionResult<List<Person>> EditPerson([FromBody] UpdatePersonDto dto, [FromRoute] int id)
        {
            var isUpdated = _service.UpdatePerson(id, dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Person>> DeletePerson([FromRoute] int id)
        {
            var isDeleted = _service.DeletePerson(id);

            return NotFound();
        }
    }
}
