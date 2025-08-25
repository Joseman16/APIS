using ERP.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Controllers
{
    [ApiController]
    [Route("api/rol")]
    public class RolController : ControllerBase
    {
        private readonly BaseErpContext _context;

        public RolController (BaseErpContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Rol>> get_rol()
        {
            return await _context.Rols.ToArrayAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post_rol([FromBody] Rol rol)
        {
            _context.Add(rol);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}
