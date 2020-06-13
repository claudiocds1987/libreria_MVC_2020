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