using SimpleAPI.AllDtos.Dtos;
using SimpleAPI.Dtos.CreateDtos;
using SimpleAPI.Dtos.UpdateDtos;

namespace SimpleAPI.Services
{
    public interface IPersonService
    {
        int Create(CreatePersonDto dto);
        IEnumerable<PersonDto> GetAll();
        PersonDto GetById(int id);
        bool? Delete(int id);
        bool? Update(int id, UpdatePersonDto dto);
    }
}