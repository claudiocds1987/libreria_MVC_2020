using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Librery_MVC.Models
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public String Nombre { get; set; }
        public int AnioDeLanzamiento { get; set; }
        public int IdAutor { get; set; }
        public int IdCategoria { get; set; }
        public int IdEditorial { get; set; }
        public String Descripcion { get; set; }
        public int Cantidad { get; set; }
        public Decimal Precio { get; set; }
        public String UrlImagen { get; set; }
        public bool Estado { get; set; }//si da error ponelo como int Mysql creo q toma False=0 y true=1

        public Libro()
        {
            //constructor vacio
        }

        public Libro(int idLibro, string nombre, int anioDeLanzamiento, int idAutor, int idCategoria, int idEditorial, string descripcion, int cantidad, decimal precio, string urlImagen, bool estado)
        {
            IdLibro = idLibro;
            Nombre = nombre;
            AnioDeLanzamiento = anioDeLanzamiento;
            IdAutor = idAutor;
            IdCategoria = idCategoria;
            IdEditorial = idEditorial;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Precio = precio;
            UrlImagen = urlImagen;
            Estado = estado;
        }

        //constructor para list light books
        public Libro(int idLibro, string urlImagen, string nombre, int anioDeLanzamiento, Decimal precio)
        {
            IdLibro = idLibro;
            UrlImagen = urlImagen;
            Nombre = nombre;
            AnioDeLanzamiento = anioDeLanzamiento;
            Precio = precio;
        }
    }
}