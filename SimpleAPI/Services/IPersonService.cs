using SimpleAPI.AllDtos.Dtos;
using SimpleAPI.Dtos.CreateDtos;
using SimpleAPI.Dtos.UpdateDtos;
using SimpleAPI.Queries;
using System.Security.Claims;

namespace SimpleAPI.Services
{
    public interface IPersonService
    {
        int AddPersonToDatabase(CreatePersonDto dto);
        PagedResult<PersonDto> GetAllPeople(PersonQuery query);
        PersonDto GetPersonById(int id);
        bool? DeletePerson(int id);
        bool? UpdatePerson(int id, UpdatePersonDto dto);
    }
}