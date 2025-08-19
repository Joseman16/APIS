using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.Datos;
using SistemaVenta.Entidades;

namespace SistemaVenta.Controllers
{
    [ApiController]
    [Route("api/puntoE")]
    public class PuntoEmisionController : ControllerBase
    {
        public readonly AplicationDbContext context;

        public PuntoEmisionController(AplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<PuntoEmision>> Get()
        {
            return await context.puntoEmision.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(PuntoEmision puntoEmision)
        {
            context.Add(puntoEmision);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
