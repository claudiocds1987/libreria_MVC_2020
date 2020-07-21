using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Librery_MVC.Models;
using MySql.Data.MySqlClient;

namespace Librery_MVC.Services
{
    public class RankingSalesService
    {

        DataAccess da = new DataAccess();

        public List<RankingSales> getSalesRanking()
        {
            MySqlConnection cn = da.ConnectToDB();
            String a = "select ventas.Fecha, ventas.IdVenta, usuarios.NombreUsuario, usuarios.Nombre, usuarios.apellido, ventas.PrecioTotal";
            String b = " from ventas inner join usuarios";
            String c = " where usuarios.NombreUsuario = ventas.NombreUsuario";
            String d = " group by ventas.NombreUsuario";
            String e = " order by ventas.PrecioTotal desc";
            String consulta = a + b + c + d + e;

            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();
            List<RankingSales> list = new List<RankingSales>();

            while (dr.Read())
            {
                list.Add(new RankingSales(
                                          dr.GetDateTime("Fecha"),
                                          dr.GetInt32("IdVenta"),
                                          dr.GetString("nombreUsuario"),
                                          dr.GetString("nombre"),
                                          dr.GetString("apellido"),
                                          dr.GetDecimal("PrecioTotal")
                ));
            }

            cn.Close();
            dr.Close();

            return list;

        }

    }
}