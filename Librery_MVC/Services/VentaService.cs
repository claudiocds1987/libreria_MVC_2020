using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using Librery_MVC.Models;
using MySql.Data.MySqlClient;

namespace Librery_MVC.Services
{
    public class VentaService
    {
        DataAccess da = new DataAccess();
        //MySqlConnection cn;

        private void ArmarParametrosSale(ref MySqlCommand Comando, Venta sale)
        {
            MySqlParameter mySqlParametros = new MySqlParameter();

            mySqlParametros = Comando.Parameters.Add("_IdVenta", MySqlDbType.Int32);
            mySqlParametros.Value = sale.IdVenta;

            mySqlParametros = Comando.Parameters.Add("_NombreUsuario", MySqlDbType.VarChar, 45);
            mySqlParametros.Value = sale.NombreUsuario;

            mySqlParametros = Comando.Parameters.Add("_PrecioTotal", MySqlDbType.Decimal);
            mySqlParametros.Value = sale.PrecioTotal;

            mySqlParametros = Comando.Parameters.Add("_Fecha", MySqlDbType.DateTime);
            mySqlParametros.Value = sale.Fecha;
            
        }

        public int InsertSale(Venta sale)
        {
            MySqlCommand comando = new MySqlCommand();
            ArmarParametrosSale(ref comando, sale);
            return da.EjecutarProcedimientoAlmacenado(comando, "InsertSale");
        }


        public List<Venta> FiltrarVenta(String consulta)
        {
            List<Venta> list = new List<Venta>();          
            MySqlConnection cn = da.ConnectToDB();
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Venta(dr.GetInt32("IdVenta"),
                                   dr.GetString("NombreUsuario"),
                                   dr.GetDecimal("PrecioTotal"),
                                   dr.GetDateTime("fecha")));
            }

            dr.Close();
            cn.Close();

            return list;
        }

        public List<Venta> getAllSalesFromClient(String userName)
        {
            List<Venta> list = new List<Venta>();
            String consulta = "SELECT * FROM ventas WHERE ventas.NombreUsuario = '" + userName + "'";
            MySqlConnection cn = da.ConnectToDB();
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Venta(dr.GetInt32("IdVenta"),
                                   dr.GetString("NombreUsuario"),
                                   dr.GetDecimal("PrecioTotal"), 
                                   dr.GetDateTime("fecha")));                        
            }

            dr.Close();
            cn.Close();

            return list;
        }
       
    }
}