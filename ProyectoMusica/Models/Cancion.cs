using System.ComponentModel.DataAnnotations;

namespace ProyectoMusica.Models
{
    public class Cancion
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int CantanteId { get; set; }
        public int GeneroId { get; set; }

        // Propiedades de navegación
        public Cantante Cantante { get; set; }
        public Genero Genero { get; set; }
    }
}
