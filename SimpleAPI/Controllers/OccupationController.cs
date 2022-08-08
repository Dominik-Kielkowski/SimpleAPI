using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleAPI.Controllers
{
    [Route("api/{personId}/occupation")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        //[HttpPost]
        //public ActionResult Post([FromRoute]int personId, CreateOccupationDto dto)
        //{
        //    return true;
        //}

    }
}
