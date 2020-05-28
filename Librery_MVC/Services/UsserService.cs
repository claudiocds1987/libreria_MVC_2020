using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Librery_MVC.Models;
using MySql.Data.MySqlClient;

namespace Librery_MVC.Services
{
    public class UsserService
    {
        DataAccess da = new DataAccess();

        //Listar usuarios tipo admin= 2 (usuarios clientes)
        public List<Usser> GetUsserClientList()
        {
            List<Usser> list = new List<Usser>();
            MySqlConnection cn = da.ConnectToDB();
            String consulta = "select * from libreria.usuarios where usuarios.adminType = 2";
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                list.Add(new Usser(
                    dr.GetString("Nombre"), 
                    dr.GetString("apellido"),
                    dr.GetDateTime("fechaNacimiento"), 
                    dr.GetString("Email"),
                    dr.GetString("NombreUsuario"),
                    dr.GetString("pass"),
                    dr.GetString("Domicilio"),
                    dr.GetInt32("adminType"),
                    dr.GetInt32("estado")
                    ));
            }

            dr.Close();
            cn.Close();
            return list;
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

        public List<Usser> GetUsserByEmail(String email)
        {
            List<Usser> list = new List<Usser>();
            String consulta = "select * from usuarios where Email = " + email;
            MySqlConnection cn = da.ConnectToDB();
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                list.Add(new Usser(
                     dr.GetString("Nombre"),
                     dr.GetString("apellido"),
                     dr.GetDateTime("fechaNacimiento"),
                     dr.GetString("Email"),
                     dr.GetString("NombreUsuario"),
                     dr.GetString("pass"),
                     dr.GetString("Domicilio"),
                     dr.GetInt32("adminType"),
                     dr.GetInt32("estado")
                     ));
            }

            dr.Close();
            cn.Close();

            return list;
        }

        public bool SearchUsserName(String userName)
        {
            String consulta = "select * from usuarios";
            MySqlConnection cn = da.ConnectToDB();
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

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

        public bool SearchUserPassword(String user, String password)
        {
            String consulta = "select * from usuarios where NombreUsuario ='"+user+"'";
            MySqlConnection cn = da.ConnectToDB();
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["pass"].Equals(password))
                    return true;
            }

            dr.Close();
            cn.Close();
            return false;

        }

        public bool SearchEmailUsser(String email)
        {
            String consulta = "select * from usuarios";
            MySqlConnection cn = da.ConnectToDB();
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                if (dr["Email"].Equals(email))
                    return true;
            }

            dr.Close();
            cn.Close();
            return false;
     
        }


        public bool SearchUserNameAndPassword(String userName, String password)
        {
            String consulta = "select * from usuarios";
            MySqlConnection cn = da.ConnectToDB();
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["NombreUsuario"].Equals(userName) && dr["pass"].Equals(password))
                    return true;
            }

            dr.Close();
            cn.Close();
            return false;
        }


        public bool SearchEmailPasswordUsser(String email, String password)
        {
            String consulta = "select * from usuarios";
            MySqlConnection cn = da.ConnectToDB();
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["Email"].Equals(email) && dr["pass"].Equals(password))
                    return true;
            }

            dr.Close();
            cn.Close();
            return false;
        }

        private void ArmarParametrosUsuario(ref MySqlCommand Comando, Usser user)
        {
            MySqlParameter mySqlParametros = new MySqlParameter();

            mySqlParametros = Comando.Parameters.Add("_nombre", MySqlDbType.VarChar, 45);
            mySqlParametros.Value = user.Name;

            mySqlParametros = Comando.Parameters.Add("_apellido", MySqlDbType.VarChar, 45);
            mySqlParametros.Value = user.Surname;

            mySqlParametros = Comando.Parameters.Add("_fechaNacimiento", MySqlDbType.DateTime);
            mySqlParametros.Value = user.dateTime;

            mySqlParametros = Comando.Parameters.Add("_email", MySqlDbType.VarChar, 45);
            mySqlParametros.Value = user.Email;

            mySqlParametros = Comando.Parameters.Add("_nombreUsuario", MySqlDbType.VarChar, 45);
            mySqlParametros.Value = user.UsserName;

            mySqlParametros = Comando.Parameters.Add("_pass", MySqlDbType.VarChar, 45);
            mySqlParametros.Value = user.Pass;

            mySqlParametros = Comando.Parameters.Add("_domicilio", MySqlDbType.VarChar, 45);
            mySqlParametros.Value = user.Address;

            mySqlParametros = Comando.Parameters.Add("_adminType", MySqlDbType.Int32);
            mySqlParametros.Value = user.AdminType;

            mySqlParametros = Comando.Parameters.Add("_estado", MySqlDbType.Int32);
            mySqlParametros.Value = user.Estado;

        }

        public int InsertUser(Usser user)
        {
            MySqlCommand comando = new MySqlCommand();
            ArmarParametrosUsuario(ref comando, user);
            return da.EjecutarProcedimientoAlmacenado(comando, "InsertUser");
        }

    }
}