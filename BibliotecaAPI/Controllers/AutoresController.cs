using BibliotecaAPI.Datos;
using BibliotecaAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers
{
    //ControllerBase, tiene funcionales auxiliares
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        //tengo acceso al context
        private readonly ApplicationDbContext context;

        //Este es el contructor de la clase con un parametro de ApplicationDbContext
        public AutoresController(ApplicationDbContext context) 
        { 
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Autor>> Get()
        {
            return await context.Autores.ToListAsync();
        }

        //Aca teniamos un metodo Harcodeado, osea con datos ya realizados
        /*public IEnumerable<Autor> Get()
        {
            return new List<Autor>
            {
                new Autor{Id = 1, Nombre = "Felipe"},
                new Autor{Id = 2, Nombre = "Nancy"},
                new Autor{Id = 3, Nombre = "Karla"}
            };
        }*/

        // Tambien existe async Await en C#
        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }
        
    }
}
