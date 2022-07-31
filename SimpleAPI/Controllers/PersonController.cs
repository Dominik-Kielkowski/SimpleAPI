using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Data;
using SimpleAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public PersonController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAllPeople()
        {
            return Ok(await _db.People.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _db.People.FindAsync(id);

            if(person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> AddPerson(Person person)
        {
            _db.People.Add(person);
            await _db.SaveChangesAsync();

            return Ok(await _db.People.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> DeletePerson(int id)
        {
            var person = await _db.People.FindAsync(id);
            
            if(person == null)
            {
                return NotFound();
            }    


            _db.People.Remove(person);
            await _db.SaveChangesAsync();

            return Ok(await _db.People.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Person>>> EditPerson(Person person)
        {
            var personToEdit = await _db.People.FindAsync(person.Id);

            if(personToEdit == null)
            {
                return NotFound();
            }


            personToEdit.Name = person.Name;
            personToEdit.Age = person.Age;

            await _db.SaveChangesAsync();

            return Ok(await _db.People.ToListAsync());
        }

    }
}
