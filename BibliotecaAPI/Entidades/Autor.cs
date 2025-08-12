using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Entidades
{
    public class Autor
    {
        public int Id { get; set; }

        [Required] //Este Required tiene otro proposito (puedo personalizar el mensaje de error)
        public required string Nombre { get; set; } 

        //Un listado de libros
        public List<Libro> libros { get; set; } = new List<Libro>();
    }
}
