using BibliotecaAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Entidades
{
    public class Autor : IValidatableObject
    {
        public int Id { get; set; }

        //Este Required tiene otro proposito (puedo personalizar el mensaje de error)
        [Required (ErrorMessage = "El campo {0} es requerido")] //Aqui estoy personalisando el mensaje de error
        [StringLength(15, ErrorMessage ="El campo {0} debe tener {1} caracteres o menos")] //Esta es otra regla de validación en el campo nombre

        //[PrimeraLetraMayuscula]
        public required string Nombre { get; set; } 

        //Un listado de libros
        public List<Libro> libros { get; set; } = new List<Libro>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                var primeraLetra = Nombre[0].ToString();

                if(primeraLetra != primeraLetra.ToUpper() && Edad > 40)
                {
                    yield return new ValidationResult("La primera letra debe ser mayuscula - por modelo",
                        new string[] { nameof(Nombre)});
                }
            }
        }

        public int Edad { get; set; }

        /* [Range(18, 100)]
         public int Edad { get; set; }

         [CreditCard]
         public string? TarjetaDeCredito { get; set; }

         [Url]
         public string? URL { get; set; }*/
    }
}
