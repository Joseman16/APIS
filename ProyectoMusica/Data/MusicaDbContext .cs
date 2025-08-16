using Microsoft.EntityFrameworkCore;
using ProyectoMusica.Models;

namespace ProyectoMusica.Data
{
    public class MusicaDbContext : DbContext
    {
        public MusicaDbContext(DbContextOptions<MusicaDbContext> options) : base(options) { }

        public DbSet<Cancion> Canciones { get; set; }
        public DbSet<Cantante> Cantantes { get; set; }
        public DbSet<Genero> Generos { get; set; }

    }
}
