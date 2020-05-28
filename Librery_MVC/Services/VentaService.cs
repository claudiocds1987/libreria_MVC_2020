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
        MySqlConnection cn;

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
       
    }
}