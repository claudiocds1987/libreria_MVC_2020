using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librery_MVC.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public String Nombre { get; set; }

        public Categoria()
        {
            //Constructor vacio
        }

        public Categoria(int id, String nombre)
        {
            //Constructor
            IdCategoria = id;
            Nombre = nombre;
        }
    }
}