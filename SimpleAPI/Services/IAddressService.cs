using SimpleAPI.AllDtos.CreateDtos;

namespace SimpleAPI.Services
{
    public interface IAddressService
    {
        public int AddAddressToPerson(AddressDto dto);
    }
}
