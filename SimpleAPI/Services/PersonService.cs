using SimpleAPI.Data;
using SimpleAPI.Models;
using Microsoft.EntityFrameworkCore;
using SimpleAPI.Dtos.UpdateDtos;
using SimpleAPI.Dtos.CreateDtos;
using SimpleAPI.AllDtos.Dtos;

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

        public IEnumerable<PersonDto> GetAll()
        {
            var people = _db.People.Include(r => r.Occupation).ToList();

            if (people == null)
                return null;

            var peopleDto = people.Select(r => new PersonDto()
            {
                Id = r.Id,
                Name = r.Name,
                Age = r.Age,
                OccupationName = r.Occupation.Name

            });

            return peopleDto;
        }

        public PersonDto GetById(int id)
        {

            _logger.LogTrace($"Person with id: {id} GET action invoked");

            var person = _db.People.Include(r => r.Occupation).FirstOrDefault(r => r.Id == id);

            if (person == null)
                return null;

            var personDto = new PersonDto()
            {
                Id = person.Id,
                Name = person.Name,
                Age = person.Age,
                OccupationName = person.Occupation.Name
            };

            return personDto;
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

        public bool? Update(int id, UpdatePersonDto dto)
        {
            var person = _db.People.FirstOrDefault(r => r.Id == id);

            if (person == null)
            {
                return null;
            }

            person.Name = dto.Name;
            person.Salary = dto.Salary;
            person.Age = dto.Age;
            person.PhoneNumber = dto.PhoneNumber;
            person.OccupationId = dto.OccupationId;

            _db.SaveChanges();

            return true;

        }

        public bool? Delete(int id)
        {
            var person = _db.People.FirstOrDefault(r => r.Id == id);

            if (person == null)
            {
                return null;
            }

            _db.People.Remove(person);
            _db.SaveChanges();

            return true;
        }
    }
}
