using Microsoft.AspNetCore.Mvc;
using SimpleAPI.AllDtos.CreateDtos;
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
    }
}
