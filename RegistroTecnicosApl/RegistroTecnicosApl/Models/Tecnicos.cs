using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Range(minimum: 0.1, maximum:9999999999,  ErrorMessage = "El monto debe ser mayor a 0.")]
        public decimal SueldoHora { get; set; }

        [ForeignKey("TipoTecnicoId")]
        public int TipoTecnicoId { get; set; }
        public TiposTecnicos? TipoTecnico { get; set; }
    }
}
