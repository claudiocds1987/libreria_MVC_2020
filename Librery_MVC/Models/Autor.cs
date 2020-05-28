using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librery_MVC.Models
{
    public class Autor
    {
        public int IdAutor { get; set; }
        public String Nombre { get; set; }

        public Autor()
        {
            //Constructor vacio
        }

        public Autor(int idAutor, String nombre)
        {
            //2do constructor
            IdAutor = idAutor;
            Nombre = nombre;
            
        }
    }
}