using SimpleAPI.Data;
using SimpleAPI.Models;
using Microsoft.EntityFrameworkCore;
using SimpleAPI.Dtos.UpdateDtos;
using SimpleAPI.Dtos.CreateDtos;
using SimpleAPI.AllDtos.Dtos;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using SimpleAPI.Authorization;
using SimpleAPI.Database.Models;
using SimpleAPI.Exceptions;
using SimpleAPI.Queries;
using SimpleAPI.AllDtos.CreateDtos;

namespace SimpleAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<PersonService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public PersonService(ApplicationDbContext db, ILogger<PersonService> logger, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _db = db;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        public PagedResult<PersonDto> GetAllPeople(PersonQuery query)
        {
            var baseQuery = _db.People.Include(r => r.Occupation)
                .Where(r => query.SearchPhrase == null || (r.Name.ToLower().Contains(query.SearchPhrase.ToLower())));

            if(!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Person, object>>>
                {
                    { nameof(Person.Name), r => r.Name },
                    {nameof(Person.Occupation), r => r.Occupation }
                };

                var selectedColumn = columnsSelector[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var people = baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = baseQuery.Count();

            if (people == null)
                throw new NotFoundException("People not found");

            var peopleDto = people.Select(r => new PersonDto()
            {
                Id = r.Id,
                Name = r.Name,
                Age = r.Age,
                OccupationName = r.Occupation.Name
            }).ToList();

            var result = new PagedResult<PersonDto>( peopleDto, totalItemsCount ,query.PageSize,query.PageNumber);

            return result;
        }

        public PersonDto GetPersonById(int id)
        {

            _logger.LogTrace($"Person with id: {id} GET action invoked");

            var person = _db.People.Include(r => r.Occupation).FirstOrDefault(r => r.Id == id);

            if (person == null)
                throw new NotFoundException("Person not found");

            var personDto = new PersonDto()
            {
                Id = person.Id,
                Name = person.Name,
                Age = person.Age,
                OccupationName = person.Occupation.Name
            };

            return personDto;
        }

        public int AddPersonToDatabase(CreatePersonDto dto)
        {
            var person = new Person()
            {
                Name = dto.Name,
                Age = dto.Age,
                Salary = dto.Salary,
                PhoneNumber = dto.PhoneNumber,
                OccupationId = dto.OccupationId,
                Addresses = new  List<Address>
                {
                    new Address
                    {
                        IsActive = dto.IsActive,
                        AddressTypeId = dto.AddressTypeId,
                        City = dto.City,
                        Street = dto.Street
                    }
                }
       
            };

            person.CreatedById = _userContextService.GetUserId;

            _db.People.Add(person);
            _db.SaveChanges();

            return person.Id;
        }

        public bool? UpdatePerson(int id, UpdatePersonDto dto)
        {
            var person = _db.People.FirstOrDefault(r => r.Id == id);

            if (person == null)
            {
                throw new NotFoundException("Person not found");
            }

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, person,
                new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            if(!authorizationResult.Succeeded)
            {
                throw new AuthorizationFailedException("Authorization Failed");
            }

            person.Name = dto.Name;
            person.Salary = dto.Salary;
            person.Age = dto.Age;
            person.PhoneNumber = dto.PhoneNumber;
            person.OccupationId = dto.OccupationId;

            _db.SaveChanges();

            return true;

        }

        public bool? DeletePerson(int id)
        {
            var person = _db.People.FirstOrDefault(r => r.Id == id);

            if (person == null)
            {
                throw new NotFoundException("Person not found");
            }

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, person,
               new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new AuthorizationFailedException("Authorization Failed");
            }

            _db.People.Remove(person);
            _db.SaveChanges();

            return true;
        }
    }
}