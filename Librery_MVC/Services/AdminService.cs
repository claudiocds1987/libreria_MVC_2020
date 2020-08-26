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
    public class AdminService
    {
        DataAccess da = new DataAccess();
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        private void ArmarParametrosUsuario(ref SqlCommand Comando, Admin admin)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@email", SqlDbType.VarChar, 45);
            SqlParametros.Value = admin.email;

            SqlParametros = Comando.Parameters.Add("@nombre", SqlDbType.VarChar, 45);
            SqlParametros.Value = admin.nombre;

            SqlParametros = Comando.Parameters.Add("@apellido", SqlDbType.VarChar, 45);
            SqlParametros.Value = admin.apellido;

            SqlParametros = Comando.Parameters.Add("@pass", SqlDbType.VarChar, 45);
            SqlParametros.Value = admin.pass;

            SqlParametros = Comando.Parameters.Add("@estado", SqlDbType.Int);
            SqlParametros.Value = admin.Estado;

        }

        public int InsertAdmin(Admin admin)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosUsuario(ref comando, admin);
            return da.EjecutarProcedimientoAlmacenado(comando, "InsertAdmin");
        }

        //Funcion para validar formato de email correcto
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool SearchEmailAdmin(String email)
        {
            String consulta = "select * from admin where admin.Email = '" + email + "'";
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                dr.Close();
                cn.Close();
                return true;
            }

            dr.Close();
            cn.Close();
            return false;

        }

        public bool SearchEmailAndPasswordAdmin(String email, String password)
        {
            String consulta = "select * from admin where admin.Email = '" + email + "'" + " and admin.Pass = '" + password + "'";
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                dr.Close();
                cn.Close();
                return true;
            }

            dr.Close();
            cn.Close();
            return false;
        }

        // ------------------ MYSQL ---------------------------
        //private void ArmarParametrosUsuario(ref MySqlCommand Comando, Admin admin)
        //{
        //    MySqlParameter mySqlParametros = new MySqlParameter();

        //    mySqlParametros = Comando.Parameters.Add("_email", MySqlDbType.VarChar, 45);
        //    mySqlParametros.Value = admin.email;

        //    mySqlParametros = Comando.Parameters.Add("_nombre", MySqlDbType.VarChar, 45);
        //    mySqlParametros.Value = admin.nombre;

        //    mySqlParametros = Comando.Parameters.Add("_apellido", MySqlDbType.VarChar, 45);
        //    mySqlParametros.Value = admin.apellido;

        //    mySqlParametros = Comando.Parameters.Add("_pass", MySqlDbType.VarChar, 45);
        //    mySqlParametros.Value = admin.pass;

        //    mySqlParametros = Comando.Parameters.Add("_estado", MySqlDbType.Int32);
        //    mySqlParametros.Value = admin.Estado;

        //}

        //public int InsertAdmin(Admin admin)
        //{
        //    MySqlCommand comando = new MySqlCommand();
        //    ArmarParametrosUsuario(ref comando, admin);
        //    return da.EjecutarProcedimientoAlmacenado(comando, "InsertAdmin");
        //}

        ////Funcion para validar formato de email correcto
        //public bool IsValidEmail(string email)
        //{
        //    try
        //    {
        //        var addr = new System.Net.Mail.MailAddress(email);
        //        return addr.Address == email;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool SearchEmailAdmin(String email)
        //{
        //    String consulta = "select * from admin where admin.Email = '" + email + "'";
        //    MySqlConnection cn = da.ConnectToDB();
        //    MySqlCommand cmd = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    if (dr.Read())
        //    {
        //        dr.Close();
        //        cn.Close();
        //        return true;
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return false;

        //}

        //public bool SearchEmailAndPasswordAdmin(String email, String password)
        //{
        //    String consulta = "select * from admin where admin.Email = '" + email + "'" + " and admin.Pass = '" + password + "'";
        //    MySqlConnection cn = da.ConnectToDB();
        //    MySqlCommand cmd = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    if (dr.Read())
        //    {
        //        dr.Close();
        //        cn.Close();
        //        return true;
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return false;
        //}

    }
}