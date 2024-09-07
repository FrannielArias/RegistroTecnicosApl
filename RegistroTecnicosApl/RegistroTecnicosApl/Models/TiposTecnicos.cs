using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Compression;

namespace RegistroTecnicosApl.Models
{
    public class TiposTecnicos
    {
        [Key]
        public int TipoTecnicoId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten letras en este campo.")]
        public string? Descripcion { get; set; }
    }
}
