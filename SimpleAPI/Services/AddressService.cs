using Microsoft.AspNetCore.Authorization;
using SimpleAPI.AllDtos.CreateDtos;
using SimpleAPI.AllDtos.UpdateDtos;
using SimpleAPI.Data;
using SimpleAPI.Database.Models;
using SimpleAPI.Exceptions;

namespace SimpleAPI.Services
{
    public class AddressService : IAddressService
    {
        private readonly ApplicationDbContext _db;

        public AddressService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddAddressToPerson(AddressDto dto)
        {
            var Address = new Address
            {
                City = dto.City,
                Street = dto.Street,
                AddressTypeId = dto.AddressTypeId,
                IsActive = dto.IsActive,
                PersonId = dto.PersonId
            };


            if ((_db.Address.Any(r => r.PersonId == dto.PersonId && r.IsActive == true)) && dto.IsActive == true)
            {
                throw new AlreadyActiveException("Only one address can be active at once");
            };

            _db.Add(Address);
            _db.SaveChanges();
        }

        public void UpdateAddress(int id, UpdateAddressDto dto)
        {
            var address = _db.Address.FirstOrDefault(r => r.Id == id);

            if (address == null)
            {
                throw new NotFoundException("Address not found");
            };

            address.Street = dto.Street;
            address.City = dto.City;
            address.AddressTypeId = dto.AddressTypeId;
            address.IsActive = dto.IsActive;
            

            if ((_db.Address.Any(r => r.PersonId == address.PersonId && r.IsActive == true)) && dto.IsActive == true)
            {
                throw new AlreadyActiveException("Only one address can be active at once");
            };

            _db.SaveChanges();
        }
    }
}
