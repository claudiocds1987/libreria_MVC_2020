using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Librery_MVC.Services;
using Librery_MVC.Models;
using System.IO;

namespace Librery_MVC.Controllers
{
    public class HomeController : Controller
    {
        AdminService adminService = new AdminService();
        CheckData check = new CheckData();

        public ActionResult index()
        {
            String email = Request.Form["adminEmail"];
            String password = Request.Form["password"];

            if (email != null && password != null)
            {

                if(!check.checkEmailFormat(email))
                {
                    ViewBag.Msg = "El email no es valido!";
                    return View();
                }

                //check que el password dno tenga caracteres raros o espacios vacios si el password 

                if(adminService.SearchEmailAndPasswordAdmin(email, password))
                {
                    //guardo el email de admin en la tempdata
                    TempData["adminEmail"] = email;                  
                    return RedirectToAction("adminPrincipal");
                }
                else
                {
                    ViewBag.Msg = "No existe el usuario, compruebe que los datos ingresados sean correctos.";
                    return View();
                }


            }
                           
            return View();
        }

        public ActionResult adminPrincipal()
        {
            //TempData["adminEmail"] fue creada en ActionResult index
            ViewBag.adminEmail = TempData["adminEmail"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult crearAdmin()
        {
            //nota: todos los TempData son creados en ActionResult registrarAdmin();

            //Aviso que hay campos vacios
            if (TempData["emptyDataAdmin"] != null)
            {
                ViewBag.Msg = "Hay campos vacios!";
                return View();
            }

            //Aviso que se supero el maxLength de el/los input
            if (TempData["lengthErrorAdminInput"] != null)
            {
                ViewBag.Msg = "Error!, no se permite mas de 45 caracteres en los campos: Nombre, Apellido, Email, Nombre de usuario, Contraseñas, Domicilio.";
                return View();
            }

            //Aviso que el formato de email es incorrecto
            if (TempData["invalidAdminEmail"] != null)
            {
                ViewBag.Msg = "El formato de email es invalido!";
                return View();
            }

            //Aviso si el email de admin ya esta registrado
            if (TempData["duplicatedEmailAdmin"] != null)
            {
                ViewBag.Msg = "Error, ya existe un administrador con el mismo email.";
                return View();
            }

            //Aviso si las dos contraseñas no son iguales
            if (TempData["invalidPasswordsAdmin"] != null)
            {
                ViewBag.Msg = "Error, Las dos contraseñas deben ser iguales.";
                return View();
            }

            return View();
        }

        public ActionResult registrarAdmin(FormCollection _form)
        {

            //****************** VALIDANDO LADO BACK-END **********************//

            //Checkeando inputs vacios

            foreach (var item in _form)
            {
                string valor = _form[item.ToString()];

                if (String.IsNullOrEmpty(valor))
                {
                    //Si hay inputs vacios se crea la TempData
                    TempData["emptyDataAdmin"] = true;
                    //redirecciono a ActionResult CrearUsuario() enviando la TempData
                    return RedirectToAction("crearAdmin");
                }

            }

            //Checking length de inputs

            int emailSize = Convert.ToInt32(Request.Form["txtEmail"].Length);
            int nameSize = Convert.ToInt32(Request.Form["txtName"].Length);
            int surnameSize = Convert.ToInt32(Request.Form["txtSurname"].Length);
            int clave1Size = Convert.ToInt32(Request.Form["txtClave1"].Length);
            int clave2Size = Convert.ToInt32(Request.Form["txtClave2"].Length);

            if (emailSize > 45 || nameSize > 45 || surnameSize > 45 || clave1Size > 45 || clave2Size > 45)
            {
                TempData["lengthErrorAdminInput"] = true;
                return RedirectToAction("crearAdmin");
            }

            //Checkeando formato valido de email
            string email = Request.Form["txtEmail"];

            if (!adminService.IsValidEmail(email))
            {
                TempData["invalidAdminEmail"] = true;
                return RedirectToAction("crearAdmin");
            }

            //Checkeando si ya existe el email
            if (adminService.SearchEmailAdmin(email))
            {
                TempData["duplicatedEmailAdmin"] = true;
                return RedirectToAction("crearAdmin");
            }
            
            //checking que las 2 contraseñas sean iguales
            String pass1 = Request.Form["txtClave1"];
            String pass2 = Request.Form["txtClave2"];
            //bool iguales = true;

            //Check que tenga el mismo tamaño
            if(pass1.Length != pass2.Length)
            {
                TempData["invalidPasswordsAdmin"] = true;
                return RedirectToAction("crearAdmin");
            }

            //ya sabiendo que tienen el mismo tamaño pregunto si son iguales
            for (int i = 0; i < pass1.Length; i++)
            {
                if (pass2[i] != pass1[i])
                {
                    TempData["invalidPasswordsAdmin"] = true;
                    return RedirectToAction("crearAdmin");
                    //iguales = false;
                    //break;
                }
            }

            //if (!iguales)
            //{
            //    TempData["invalidPasswordsAdmin"] = true;
            //    return RedirectToAction("crearAdmin");
            //}

            //****************** FIN VALIDACIONES LADO BACK-END ***************************//

            Admin admin = new Admin();

            admin.email = Request.Form["txtEmail"];
            admin.nombre = Request.Form["txtName"];
            admin.apellido = Request.Form["txtSurname"];
            admin.pass = Request.Form["txtClave1"];
            admin.Estado = 1;

            ViewBag.Admin = admin.email; //creando la ViewBag.Email con el email del administrador
            AdminService sa = new AdminService();

            int filasAfectadas = sa.InsertAdmin(admin);

            if(filasAfectadas > 0)         
                ViewBag.Msg = 1;          
            else
                ViewBag.Msg = 0;


            return View(); //pasando el objeto admin y ViewBag.Email a la vista registrarAdmin.cshtml

        }

        public ActionResult Libros(string option, string search)
        {
            LibroService ls = new LibroService();  
            //ViewBag.Message = "Your contact page.";     
            String consulta = "Select * from libros";
   
            return View(ls.filtrarLibro(consulta));
            //return View(ls.buscarLibrosByName(searching).ToList());
        }

        public ActionResult adminFiltrarLibro(String option, String search)
        {
            //no hacer back-end de option o search, si el usuario escribe cualqueir cosa
            //porque en la view va a aparecer 0 registros encontrados!

            LibroService ls = new LibroService();
            String consulta = "Select * from libros";

            if(search == "")
                return View(ls.filtrarLibro(consulta));

            
            if (option == "bookName" || option == "idBook")
            {
                if (option == "bookName")
                    consulta = consulta + " where libros.nombre like'%" + search + "%'";
                else
                    consulta = consulta + " where libros.IdLibro = " + search;              
            }
           else
            { //por si pinchan los values de los radio button
               ViewBag.Msg = "Error al recibir los value de los radio button";
               return View();
           }
           
           
            return View(ls.filtrarLibro(consulta));

        }

        public ActionResult BajaLibro(int idLibro)
        {
            ViewBag.Message = "Your contact page.";
            Libro book = new Libro();
            book.IdLibro = idLibro;
            LibroService ls = new LibroService();
            int filasAfectadas = ls.DeleteBook(book);
            return View(filasAfectadas);
        }


        //[HttpPost]
        public ActionResult EditarLibro(int idLibro)
        {

            LibroService ls = new LibroService();
            Libro book = new Libro();
            book = ls.GetBook(idLibro);
            
            //****************** VALIDANDO LADO BACK-END *********************************//
            
            //nota: todos los TempData son creados en ActionResult Libroeditado();
        
            //Aviso si hay un error en el nombre del libro
            //if (TempData["errorString"] != null)
            //{
            //    ViewBag.Msg = "El nombre del libro solo debe tener letras!";
            //    return View();
            //}

            //Aviso error de precio 
            if (TempData["errorPrice"] != null)
            {
                ViewBag.Msg = "El precio no es valido!, si es un numero decimal use el punto decimal con un maximo de dos decimales ej: 1500.88";
                return View();
            }

            //Aviso si hay un error en el año del libro
            if (TempData["errorYear"] != null)
            {
                ViewBag.Msg = "El año no es valido!";
                return View();
            }

            //Aviso si el autor existe en la base de datos
            if (TempData["errorAutor"] != null)
            {
                ViewBag.Msg = "El autor no existe en la base de datos!";
                return View();
            }

            if (TempData["errorCategory"] != null)
            {
                ViewBag.Msg = "La categoria no existe en la base de datos!";
                return View();
            }

            if (TempData["errorEditorial"] != null)
            {
                ViewBag.Msg = "La editorial no existe en la base de datos!";
                return View();
            }

            if (TempData["errorQuantity"] != null)
            {
                ViewBag.Msg = "La cantidad debe ser un numero entero";
                return View();
            }

            //Aviso si la img no se encuentra en la ruta especificada
            if (TempData["errorPathImg"] != null)
            {
                ViewBag.Msg = "Error. La imagen no se encuentra en la ruta especificada";
                return View();
            }

            //Aviso si el formato de img es incorrecto
            if (TempData["errorImg"] != null)
            {
                ViewBag.Msg = "Error. El formato de imagen no es correcto. Formatos permitidos .jpg, .png, .gif, .bmp";
                return View();
            }


            //Aviso error de precio
            if (TempData["errorPrice"] != null)
            {
                ViewBag.Msg = "El precio fue invalido!. No debe contener simbolos. Si el precio es decimal, use el punto decimal en vez de la coma.";
                return View();
            }

            //******** fin validaciones back-end ************************

            
            return View(book);
        }

        [HttpPost]
        public ActionResult LibroEditado(FormCollection form)
        {
            ViewBag.Message = "Your contact page.";
            String ruta = "principal/imagenes/";
            Libro book = new Libro();
            CheckData check = new CheckData();

            //****************** VALIDACIONES BACK-END ***********************//
            //permite white space en el nombre y checkea que no tenga numeros ni simbolos 
            //if (!check.CheckStringWithWhiteSpace(Request.Form["txt_bookName"]))
            //{
            //    TempData["errorString"] = true;
            //    //redirecciono a ActionResult editarLibro() enviando la TempData
            //    //y el id del libro
            //    int idBook = Convert.ToInt32(form[0]);
            //    return RedirectToAction("EditarLibro", new { idLibro = idBook });
            //}

            //check length del año de lanzamiento solo cuatro numeros
            if (Request.Form["nbr_lanzamiento"].Length != 4)
            {
                TempData["errorYear"] = true;              
                int idBook = Convert.ToInt32(form[0]);
                return RedirectToAction("EditarLibro", new { idLibro = idBook });
            }
            //check que el año de lanzamiento sea solo numeros
            if (!check.CheckIntNumber(Request.Form["nbr_lanzamiento"]))
            {
                TempData["errorYear"] = true;               
                int idBook = Convert.ToInt32(form[0]);
                return RedirectToAction("EditarLibro", new { idLibro = idBook });
            }

            //check si existe el idAutor es un dato int
            if (!check.CheckIntNumber(Request.Form["ddlAutor"]))
            {
                TempData["errorAutor"] = true;              
                int idBook = Convert.ToInt32(form[0]);
                return RedirectToAction("EditarLibro", new { idLibro = idBook });
            }
            //check si el idAutor existe en la base de datos
            if (!check.CheckIdAutor(Request.Form["ddlAutor"]))
            {
                TempData["errorAutor"] = true;               
                int idBook = Convert.ToInt32(form[0]);
                return RedirectToAction("EditarLibro", new { idLibro = idBook });
            }

            //check si existe el idCategoria es un dato int
            if (!check.CheckIntNumber(Request.Form["ddlCategory"]))
            {
                TempData["errorCategory"] = true;              
                int idBook = Convert.ToInt32(form[0]);
                return RedirectToAction("EditarLibro", new { idLibro = idBook });
            }
            //check si el idCategory existe en la base de datos
            if (!check.CheckIdCategory(Request.Form["ddlCategory"]))
            {
                TempData["errorCategory"] = true;               
                int idBook = Convert.ToInt32(form[0]);
                return RedirectToAction("EditarLibro", new { idLibro = idBook });
            }

            //check si el idEditorial es un dato int
            if (!check.CheckIntNumber(Request.Form["ddlEditorial"]))
            {
                TempData["errorEditorial"] = true;             
                int idBook = Convert.ToInt32(form[0]);
                return RedirectToAction("EditarLibro", new { idLibro = idBook });
            }
            //check si el idEditorial existe en la base de datos
            if (!check.CheckIdEditorial(Request.Form["ddlEditorial"]))
            {
                TempData["errorEditorial"] = true;                
                int idBook = Convert.ToInt32(form[0]);
                return RedirectToAction("EditarLibro", new { idLibro = idBook });
            }

            //checking si la cantidad es un numero (si es null devuelve false)
            if (!check.CheckIntNumber(Request.Form["nbr_quantity"]))
            {
                TempData["errorQuantity"] = true;
                int idBook = Convert.ToInt32(form[0]);
                return RedirectToAction("EditarLibro", new { idLibro = idBook });
            }

            //checking precio, tambien evalua si llega vacio
            if (!check.CheckPrice(Request.Form["txt_price"]))
            {
                TempData["errorPrice"] = true;              
                int idBook = Convert.ToInt32(form[0]);
                return RedirectToAction("EditarLibro", new { idLibro = idBook });
            }
      
            /****************** fin validaciones back end****************************/

            //convierto el precio string en decimal
            String precio = Request.Form["txt_price"];
            decimal price = check.ConvertStringToDecimal(precio);

            book.IdLibro = Convert.ToInt32(form[0]);
            book.Nombre = form[1];
            book.AnioDeLanzamiento = Convert.ToInt32(form[2]);
            book.IdAutor = Convert.ToInt32(form[3]);
            book.IdCategoria = Convert.ToInt32(form[4]);
            book.IdEditorial = Convert.ToInt32(form[5]);
            //Obtengo lo que se edito en el textarea llamado description"
            book.Descripcion = Request.Form["description"];
            book.Cantidad = Convert.ToInt32(form[7]);           
            book.Precio = price;

            if (Request.Form["itf_urlImage"].Equals(""))
                book.UrlImagen = Request.Form["txt_urlImage"];
            else
                book.UrlImagen = ruta + Request.Form["itf_urlImage"];

          
            book.Estado = true;

            LibroService ls = new LibroService();
            int filasAfectadas;
            filasAfectadas = ls.UpdateBook(book);

            if(filasAfectadas > 0)        
                ViewBag.Filas = 1;  
            else
                ViewBag.Filas = 0;

            return View();
        }


        public ActionResult InsertarLibro()
        {
            //****************** VALIDANDO LADO BACK-END *********************************//
            //nota: todos los TempData son creados en ActionResult LibroInsertado();

            //Aviso si hay un error en el nombre del libro
            //if(TempData["errorString"] != null)
            //{
            //    ViewBag.Msg = "El nombre del libro solo debe tener letras!";
            //    return View();
            //}

            //Aviso error de precio 
            if (TempData["errorPrice"] != null)
            {
                ViewBag.Msg = "El precio no es valido!, si es un numero decimal use el punto decimal con un maximo de dos decimales ej: 1500.88";
                return View();
            }

            //Aviso si hay un error en el año del libro
            if (TempData["errorYear"] != null)
            {
                ViewBag.Msg = "El año no es valido!";
                return View();
            }

            //Aviso si el autor existe en la base de datos
            if(TempData["errorAutor"] != null)
            {
                ViewBag.Msg = "El autor no existe en la base de datos!";
                return View();
            }

            if(TempData["errorCategory"] != null)
            {
                ViewBag.Msg = "La categoria no existe en la base de datos!";
                return View();
            }

            if (TempData["errorEditorial"] != null)
            {
                ViewBag.Msg = "La editorial no existe en la base de datos!";
                return View();
            }

            if(TempData["errorQuantity"] != null)
            {
                ViewBag.Msg = "La cantidad debe ser un numero entero";
                return View();
            }

            //Aviso si la img no se encuentra en la ruta especificada
            if(TempData["errorPathImg"] != null)
            {
                ViewBag.Msg = "Error. La imagen no se encuentra en la ruta especificada";
                return View();
            }

            //Aviso si el formato de img es incorrecto
            if(TempData["errorImg"] != null)
            {
                ViewBag.Msg = "Error. El formato de imagen no es correcto. Formatos permitidos .jpg, .png, .gif, .bmp";
                return View();
            }

            //Aviso si el libro  ya existe en la base de datos
            if(TempData["duplicatedBook"] != null)
            {
                ViewBag.Msg = "Error. Ya existe un libro del mismo autor";
                return View();
            }

            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]
        public ActionResult LibroInsertado()
        {
            ViewBag.Message = "Your contact page.";
            String ruta = "principal/imagenes/";
            Libro book = new Libro();
            CheckData check = new CheckData();

            //****************** VALIDACIONES BACK-END ***********************//
            //permite white space en el nombre y checkea que no tenga numeros ni simbolos 
            //if (!check.CheckStringWithWhiteSpace(Request.Form["txt_bookName"]))
            //{
            //    //corregir porque no permite acentos
            //    TempData["errorString"] = true;
            //    return RedirectToAction("InsertarLibro");
            //}
           
            //check length del año de lanzamiento solo cuatro numeros
            if(Request.Form["nbr_lanzamiento"].Length != 4)
            {
                TempData["errorYear"] = true;
                return RedirectToAction("InsertarLibro");
            }
            //check que el año de lanzamiento sea solo numeros
            if (!check.CheckIntNumber(Request.Form["nbr_lanzamiento"]))
            {
                TempData["errorYear"] = true;               
                return RedirectToAction("InsertarLibro");
            }
      
            //check si existe el idAutor es un dato int
            if (!check.CheckIntNumber(Request.Form["ddlAutor"]))
            {
                TempData["errorAutor"] = true;
                return RedirectToAction("InsertarLibro");
            }
            //check si el idAutor existe en la base de datos
            if (!check.CheckIdAutor(Request.Form["ddlAutor"]))
            {
                TempData["errorAutor"] = true;
                return RedirectToAction("InsertarLibro");
            }

            //check si existe el idCategoria es un dato int
            if (!check.CheckIntNumber(Request.Form["ddlCategory"]))
            {
                TempData["errorCategory"] = true;
                return RedirectToAction("InsertarLibro");
            }
            //check si el idCategory existe en la base de datos
            if (!check.CheckIdCategory(Request.Form["ddlCategory"]))
            {
                TempData["errorCategory"] = true;
                return RedirectToAction("InsertarLibro");
            }

            //check si el idEditorial es un dato int
            if (!check.CheckIntNumber(Request.Form["ddlEditorial"]))
            {
                TempData["errorEditorial"] = true;
                return RedirectToAction("InsertarLibro");
            }
            //check si el idEditorial existe en la base de datos
            if (!check.CheckIdEditorial(Request.Form["ddlEditorial"]))
            {
                TempData["errorEditorial"] = true;
                return RedirectToAction("InsertarLibro");
            }
            //checking precio, tambien evalua si llega vacio
            if (!check.CheckPrice(Request.Form["txt_price"]))
            {
                TempData["errorPrice"] = true;
                return RedirectToAction("InsertarLibro");
            }
            //checking si la cantidad es un numero (si es null devuelve false)
            if(!check.CheckIntNumber(Request.Form["nbr_quantity"]))
            {
                TempData["errorQuantity"] = true;
                return RedirectToAction("InsertarLibro");
            }

            //convierto el precio string en decimal
            String precio = Request.Form["txt_price"];
            decimal price = check.ConvertStringToDecimal(precio);           
            
            //para la descripcion no hago check

            //pregunto si se recibió null como imagen
            String imagen = Request.Form["itf_urlImage"];
           
            if (imagen != "")
            {
                //check formato de imagen jpg, png, gif, bmp         
                if (!check.checkImageFormat(ruta + Request.Form["itf_urlImage"]))
                {
                    TempData["errorImg"] = true;
                    return RedirectToAction("InsertarLibro");
                }
            }
              
            //ckeck existencia del libro en la base de datos por idAutor y nombre de libro
            if(check.checkAutorAndBookName(Request.Form["txt_bookName"], Request.Form["ddlAutor"]))
            {
                TempData["duplicatedBook"] = true;
                return RedirectToAction("InsertarLibro");
            }


            // **************** fin validaciones back-end *********************//

            book.Nombre = Request.Form["txt_bookName"];
            book.AnioDeLanzamiento = Convert.ToInt32(Request.Form["nbr_lanzamiento"]);
            book.IdAutor = Convert.ToInt32(Request.Form["ddlAutor"]);
            book.IdCategoria = Convert.ToInt32(Request.Form["ddlCategory"]);
            book.IdEditorial = Convert.ToInt32(Request.Form["ddlEditorial"]);
            book.Descripcion = Request.Form["txta_description"];
            book.Cantidad = Convert.ToInt32(Request.Form["nbr_quantity"]);
            book.Precio = price;

            /*Para obtener la ruta absoluta de la img Usar esto:
            //var nombreImagen = Request.Form["itf_urlImage"];
            //var path = Path.Combine(Server.MapPath("~/principal/imagenes/"), nombreImagen);
            //book.UrlImagen = path;
            */
            if (imagen == "")
                book.UrlImagen = imagen;
            else
                book.UrlImagen = ruta + Request.Form["itf_urlImage"];

            book.Estado = true;

            LibroService ls = new LibroService();
            int filasAfectadas = 0;
            filasAfectadas = ls.InsertBook(book);
            //si filasAfectadas devuelve 1, es porque se pudo insertar en la base de datos
            if (filasAfectadas > 0)
            {               
                ViewBag.Msg = 1;
            }
            else
                ViewBag.Msg = 0;

            return View();
        }

        public ActionResult ListarClientes()
        {
            UsserService us = new UsserService();
            List<Usser> list = us.GetUsserClientList();
            return View(list);
        }

        //[HttpGet]
        //public FileResult ObtenerImagen(string itf_urlImage)
        //{
        //    var nombreImagen = itf_urlImage;
        //    var path = Path.Combine(Server.MapPath("~/principal/imagenes/"), nombreImagen);

        //    return File(path);
        //}
    }
}