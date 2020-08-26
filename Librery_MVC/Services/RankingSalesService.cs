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
    public class RankingSalesService
    {
        DataAccess da = new DataAccess();
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection cn = new SqlConnection();


        public List<RankingSales> getSalesRanking()
        {
            cn = da.ConnectToDB();
            String a = "select ventas.NombreUsuario, sum(ventas.PrecioTotal) as 'Monto'";
            String b = " from ventas";
            String c = " group by ventas.NombreUsuario";
            String d = " order by 2 desc";
            String consulta = a + b + c + d;

            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();
            List<RankingSales> list = new List<RankingSales>();

            while (dr.Read())
            {
                list.Add(new RankingSales(
                                          Convert.ToString(dr["NombreUsuario"]),
                                          Convert.ToDecimal(dr["Monto"])
                ));
            }

            cn.Close();
            dr.Close();

            return list;

        }

        // ---------------- MYSQL -----------------------------------------

        //DataAccess da = new DataAccess();

        //public List<RankingSales> getSalesRanking()
        //{
        //    MySqlConnection cn = da.ConnectToDB();
        //    String a = "select ventas.NombreUsuario, sum(ventas.PrecioTotal) as 'Monto'";
        //    String b = " from ventas";
        //    String c = " group by ventas.NombreUsuario";
        //    String d = " order by 2 desc";
        //    String consulta = a + b + c + d;

        //    MySqlCommand cmd = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cmd.ExecuteReader();
        //    List<RankingSales> list = new List<RankingSales>();

        //    while (dr.Read())
        //    {
        //        list.Add(new RankingSales(                                        
        //                                  dr.GetString("NombreUsuario"),                                    
        //                                  dr.GetDecimal("Monto")
        //        ));
        //    }

        //    cn.Close();
        //    dr.Close();

        //    return list;

        //}

    }
}