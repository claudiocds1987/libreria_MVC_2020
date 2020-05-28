using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Librery_MVC.Models;
using MySql.Data.MySqlClient;


namespace Librery_MVC.Services
{
    public class DetalleVentaService
    {

        DataAccess da = new DataAccess();
        MySqlConnection cn = new MySqlConnection();
        
        private void ArmarParametrosDetalleVenta(ref MySqlCommand Comando, DetalleVenta saleDetail)
        {
            MySqlParameter mySqlParametros = new MySqlParameter();

            mySqlParametros = Comando.Parameters.Add("_IdVenta", MySqlDbType.Int32);
            mySqlParametros.Value = saleDetail.IdVenta;

            mySqlParametros = Comando.Parameters.Add("_IdLibro", MySqlDbType.Int32);
            mySqlParametros.Value = saleDetail.IdLibro;

            mySqlParametros = Comando.Parameters.Add("_Cantidad", MySqlDbType.Int32);
            mySqlParametros.Value = saleDetail.Cantidad;

            mySqlParametros = Comando.Parameters.Add("_Precio", MySqlDbType.Decimal);
            mySqlParametros.Value = saleDetail.Precio;

        }

        public int InsertSaleDetail(DetalleVenta saleDetail)
        {
            MySqlCommand comando = new MySqlCommand();
            ArmarParametrosDetalleVenta(ref comando, saleDetail);
            return da.EjecutarProcedimientoAlmacenado(comando, "InsertSaleDetail");
        }

        public int getLastIdVenta()
        {
            cn = da.ConnectToDB();
            String consulta = "select IdVenta from ventas order by IdVenta Desc Limit 1";
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();
            int id = -1;

            while(dr.Read())
            {
                id = Convert.ToInt32(dr["IdVenta"]);
            }

            dr.Close();
            cn.Close();

            return id;
        }
    }
}