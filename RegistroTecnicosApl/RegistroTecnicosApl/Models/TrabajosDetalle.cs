﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicosApl.Models
{
    public class TrabajosDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        public int Cantidad { get; set; }

        public decimal Costo { get; set; }

        public decimal Precio { get; set; }

        public int ArticuloId { get; set; }
        [ForeignKey("ArticuloId")]
        public Articulos? Articulos { get; set; }

        public int TrabajoId { get; set; }
        [ForeignKey("TrabajoId")]
        public Trabajos? Trabajos { get; set; }

    }
}
