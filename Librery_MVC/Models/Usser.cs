using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Librery_MVC.Models
{
    public class Usser
    {
        [Required(ErrorMessage = "Ingrese un nombre.")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Ingrese un apellido")]
        public String Surname { get; set; }
        [Required(ErrorMessage = "Ingrese una fecha.")]
        public DateTime dateTime { get; set; }
        [Required(ErrorMessage = "Ingrese un email valido.")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre de usuario.")]
        public String UsserName { get; set; }
        [Required(ErrorMessage = "Ingrese una contraseña.")]
        public String Pass { get; set; }
        [Required(ErrorMessage = "Ingrese una direccion.")]
        public String Address { get; set; }
        public int AdminType { get; set; } //Tipo de admin: "1" es administrador. "2" Usuario.
        public int Estado { get; set; }

        public Usser()
        {
            //Constructor empty
        }

        //Constructor 
        public Usser(String _name, String _surname, DateTime _dateTime,
            String _email, String _usserName, String _password, String _address, 
            int _admin, int _estado)
        {
            Name = _name;
            Surname = _surname;
            dateTime = _dateTime;
            Email = _email;
            UsserName = _usserName;
            Pass = _password;
            Address = _address;
            AdminType = _admin;
            Estado = _estado;
        }

    }
}