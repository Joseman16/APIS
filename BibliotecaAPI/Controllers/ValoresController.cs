using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/valores")]
    public class ValoresController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Valor> Get()
        {

        }
    }
}
