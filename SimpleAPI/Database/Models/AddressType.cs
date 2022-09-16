using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.Database.Models
{
    public class AddressType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
