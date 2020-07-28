using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Librery_MVC.Models;
using MySql.Data.MySqlClient;

namespace Librery_MVC.Services
{
    public class BestSellingBooksService
    {
        DataAccess da = new DataAccess();
        MySqlConnection cn = new MySqlConnection();
       
        public List<BestSellingBooks> TopBooksGet()
        {
            List<BestSellingBooks> list = new List<BestSellingBooks>();
            String a = "SELECT detalleventas.IdLibro, (sum(detalleventas.Cantidad)) as 'Total'";
            String b = " FROM detalleventas group by detalleventas.IdLibro";
            String c = " order by 2 desc limit 20";
            String consulta = a + b + c;

            cn = da.ConnectToDB();
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new BestSellingBooks(dr.GetInt32("IdLibro"),
                                              dr.GetInt32("Total")));
            }

            dr.Close();
            cn.Close();

            return list;
        }

    }
}