using SimpleAPI.Database.Models;
using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,100)]
        public int Age { get; set; }
        public int Salary { get; set; }
        public int PhoneNumber { get; set; }
        public int? CreatedById { get; set; }
        public virtual User CreatedBy { get; set;  }

        public int? OccupationId { get; set; }
        public virtual Occupation Occupation { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
