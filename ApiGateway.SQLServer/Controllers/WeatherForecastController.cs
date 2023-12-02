using ApiGateway.SQLServer.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.SQLServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Nombre/{nombre}")]
        public ActionResult<string> GetNombre(string nombre) 
        {
            return Ok (nombre);
        }

        [HttpGet("Nombre/{nombre}/{edad:int}")]
        public ActionResult<string> GetNombre(string nombre, int edad)
        {
            return Ok(nombre + " " + edad.ToString());
        }

        [HttpPost("login")]
        public ActionResult<string> GetNombre([FromBody] LoginDto login)
        {
            if (login.Usuario == "pepe" && login.Contrasenia == "123")
            {
                return Ok ();
            }
            return Unauthorized ();
        }
    }
}