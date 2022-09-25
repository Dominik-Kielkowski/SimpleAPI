namespace SimpleAPI.AllDtos.UpdateDtos
{
    public class UpdateAddressDto
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int AddressTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
