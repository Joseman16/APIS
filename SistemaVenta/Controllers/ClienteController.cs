using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.Datos;

namespace SistemaVenta.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly AplicationDbContext context;

        //Este es el contructor de la clase con un parametro de ApplicationDbContext
        public ClienteController(AplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await context.clientes.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cliente cliente)
        {
            context.Add(cliente);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
