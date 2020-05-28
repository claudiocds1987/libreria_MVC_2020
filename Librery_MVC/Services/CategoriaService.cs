using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Librery_MVC.Models;
using MySql.Data.MySqlClient;

namespace Librery_MVC.Services
{
    public class CategoriaService
    {
        DataAccess datos = new DataAccess();

        public String getCategoryName(int id)
        {
            String idCat = Convert.ToString(id);
            String name = "";
            Categoria cat = new Categoria();
            MySqlConnection cn = datos.ConnectToDB();
            String query = "SELECT nombreCategoria FROM libreria.categorias WHERE categorias.idCategoria = " + idCat;
            MySqlCommand cmd = new MySqlCommand(query, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {               
                name = Convert.ToString(dr["nombreCategoria"]);
            }

            dr.Close();
            cn.Close();
            return name;
        }

        public Categoria getCategoria(int id)
        {
            String idCat = Convert.ToString(id);
            Categoria cat = new Categoria();
            MySqlConnection cn = datos.ConnectToDB();
            String query = "SELECT * FROM libreria.categorias WHERE categorias.idCategoria = " + idCat;
            MySqlCommand cmd = new MySqlCommand(query, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cat.IdCategoria = Convert.ToInt32(dr[0]);
                cat.Nombre = Convert.ToString(dr[1]);
            }

            dr.Close();
            cn.Close();
            return cat;
        }

        public List<Categoria> getAllCategories()
        {
            List<Categoria> catList = new List<Categoria>();
            MySqlConnection cn = datos.ConnectToDB();
            String consulta = "SELECT * FROM libreria.categorias";
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                catList.Add(new Categoria(dr.GetInt32(0), dr.GetString(1)));     
            }

            dr.Close();
            cn.Close();
            return catList;
        }
    }
}