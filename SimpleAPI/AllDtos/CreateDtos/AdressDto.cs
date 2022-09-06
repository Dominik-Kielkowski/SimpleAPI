namespace SimpleAPI.AllDtos.CreateDtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string AddressType { get; set; }
        public bool IsActive { get; set; }
    }
}
