using MedicineRegistry.Api.AppConfiguration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineRegistry.Api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    private readonly ILogger<WeatherForecastController> logger;
    private readonly IOptions<AzureAdOptions> azureAdOptions;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<AzureAdOptions> azureAdOptions)
    {
      this.logger = logger;
      this.azureAdOptions = azureAdOptions;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
      HttpContext.VerifyUserHasAnyAcceptedScope(azureAdOptions.Value.Scopes);

      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();
    }
  }
}
