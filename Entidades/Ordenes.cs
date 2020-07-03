using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrdenSuplidor.Entidades
{
    public class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int SuplidorId { get; set; }
        public double Monto { get; set; }

        [ForeignKey("OrdenId")]
        public virtual List<OrdenesDetalle> OrdenesDetalles { get; set; } = new List<OrdenesDetalle>();
    }
}
