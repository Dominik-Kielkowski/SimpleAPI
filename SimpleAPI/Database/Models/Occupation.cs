using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.Models
{
    public class Occupation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public  List<Person> People { get; set; }
    }
}
