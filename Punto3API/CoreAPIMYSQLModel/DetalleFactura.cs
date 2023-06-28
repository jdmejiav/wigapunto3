using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPIMYSQLModel
{
    [Table("detalle_factura")]
    public class DetalleFactura
    {
        [Key]
        [Column("num_detalle")]
        public int NumDetalle { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        public Factura NumeroFactura { get; set; }

        public Producto IdProducto { get; set; }

        public DetalleFactura() { }

        public DetalleFactura(int numDetalle, Factura numeroFacturaId, Producto idProductoId, int cantidad)
        {
            NumDetalle = numDetalle;
            NumeroFactura = numeroFacturaId;
            IdProducto = idProductoId;
            Cantidad = cantidad;
        }
    }
}
