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
        public List<AddressDto> Address { get; set; }
    }
}
