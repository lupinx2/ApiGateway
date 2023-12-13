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

        [HttpGet(Name = "GetProductosCategoria")]
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