using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicosApl.Models
{
    public class Tecnicos
    {
        [Key]
        public int EstudianteId {  get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "No se permite numeros en este campo.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(maximum:9999999999, minimum:0.1, ErrorMessage = "El monto debe ser mayor a 0 o es demasiado alto para el sistema")]
        public decimal SueldoHora { get; set; }
    }
}
