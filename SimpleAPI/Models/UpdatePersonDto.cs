using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.Models
{
    public class UpdatePersonDto
    {
        [Required]
        public string Name { get; set; }
        [Range(1, 100)]
        public int Age { get; set; }
        public int Salary { get; set; }
    }
}
