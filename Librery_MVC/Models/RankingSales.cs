using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librery_MVC.Models
{
    public class RankingSales
    {

        public DateTime Date { get; set; }
        public int idSale { get; set; }
        public String UserName { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public decimal TotalPrice { get; set; }

        public RankingSales(DateTime date, int idSale, string userName, string name, string surname, decimal totalPrice)
        {
            Date = date;
            this.idSale = idSale;
            UserName = userName;
            Name = name;
            Surname = surname;
            TotalPrice = totalPrice;
        }

        public RankingSales()
        {
            //empty Constructor
        }
             
    }
}