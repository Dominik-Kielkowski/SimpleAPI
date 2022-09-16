using SimpleAPI.AllDtos.CreateDtos;
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

        public int AddAddressToPerson(AddressDto dto)
        {
            var Address = new Address
            {
                City = dto.City,
                Street = dto.Street,
                AddressTypeId = dto.AddressTypeId,
                IsActive = dto.IsActive,
                PersonId = dto.PersonId
            };


            if ((_db.Address.Where(r => r.PersonId == dto.PersonId && r.IsActive == true).ToList().Count != 0) && dto.IsActive == true)
            {
                throw new Exception();
            };
         

            _db.Add(Address);
            _db.SaveChanges();

            return Address.Id;
        }
    }
}
