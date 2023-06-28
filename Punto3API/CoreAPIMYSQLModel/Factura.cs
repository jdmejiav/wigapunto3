using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPIMYSQLModel
{
    public class Factura
    {
        [Key]
        [Column("numero")]
        public int Numero { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }
        public Cliente IdCliente { get; set; }
        public Factura() { }

        public Factura(int numero, DateTime fecha, Cliente IdCliente)
        {
            Numero = numero;
            Fecha = fecha;
            IdCliente = IdCliente;
        }
    }
}
