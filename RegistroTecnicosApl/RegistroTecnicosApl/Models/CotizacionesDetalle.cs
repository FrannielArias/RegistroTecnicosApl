using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicosApl.Models
{
    public class CotizacionesDetalle
    {
        [Key]
        public int CotizacionDetalleId { get; set; }

        [ForeignKey("CotizacionId")]
        public int CotizacionId { get; set; }
        public Cotizaciones Cotizaciones { get; set; }

        [ForeignKey("ArticuloId")]
        public int ArticuloId { get; set; }
        public Articulos Articulos { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(minimum: 0.1, maximum: 9999999999999, ErrorMessage = "El monto debe ser mayor a 0.")]
        public double Cantidad { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(minimum: 0.1, maximum: 9999999999999, ErrorMessage = "El monto debe ser mayor a 0.")]
        public double Precio { get; set; }

    }
}
