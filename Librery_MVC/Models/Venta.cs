using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librery_MVC.Models
{
    public class Venta
    {

        public int IdVenta { get; set; }
        public String NombreUsuario { get; set; }
        public Decimal PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }

        public Venta()
        {
            //empty constructor
        }

        public Venta(int idVenta, string nombreUsuario, decimal precioTotal, DateTime fecha)
        {
            IdVenta = idVenta;
            NombreUsuario = nombreUsuario;
            PrecioTotal = precioTotal;
            Fecha = fecha;
        }
       
    }
}