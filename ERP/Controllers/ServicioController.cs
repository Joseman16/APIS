using ERP.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [ApiController]
    [Route("api/servicio")]
    public class ServicioController : Controller
    {
        private readonly BaseErpContext context;

        public ServicioController(BaseErpContext context)
        {
            this.context = context;

        }

        [HttpGet("testDb")]
        public IActionResult testDb()
        {
            BaseErpContext context = new BaseErpContext();
            return Ok(context.Pais.ToList());
        }

    }
}
