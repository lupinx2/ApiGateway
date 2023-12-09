using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpClientFactory _client;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult> Get()
        {
            var sqlClient = _client.CreateClient("SQLServer");

            var response = await sqlClient.GetAsync("api/Productos/770");

            if (response.IsSuccessStatusCode) 
            {
                return Ok(response.Content);
            }
            return BadRequest(response.Content);
        }
    }
}