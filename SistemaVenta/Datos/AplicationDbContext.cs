using Microsoft.EntityFrameworkCore;
using SistemaVenta.Entidades;

namespace SistemaVenta.Datos
{

        public class AplicationDbContext : DbContext
        {
            //Constructor de la clasew
            public AplicationDbContext(DbContextOptions options) : base(options)
            {

            }

            //MyProperty
            public DbSet<Cliente> clientes{ get; set; }

            public DbSet<Rol> rol { get; set; }

            public DbSet<PuntoEmision> puntoEmision { get; set; }
            public DbSet<PuntoVenta> puntoVenta { get; set; }
            public DbSet<Usuario> usuario { get; set; }

        }
   
}
