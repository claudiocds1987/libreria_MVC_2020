using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Librery_MVC.Models;
using MySql.Data.MySqlClient;

namespace Librery_MVC.Services
{
    public class CompraService
    {

        DataAccess da = new DataAccess();

        public List<Compra> filterPursache(String month1, String month2, String year, String userName)
        {
            List<Compra> list = new List<Compra>();
            MySqlConnection cn = da.ConnectToDB();

            String a = "select ventas.Fecha, detalleventas.IdLibro, detalleventas.Cantidad, detalleventas.Precio from Ventas";
            String b = " inner join usuarios on ventas.NombreUsuario = usuarios.NombreUsuario";
            String c = " inner join detalleventas on detalleventas.IdVenta = ventas.IdVenta";
            String d = " where usuarios.NombreUsuario = " + "'" + userName + "'";
            String e = " and month(Fecha) >= " + month1;
            String f = " and month(Fecha) <= " + month2;
            String g = " and year(Fecha) = " + year;
            String h = " order by date(ventas.Fecha) desc";
            String consulta = a + b + c + d + e + f + g + h;

            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                list.Add(new Compra(
                    dr.GetDateTime("Fecha"),
                    dr.GetInt32("IdLibro"),
                    dr.GetDecimal("Precio"),
                    dr.GetInt32("Cantidad")

                ));
            }

            dr.Close();
            cn.Close();
            return list;
        }
       
        public List<Compra> ShoppingListbyUser(String userName)
        {
            List<Compra> lista = new List<Compra>();
            //LibroService ls = new LibroService();            
            MySqlConnection cn = da.ConnectToDB();
             
            String a = "select ventas.Fecha, detalleventas.IdLibro, detalleventas.Cantidad, detalleventas.Precio from Ventas";
            String b = " inner join usuarios on ventas.NombreUsuario = usuarios.NombreUsuario";
            String c = " inner join detalleventas on detalleventas.IdVenta = ventas.IdVenta";
            String d = " where usuarios.NombreUsuario = " + "'" + userName + "'";
            String e = " order by date(ventas.Fecha) desc";
            String consulta = a + b + c + d + e;
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lista.Add(new Compra(
                    dr.GetDateTime("Fecha"),
                    dr.GetInt32("IdLibro"),                    
                    dr.GetDecimal("Precio"),
                    dr.GetInt32("Cantidad")

                ));
            }

            dr.Close();
            cn.Close();
            return lista;
        }
    }   
}