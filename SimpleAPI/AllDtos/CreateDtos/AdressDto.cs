namespace SimpleAPI.AllDtos.CreateDtos
{
    public class AddressDto
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int AddressTypeId { get; set; }
        public bool IsActive { get; set; }
        public int PersonId { get; set; }
    }
}
