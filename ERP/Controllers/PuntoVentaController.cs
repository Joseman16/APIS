using ERP.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Controllers
{
    [ApiController]
    [Route("api/puntoVenta")]
    public class PuntoVentaController : ControllerBase
    {
        private readonly BaseErpContext _context;

        public PuntoVentaController(BaseErpContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<PuntoVentum>> get_pVenta()
        {
            return await _context.PuntoVenta.ToArrayAsync();
        }


    }
}
