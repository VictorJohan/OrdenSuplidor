using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrdenSuplidor.Entidades
{
    public class OrdenesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int Cantidad { get; set; }
        public double Costo { get; set; }

        public OrdenesDetalle(int id, int ordenId, int cantidad, double costo)
        {
            Id = id;
            OrdenId = ordenId;
            Cantidad = cantidad;
            Costo = costo;
        }

    }
}
