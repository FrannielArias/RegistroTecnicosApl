using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicosApl.Models
{
    public class Cotizaciones
    {
        [Key]
        public int CotizacionId { get; set; }
        public DateTime? Fecha { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Solo se permiten letras en este campo.")]
        public string? Observacion { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(minimum: 0.1, maximum: 9999999999999, ErrorMessage = "El monto debe ser mayor a 0.")]
        public double Monto { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        public ICollection<CotizacionesDetalle> CotizacionesDetalles { get; set; } = new List<CotizacionesDetalle>();
    }
}
