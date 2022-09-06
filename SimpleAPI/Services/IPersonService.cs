using SimpleAPI.AllDtos.Dtos;
using SimpleAPI.Dtos.CreateDtos;
using SimpleAPI.Dtos.UpdateDtos;
using System.Security.Claims;

namespace SimpleAPI.Services
{
    public interface IPersonService
    {
        int Create(CreatePersonDto dto);
        PagedResult<PersonDto> GetAll(PersonQuery query);
        PersonDto GetById(int id);
        bool? Delete(int id);
        bool? Update(int id, UpdatePersonDto dto);
    }
}