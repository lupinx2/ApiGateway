using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {

        private readonly ILogger<GatewayController> _logger;
        private readonly IHttpClientFactory _client;
        public GatewayController(ILogger<GatewayController> logger, IHttpClientFactory client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet("test")]
        public ActionResult Get()
        {
            // just return 200
            return Ok();
            /*             var sqlClient = _client.CreateClient("SQLServer");

                        var response = await sqlClient.GetAsync("api/Productos/770");

                        if (response.IsSuccessStatusCode) 
                        {
                            return Ok(response.Content);
                        }
                        return BadRequest(response.Content); */
        }

        [HttpPost("login")]
        public async Task<ActionResult> Post([FromBody] LoginRequest loginrequest)
        {
            var sqlClient = _client.CreateClient("SQLServer");

            var response = await sqlClient.PostAsJsonAsync("http://localhost:5031/api/Login", loginrequest);

            var content = await response.Content.ReadAsStringAsync();
            return Ok(content);
        }

        [HttpPost("fresh")]
        public async Task<ActionResult> Post()
        {
            return Ok();
        }
    }
}