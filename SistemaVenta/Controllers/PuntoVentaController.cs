using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.Datos;
using SistemaVenta.Entidades;

namespace SistemaVenta.Controllers
{
    [ApiController]
    [Route("api/puntoV")]
    public class PuntoVentaController : ControllerBase
    {
        public readonly AplicationDbContext context;

        public PuntoVentaController(AplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<PuntoVenta>> Get()
        {
            return await context.puntoVenta.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PuntoVenta puntoVenta)
        {
            context.Add(puntoVenta);
            await context.SaveChangesAsync();
            return Ok();
        }


    }
}
