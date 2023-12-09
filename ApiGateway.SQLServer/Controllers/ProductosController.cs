using ApiGateway.SQLServer.Models;
using ApiGateway.SQLServer.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGateway.SQLServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
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
    }
}
