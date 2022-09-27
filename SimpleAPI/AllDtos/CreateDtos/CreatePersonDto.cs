using SimpleAPI.AllDtos.CreateDtos;

namespace SimpleAPI.Dtos.CreateDtos
{
    public class CreatePersonDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int PhoneNumber { get; set; }
        public int OccupationId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int AddressTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
