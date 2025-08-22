using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Validaciones
{
    public class PrimeraLetraMayusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var valueString = value.ToString()!;

            //Aqui tenemos la primera letra del valor (osea del caracter)
            var primeraLetra = valueString[0].ToString();

            if(primeraLetra != primeraLetra.ToUpper())
            {
                return new ValidationResult("La primera letra debe ser mayúscula");
            }

            return ValidationResult.Success;
        }

    }
}
