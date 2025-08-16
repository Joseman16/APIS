using System.ComponentModel.DataAnnotations;

namespace ProyectoMusica.Models
{
    public class Cantante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }

        // Relación uno a muchos
        public ICollection<Cancion> Canciones { get; set; }
    }
}
