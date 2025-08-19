using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.Datos;

namespace SistemaVenta.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly AplicationDbContext context;

        //Este es el contructor de la clase con un parametro de ApplicationDbContext
        public UsuarioController(AplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await context.usuario.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Usuario usuario)
        {
            context.Add(usuario);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
