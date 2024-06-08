using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuestoMVC.Validaciones
{
    public class PrimeraLetraMayusculaAttribute : ValidationAttribute
    {
                                                    // Valor que tiene el campo
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Primero, verificamos si es null. Nosotros tomamos que si es nulo, lo tomamos como válida
            // Esto es para no llegar a tener conflictos con otras validaciones
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var primeraLetra = value.ToString()[0].ToString();

            if (primeraLetra != primeraLetra.ToUpper())
            {
                return new ValidationResult("La primera letra debe ser mayúscula");
            }

            return ValidationResult.Success;
        }
    }
}
