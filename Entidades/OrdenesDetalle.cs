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
        public int IdProducto { get; set; }
        public double Total { get; set; }
        public string Descripcion { get; set; }
        public OrdenesDetalle(int ordenId, int idProducto, int cantidad, double costo, double total, string descripcion)
        {
            Id = 0;
            OrdenId = ordenId;
            IdProducto = idProducto;
            Cantidad = cantidad;
            Costo = costo;
            Total = total;
            Descripcion = descripcion;
        }

    }
}
