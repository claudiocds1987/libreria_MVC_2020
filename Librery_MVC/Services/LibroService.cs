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
    public class LibroService
    {
        public LibroService()
        {
            //Constructor vacio
        }

        DataAccess da = new DataAccess();
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection cn = new SqlConnection();

        public List<Libro> getListLightBooks()
        {
            List<Libro> list = new List<Libro>();
            String consulta = "SELECT libros.IdLibro, libros.urlImagen, libros.nombre, libros.anioDeLanzamiento, libros.precio FROM libros";
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {               
                list.Add(new Libro(Convert.ToInt32(dr["IdLibro"]), 
                                   Convert.ToString(dr["urlImagen"]),
                                   Convert.ToString(dr["nombre"]), 
                                   Convert.ToInt32(dr["anioDeLanzamiento"]),
                                   Convert.ToDecimal(dr["precio"])
                                   ));
            }

            dr.Close();
            cn.Close();
            return list;

        }

        public List<Libro> filterLightBook(String consulta)
        {
            List<Libro> list = new List<Libro>();           
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Libro(Convert.ToInt32(dr["IdLibro"]),
                                    Convert.ToString(dr["urlImagen"]),
                                    Convert.ToString(dr["nombre"]),
                                    Convert.ToInt32(dr["anioDeLanzamiento"]),
                                    Convert.ToDecimal(dr["precio"])
                                    ));
            }

            dr.Close();
            cn.Close();
            return list;
        }



        public Decimal getBookPrice(int idBook)
        {
            String consulta = "SELECT precio from libros where IdLibro = " + idBook + " AND estado = 1";
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();
            Decimal price = 0;

            while (dr.Read())
            {
                price = Convert.ToDecimal(dr["precio"]);
            }

            dr.Close();
            cn.Close();
            return price;
        }

        public string getBookName(int id)
        {
            String name = "";
            String consulta = "SELECT nombre from libros where IdLibro = " + id + " AND estado = 1";
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                name = Convert.ToString(dr["nombre"]);
            }

            dr.Close();
            cn.Close();
            return name;
        }


        public List<Libro> LibrosByQueryGet(String consulta)
        {
            List<Libro> list = new List<Libro>();
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {             
                list.Add(new Libro(Convert.ToInt32(dr["IdLibro"]), 
                                   Convert.ToString(dr["nombre"]),
                                   Convert.ToInt32(dr["anioDeLanzamiento"]), 
                                   Convert.ToInt32(dr["idAutor"]),
                                   Convert.ToInt32(dr["idCategoria"]), 
                                   Convert.ToInt32(dr["idEditorial"]),
                                   Convert.ToString(dr["descripcion"]), 
                                   Convert.ToInt32(dr["cantidad"]),
                                   Convert.ToDecimal(dr["precio"]), 
                                   Convert.ToString(dr["urlImagen"]),
                                   Convert.ToBoolean(dr["estado"])
                                   ));
            }

            dr.Close();
            cn.Close();
            return list;
        }

        //inicio los parametros name="" y los int=0 por si recibe datos vacios en los parametros
        public List<Libro> FilterBooks(String name = "", int idAuthor = 0, int idCategory = 0)
        {
            List<Libro> list = new List<Libro>();      
            cn = da.ConnectToDB();
            String a = "where libros.nombre = " + "'" + name + "' ";
            String b = "and libros.idAutor = " + idAuthor;
            String c = " and libros.idCategoria = " + idCategory;
            String consulta = a + b + c;
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Libro(Convert.ToInt32(dr["IdLibro"]),
                                  Convert.ToString(dr["nombre"]),
                                  Convert.ToInt32(dr["anioDeLanzamiento"]),
                                  Convert.ToInt32(dr["idAutor"]),
                                  Convert.ToInt32(dr["idCategoria"]),
                                  Convert.ToInt32(dr["idEditorial"]),
                                  Convert.ToString(dr["descripcion"]),
                                  Convert.ToInt32(dr["cantidad"]),
                                  Convert.ToDecimal(dr["precio"]),
                                  Convert.ToString(dr["urlImagen"]),
                                  Convert.ToBoolean(dr["estado"])
                                  ));
            }

            dr.Close();
            cn.Close();
            return list;
        }


        public void ArmarParametrosBajaLibro(ref SqlCommand Comando, Libro book)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IdLibro", SqlDbType.Int);
            SqlParametros.Value = book.IdLibro;
        }

        public void ArmarParametrosInsertBook(ref SqlCommand Comando, Libro book)
        {
            SqlParameter SqlParametros = new SqlParameter();
            // el idLibro no va porque es auto incremental cuando se inserta
            //SqlParametros = Comando.Parameters.Add("@IdLibro", SqlDbType.Int);
            //SqlParametros.Value = book.IdLibro;
            SqlParametros = Comando.Parameters.Add("@nombre", SqlDbType.VarChar, 100);
            SqlParametros.Value = book.Nombre;
            SqlParametros = Comando.Parameters.Add("@anioDeLanzamiento", SqlDbType.Int);
            SqlParametros.Value = book.AnioDeLanzamiento;
            SqlParametros = Comando.Parameters.Add("@idAutor", SqlDbType.Int);
            SqlParametros.Value = book.IdAutor;
            SqlParametros = Comando.Parameters.Add("@idCategoria", SqlDbType.Int);
            SqlParametros.Value = book.IdCategoria;
            SqlParametros = Comando.Parameters.Add("@idEditorial", SqlDbType.Int);
            SqlParametros.Value = book.IdEditorial;
            SqlParametros = Comando.Parameters.Add("@descripcion", SqlDbType.VarChar, 2500);
            SqlParametros.Value = book.Descripcion;
            SqlParametros = Comando.Parameters.Add("@cantidad", SqlDbType.Int);
            SqlParametros.Value = book.Cantidad;
            SqlParametros = Comando.Parameters.Add("@precio", SqlDbType.Decimal);
            SqlParametros.Value = book.Precio;
            SqlParametros = Comando.Parameters.Add("@urlImagen", SqlDbType.VarChar, 250);
            SqlParametros.Value = book.UrlImagen;
            SqlParametros = Comando.Parameters.Add("@estado", SqlDbType.Bit);
            SqlParametros.Value = book.Estado;
        }

        public void ArmarParametros(ref SqlCommand Comando, Libro book)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IdLibro", SqlDbType.Int);
            SqlParametros.Value = book.IdLibro;
            SqlParametros = Comando.Parameters.Add("@nombre", SqlDbType.VarChar, 100);
            SqlParametros.Value = book.Nombre;
            SqlParametros = Comando.Parameters.Add("@anioDeLanzamiento", SqlDbType.Int);
            SqlParametros.Value = book.AnioDeLanzamiento;
            SqlParametros = Comando.Parameters.Add("@idAutor", SqlDbType.Int);
            SqlParametros.Value = book.IdAutor;
            SqlParametros = Comando.Parameters.Add("@idCategoria", SqlDbType.Int);
            SqlParametros.Value = book.IdCategoria;
            SqlParametros = Comando.Parameters.Add("@idEditorial", SqlDbType.Int);
            SqlParametros.Value = book.IdEditorial;
            SqlParametros = Comando.Parameters.Add("@descripcion", SqlDbType.VarChar, 2500);
            SqlParametros.Value = book.Descripcion;
            SqlParametros = Comando.Parameters.Add("@cantidad", SqlDbType.Int);
            SqlParametros.Value = book.Cantidad;
            SqlParametros = Comando.Parameters.Add("@precio", SqlDbType.Decimal);
            SqlParametros.Value = book.Precio;
            SqlParametros = Comando.Parameters.Add("@urlImagen", SqlDbType.VarChar, 250);
            SqlParametros.Value = book.UrlImagen;
            SqlParametros = Comando.Parameters.Add("@estado", SqlDbType.Bit);
            SqlParametros.Value = book.Estado;
        }

        public int UpdateBook(Libro book)
        {
            cmd = new SqlCommand();
            ArmarParametros(ref cmd, book);
            return da.EjecutarProcedimientoAlmacenado(cmd, "UpdateBook");
        }

        public int InsertBook(Libro book)
        {
            cmd = new SqlCommand();
            ArmarParametrosInsertBook(ref cmd, book);
            return da.EjecutarProcedimientoAlmacenado(cmd, "InsertBook");
        }

        public int DeleteBook(Libro book)
        {
            cmd = new SqlCommand();
            ArmarParametrosBajaLibro(ref cmd, book);
            return da.EjecutarProcedimientoAlmacenado(cmd, "DeleteBook");
        }


        public Libro GetBook(int id)
        {
            Libro book = new Libro();
            String consulta = "Select * From libros where IdLibro = " + id;
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                book.IdLibro = Convert.ToInt32(dr[0]);
                book.Nombre = dr[1].ToString();
                book.AnioDeLanzamiento = Convert.ToInt32(dr[2]);
                book.IdAutor = Convert.ToInt32(dr[3]);
                book.IdCategoria = Convert.ToInt32(dr[4]);
                book.IdEditorial = Convert.ToInt32(dr[5]);
                book.Descripcion = dr[6].ToString();
                book.Cantidad = Convert.ToInt32(dr[7]);
                book.Precio = Convert.ToDecimal(dr[8]);
                book.UrlImagen = dr[9].ToString();
                book.Estado = Convert.ToBoolean(dr[10]);
            }

            dr.Close();
            cn.Close();
            return book;
        }

        public List<Libro> buscarLibrosByName(String texto)
        {
            List<Libro> list = new List<Libro>();           
            String consulta = "Select * From Libros where nombre LIKE '%" + texto + "%' And estado=1";
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Libro(Convert.ToInt32(dr["IdLibro"]),
                                  Convert.ToString(dr["nombre"]),
                                  Convert.ToInt32(dr["anioDeLanzamiento"]),
                                  Convert.ToInt32(dr["idAutor"]),
                                  Convert.ToInt32(dr["idCategoria"]),
                                  Convert.ToInt32(dr["idEditorial"]),
                                  Convert.ToString(dr["descripcion"]),
                                  Convert.ToInt32(dr["cantidad"]),
                                  Convert.ToDecimal(dr["precio"]),
                                  Convert.ToString(dr["urlImagen"]),
                                  Convert.ToBoolean(dr["estado"])
                                  ));

            }

            dr.Close();
            cn.Close();
            return list;
        }

        public List<Libro> ListBooks()
        {     
            List<Libro> list = new List<Libro>();
            String consulta = "SELECT * FROM libreria.libros Where Estado=1";
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Libro(Convert.ToInt32(dr["IdLibro"]),
                                 Convert.ToString(dr["nombre"]),
                                 Convert.ToInt32(dr["anioDeLanzamiento"]),
                                 Convert.ToInt32(dr["idAutor"]),
                                 Convert.ToInt32(dr["idCategoria"]),
                                 Convert.ToInt32(dr["idEditorial"]),
                                 Convert.ToString(dr["descripcion"]),
                                 Convert.ToInt32(dr["cantidad"]),
                                 Convert.ToDecimal(dr["precio"]),
                                 Convert.ToString(dr["urlImagen"]),
                                 Convert.ToBoolean(dr["estado"])
                                 ));
            }

            dr.Close();//cierro el DataReader
            cn.Close();
            return list;
        }

        public List<Libro> getPartListByDescPrice()
        {
            List<Libro> list = new List<Libro>();
            String consulta = "SELECT * FROM libros where estado = 1 ORDER BY precio DESC LIMIT 8";
            cn = da.ConnectToDB();
            cmd = new SqlCommand(consulta, cn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Libro(Convert.ToInt32(dr["IdLibro"]),
                                 Convert.ToString(dr["nombre"]),
                                 Convert.ToInt32(dr["anioDeLanzamiento"]),
                                 Convert.ToInt32(dr["idAutor"]),
                                 Convert.ToInt32(dr["idCategoria"]),
                                 Convert.ToInt32(dr["idEditorial"]),
                                 Convert.ToString(dr["descripcion"]),
                                 Convert.ToInt32(dr["cantidad"]),
                                 Convert.ToDecimal(dr["precio"]),
                                 Convert.ToString(dr["urlImagen"]),
                                 Convert.ToBoolean(dr["estado"])
                                 ));
            }

            dr.Close();
            cn.Close();
            return list;
        }

        // -------------------- MYSQL ------------------------------

        //public LibroService()
        //{
        //    //Constructor vacio
        //}

        //DataAccess da = new DataAccess();

        //public List<Libro> getListLightBooks()
        //{
        //    List<Libro> list = new List<Libro>();
        //    String consulta = "SELECT libros.IdLibro, libros.urlImagen, libros.nombre, libros.anioDeLanzamiento, libros.precio FROM libros";
        //    MySqlConnection cn = new MySqlConnection();
        //    cn = da.ConnectToDB();
        //    MySqlCommand cmd = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    while(dr.Read())
        //    {
        //        list.Add(new Libro(dr.GetInt32("IdLibro"), dr.GetString("urlImagen"), 
        //                           dr.GetString("nombre"), dr.GetInt32("anioDeLanzamiento"), 
        //                           dr.GetDecimal("precio")));
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return list;

        //}

        //public List<Libro> filterLightBook(String consulta)
        //{
        //    List<Libro> list = new List<Libro>();
        //    MySqlConnection cn = new MySqlConnection();
        //    cn = da.ConnectToDB();
        //    MySqlCommand cmd = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        list.Add(new Libro(dr.GetInt32("IdLibro"), dr.GetString("urlImagen"),
        //                          dr.GetString("nombre"), dr.GetInt32("anioDeLanzamiento"),
        //                          dr.GetDecimal("precio")));
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return list;
        //}



        //public Decimal getBookPrice(int idBook)
        //{
        //    String consulta = "SELECT precio from libros where IdLibro = " + idBook + " AND estado = 1";
        //    MySqlConnection cn = new MySqlConnection();
        //    cn = da.ConnectToDB();
        //    MySqlCommand cmd = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cmd.ExecuteReader();
        //    Decimal price = 0;

        //    while (dr.Read())
        //    {
        //        price = Convert.ToDecimal(dr["precio"]);
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return price;
        //}

        //public string getBookName(int id)
        //{
        //    String name = "";
        //    String consulta = "SELECT nombre from libros where IdLibro = " + id + " AND estado = 1";
        //    MySqlConnection cn = new MySqlConnection();
        //    cn = da.ConnectToDB();
        //    MySqlCommand cmd = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    while(dr.Read())
        //    {
        //        name = Convert.ToString(dr["nombre"]);               
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return name;
        //}


        //public List <Libro> LibrosByQueryGet(String consulta)
        //{
        //    List<Libro> list = new List<Libro>();
        //    MySqlConnection cn = new MySqlConnection();
        //    cn = da.ConnectToDB();
        //    MySqlCommand cmd = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    while(dr.Read())
        //    {
        //        list.Add(new Libro(dr.GetInt32("IdLibro"), dr.GetString("nombre"),
        //                           dr.GetInt32("anioDeLanzamiento"), dr.GetInt32("idAutor"),
        //                           dr.GetInt32("idCategoria"), dr.GetInt32("idEditorial"),
        //                           dr.GetString("descripcion"), dr.GetInt32("cantidad"),
        //                           dr.GetDecimal("precio"), dr.GetString("urlImagen"),
        //                           dr.GetBoolean("estado")));
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return list;
        //}

        ////inicio los parametros name="" y los int=0 por si recibe datos vacios en los parametros
        //public List<Libro> FilterBooks(String name = "", int idAuthor = 0, int idCategory = 0)
        //{
        //    List<Libro> list = new List<Libro>();
        //    MySqlConnection cn = new MySqlConnection();
        //    cn = da.ConnectToDB();
        //    String a = "where libros.nombre = "+"'"+name+"' ";
        //    String b = "and libros.idAutor = " + idAuthor;
        //    String c = " and libros.idCategoria = " + idCategory;
        //    String consulta = a + b + c;
        //    MySqlCommand cmd = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    while(dr.Read())
        //    {
        //        list.Add(new Libro(dr.GetInt32("IdLibro"), dr.GetString("nombre"), 
        //                           dr.GetInt32("anioDeLanzamiento"), dr.GetInt32("idAutor"), 
        //                           dr.GetInt32("idCategoria"), dr.GetInt32("idEditorial"), 
        //                           dr.GetString("descripcion"), dr.GetInt32("cantidad"), 
        //                           dr.GetDecimal("precio"), dr.GetString("urlImagen"), 
        //                           dr.GetBoolean("estado")));
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return list;
        //}


        //public void ArmarParametrosBajaLibro(ref MySqlCommand Comando, Libro book)
        //{
        //    MySqlParameter mySqlParametros = new MySqlParameter();
        //    mySqlParametros = Comando.Parameters.Add("_IdLibro", MySqlDbType.Int32);
        //    mySqlParametros.Value = book.IdLibro;
        //}

        //public void ArmarParametros(ref MySqlCommand Comando, Libro book)
        //{
        //    MySqlParameter mySqlParametros = new MySqlParameter();
        //    mySqlParametros = Comando.Parameters.Add("_IdLibro", MySqlDbType.Int32);
        //    mySqlParametros.Value = book.IdLibro;
        //    mySqlParametros = Comando.Parameters.Add("_nombre", MySqlDbType.VarChar, 100);
        //    mySqlParametros.Value = book.Nombre;
        //    mySqlParametros = Comando.Parameters.Add("_anioDeLanzamiento", MySqlDbType.Int32);
        //    mySqlParametros.Value = book.AnioDeLanzamiento;
        //    mySqlParametros = Comando.Parameters.Add("_idAutor", MySqlDbType.Int32);
        //    mySqlParametros.Value = book.IdAutor;
        //    mySqlParametros = Comando.Parameters.Add("_idCategoria", MySqlDbType.Int32);
        //    mySqlParametros.Value = book.IdCategoria;
        //    mySqlParametros = Comando.Parameters.Add("_idEditorial", MySqlDbType.Int32);
        //    mySqlParametros.Value = book.IdEditorial;           
        //    mySqlParametros = Comando.Parameters.Add("_descripcion", MySqlDbType.MediumText);
        //    mySqlParametros.Value = book.Descripcion;
        //    mySqlParametros = Comando.Parameters.Add("_cantidad", MySqlDbType.Int32);
        //    mySqlParametros.Value = book.Cantidad;
        //    mySqlParametros = Comando.Parameters.Add("_precio", MySqlDbType.Decimal);
        //    mySqlParametros.Value = book.Precio;
        //    mySqlParametros = Comando.Parameters.Add("_urlImagen", MySqlDbType.TinyText);
        //    mySqlParametros.Value = book.UrlImagen;
        //    mySqlParametros = Comando.Parameters.Add("_estado", MySqlDbType.Bit);
        //    mySqlParametros.Value = book.Estado;           
        //}

        //public int UpdateBook(Libro book)
        //{
        //    MySqlCommand comando = new MySqlCommand();
        //    ArmarParametros(ref comando, book);
        //    return da.EjecutarProcedimientoAlmacenado(comando, "UpdateBook");
        //}

        //public int InsertBook(Libro book)
        //{
        //    MySqlCommand comando = new MySqlCommand();
        //    ArmarParametros(ref comando, book);
        //    return da.EjecutarProcedimientoAlmacenado(comando, "InsertBook");
        //}

        //public int DeleteBook(Libro book)
        //{
        //    MySqlCommand comando = new MySqlCommand();
        //    ArmarParametrosBajaLibro(ref comando, book);
        //    return da.EjecutarProcedimientoAlmacenado(comando, "DeleteBook");
        //}


        //public Libro GetBook(int id)
        //{
        //    Libro book = new Libro();
        //    MySqlConnection cn = da.ConnectToDB();
        //    String consulta = "Select * From libros where IdLibro = "+ id;
        //    MySqlCommand cm = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cm.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        book.IdLibro = Convert.ToInt32(dr[0]);
        //        book.Nombre = dr[1].ToString();
        //        book.AnioDeLanzamiento = Convert.ToInt32(dr[2]);
        //        book.IdAutor = Convert.ToInt32(dr[3]);
        //        book.IdCategoria = Convert.ToInt32(dr[4]);
        //        book.IdEditorial = Convert.ToInt32(dr[5]);
        //        book.Descripcion = dr[6].ToString();
        //        book.Cantidad = Convert.ToInt32(dr[7]);
        //        book.Precio = Convert.ToDecimal(dr[8]);
        //        book.UrlImagen = dr[9].ToString();
        //        book.Estado = Convert.ToBoolean(dr[10]);
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return book;
        //}

        //public List<Libro> buscarLibrosByName(String texto)
        //{
        //    List<Libro> Lista = new List<Libro>();
        //    MySqlConnection cn = da.ConnectToDB();
        //    String consulta = "Select * From Libros where nombre LIKE '%" + texto + "%' And estado=1";
        //    MySqlCommand cm = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cm.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        Lista.Add(new Libro(dr.GetInt32("IdLibro"), dr.GetString("nombre"), dr.GetInt32("anioDeLanzamiento"), dr.GetInt32("idAutor"), dr.GetInt32("idCategoria"), dr.GetInt32("idEditorial"), dr.GetString("descripcion"), dr.GetInt32("cantidad"), dr.GetDecimal("precio"), dr.GetString("urlImagen"), dr.GetBoolean("estado")));

        //    }

        //    dr.Close();
        //    cn.Close();
        //    return Lista;
        //}

        //public List<Libro> ListBooks()
        //{
        //    MySqlConnection cn = da.ConnectToDB();
        //    List<Libro> Lista = new List<Libro>();
        //    String consulta = "SELECT * FROM libreria.libros Where Estado=1";
        //    MySqlCommand command = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = command.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        Lista.Add(new Libro(dr.GetInt32("IdLibro"), dr.GetString("nombre"), 
        //            dr.GetInt32("anioDeLanzamiento"), dr.GetInt32("idAutor"), 
        //            dr.GetInt32("idCategoria"), dr.GetInt32("idEditorial"), 
        //            dr.GetString("descripcion"), dr.GetInt32("cantidad"), 
        //            dr.GetDecimal("precio"), dr.GetString("urlImagen"), 
        //            dr.GetBoolean("estado")));

        //    }

        //    dr.Close();//cierro el DataReader
        //    cn.Close();
        //    return Lista;
        //}

        //public List<Libro> getPartListByDescPrice()
        //{
        //    List<Libro> list = new List<Libro>();
        //    MySqlConnection cn = da.ConnectToDB(); 
        //    String consulta = "SELECT * FROM libros where estado = 1 ORDER BY precio DESC LIMIT 8";
        //    MySqlCommand cmd = new MySqlCommand(consulta, cn);
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    while(dr.Read())
        //    {
        //        list.Add(new Libro(dr.GetInt32("IdLibro"), dr.GetString("nombre"), dr.GetInt32("anioDeLanzamiento"), dr.GetInt32("idAutor"), dr.GetInt32("idCategoria"), dr.GetInt32("idEditorial"), dr.GetString("descripcion"), dr.GetInt32("cantidad"), dr.GetDecimal("precio"), dr.GetString("urlImagen"), dr.GetBoolean("estado")));
        //    }

        //    dr.Close();
        //    cn.Close();
        //    return list;
        //}
    }
}