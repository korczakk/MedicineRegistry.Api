using Microsoft.AspNetCore.Mvc;

namespace MedicineRegistry.Api.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class HealthController : ControllerBase
  {
    [HttpGet]
    public ActionResult Get()
    {
      return Ok();
    }
  }
}
