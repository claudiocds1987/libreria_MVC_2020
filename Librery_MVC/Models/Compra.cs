using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librery_MVC.Models
{
    public class Compra
    {
        public DateTime date { get; set; }
        public int idBook { get; set; }
        public Decimal price { get; set; }
        public int quantity { get; set; }

        public Compra()
        {
            //empty constructor
        }

        public Compra(DateTime date, int idBook, decimal price, int quantity)
        {
            this.date = date;
            this.idBook = idBook;
            this.price = price;
            this.quantity = quantity;
        }
    }
}    