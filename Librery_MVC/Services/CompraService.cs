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
    public class CompraService
    {

        DataAccess da = new DataAccess();
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection cn = new SqlConnection();


        public List<Compra> filterPursache(String month1, String month2, String year, String userName)
        {
            List<Compra> list = new List<Compra>();
            cn = da.ConnectToDB();

            String a = "select ventas.Fecha, detalleventas.IdLibro, detalleventas.Cantidad, detalleventas.Precio from Ventas";
            String b = " inner join usuarios on ventas.NombreUsuario = usuarios.NombreUsuario";
            String c = " inner join detalleventas on detalleventas.IdVenta = ventas.IdVenta";
            String d = " where usuarios.NombreUsuario = " + "'" + userName + "'";
            String e = " and month(Fecha) >= " + month1;
            String f = " and month(Fecha) <= " + month2;
            String g = " and year(Fecha) = " + year;
            String h = " order by date(ventas.Fecha) desc";
            String consulta = a + b + c + d + e + f + g + h;

            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while(dr.Read())
            {              
                list.Add(new Compra(
                  Convert.ToDateTime(dr["Fecha"]),
                  Convert.ToInt32(dr["IdLibro"]),
                  Convert.ToDecimal(dr["Precio"]),
                  Convert.ToInt32(dr["Cantidad"])

              ));
            }

            dr.Close();
            cn.Close();
            return list;
        }
       
        public List<Compra> ShoppingListbyUser(String userName)
        {
            List<Compra> lista = new List<Compra>();                
            cn = da.ConnectToDB();            
            String a = "select ventas.Fecha, detalleventas.IdLibro, detalleventas.Cantidad, detalleventas.Precio from Ventas";
            String b = " inner join usuarios on ventas.NombreUsuario = usuarios.NombreUsuario";
            String c = " inner join detalleventas on detalleventas.IdVenta = ventas.IdVenta";
            String d = " where usuarios.NombreUsuario = " + "'" + userName + "'";
            String e = " order by date(ventas.Fecha) desc";
            String consulta = a + b + c + d + e;
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Compra(
                 Convert.ToDateTime(dr["Fecha"]),
                 Convert.ToInt32(dr["IdLibro"]),
                 Convert.ToDecimal(dr["Precio"]),
                 Convert.ToInt32(dr["Cantidad"])
                 ));
            }

            dr.Close();
            cn.Close();
            return lista;
        }
    }   
}