using BibliotecaAPI.Datos;
using BibliotecaAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers
{

    [ApiController]
    [Route("api/libros")]
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext context;
        public LibrosController(ApplicationDbContext context) 
        {
            this.context = context;
        }

        //Obtner libro
        [HttpGet]
        public async Task<IEnumerable<Libro>> Get()
        {
            return await context.Libros.ToListAsync();
        }

        //Postear o insertar un nuevo libro
        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
            var existeAutor = await context.Autores.AnyAsync(x => x.Id == libro.AutorId);

            if (!existeAutor)
            {
                return BadRequest($"El autor de id {libro.AutorId} no existe");
            }
            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();
        }

        //Obtnere libro por id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> GetId(int id)
        {
            //Va traer el id y el nombre del autor
            var libro = await context.Libros
                .Include(x => x.Autor)
                .FirstOrDefaultAsync(x => x.Id == id);
            if(libro == null)
            {
                return NotFound();
            }
            return libro;
        }

        //Actualizar libros
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutId(int id, Libro libro)
        {
            if(id != libro.Id)
            {
                return BadRequest("Los ids deben coincidir");
            }

            var existeAutor = await context.Autores.AnyAsync(x => x.Id == libro.AutorId);
            if (!existeAutor)
            {
                return BadRequest($"El autor de id {libro.AutorId} no existe");
            }

            context.Update(libro);
            await context.SaveChangesAsync();
            return Ok();
        }

        //Eliminar libros
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteId(int id)
        {
            var registroBorrados = await context.Autores.Where(x => x.Id == id).ExecuteDeleteAsync();
            if(registroBorrados == 0)
            {
                return NotFound();
            }
            return Ok();

        }


        
    }
}
