using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Librery_MVC.Models;
using MySql.Data.MySqlClient;

namespace Librery_MVC.Services
{
    public class LightBookService
    {
        DataAccess da = new DataAccess();

        public LightBook getLightBookById(String idBook)
        {
            LightBook book= new LightBook();
            String consulta = "SELECT libros.IdLibro, libros.urlImagen, libros.nombre, libros.anioDeLanzamiento, libros.precio, libros.estado FROM libros WHERE libros.IdLibro = " + idBook;
            MySqlConnection cn = new MySqlConnection();
            cn = da.ConnectToDB();
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                book.IdLibro = dr.GetInt32("IdLibro");
                book.Nombre = dr.GetString("nombre");
                book.AnioDeLanzamiento = dr.GetInt32("anioDeLanzamiento");
                book.Precio = dr.GetDecimal("precio");
                book.UrlImagen = dr.GetString("urlImagen");
                book.Estado = dr.GetBoolean("estado");                                  
            }

            dr.Close();
            cn.Close();
            return book;

        }

        public List<LightBook> getFilteredPaginationList(List<LightBook> list, int booksxPage, int numberPage, int totalPages)
        {
            List<LightBook> listPaginada = new List<LightBook>();
            int totalBooks = list.Count<LightBook>();
          
            int[] pos = new Int32[totalPages];
            int cont = 0;
            int librosAmostrar = 0;
            int librosListados = 0;
            int desde = 0;
            int hasta = 0;

            //guardo en el vector las diferentes formas de iniciar el recorrido de la lista
            //segun la cantidad de booksxPage

            for (var i = 0; i < totalPages; i++)
            {
                if (i == 0)
                {

                    pos[0] = 0;
                    cont = booksxPage;
                }
                else
                {
                    //pos[i] += booksxPage;
                    pos[i] = cont;
                    cont += booksxPage;
                    librosListados += booksxPage;
                    librosAmostrar = totalBooks - librosListados;
                }
            }

            //determinando los indices para recorrer la lista
            if (numberPage == 1)
            {
                desde = pos[0];
                hasta = (desde + booksxPage) - 1;
            }

            else if (numberPage == totalPages)
            {
                desde = totalBooks - librosAmostrar;
                hasta = totalBooks - 1;
            }

            else
            {
                desde = pos[numberPage - 1];
                hasta = (desde + booksxPage) - 1;
            }

            //Recorro la lista con los indices armados
            for (int z = desde; z <= hasta; z++)
            {
                listPaginada.Add(list[z]);
            }

            return listPaginada;
        }

        public List<LightBook> getListPagination(List<LightBook> list, int booksxPage, int numberPage)
        {
            List<LightBook> listPaginada = new List<LightBook>();
            int totalBooks = list.Count<LightBook>();
            int pages = totalBooks % booksxPage; //obtengo el resto de la division

            if (pages != 0) // si de resto no da cero, es un numero decimal
            {
                //redondeo hacia arriba ej 1,7 => lo redondeo a 2
                pages = (totalBooks / booksxPage) + 1;
            }
            else
                pages = totalBooks / booksxPage;

          
            int[] pos = new Int32[pages];
            int cont = 0;
            int librosAmostrar = 0;
            int librosListados = 0;
            int desde = 0;
            int hasta = 0;

            //guardo en el vector las diferentes formas de iniciar el recorrido de la lista
            //segun la cantidad de booksxPage

            for (var i = 0; i < pages; i++)
            {
                if (i == 0)
                {

                    pos[0] = 0;
                    cont = booksxPage;
                }
                else
                {

                    pos[i] = cont;
                    cont += booksxPage;
                    librosListados += booksxPage;
                    librosAmostrar = totalBooks - librosListados;
                }
            }

            //determinando los indices para recorrer la lista
            if (numberPage == 1)
            {
                desde = pos[0];
                hasta = (desde + booksxPage) - 1;
            }

            else if (numberPage == pages)
            {
                desde = totalBooks - librosAmostrar;
                hasta = totalBooks - 1;
            }

            else
            {
                desde = pos[numberPage - 1];
                hasta = (desde + booksxPage) - 1;
            }

            //Recorro la lista con los indices armados
            for (int z = desde; z <= hasta; z++)
            {
                listPaginada.Add(list[z]);
            }

            return listPaginada;
        }

        public List<LightBook> getListLightBooks()
        {
            List<LightBook> list = new List<LightBook>();
            String consulta = "SELECT libros.IdLibro, libros.urlImagen, libros.nombre, libros.anioDeLanzamiento, libros.precio, libros.estado FROM libros";
            MySqlConnection cn = new MySqlConnection();
            cn = da.ConnectToDB();
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new LightBook(dr.GetInt32("IdLibro"), dr.GetString("nombre"),
                                       dr.GetInt32("anioDeLanzamiento"), dr.GetDecimal("precio"),
                                       dr.GetString("urlImagen"), dr.GetBoolean("estado")));
            }

            dr.Close();
            cn.Close();
            return list;

        }

        public List<LightBook> filterLightBook(String consulta)
        {
            List<LightBook> list = new List<LightBook>();
            MySqlConnection cn = new MySqlConnection();
            cn = da.ConnectToDB();
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new LightBook(dr.GetInt32("IdLibro"), dr.GetString("nombre"),
                                       dr.GetInt32("anioDeLanzamiento"), dr.GetDecimal("precio"),
                                       dr.GetString("urlImagen"), dr.GetBoolean("estado")));
            }

            dr.Close();
            cn.Close();
            return list;
        }

        public int getQuantityBook(String idBook)
        {
            String consulta = "SELECT libros.cantidad FROM libros WHERE libros.IdLibro = " + idBook;
            MySqlConnection cn = new MySqlConnection();
            cn = da.ConnectToDB();
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();
            int quantity = 0;

            if (dr.Read())
                quantity = dr.GetInt32("cantidad");

            return quantity;
        }

    }
}