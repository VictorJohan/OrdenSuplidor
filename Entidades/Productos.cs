using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrdenSuplidor.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductosId { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public int Inventario { get; set; }
    }
}
