using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Data;
using SimpleAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public PersonService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public PersonDto GetById(int id)
        {
            var person = _db.People.Include(r => r.Occupation).FirstOrDefault(r => r.Id == id);

            if (person == null)
            {
                return null;
            }

            var result = _mapper.Map<PersonDto>(person);
            return result;
        }

        public IEnumerable<PersonDto> GetAll()
        {
            var people = _db.People.Include(r => r.Occupation).ToList();

            var peopleDto = _mapper.Map<List<PersonDto>>(people);

            return peopleDto;
        }

        public int Create(CreatePersonDto dto)
        {
            var person = _mapper.Map<Person>(dto);
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

            _db.SaveChanges();

            return true;

        }
    }
}
