using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    //ControllerBase, tiene funcionales auxiliares
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "autores";
        }
        
    }
}
