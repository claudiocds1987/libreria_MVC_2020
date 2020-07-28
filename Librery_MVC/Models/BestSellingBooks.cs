using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librery_MVC.Models
{
    public class BestSellingBooks
    {      
        public int id { get; set; }
        public int total { get; set; }

        public BestSellingBooks(int id, int total)
        {
            this.id = id;
            this.total = total;
        }

        public BestSellingBooks()
        {
            //empty constructor
        }

    }
}