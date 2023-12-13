using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.MongoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuggestionController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<SuggestionController> _logger;

        public SuggestionController(ILogger<SuggestionController> logger)
        {
            _logger = logger;
        }
    }
}