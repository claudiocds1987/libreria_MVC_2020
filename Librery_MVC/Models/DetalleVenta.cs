using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librery_MVC.Models
{
    public class DetalleVenta
    {

        public int IdVenta { get; set; }
        public int IdLibro { get; set; }
        public int Cantidad { get; set; }
        public Decimal Precio { get; set; }

        public DetalleVenta()
        {
            //empty Constructor
        }

        public DetalleVenta(int idVenta, int idLibro, int cantidad, decimal precio)
        {
            IdVenta = idVenta;
            IdLibro = idLibro;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}