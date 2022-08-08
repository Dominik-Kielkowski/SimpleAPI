using SimpleAPI.Data;
using SimpleAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<PersonService> _logger;

        public PersonService(ApplicationDbContext db, ILogger<PersonService> logger)
        {
            _db = db;
            _logger = logger;
        }


        public PersonDto GetById(int id)
        {

            _logger.LogTrace($"Person with id: {id} GET action invoked");

            var person = _db.People.Include(r => r.Occupation).FirstOrDefault(r => r.Id == id);

            var personDto = new PersonDto()
            {
                Id = person.Id,
                Name = person.Name,
                Age = person.Age,
                OccupationName = person.Occupation.OccupationName
            };

            if (person == null)
            {
                return null;
            }

            return personDto;
        }

        public IEnumerable<PersonDto> GetAll()
        {
            var people = _db.People.Include(r => r.Occupation).ToList();

            var peopleDto = people.Select(r => new PersonDto()
            {
                Id = r.Id,
                Name = r.Name,
                Age = r.Age,
                OccupationName = r.Occupation.OccupationName
                
            });

            return peopleDto;
        }

        public int Create(CreatePersonDto dto)
        {
            var person = new Person() 
            {
                Name = dto.Name,
                Age= dto.Age,
                Salary = dto.Salary,
                PhoneNumber = dto.PhoneNumber,
                OccupationId = dto.OccupationId
            };

            _db.People.Add(person);
            _db.SaveChanges();

            return person.Id;
        }

        public bool Delete(int id)
        {
            var person = _db.People.FirstOrDefault(r => r.Id == id);

            if (person == null)
            {
                return false;
            }

            _db.People.Remove(person);
            _db.SaveChanges();

            return true;
        }

        public bool Update(int id, UpdatePersonDto dto)
        {
            var person = _db.People.FirstOrDefault(r => r.Id == id);

            if(person == null)
            {
                return false;
            }

            person.Name = dto.Name;
            person.Salary = dto.Salary;
            person.Age = dto.Age;
            person.PhoneNumber = dto.PhoneNumber;
            person.OccupationId = dto.OccupationId;

            _db.SaveChanges();

            return true;

        }
    }
}
