using ApiGateway.SQLServer.Models;
using ApiGateway.SQLServer.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGateway.SQLServer.Controllers
{
    [ApiController]
    [Route("api/")]
    public class SQLDBController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SQLDBController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Producto>> ObtenerProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpGet("{codigo}")]
        public async Task<Producto?> ObtenerProductosPorCodigo(string codigo)
        {
            return await _context.Productos.FirstOrDefaultAsync(x => x.Codigo==codigo);
        }


        [HttpPost("login")]
        public async Task<ActionResult> Post([FromBody] LoginRequest loginrequest)
        {   
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.usuario == loginrequest.Username && c.contraseña == loginrequest.Password);
            System.Console.WriteLine(cliente);
            if (cliente == null){return BadRequest();}
            if (cliente.cliente_ID !=0)
            {
                return Ok(cliente.cliente_ID);
            }else{
                return BadRequest();
            }
        }
    }
}
