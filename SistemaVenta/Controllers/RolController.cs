using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.Datos;
using SistemaVenta.Entidades;

namespace SistemaVenta.Controllers
{
    [ApiController]
    [Route("api/rol")]
    public class RolController : ControllerBase
    {
        public readonly AplicationDbContext context;

        public RolController(AplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<Rol>> Get()
        {
            return await context.rol.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Rol rol)
        {
            context.Add(rol);
            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpPut("{id:int}")] // api/autores/id
        public async Task<ActionResult> PutId(int id, Rol rol)
        {
            if (id !=rol.Id)
            {
                return BadRequest("Los ids deben de coincidir");
            }
            context.Update(rol);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
