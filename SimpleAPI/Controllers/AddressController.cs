using Microsoft.AspNetCore.Mvc;
using SimpleAPI.AllDtos.CreateDtos;
using SimpleAPI.AllDtos.UpdateDtos;
using SimpleAPI.Services;

namespace SimpleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddAddressToPerson([FromBody] AddressDto dto)
        {
            _service.AddAddressToPerson(dto);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateAddress(int id, UpdateAddressDto dto)
        {
            _service.UpdateAddress(id, dto);
            return Ok();
        }
    }
}
