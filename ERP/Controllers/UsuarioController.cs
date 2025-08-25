using ERP.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : Controller
    {
        private readonly BaseErpContext _context;

        public UsuarioController(BaseErpContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post_pEmision([FromBody] Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}
