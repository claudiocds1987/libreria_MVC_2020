using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Librery_MVC.Models;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;

namespace Librery_MVC.Services
{
    public class EditorialService
    {
        DataAccess datos = new DataAccess();
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection cn = new SqlConnection();

        public Editorial GetEditorial(int id)
        {
            String idEditorial = Convert.ToString(id);
            cn = datos.ConnectToDB();
            Editorial editorial = new Editorial();
            //String consulta = "SELECT * FROM libreria.editoriales WHERE editoriales.IdEditorial = " + idEditorial;
            String consulta = "SELECT * FROM editoriales WHERE editoriales.IdEditorial = " + idEditorial;
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                editorial.IdEditorial = Convert.ToInt32(dr[0]);
                editorial.Nombre = Convert.ToString(dr[1]);
            }

            dr.Close();
            cn.Close();
            return editorial;
        }

        public List<Editorial> getAllEditorials()
        {
            List<Editorial> list = new List<Editorial>();
            String consulta = "SELECT * FROM editoriales";
            //String consulta = "SELECT * FROM Libreria.editoriales";
            cn = datos.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Editorial(dr.GetInt32(0), dr.GetString(1)));
            }

            dr.Close();
            cn.Close();
            return list;
        }


        // ------------------ MYSQL ---------------------------------

        //DataAccess datos = new DataAccess();

        //public Editorial GetEditorial(int id)
        //{
        //    String idEditorial = Convert.ToString(id);
        //    MySqlConnection cn = datos.ConnectToDB();
        //    Editorial editorial = new Editorial();
        //    String consulta = "SELECT * FROM libreria.editoriales WHERE editoriales.IdEditorial = " + idEditorial;
        //    MySqlCommand cmd = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        editorial.IdEditorial = Convert.ToInt32(dr[0]);
        //        editorial.Nombre = Convert.ToString(dr[1]);
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return editorial;
        //}

        //public List<Editorial> getAllEditorials()
        //{
        //    List<Editorial> list = new List<Editorial>();
        //    String consulta = "SELECT * FROM Libreria.editoriales";
        //    MySqlConnection cn = datos.ConnectToDB();
        //    MySqlCommand cmd = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    while(dr.Read())
        //    {
        //        list.Add(new Editorial(dr.GetInt32(0), dr.GetString(1)));
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return list;
        //}
    }
}