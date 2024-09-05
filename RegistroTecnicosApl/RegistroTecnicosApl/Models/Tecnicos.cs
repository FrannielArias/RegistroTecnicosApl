﻿using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicosApl.Models
{
    public class Tecnicos
    {
        [Key]
        public int TecnicoId {  get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten letras en este campo.")]
        public string? Nombres { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(minimum: 0.1, maximum:9999999999,  ErrorMessage = "El monto debe ser mayor a 0 o es demasiado alto para el sistema")]
        public decimal SueldoHora { get; set; }
    }
}
