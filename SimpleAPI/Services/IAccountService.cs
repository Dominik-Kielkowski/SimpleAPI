using SimpleAPI.AllDtos.CreateDtos;
using SimpleAPI.AllDtos.Dtos;

namespace SimpleAPI.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        string GenerateJwt(LoginUserDto dto);
    }
}