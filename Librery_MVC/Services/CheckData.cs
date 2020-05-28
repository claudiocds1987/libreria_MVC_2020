using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Librery_MVC.Models;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Librery_MVC.Services
{
    public class CheckData
    {

        DataAccess da = new DataAccess();

        public Decimal DividirNumber(String number)
        {
            /*nota: si el string tiene mas de 7 caracteres ej 152988.25
                la division no va a dar exacta, esto es porque float soporta hasta 7 digitos.
                una solucion seria cambiar en la base de datos de float a double.
            */

            int tam = number.Length;
            int pos = 0;
            decimal newNumber = Convert.ToDecimal(number);

            if (!number.Contains("."))
                return newNumber;
            else
            {
                for (int i = 0; i < tam; i++)
                {
                    if (number[i].Equals('.'))
                    {
                        if (pos == 1)
                            return newNumber;

                        else if (pos == 2)
                        {
                            if (tam >= 5)
                            {
                                newNumber = newNumber / 100;//ej 1588 = 15.88
                                break;
                            }

                            else
                            {
                                newNumber = newNumber / 10;//ej 158 = 15.8
                                break;
                            }
                               
                        }
                        else if(pos >= 3)
                        {
                            if(tam >= 6)
                            {
                                newNumber = newNumber / 100;//ej 15088 = 150.88
                                break;
                            }
                                                         
                        }
                    }

                    pos++;

                }
            }


            return newNumber;

        }

        public bool CheckDateFormat(String date)
        {
            DateTime dt;

            if (DateTime.TryParse(date, out dt))
                return true;

            return false;
        }

        //funcion que verifica que la persona tenga entre 18 y 100 años
        public bool CheckAdultAge(DateTime nacimiento)
        {        
            int day = nacimiento.Day;
            int month = nacimiento.Month;
            int year = nacimiento.Year;
            //obteniendo la fecha actual completa dia/mes/año/hora
            DateTime actualDate = DateTime.Today;
            int actualDay = actualDate.Day;//obteniendo solo el dia actual
            int actualMonth = actualDate.Month;//obtengo solo el mes actual
            int actualYear = actualDate.Year;//obtengo solo el año actual

            int diference = actualYear - year;

            if (diference >= 18 && diference <= 100)
            {
                if (diference == 18)
                {
                    if (month <= actualMonth)
                    {
                        if (day > actualDay)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }


            return true;
        }

        //busca en la tabla actores de la db si existe el idAutor
        public bool CheckIdAutor(String id)
        {
            MySqlConnection cn = da.ConnectToDB();
            String consulta = "select nombre from autores where autores.idAutor = " + id;
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                dr.Close();
                cn.Close();
                return true;
            }
          
            dr.Close();
            cn.Close();
            return false;
        }

        public bool CheckIdCategory(String id)
        {
            MySqlConnection cn = da.ConnectToDB();
            String consulta = "select nombreCategoria from categorias where categorias.idCategoria = " + id;
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

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

        public bool CheckIdEditorial(String id)
        {
            MySqlConnection cn = da.ConnectToDB();
            String consulta = "select nombreEditorial from editoriales where editoriales.IdEditorial = " + id;
            MySqlCommand cmd = new MySqlCommand(consulta, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

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

        //Si la cadena solo contiene letras devuelve true
        public bool CheckStringWithoutWhiteSpace(String word)
        {
            return Regex.IsMatch(word, @"^[a-zA-Z]+$");         
        }

        public bool CheckStringWithWhiteSpace(String word)
        {
            return Regex.IsMatch(word, @"^[a-zA-Z ]+$");
        }

        public bool CheckPrice(String price)
        {
            //expresion regular solo acepta numeros y un solo punto decimal
            //no acepta 150.445.2(ciento cincuenta mil cuatrocientos cuarenta y cinco con dos)
            //si acepta 150445.2(ciento cincuenta mil cuatrocientos cuarenta y cinco con dos)
            var regexItem = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
 
            //si el precio esta vacio
            if (price == null || price == "")
                return false;

            if (!regexItem.IsMatch(price))
            {
                return false;
            }

            return true;
        }

        public bool CheckIntNumber(String num)
        {
            Regex regex = new Regex("^[0-9]+$");

            if (!regex.IsMatch(num))
            {
                return false;
            }

            return true;
        }


        public bool CheckId(int num)
        {
            /*nota: esta funcion la utilizo en  ActionResult CompraFinalizada() 
             del usserController para chequear un array que contiene los id de 
             los libros libros*/

            //Expresion regular, solo acepta numeros int
            Regex regex = new Regex("^[0-9]+$");

            String number = Convert.ToString(num);

            if (!regex.IsMatch(number))
            {
                return false;
            }

            return true;
        }

        public bool CheckPasswords(String pass1, String pass2)
        {
            //nota: ambas contraseñas deben tener un min de 5 y un max de 45 caracteres

            int tam1 = pass1.Length;
            int tam2 = pass2.Length;

            //Comparo el lenght de caracteres de pass1
            if(tam1 >= 5 && tam1 <= 45)
            {   //Comparo el lenght de caracteres de pass2
                if (tam2 >= 5 && tam2 <= 45)
                {
                    //Comparo que las contraseñas sean iguales
                    for (int i = 0; i <= pass1.Length - 1; i++)
                    {
                        if (pass2[i] != pass1[i])
                        {
                            return false;
                        }
                    }

                }
                else
                    return false;
            }
            else
                return false;


            return true;
        }

        public bool checkImageFormat(String img)
        {
            Regex regex = new Regex("[^\\s]+(\\.(?i)(jpg|jpeg|png|gif|bmp))$");

            if (!regex.IsMatch(img))
            {
                return false;
            }

            return true;
        }

        //public bool checkFileExist(String path)
        //{
        //    if (!File.Exists(path))
        //        return false;

        //    return true;
        //}
       
    }
}