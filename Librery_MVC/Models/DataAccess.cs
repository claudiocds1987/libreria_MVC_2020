using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace Librery_MVC.Models
{
    public class DataAccess
    {
        String rutaDB = "datasource=localhost;port=3306;database=libreria;username=root;password=root";

        //CONEXION A BASE DE DATOS MYSQL
        public MySqlConnection ConnectToDB()
        {
            MySqlConnection cn = new MySqlConnection(rutaDB);

            try
            {
                cn.Open();
                return cn;
            }
            catch (MySqlException e)
            {
                //return null;
                throw new Exception(e.Message);
            }

            //finally
            //{
            //    //
            //}
        }

        public int EjecutarProcedimientoAlmacenado(MySqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            MySqlConnection Conexion = ConnectToDB();
            MySqlCommand cmd = new MySqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }
    }
}