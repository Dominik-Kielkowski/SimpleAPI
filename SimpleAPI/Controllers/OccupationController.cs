using Microsoft.AspNetCore.Mvc;
using SimpleAPI.AllDtos.Dtos;
using SimpleAPI.AllDtos.UpdateDtos;
using SimpleAPI.Dtos.CreateDtos;
using SimpleAPI.Exceptions;
using SimpleAPI.Services;

namespace SimpleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        private readonly IOccupationService _service;

        public OccupationController(IOccupationService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OccupationDto>> GetAllOccupations()
        {
            var OccupationList = _service.GetAllOccupations();

            return Ok(OccupationList);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<OccupationDto> GetOccupationById([FromRoute] int id)
        {
            var Occupation = _service.GetOccupationById(id);

            return Ok(Occupation);
        }

        [HttpPost]
        public ActionResult AddOccupationToDatabase([FromBody] CreateOccupationDto createOccupationDto)
        {
            var createdOccupationId = _service.AddOccupationToDatabase(createOccupationDto);

            return Created($"api/Occupation/{createdOccupationId}", null);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateOccupation([FromRoute] int id, [FromBody] UpdateOccupationDto updateOccupationDto)
        {
            var updatedOccupationId = _service.UpdateOccupation(id, updateOccupationDto);

            return Created($"api/Occupation/{updatedOccupationId}",null);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteOccupation([FromRoute] int id)
        {
            _service.DeleteOccupation(id);

            return NoContent();
        }
    }
}
