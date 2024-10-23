using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicosApl.Models;

public class Articulos
{
    [Key]
    public int ArticuloId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Este campo solo permite letras.")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [Range(minimum:0.1, maximum:9999999999999, ErrorMessage = "El monto debe ser mayor a 0.")]
    public double Costo { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [Range(minimum: 0.1, maximum: 9999999999999, ErrorMessage = "El monto debe ser mayor a 0.")]
    public double Precio { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [Range(minimum: 0.1, maximum: 9999999999999, ErrorMessage = "El monto debe ser mayor a 0.")]
    public int Existencia { get; set; }
    
}
