using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.Dtos.UpdateDtos
{
    public class UpdatePersonDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int PhoneNumber { get; set; }
        public int? OccupationId { get; set; }
    }
}
