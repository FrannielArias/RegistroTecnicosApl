using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace RegistroTecnicosApl.Models
{
    public class Trabajos
    {
        [Key]
        public int TrabajoId { get; set; }

        public DateTime? Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Solo se permiten letras.")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Este campi es obligatorio.")]
        [Range(maximum: 99999999, minimum: 0.1, ErrorMessage = "No se permiten valores menores a 0.")]
        public decimal Monto { get; set; }

        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Clientes? Clientes { get; set; }

        public int TecnicoId { get; set; }
        [ForeignKey("TecnicoId")]
        public Tecnicos? Tecnicos { get; set; }

        public int PrioridadId { get; set; }
        [ForeignKey("PrioridadId")]

        public Prioridades? Prioridades { get; set; }

        public ICollection<TrabajosDetalle> TrabajoDetalle { get; set; }
    }
}
