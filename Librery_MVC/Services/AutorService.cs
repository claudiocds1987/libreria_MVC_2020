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
    public class AutorService
    {
        DataAccess datos = new DataAccess();
        Autor autor = new Autor();
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        public String getNameAutor(int id)
        {
            cn = datos.ConnectToDB();
            String name = "";
            String idAutor = Convert.ToString(id);
            String query = "SELECT nombre FROM autores WHERE idAutor = " + id;
            //String query = "SELECT nombre FROM libreria.autores WHERE idAutor = " + id;
            cmd = new SqlCommand(query, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {             
                name = Convert.ToString(dr["nombre"]);
            }

            dr.Close();
            cn.Close();
            return name;
        }

        public Autor getAutor(int id)
        {
            cn = datos.ConnectToDB();
            String idAutor = Convert.ToString(id);
            String query = "SELECT * FROM autores WHERE idAutor = " + id;
            //String query = "SELECT * FROM libreria.autores WHERE idAutor = " + id;
            cmd = new SqlCommand(query, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                autor.IdAutor = Convert.ToInt32(dr["idAutor"]);
                autor.Nombre = Convert.ToString(dr["nombre"]);
            }

            dr.Close();
            cn.Close();
            return autor;
        }

        public List<Autor> ListAutores()
        {
            cn = datos.ConnectToDB();
            List<Autor> Lista = new List<Autor>();
            //String consulta = "SELECT * FROM libreria.autores";
            String consulta = "SELECT * FROM autores";
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {            
                Lista.Add(new Autor(Convert.ToInt32(dr["idAutor"]), 
                                   dr["Nombre"].ToString()
                ));
            }

            dr.Close();//cierro el DataReader
            cn.Close();
            return Lista;
        }

    }

}