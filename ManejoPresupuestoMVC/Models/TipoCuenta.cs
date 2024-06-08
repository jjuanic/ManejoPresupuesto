﻿using ManejoPresupuestoMVC.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuestoMVC.Models
{
    public class TipoCuenta //: IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [PrimeraLetraMayuscula] // Se sobreentiende que Attribute está presente.
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public int Orden { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Nombre != null && Nombre.Length > 0)
        //    {
        //        var primeraLetra = Nombre[0].ToString();
        //        if (primeraLetra != primeraLetra.ToUpper()){
        //            yield return new ValidationResult("La primera letra debe ser mayuscula", 
        //                new[] {nameof(Nombre)}); // Acá le decimos que este error le corresponde al campo Nombre
        //        }
        //    }
        //}
    }
}
