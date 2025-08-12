using BibliotecaAPI.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Datos
{
    //Aqui configuro las tablas de mi base de datos...
    public class ApplicationDbContext: DbContext
    {
        //Constructor de la clasew
        public ApplicationDbContext(DbContextOptions options): base(options) {
            
        }

        //MyProperty
        public DbSet<Autor> Autores {  get; set; }

        public DbSet<Libro> Libros { get; set; }

    }
}
 