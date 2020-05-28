using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librery_MVC.Models
{
    public class Editorial
    {
        public int IdEditorial { get; set; }
        public String Nombre { get; set; }

        public Editorial()
        {
            //Constructor vacio
        }

        public Editorial(int idEditorial, string nombre)
        {
            IdEditorial = idEditorial;
            Nombre = nombre;
        }

        //public Editorial(int id, String name)
        //{
        //    //Constructor
        //    IdEditorial = id;
        //    Nombre = name;
        //}
    }
}