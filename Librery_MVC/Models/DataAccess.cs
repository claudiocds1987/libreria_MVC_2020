using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;


namespace Librery_MVC.Models
{
    public class DataAccess
    {
        // conection string mySql local
        //String rutaDB = "datasource=localhost;port=3306;database=libreria;username=root;password=root";
        
        // conection string sqlServer local
        //String rutaDB = "Data Source=localhost\\SQLEXPRESSCLAU;Initial Catalog=libreria;Integrated Security=True";

        // conection string SOMEE
        String rutaDB = "workstation id=libreriaMVC.mssql.somee.com;packet size=4096;user id=cla8787_SQLLogin_1;pwd=ltzgfuzf41;data source=libreriaMVC.mssql.somee.com;persist security info=False;initial catalog=libreriaMVC";
        
        public SqlConnection ConnectToDB()
        {
            SqlConnection cn = new SqlConnection(rutaDB);

            try
            {
                cn.Open();
                return cn;
            }
            catch (SqlException e)
            {
                //return null;
                throw new Exception(e.Message);
            }

            //finally
            //{
            //    //
            //}
        }

        //public int EjecutarProcedimientoAlmacenado(MySqlCommand Comando, String NombreSP)
        //{
        //    int FilasCambiadas;
        //    MySqlConnection Conexion = ConnectToDB();
        //    MySqlCommand cmd = new MySqlCommand();
        //    cmd = Comando;
        //    cmd.Connection = Conexion;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = NombreSP;
        //    FilasCambiadas = cmd.ExecuteNonQuery();
        //    Conexion.Close();
        //    return FilasCambiadas;
        //}

        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            //MySqlConnection Conexion = ConnectToDB();
            //MySqlCommand cmd = new MySqlCommand();
            SqlConnection Conexion = ConnectToDB();
            SqlCommand cmd = new SqlCommand();
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