using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librery_MVC.Models
{
    public class LightBook
    {
        public int IdLibro { get; set; }
        public String Nombre { get; set; }
        public int AnioDeLanzamiento { get; set; }
        public Decimal Precio { get; set; }
        public String UrlImagen { get; set; }
        public bool Estado { get; set; }

        public LightBook()
        {
            //Constructor vacio
        }

        public LightBook(int idLibro, string nombre, int anioDeLanzamiento, decimal precio, string urlImagen, bool estado)
        {
            IdLibro = idLibro;
            Nombre = nombre;
            AnioDeLanzamiento = anioDeLanzamiento;
            Precio = precio;
            UrlImagen = urlImagen;
            Estado = estado;
        }
    }
}