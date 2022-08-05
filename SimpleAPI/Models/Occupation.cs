using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.Models
{
    public class Occupation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string OccupationName { get; set; }

        public virtual Person Person { get; set; }
    }
}
