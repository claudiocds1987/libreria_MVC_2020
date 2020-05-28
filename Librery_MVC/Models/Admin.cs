using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librery_MVC.Models
{
    public class Admin
    {
        public String email { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String pass { get; set; }
        public int Estado { get; set; }

        public Admin()
        {
            //empty constructor
        }

        public Admin(string email, string nombre, string apellido, string pass, int estado)
        {
            this.email = email;
            this.nombre = nombre;
            this.apellido = apellido;
            this.pass = pass;
            Estado = estado;
        }
    }
}