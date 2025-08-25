using ERP.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ERP.Controllers
{
    [ApiController]
    [Route("api/servicio")]
    public class ServicioController : ControllerBase
    {
        private readonly BaseErpContext _context;

        public ServicioController(BaseErpContext context)
        {
            _context = context;
        }

        [HttpGet("testDb")]
        public IActionResult TestDb()
        {
            // Usar el context inyectado, no crear uno nuevo
            var paises = _context.Pais.ToList();
            return Ok(paises);
        }
    }
}
