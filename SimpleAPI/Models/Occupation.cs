using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.Models
{
    public class Occupation
    {
        [Key]
        public int OccupationId { get; set; }
        [Required]
        public string OccupationName { get; set; } = string.Empty;
    }
}
