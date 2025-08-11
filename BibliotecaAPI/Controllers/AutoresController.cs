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
        //Insertar o postear autores
        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        //usamos una plantilla para buscar nuestro ID
        [HttpGet("{id:int}")] // api/autores/id (ej: 1,2,3 u otro)
        public async Task<ActionResult<Autor>> GetId(int id)
        {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);
            if (autor == null)
            {
                //si autor es NULL, retornamos un "No encontrado"
                return NotFound();
            }
            return autor;
        }

        //Actualizar autores
        [HttpPut("{id:int}")] // api/autores/id
        public async Task<ActionResult> PutId(int id, Autor autor)
        {
            if (id !=autor.Id)
            {
                return BadRequest("Los ids deben de coincidir");
            }
            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        //Eliminar autores
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DelelteId(int id)
        {
            var registrosBorrados = await context.Autores.Where(x=> x.Id == id).ExecuteDeleteAsync();
            if(registrosBorrados == 0)
            {
                return NotFound();
            }
            return Ok();
        }
        
    }
}
