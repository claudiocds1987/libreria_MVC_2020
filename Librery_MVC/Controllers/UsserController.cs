using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Librery_MVC.Services;
using Librery_MVC.Models;

namespace Librery_MVC.Controllers
{
    public class UsserController : Controller
    {

        public ActionResult index()
        {
            List<LightBook> list = new List<LightBook>();
            LightBookService lbs = new LightBookService();
            //Guardo en la ViewBag.User el nombre del usuario guardado en TempData
            ViewBag.User = "";

            if (TempData["User"] != null)
            {
                ViewBag.User = TempData["User"];
            }
         
            //Obteniendo todos los libros de la db
            list = lbs.getListLightBooks();
                       
            return View(list);

        }

       
        public ActionResult userLogin()
        {
            //Cuando el usuario cierre sesion, se borra el Tempdata["Email"]
            //if (TempData["User"] != null)
            //    TempData.Remove("User");

            String user = Request.Form["user"];
            String password = Request.Form["password"];
            UsserService us = new UsserService();
            bool exist = false;

            if (user != null && password != null)
            {
                //funcion que verifica si existe el nombre de usuario.
                //bool R = us.SearchEmailUsser(email);
                bool R = us.SearchUsserName(user);

                if (R == false)
                {
                    ViewBag.Msg = "No existe el usuario";
                    return View();
                }
                else
                {
                    //compruebo que la contraseña pertenezca al mismo usuario
                    exist = us.SearchUserPassword(user, password);
                }
                //si el nombreDeUsuario y password son correctos redirige a actionResult index()
                if (exist == true)
                {
                    //TempData es similar a session/local storage, tiene corta duracion, 
                    //al recargarse la pagina desaparece, para evitar esto, 
                    //en _UsserLayout poner  @{TempData.Keep("Email");}

                    TempData["User"] = user;//guardo el nombre de usuario ingreasdo en TempData
                    return RedirectToAction("index");//redirige al actionResult index()
                }
                else
                {
                    ViewBag.Msg = "La contraseña no es válida.";
                    return View();
                }

            }

            return View();
        }

        public ActionResult CrearUsuario()
        {
            //****************** VALIDANDO LADO BACK-END *********************************//

            //nota: todos los TempData son creados en ActionResult registrarUsuario();

            //Aviso que hay campos vacios
            if (TempData["emptyData"] != null)
            {
                ViewBag.Msg = "Hay campos vacios!";
                return View();
            }

            //Aviso si el nombre no es de tipo String
            if (TempData["errorName"] != null)
            {
                ViewBag.Msg = "El nombre debe tener solo letras.";
                return View();
            }

            //Aviso si el apellido no es de tipo String
            if (TempData["errorSurname"] != null)
            {
                ViewBag.Msg = "El apellido debe tener solo letras.";
                return View();
            }

            //Aviso que la fecha es invalida
            if (TempData["fechaInvalida"] != null)
            {
                ViewBag.Msg = "La fecha es invalida!, rango permitido entre 18 y 100 años.";
                return View();
            }

            //Aviso que se supero el maxLength de el/los input
            if (TempData["lengthError"] != null)
            {
                ViewBag.Msg = "Error!, no se permite mas de 45 caracteres en los campos: Nombre, Apellido, Email, Nombre de usuario, Contraseñas, Domicilio.";
                return View();
            }

            //Aviso que el formato de email es incorrecto
            if (TempData["invalidEmail"] != null)
            {
                ViewBag.Msg = "El formato de email es invalido!";
                return View();
            }

            //Aviso si el nombre de usuario ya esta registrado
            if (TempData["duplicatedUser"] != null)
            {
                ViewBag.Msg = "Error. El nombre de usuario ya esta registrado!, elija otro nombre.";
                return View();
            }

            //Aviso si las dos contraseñas son distintas
            if (TempData["invalidPasswordsUser"] != null)
            {
                ViewBag.Msg = "Error. Ambas contraseñas deben ser iguales con un minimo de 5 y un maximo de 45 caracteres.";
                return View();
            }


            //****************** FIN VALIDACIONES LADO BACK-END ***************************//

            return View();
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(FormCollection _data)
        {
            //****************** VALIDANDO LADO BACK-END **********************//

            CheckData check = new CheckData();

            //Checkeando inputs vacios

            foreach (var item in _data)
            {
                string valor = _data[item.ToString()];

                if (String.IsNullOrEmpty(valor))
                {
                    //Si hay inputs vacios se crea la TempData
                    TempData["emptyData"] = true;
                    //redirecciono a ActionResult CrearUsuario() enviando la TempData
                    return RedirectToAction("CrearUsuario");
                }
            }

            //check si el nombre solo contiene letras
            if (!check.CheckStringWithWhiteSpace(Request.Form["txtName"]))
            {
                TempData["errorName"] = true;
                return RedirectToAction("CrearUsuario");
            }

            //check si el apellido solo contiene letras
            if (!check.CheckStringWithWhiteSpace(Request.Form["txtSurname"]))
            {
                TempData["errorSurname"] = true;
                return RedirectToAction("CrearUsuario");
            }

            //Checkeando formato valido de email

            string email = Request.Form["txtEmail"];
            UsserService us = new UsserService();
            bool validEmail = us.IsValidEmail(email);

            if (!validEmail)
            {
                TempData["invalidEmail"] = true;
                return RedirectToAction("CrearUsuario");
            }

            //Checkeando si ya existe el nombreDeUsuario

            string userName = Request.Form["txtUsserName"];
            bool existNameUser = us.SearchUsserName(userName);

            if (existNameUser)
            {
                TempData["duplicatedUser"] = true;
                return RedirectToAction("CrearUsuario");
            }

            //check fecha valida
            if (!check.CheckDateFormat(Request.Form["date-input"]))
            {
                TempData["fechaInvalida"] = true;
                return RedirectToAction("CrearUsuario");
            }

            //checkeando Fecha de nacimiento entre 18 y 100 años///
            if (!check.CheckAdultAge(Convert.ToDateTime(Request.Form["date-input"])))
            {
                TempData["fechaInvalida"] = true;
                return RedirectToAction("CrearUsuario");
            }

            int nameSize = Convert.ToInt32(Request.Form["txtName"].Length);
            int surnameSize = Convert.ToInt32(Request.Form["txtSurname"].Length);
            int emailSize = Convert.ToInt32(Request.Form["txtEmail"].Length);
            int usserNameSize = Convert.ToInt32(Request.Form["txtUsserName"].Length);
            int clave1Size = Convert.ToInt32(Request.Form["txtClave1"].Length);
            int clave2Size = Convert.ToInt32(Request.Form["txtClave2"].Length);
            int adressSize = Convert.ToInt32(Request.Form["txtAddress"].Length);

            if (nameSize > 45 || surnameSize > 45 || emailSize > 45 || usserNameSize > 45 || clave1Size > 45 || clave2Size > 45 || adressSize > 45)
            {
                TempData["lengthError"] = true;
                return RedirectToAction("CrearUsuario");
            }

            //checking que las 2 contraseñas sean iguales con un min de 5 y max de 45 caracteres

            String pass1 = Request.Form["txtClave1"];
            String pass2 = Request.Form["txtClave2"];

            if (!check.CheckPasswords(pass1, pass2))
            {
                TempData["invalidPasswordsUser"] = true;
                return RedirectToAction("CrearUsuario");
            }

            //****************** FIN VALIDACIONES LADO BACK-END *****************//

            //Declaro el objeto usser, implemento el metodo set para guardar los datos de los input
            Usser usser = new Usser();

            usser.Name = Request.Form["txtName"];
            usser.Surname = Request.Form["txtSurname"];
            usser.dateTime = Convert.ToDateTime(Request.Form["date-input"]);
            usser.Email = Request.Form["txtEmail"];
            usser.UsserName = Request.Form["txtUsserName"];
            usser.Pass = Request.Form["txtClave1"];
            usser.Address = Request.Form["txtAddress"];
            usser.AdminType = 2;
            usser.Estado = 1;

            ViewBag.User = usser.Email; //creando la ViewBag.Email con el email del usuario
            return View(usser); //pasando el objeto usser y ViewBag.Email a la vista registrarUsuario.cshtml

        }

        public ActionResult userListarLibros()
        {
            //Guardo en el ViewBag.User el userName guardado en TempData
            ViewBag.User = TempData["User"];
            return View();
        }


        public ActionResult MostrarLibro(int idLibro)
        {
            LibroService ls = new LibroService();
            Libro book = new Libro();
            book = ls.GetBook(idLibro);
            //Obtengo el userName guardado en TempData["User"] TempData es similar a session/LocalStorage
            ViewBag.User = TempData["User"];
            return View(book);
        }

       


        //[HttpPost]
        public ActionResult Comprar()
        {
            //Creo y Guardo en el ViewBag.User el userName guardado en TempData
            ViewBag.User = TempData["User"];
            //?ViewBag.User = Request.Form["user"];

            int tam = Convert.ToInt32(Request.Form["idTotales"]);
            LibroService ls = new LibroService();
            Libro book = new Libro();
            List<Libro> lista = new List<Libro>();

            for (int i = 0; i < tam; i++)
            {
                //pasando los value de los input hidden de userListarLibros
                book = ls.GetBook(Convert.ToInt32(Request.Form[i]));
                lista.Add(book);
            }

            return View(lista);
        }

        public ActionResult CarritoDeCompra(string totalBooks, string[] arrayIdBooks)
        {
            //Creo y Guardo en el ViewBag.User el userName guardado en TempData
            ViewBag.User = TempData["User"];

            if (String.IsNullOrEmpty(totalBooks) || arrayIdBooks == null || arrayIdBooks.Length == 0)
            {
                ViewBag.Msg = "Usted no tiene productos en el carrito";
                return View();
            }

            LightBookService lbs = new LightBookService();
            List<LightBook> list = new List<LightBook>();

            //recorro el arrayIdBooks recibido desde ajax para extraer c/u de los id
            //y pasarselo a la funcion getLightBookById(id) para obtener cada libro
            for (int i = 0; i < arrayIdBooks.Length; i++)
            {
                string id = arrayIdBooks[i];
                list.Add(lbs.getLightBookById(id));
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult userFiltrarLibros(string[] data)
        {
            CheckData check = new CheckData();
            AutorService sa = new AutorService();
            CategoriaService cs = new CategoriaService();
            LibroService ls = new LibroService();
            List<Libro> list = new List<Libro>();
            //Obteniendo los datos enviados desde ajax
            String bookName = data[0];
            String idAutor = data[1];
            String idCategory = data[2];
            String price1 = data[3];
            String price2 = data[4];

            //si no filtra y hace click en "buscar" lista todos los libros
            if (bookName == "" && idAutor == "todos" && idCategory == "todos" && price1 == "" && price2 == "")
            {
                list = ls.ListBooks();
                return View(list);
            }

            String consulta = "SELECT * FROM libros WHERE";
            String estado = " AND libros.estado = 1";
            int cont = 0; // referencia si hay que agregar  el "AND" a la consulta

            //****************** Check back-end *************************//

            if (!String.IsNullOrEmpty(bookName))
            {
                consulta += " libros.nombre LIKE '%" + bookName + "%'";
                cont++;
            }


            if (check.CheckIntNumber(idAutor)) //idAutor es un numero int?
            {
                if (check.CheckIdAutor(idAutor)) //idAutor existe en la base datos?
                {
                    if (cont > 0)
                        consulta += " AND libros.idAutor= " + idAutor;
                    else
                    {
                        consulta += " libros.idAutor= " + idAutor;
                        cont++;
                    }

                }
                else
                {
                    ViewBag.Msg = "Error al recibir el value del autor";
                    return View();
                }

            }
            else if (idAutor != "todos")
            {
                ViewBag.Msg = "Error al recibir el value del autor";
                return View();
            }

            if (check.CheckIntNumber(idCategory)) //idCategory es un numero int?
            {
                if (check.CheckIdCategory(idCategory)) //idCategory existe en la db?
                {
                    if (cont > 0) //si es > a 0 agrego el "AND" a la consulta                  
                        consulta += " AND libros.idCategoria= " + idCategory;
                    else
                    {
                        consulta += " libros.idCategoria= " + idCategory;
                        cont++;
                    }

                }
                else
                {
                    ViewBag.Msg = "Error al recibir el value de la categoria";
                    return View();
                }

            }
            else if (idCategory != "todos")
            {
                ViewBag.Msg = "Error al recibir el value de la categoria";
                return View();
            }

            //check precio 1
            if (check.CheckIntNumber(price1))
            {
                if (cont > 0)
                    consulta += " AND libros.precio >= " + price1;
                else
                {
                    consulta += " libros.precio >= " + price1;
                    cont++;
                }

            }
            else if (!String.IsNullOrEmpty(price1))
            {
                ViewBag.Msg = "Error al recibir el value del precio 1";
                return View();
            }

            //check precio 2
            if (check.CheckIntNumber(price2))
            {
                if (cont > 0)
                    consulta += " AND libros.precio <= " + price2;
                else
                    consulta += " libros.precio <= " + price2;
            }
            else if (!String.IsNullOrEmpty(price2))
            {
                ViewBag.Msg = "Error al recibir el value del precio 2";
                return View();
            }


            //****************** Fin Check back-end *************************//

            list = ls.filtrarLibro(consulta += estado);
            return View(list);
        }

        [HttpPost]
        public ActionResult CompraFinalizada(int[] dataId, int[] dataQuantity, String usuario, String precioTotal)
        {

            //**** Validacion back-end ****

            CheckData check = new CheckData();

            //checking que el array dataId recibido solo tenga numeros int
            for (int i = 0; i <= dataId.Length - 1; i++)
            {
                if (!check.CheckId(dataId[i]))
                {
                    ViewBag.Msg = "Error, los id de libros recibidos, debe ser de tipo int";
                    return View();
                }

            }
            //checking que el array dataQuantity recibido solo tenga numeros int
            for (int i = 0; i <= dataQuantity.Length - 1; i++)
            {
                if (!check.CheckId(dataQuantity[i]))
                {
                    ViewBag.Msg = "Error, el tipo de dato para la 'cantidad' de libros debe ser de tipo int";
                    return View();
                }

            }

            //checking que el String que contiene el nombre de usuario no este vacio
            if (usuario == null || usuario == "")
            {
                ViewBag.Msg = "Error, se necesita el nombre de usuario para realizar la compra!";
                return View();
            }

            //checking si el usuario existe en la base de datos
            UsserService us = new UsserService();

            if (!us.SearchUsserName(usuario))
            {
                ViewBag.Msg = "Error, el nombre de usuario no existe en la base de datos!";
                return View();
            }

            //checking el precioTotal
            if (!check.CheckPrice(precioTotal))
            {
                //Si hay error en el precio creo la Tempdata
                ViewBag.Msg = "El precio es invalido";
                return View();
            }

            //**** fin validaciones back-end *** // 

            ViewBag.Sold = true;
            VentaService vs = new VentaService();
            Venta sale = new Venta();
            decimal totalPrice = decimal.Parse(precioTotal);
            totalPrice = totalPrice / 100;
            //enviando por set
            sale.NombreUsuario = usuario;
            sale.PrecioTotal = totalPrice;
            DateTime actualDate = DateTime.Today;
            sale.Fecha = actualDate;
            //insert en la tabla Ventas de la db
            int afectedRows = vs.InsertSale(sale);

            if (afectedRows > 0)//si se pudo insertar en la tabla ventas, se inserta en detalleVentas
            {

                DetalleVenta saleDetail = new DetalleVenta();
                DetalleVentaService dvs = new DetalleVentaService();

                List<string> list = new List<string>();
                LibroService ls = new LibroService();

                int tam = dataId.Length;

                for (int i = 0; i < tam; i++)
                {
                    int idVenta = dvs.getLastIdVenta();//get ultimo idVenta de la tabla Ventas
                    decimal price = ls.getBookPrice(dataId[i]);//get price del libro
                    //set
                    saleDetail.IdVenta = idVenta;
                    saleDetail.IdLibro = dataId[i];
                    saleDetail.Cantidad = dataQuantity[i];
                    saleDetail.Precio = price;

                    //insert en tabla DetalleVentas de la db
                    int insertRows = dvs.InsertSaleDetail(saleDetail);

                    if (insertRows > 0)//si pudo insertar
                    {
                        list.Add(ls.getBookName(saleDetail.IdLibro));
                        ViewBag.Sold = true;//aviso de compra exitosa                     
                    }
                    else
                        ViewBag.Sold = false;
                }

                if (ViewBag.Sold == true)
                    return View(list);//Enviando a la view lista de la compra reciente
                else
                    return View();

            }

            ViewBag.Sold = false;
            return View();
        }

        public ActionResult MisCompras()
        {
            ViewBag.User = TempData["User"];
            String userName = ViewBag.User;

            if (userName == null)
            {
                ViewBag.Usuario = false;
                return View();
            }

            return View();
        }

        public ActionResult FiltrarCompras(String listAll, String month1, String month2, String year)
        {

            ViewBag.User = TempData["User"];
            CompraService cs = new CompraService();
            String userName = ViewBag.User;
            List<Compra> list = new List<Compra>();

            //Si pulsa el boton todas mis compras
            if (listAll == "si")
            {
                //carga la lista con todas las compras realizadas
                list = cs.ShoppingListbyUser(userName);
            }

            //Si no selecciono las tres opciones desde el filtro de MisCompras.cshtml
            if (month1 == "" || month2 == "" || year == "")
            {
                ViewBag.Msg = "Debe elegir un rango de meses y el año";
                return View();
            }

            if (userName == null)
            {
                ViewBag.Usuario = false;
                return View();
            }

            if (month1 != null && month2 != null && year != null)
            {
                //lista de compra filtrada 
                list = cs.filterPursache(month1, month2, year, userName);
            }

            return View(list);
        }

        public ActionResult Contacto()
        {
            ViewBag.User = TempData["User"];
            return View();
        }

        //[HttpPost]
        public ActionResult userFilterLightBooks(string[] data)
        {
            CheckData check = new CheckData();
            AutorService sa = new AutorService();
            CategoriaService cs = new CategoriaService();
            LightBookService lbs = new LightBookService();
            //LibroService ls = new LibroService();
            List<LightBook> list = new List<LightBook>();
            list = lbs.getListLightBooks();
            List<LightBook> listaPaginada = new List<LightBook>();
            //Obteniendo los datos enviados desde ajax
            String bookName = data[0];
            String idAutor = data[1];
            String idCategory = data[2];
            String price1 = data[3];
            String price2 = data[4];

            //int totalBooks = 0;
            int totalBooks = list.Count();
            int itemsxPage = 20;//cant de items por pagina que quiero mostrar
            int totalPages = 0;

            totalPages = totalBooks % itemsxPage; //obtengo el resto de la division

            if (totalPages != 0) // si de resto no da cero, es un numero decimal
            {
                //redondeo hacia arriba ej 1,7 => lo redondeo a 2
                totalPages = (totalBooks / itemsxPage) + 1;
            }
            else
                totalPages = totalBooks / itemsxPage;

           
            //si no filtra y hace click en "buscar" lista todos los libros
            if (bookName == "" && idAutor == "todos" && idCategory == "todos" && price1 == "" && price2 == "")
            {                             
                //a listaPaginada le voy a guardar los elementos de la lista que 
                //tiene todos los libros desde su indice 0 hasta la cantidad
                //fijada en itemsXpage
                for (int i = 0; i < itemsxPage; i++)
                {
                    listaPaginada.Add(list[i]);
                }
          
                //creando las TempData y ViewBag
                TempData["filterBooks"] = list;                          
                TempData["totalPages"] = totalPages;
                ViewBag.TotalPages = totalPages;
                ViewBag.ItemsxPage = itemsxPage;
                ViewBag.Resultados = totalBooks;
                return View(listaPaginada);
            }

            String consulta = "SELECT * FROM libros WHERE";
            String estado = " AND libros.estado = 1";
            int cont = 0; // referencia si hay que agregar  el "AND" a la consulta

            //****************** Check back-end *************************//

            if (!String.IsNullOrEmpty(bookName))
            {
                consulta += " libros.nombre LIKE '%" + bookName + "%'";
                cont++;
            }


            if (check.CheckIntNumber(idAutor)) //idAutor es un numero int?
            {
                if (check.CheckIdAutor(idAutor)) //idAutor existe en la base datos?
                {
                    if (cont > 0)
                        consulta += " AND libros.idAutor= " + idAutor;
                    else
                    {
                        consulta += " libros.idAutor= " + idAutor;
                        cont++;
                    }

                }
                else
                {
                    ViewBag.Msg = "Error al recibir el value del autor";
                    return View();
                }

            }
            else if (idAutor != "todos")
            {
                ViewBag.Msg = "Error al recibir el value del autor";
                return View();
            }

            if (check.CheckIntNumber(idCategory)) //idCategory es un numero int?
            {
                if (check.CheckIdCategory(idCategory)) //idCategory existe en la db?
                {
                    if (cont > 0) //si es > a 0 agrego el "AND" a la consulta                  
                        consulta += " AND libros.idCategoria= " + idCategory;
                    else
                    {
                        consulta += " libros.idCategoria= " + idCategory;
                        cont++;
                    }

                }
                else
                {
                    ViewBag.Msg = "Error al recibir el value de la categoria";
                    return View();
                }

            }
            else if (idCategory != "todos")
            {
                ViewBag.Msg = "Error al recibir el value de la categoria";
                return View();
            }

            //check precio 1
            if (check.CheckIntNumber(price1))
            {
                if (cont > 0)
                    consulta += " AND libros.precio >= " + price1;
                else
                {
                    consulta += " libros.precio >= " + price1;
                    cont++;
                }

            }
            else if (!String.IsNullOrEmpty(price1))
            {
                ViewBag.Msg = "Error al recibir el value del precio 1";
                return View();
            }

            //check precio 2
            if (check.CheckIntNumber(price2))
            {
                if (cont > 0)
                    consulta += " AND libros.precio <= " + price2;
                else
                    consulta += " libros.precio <= " + price2;
            }
            else if (!String.IsNullOrEmpty(price2))
            {
                ViewBag.Msg = "Error al recibir el value del precio 2";
                return View();
            }


            //****************** Fin Check back-end *************************//

            list = lbs.filterLightBook(consulta += estado);
       
            totalBooks = list.Count<LightBook>();

            if(totalBooks > itemsxPage)
            {
                for (int i = 0; i < itemsxPage; i++)
                {
                    listaPaginada.Add(list[i]);
                }
                //creando las tempDatay ViewBag
                TempData["filterBooks"] = list;
                TempData["totalPages"] = totalPages;
                ViewBag.ItemsxPage = itemsxPage;
                ViewBag.TotalPages = totalPages;
                ViewBag.Resultados = totalBooks;
                return View(listaPaginada);
            }
            else
            {
                //creando las tempData y ViewBag
                TempData["filterBooks"] = list;
                TempData["totalPages"] = totalPages;
                ViewBag.ItemsxPage = itemsxPage;
                ViewBag.TotalPages = totalPages;
                ViewBag.Resultados = totalBooks;
                return View(list);
            }
            
    
        }

        public ActionResult Paginar(string numberPage)
        {           
            List<LightBook> list = new List<LightBook>();
            List<LightBook> listaPaginada = new List<LightBook>();
            LightBookService lbs = new LightBookService();
            int totalPages = 1;

            //Las tempData fueron creadas en ActionResult userFilterLightBooks
            if (TempData["filterBooks"] != null && TempData["totalPages"] != null)
            {
                list = TempData["filterBooks"] as List<LightBook>;
                totalPages = Convert.ToInt32(TempData["totalPages"]);
            }               
                          
            int totalBooks = list.Count<LightBook>();
            int booksxPage = 20; //tiene que tener el mismo valor que figura en userFilterLightBooks
            int page = Convert.ToInt32(numberPage);

            listaPaginada = lbs.getFilteredPaginationList(list, booksxPage, page, totalPages);
            
            //ViewBag.TotalPages = totalPages;
            ViewBag.TotalPages = totalPages;
            return View(listaPaginada);

        }

    }
}