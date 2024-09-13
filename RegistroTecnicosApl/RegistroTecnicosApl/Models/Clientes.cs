using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicosApl.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Solo se permiten letras en este campo.")]
        public string? Nombres { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(12, ErrorMessage = "El numero de WhatsApp solo debe tener 10 digitos")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}", ErrorMessage = "El numero de WhatsApp debe tener este formato xxx-xxx-xxxx.")]
        public string? WhatsApp { get; set; }
    }
}
