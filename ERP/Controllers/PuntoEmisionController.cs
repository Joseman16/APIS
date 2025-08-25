using ERP.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Controllers
{
    [ApiController]
    [Route("api/puntoEmision")]
    public class PuntoEmisionController : ControllerBase
    {
        private readonly BaseErpContext _context;
        
        public PuntoEmisionController(BaseErpContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<PuntoEmisionSri>> get_pEmision()
        {
            return await _context.PuntoEmisionSris.ToArrayAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post_pEmision([FromBody] PuntoEmisionSri puntoEmisionSri)
        {
            _context.Add(puntoEmisionSri);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
