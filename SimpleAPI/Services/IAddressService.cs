using SimpleAPI.AllDtos.CreateDtos;
using SimpleAPI.AllDtos.UpdateDtos;

namespace SimpleAPI.Services
{
    public interface IAddressService
    {
        public void AddAddressToPerson(AddressDto dto);
        public void UpdateAddress(int id, UpdateAddressDto dto);
    }
}
