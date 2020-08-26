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
    public class UsserService
    {
        DataAccess da = new DataAccess();
        //MySqlCommand cmd;
        //MySqlDataReader dr;
        //MySqlConnection cn;

        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection cn = new SqlConnection();

        public List<Usser> filtrarUsuario(String consulta)
        {
            List<Usser> list = new List<Usser>();       
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Usser(
                   dr["Nombre"].ToString(),
                   dr["apellido"].ToString(),
                   Convert.ToDateTime(dr["fechaNacimiento"]),
                   dr["Email"].ToString(),
                   dr["NombreUsuario"].ToString(),
                   dr["pass"].ToString(),
                   dr["Domicilio"].ToString(),
                   Convert.ToInt32(dr["adminType"]),
                   Convert.ToInt32(dr["estado"])                 
                ));
            }

            dr.Close();
            cn.Close();
            return list;
        }

        //public List<Usser> filtrarUsuario(String consulta)
        //{
        //    List<Usser> list = new List<Usser>();
        //    MySqlConnection cn = new MySqlConnection();
        //    cn = da.ConnectToDB();
        //    //cmd = new MySqlCommand(consulta, cn);
        //    cmd = new SqlCommand(consulta, cn);
        //    dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        list.Add(new Usser(
        //            dr.GetString("Nombre"),
        //            dr.GetString("apellido"),
        //            dr.GetDateTime("fechaNacimiento"),
        //            dr.GetString("Email"),
        //            dr.GetString("NombreUsuario"),
        //            dr.GetString("pass"),
        //            dr.GetString("Domicilio"),
        //            dr.GetInt32("adminType"),
        //            dr.GetInt32("estado")
        //            ));
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return list;
        //}

        public List<Usser> GetUsserClientList()
        {
            List<Usser> list = new List<Usser>();
            cn = da.ConnectToDB();
            String consulta = "select * from libreria.usuarios";
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Usser(
                   dr["Nombre"].ToString(),
                   dr["apellido"].ToString(),
                   Convert.ToDateTime(dr["fechaNacimiento"]),
                   dr["Email"].ToString(),
                   dr["NombreUsuario"].ToString(),
                   dr["pass"].ToString(),
                   dr["Domicilio"].ToString(),
                   Convert.ToInt32(dr["adminType"]),
                   Convert.ToInt32(dr["estado"])
                ));
            }

            dr.Close();
            cn.Close();
            return list;
        }
        //public List<Usser> GetUsserClientList()
        //{
        //    List<Usser> list = new List<Usser>();
        //    cn = da.ConnectToDB();
        //    String consulta = "select * from libreria.usuarios";
        //    cmd = new MySqlCommand(consulta, cn);
        //    dr = cmd.ExecuteReader();

        //    while(dr.Read())
        //    {
        //        list.Add(new Usser(
        //            dr.GetString("Nombre"), 
        //            dr.GetString("apellido"),
        //            dr.GetDateTime("fechaNacimiento"), 
        //            dr.GetString("Email"),
        //            dr.GetString("NombreUsuario"),
        //            dr.GetString("pass"),
        //            dr.GetString("Domicilio"),
        //            dr.GetInt32("adminType"),
        //            dr.GetInt32("estado")
        //            ));
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return list;
        //}

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

        // mySql
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

        public List<Usser> GetUsserByEmail(String email)
        {
            List<Usser> list = new List<Usser>();
            String consulta = "select * from usuarios where Email = " + email;
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Usser(
                   dr["Nombre"].ToString(),
                   dr["apellido"].ToString(),
                   Convert.ToDateTime(dr["fechaNacimiento"]),
                   dr["Email"].ToString(),
                   dr["NombreUsuario"].ToString(),
                   dr["pass"].ToString(),
                   dr["Domicilio"].ToString(),
                   Convert.ToInt32(dr["adminType"]),
                   Convert.ToInt32(dr["estado"])
                ));
            }

            dr.Close();
            cn.Close();

            return list;
        }




        // mySql
        //public List<Usser> GetUsserByEmail(String email)
        //{
        //    List<Usser> list = new List<Usser>();
        //    String consulta = "select * from usuarios where Email = " + email;
        //    cn = da.ConnectToDB();
        //    cmd = new MySqlCommand(consulta, cn);
        //    dr = cmd.ExecuteReader();

        //    while(dr.Read())
        //    {
        //        list.Add(new Usser(
        //             dr.GetString("Nombre"),
        //             dr.GetString("apellido"),
        //             dr.GetDateTime("fechaNacimiento"),
        //             dr.GetString("Email"),
        //             dr.GetString("NombreUsuario"),
        //             dr.GetString("pass"),
        //             dr.GetString("Domicilio"),
        //             dr.GetInt32("adminType"),
        //             dr.GetInt32("estado")
        //             ));
        //    }

        //    dr.Close();
        //    cn.Close();

        //    return list;
        //}

        public bool SearchUsserName(String userName)
        {
            String consulta = "select * from usuarios";
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["NombreUsuario"].Equals(userName))
                {
                    dr.Close();
                    cn.Close();
                    return true;
                }

            }

            dr.Close();
            cn.Close();
            return false;
        }

        // mySql
        //public bool SearchUsserName(String userName)
        //{
        //    String consulta = "select * from usuarios";
        //    cn = da.ConnectToDB();
        //    cmd = new MySqlCommand(consulta, cn);
        //    dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        if (dr["NombreUsuario"].Equals(userName))
        //        {
        //            dr.Close();
        //            cn.Close();
        //            return true;
        //        }

        //    }

        //    dr.Close();
        //    cn.Close();
        //    return false;

        //}

        public bool SearchUserPassword(String user, String password)
        {
            String consulta = "select * from usuarios where NombreUsuario ='" + user + "'";
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["pass"].Equals(password))
                    return true;
            }

            dr.Close();
            cn.Close();
            return false;

        }

        // mySql
        //public bool SearchUserPassword(String user, String password)
        //{
        //    String consulta = "select * from usuarios where NombreUsuario ='"+user+"'";
        //    cn = da.ConnectToDB();
        //    cmd = new MySqlCommand(consulta, cn);
        //    dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        if (dr["pass"].Equals(password))
        //            return true;
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return false;

        //}

        public bool SearchEmailUsser(String email)
        {
            String consulta = "select * from usuarios";
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["Email"].Equals(email))
                    return true;
            }

            dr.Close();
            cn.Close();
            return false;

        }

        // mySql
        //public bool SearchEmailUsser(String email)
        //{
        //    String consulta = "select * from usuarios";
        //    cn = da.ConnectToDB();
        //    cmd = new MySqlCommand(consulta, cn);
        //    dr = cmd.ExecuteReader();

        //    while(dr.Read())
        //    {
        //        if (dr["Email"].Equals(email))
        //            return true;
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return false;

        //}

        public bool SearchUserNameAndPassword(String userName, String password)
        {
            String consulta = "select * from usuarios";
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["NombreUsuario"].Equals(userName) && dr["pass"].Equals(password))
                    return true;
            }

            dr.Close();
            cn.Close();
            return false;
        }


        //public bool SearchUserNameAndPassword(String userName, String password)
        //{
        //    String consulta = "select * from usuarios";
        //    cn = da.ConnectToDB();
        //    cmd = new MySqlCommand(consulta, cn);
        //    dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        if (dr["NombreUsuario"].Equals(userName) && dr["pass"].Equals(password))
        //            return true;
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return false;
        //}

        public bool SearchEmailPasswordUsser(String email, String password)
        {
            String consulta = "select * from usuarios";
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["Email"].Equals(email) && dr["pass"].Equals(password))
                    return true;
            }

            dr.Close();
            cn.Close();
            return false;
        }

        //public bool SearchEmailPasswordUsser(String email, String password)
        //{
        //    String consulta = "select * from usuarios";
        //    cn = da.ConnectToDB();
        //    cmd = new MySqlCommand(consulta, cn);
        //    dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        if (dr["Email"].Equals(email) && dr["pass"].Equals(password))
        //            return true;
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return false;
        //}

        // mySql
        //private void ArmarParametrosUsuario(ref MySqlCommand Comando, Usser user)
        //{
        //    MySqlParameter mySqlParametros = new MySqlParameter();

        //    mySqlParametros = Comando.Parameters.Add("_nombre", MySqlDbType.VarChar, 45);
        //    mySqlParametros.Value = user.Name;

        //    mySqlParametros = Comando.Parameters.Add("_apellido", MySqlDbType.VarChar, 45);
        //    mySqlParametros.Value = user.Surname;

        //    mySqlParametros = Comando.Parameters.Add("_fechaNacimiento", MySqlDbType.DateTime);
        //    mySqlParametros.Value = user.dateTime;

        //    mySqlParametros = Comando.Parameters.Add("_email", MySqlDbType.VarChar, 45);
        //    mySqlParametros.Value = user.Email;

        //    mySqlParametros = Comando.Parameters.Add("_nombreUsuario", MySqlDbType.VarChar, 45);
        //    mySqlParametros.Value = user.UsserName;

        //    mySqlParametros = Comando.Parameters.Add("_pass", MySqlDbType.VarChar, 45);
        //    mySqlParametros.Value = user.Pass;

        //    mySqlParametros = Comando.Parameters.Add("_domicilio", MySqlDbType.VarChar, 45);
        //    mySqlParametros.Value = user.Address;

        //    mySqlParametros = Comando.Parameters.Add("_adminType", MySqlDbType.Int32);
        //    mySqlParametros.Value = user.AdminType;

        //    mySqlParametros = Comando.Parameters.Add("_estado", MySqlDbType.Int32);
        //    mySqlParametros.Value = user.Estado;

        //}

        private void ArmarParametrosUsuario(ref SqlCommand Comando, Usser user)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("_nombre", SqlDbType.VarChar, 45);
            SqlParametros.Value = user.Name;

            SqlParametros = Comando.Parameters.Add("_apellido", SqlDbType.VarChar, 45);
            SqlParametros.Value = user.Surname;

            SqlParametros = Comando.Parameters.Add("_fechaNacimiento", SqlDbType.DateTime);
            SqlParametros.Value = user.dateTime;

            SqlParametros = Comando.Parameters.Add("_email", SqlDbType.VarChar, 45);
            SqlParametros.Value = user.Email;

            SqlParametros = Comando.Parameters.Add("_nombreUsuario", SqlDbType.VarChar, 45);
            SqlParametros.Value = user.UsserName;

            SqlParametros = Comando.Parameters.Add("_pass", SqlDbType.VarChar, 45);
            SqlParametros.Value = user.Pass;

            SqlParametros = Comando.Parameters.Add("_domicilio", SqlDbType.VarChar, 45);
            SqlParametros.Value = user.Address;

            SqlParametros = Comando.Parameters.Add("_adminType", SqlDbType.Int);
            SqlParametros.Value = user.AdminType;

            SqlParametros = Comando.Parameters.Add("_estado", SqlDbType.Int);
            SqlParametros.Value = user.Estado;

        }

        //// mySql
        //public int InsertUser(Usser user)
        //{
        //    MySqlCommand comando = new MySqlCommand();
        //    ArmarParametrosUsuario(ref comando, user);
        //    return da.EjecutarProcedimientoAlmacenado(comando, "InsertUser");
        //}

        
        public int InsertUser(Usser user)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosUsuario(ref comando, user);
            return da.EjecutarProcedimientoAlmacenado(comando, "InsertUser");
        }

    }
}