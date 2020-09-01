using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using Librery_MVC.Models;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;


namespace Librery_MVC.Services
{
    public class VentaService
    {
        DataAccess da = new DataAccess();
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection cn = new SqlConnection();

        private void ArmarParametrosSale(ref SqlCommand Comando, Venta sale)
        {
            SqlParameter SqlParametros = new SqlParameter();

            //SqlParametros = Comando.Parameters.Add("@IdVenta", SqlDbType.Int);
            //SqlParametros.Value = sale.IdVenta;

            SqlParametros = Comando.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 45);
            SqlParametros.Value = sale.NombreUsuario;

            SqlParametros = Comando.Parameters.Add("@PrecioTotal", SqlDbType.Decimal);
            SqlParametros.Value = sale.PrecioTotal;

            SqlParametros = Comando.Parameters.Add("@Fecha", SqlDbType.DateTime);
            SqlParametros.Value = sale.Fecha;

        }

        public int InsertSale(Venta sale)
        {
            cmd = new SqlCommand();
            ArmarParametrosSale(ref cmd, sale);
            return da.EjecutarProcedimientoAlmacenado(cmd, "InsertSale");
        }


        public List<Venta> SalesByQueryGet(String consulta)
        {
            List<Venta> list = new List<Venta>();
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Venta(Convert.ToInt32(dr["IdVenta"]),
                                   Convert.ToString(dr["NombreUsuario"]),
                                   Convert.ToDecimal(dr["PrecioTotal"]),
                                   Convert.ToDateTime(dr["fecha"])
                                   ));
            }

            dr.Close();
            cn.Close();

            return list;
        }

        public List<Venta> getAllSalesFromClient(String userName)
        {
            List<Venta> list = new List<Venta>();
            String consulta = "SELECT * FROM ventas WHERE ventas.NombreUsuario = '" + userName + "'";
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Venta(Convert.ToInt32(dr["IdVenta"]),
                                   Convert.ToString(dr["NombreUsuario"]),
                                   Convert.ToDecimal(dr["PrecioTotal"]),
                                   Convert.ToDateTime(dr["fecha"])
                                   ));
            }

            dr.Close();
            cn.Close();

            return list;
        }

        public List<Venta> getAllSales()
        {
            List<Venta> list = new List<Venta>();
            String consulta = "SELECT * FROM ventas order by ventas.Fecha desc";
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Venta(Convert.ToInt32(dr["IdVenta"]),
                                    Convert.ToString(dr["NombreUsuario"]),
                                    Convert.ToDecimal(dr["PrecioTotal"]),
                                    Convert.ToDateTime(dr["fecha"])
                                    ));
            }

            dr.Close();
            cn.Close();

            return list;

        }

        public List<Venta> getSalesByDateAndUser(String userName, String month1, String month2, String year)
        {

            List<Venta> list = new List<Venta>();
            String a = "SELECT * from ventas";
            String b = " where month(Fecha) >= " + month1;
            String c = " and month(Fecha) <= " + month2;
            String d = " and year(Fecha) = " + year;
            String e = " and ventas.NombreUsuario = '" + userName + "'";
            String f = " order by ventas.Fecha desc";

            String consulta = a + b + c + d + e + f;

            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Venta(Convert.ToInt32(dr["IdVenta"]),
                                   Convert.ToString(dr["NombreUsuario"]),
                                   Convert.ToDecimal(dr["PrecioTotal"]),
                                   Convert.ToDateTime(dr["fecha"])
                                   ));
            }

            dr.Close();
            cn.Close();
            return list;
        }

        // --------------------- MYSQL --------------------------------

        //DataAccess da = new DataAccess();

        //private void ArmarParametrosSale(ref MySqlCommand Comando, Venta sale)
        //{
        //    MySqlParameter mySqlParametros = new MySqlParameter();

        //    mySqlParametros = Comando.Parameters.Add("_IdVenta", MySqlDbType.Int32);
        //    mySqlParametros.Value = sale.IdVenta;

        //    mySqlParametros = Comando.Parameters.Add("_NombreUsuario", MySqlDbType.VarChar, 45);
        //    mySqlParametros.Value = sale.NombreUsuario;

        //    mySqlParametros = Comando.Parameters.Add("_PrecioTotal", MySqlDbType.Decimal);
        //    mySqlParametros.Value = sale.PrecioTotal;

        //    mySqlParametros = Comando.Parameters.Add("_Fecha", MySqlDbType.DateTime);
        //    mySqlParametros.Value = sale.Fecha;

        //}

        //public int InsertSale(Venta sale)
        //{
        //    MySqlCommand comando = new MySqlCommand();
        //    ArmarParametrosSale(ref comando, sale);
        //    return da.EjecutarProcedimientoAlmacenado(comando, "InsertSale");
        //}


        //public List<Venta> SalesByQueryGet(String consulta)
        //{
        //    List<Venta> list = new List<Venta>();          
        //    MySqlConnection cn = da.ConnectToDB();
        //    MySqlCommand cmd = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        list.Add(new Venta(dr.GetInt32("IdVenta"),
        //                           dr.GetString("NombreUsuario"),
        //                           dr.GetDecimal("PrecioTotal"),
        //                           dr.GetDateTime("fecha")));
        //    }

        //    dr.Close();
        //    cn.Close();

        //    return list;
        //}

        //public List<Venta> getAllSalesFromClient(String userName)
        //{
        //    List<Venta> list = new List<Venta>();
        //    String consulta = "SELECT * FROM ventas WHERE ventas.NombreUsuario = '" + userName + "'";
        //    MySqlConnection cn = da.ConnectToDB();
        //    MySqlCommand cmd = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        list.Add(new Venta(dr.GetInt32("IdVenta"),
        //                           dr.GetString("NombreUsuario"),
        //                           dr.GetDecimal("PrecioTotal"), 
        //                           dr.GetDateTime("fecha")));                        
        //    }

        //    dr.Close();
        //    cn.Close();

        //    return list;
        //}

        //public List<Venta> getAllSales()
        //{
        //    List<Venta> list = new List<Venta>();
        //    String consulta = "SELECT * FROM ventas order by ventas.Fecha desc";
        //    MySqlConnection cn = da.ConnectToDB();
        //    MySqlCommand cmd = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        list.Add(new Venta(dr.GetInt32("IdVenta"),
        //                           dr.GetString("NombreUsuario"),
        //                           dr.GetDecimal("PrecioTotal"),
        //                           dr.GetDateTime("fecha")));
        //    }

        //    dr.Close();
        //    cn.Close();

        //    return list;

        //}

        //public List<Venta> getSalesByDateAndUser(String userName, String month1, String month2, String year)
        //{

        //    List<Venta> list = new List<Venta>();
        //    String a = "SELECT * from ventas";
        //    String b = " where month(Fecha) >= " + month1;
        //    String c = " and month(Fecha) <= " + month2;
        //    String d = " and year(Fecha) = " + year;
        //    String e = " and ventas.NombreUsuario = '" + userName + "'";
        //    String f = " order by ventas.Fecha desc";

        //    String consulta = a + b + c + d + e + f;

        //    MySqlConnection cn = da.ConnectToDB();
        //    MySqlCommand cmd = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        list.Add(new Venta(dr.GetInt32("IdVenta"),
        //                           dr.GetString("NombreUsuario"),
        //                           dr.GetDecimal("PrecioTotal"),
        //                           dr.GetDateTime("fecha")));
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return list;
        //}       
    }
}