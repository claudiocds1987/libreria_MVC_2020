using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Librery_MVC.Models;
using MySql.Data.MySqlClient;

namespace Librery_MVC.Services
{
    public class AutorService
    {
        DataAccess datos = new DataAccess();
        Autor autor = new Autor();

        public String getNameAutor(int id)
        {
            MySqlConnection cn = datos.ConnectToDB();
            String name = "";
            String idAutor = Convert.ToString(id);
            String query = "SELECT nombre FROM libreria.autores WHERE idAutor = " + id;
            MySqlCommand cmd = new MySqlCommand(query, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

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
            MySqlConnection cn = datos.ConnectToDB();
            String idAutor = Convert.ToString(id);
            String query = "SELECT * FROM libreria.autores WHERE idAutor = " + id;
            MySqlCommand cmd = new MySqlCommand(query, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

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
            MySqlConnection cn = datos.ConnectToDB();
            List<Autor> Lista = new List<Autor>();
            String consulta = "SELECT * FROM libreria.autores";
            MySqlCommand command = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Lista.Add(new Autor(dr.GetInt32("idAutor"), dr.GetString("Nombre")));

            }

            dr.Close();//cierro el DataReader
            cn.Close();
            return Lista;
        }

    }

}