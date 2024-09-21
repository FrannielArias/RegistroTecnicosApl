using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicosApl.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Solo se permiten letras en este campo.")]
        public string? Descripcion {get; set;}

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public TimeSpan Tiempo {get; set;}

    }
}
