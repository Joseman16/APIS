
using System.ComponentModel.DataAnnotations;

namespace ProyectoMusica.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Relación uno a muchos
        public ICollection<Cancion> Canciones { get; set; }
    }
}
