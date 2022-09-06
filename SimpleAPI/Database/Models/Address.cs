using SimpleAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.Database.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string AddressType { get; set; }
        public bool IsActive { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
