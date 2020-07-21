using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librery_MVC.Models
{
    public class RankingSales
    {            
        public String UserName { get; set; }      
        public decimal Monto { get; set; }

        public RankingSales()
        {
            //empty Constructor
        }

        public RankingSales(string userName, decimal monto)
        {
            UserName = userName;
            Monto = monto;
        }
    }
}