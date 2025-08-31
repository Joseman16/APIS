using BibliotecaAPI.Datos;
using BibliotecaAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers
{
    //ControllerBase, tiene funcionales auxiliares
    [ApiController]
    [Route("api/autores")] //Route: definimos la ruta de nuestro controladores
    public class AutoresController : ControllerBase
    {
        //tengo acceso al context
        private readonly ApplicationDbContext context;

        private readonly ILogger<AutoresController> logger;

        //Este es el contructor de la clase con un parametro de ApplicationDbContext
        public AutoresController(ApplicationDbContext context, ILogger<AutoresController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpGet("listado-autores")] //Su ruta es: api/autores/listado-autores
        [HttpGet]
        public async Task<IEnumerable<Autor>> Get()
        {
            logger.LogTrace("Obteniendo el listado de autores");
            /*logger.LogDebug("Obteniendo el listado de autores");
            logger.LogInformation("Obteniendo el listado de autores");
            logger.LogWarning("Obteniendo el listado de autores");
            logger.LogError("Obteniendo el listado de autores");
            logger.LogCritical("Obteniendo el listado de autores");*/
            return await context.Autores.ToListAsync();
        }

        [HttpGet("primero")] //Su ruta es: api/autores/primero
        public async Task<Autor> GetPrimerAutor()
        {
            //Aqui indico que quiero elprimer autor (el id == 1)
            return await context.Autores.FirstAsync();
        }


        [HttpGet("{parametro1}/{parametro2?}")] //api/autores/Jose/Leon...
        public ActionResult Get(string parametro1, string? parametro2 = "Valor por defecto")
        {
            //retorno un cuerpo (new) anonimo o creado por mi...
            return Ok(new {parametro1, parametro2});
        }

        //Colocamos una restricción
        [HttpGet("{nombre:alpha}")]
        public async Task<IEnumerable<Autor>> Get(string nombre)
        {
            return await context.Autores.Where(x => x.Nombre.Contains(nombre)).ToListAsync();
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
        public async Task<ActionResult> Post([FromBody] Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        //usamos una plantilla para buscar nuestro ID
        // api/autores/id (ej: 1,2,3 u otro)

        // api/autores/id?incluirLibros=true|false
        [HttpGet("{id:int}")] // api/autores/id? llave1=valor1&llave2=valor2
        public async Task<ActionResult<Autor>> GetId([FromRoute] int id, [FromHeader]bool incluirLibros)
        {
            var autor = await context.Autores
                .Include(x => x.libros)
                .FirstOrDefaultAsync(x => x.Id == id);
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
