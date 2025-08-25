using ERP.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly BaseErpContext _context;

        public ClienteController(BaseErpContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<Cliente>> getCliente()
        {
            return await _context.Clientes.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> PostCliente([FromBody] Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
