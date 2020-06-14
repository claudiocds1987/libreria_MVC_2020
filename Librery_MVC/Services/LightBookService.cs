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
            int hasta = 0;
            int librosAmostrar = 0;
            int desde = 0;
            int co = 0;

            //guardo en el vector las diferentes formas de iniciar el recorrido de la lista
            for (int i = 0; i < pages; i++)
            {
                if (i == 0)
                {
                    pos[i] = 0;
                    cont = booksxPage;                    
                }
                else
                {
                    pos[i] = cont;                    
                    cont += booksxPage;
                    co++;                    
                    totalBooks = totalBooks - booksxPage;
                }
            }

            librosAmostrar = totalBooks;
            
            //determinando los indices para recorrer la lista
            if (numberPage == 1)
            {
                desde = pos[0];
                hasta = pos[0] + booksxPage;
            }

            else if (numberPage == pages)
            {
                desde = pos[co];
                hasta = pos[co] + librosAmostrar;
            }

            else
            {
                desde = pos[numberPage - 1];
                hasta = pos[numberPage - 1] + booksxPage;
            }

            //Recorro la lista con los indices armados
            for (int z = desde; z < hasta; z++)
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



    }
}