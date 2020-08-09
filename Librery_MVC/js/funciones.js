

//function loadPriceWithDecimalDot(idInput) {

//    var getprice = $('#'+ idInput).val();
//    //si es num decimal, cambio la coma ","por el punto "." para poder hacer el calculo
//    var price = parseFloat(getprice.replace(/,/g, "."));
//    $('#' + idInput).val(price)
//}

/*---------------------------------------------------------------------------- 
 * FUNCTION: cleanUnnecessaryWhiteSpaces(R).                                                                                                     
 * PARAMETRO: inputText(this), id del input text.                                                                                                                                  
 * ACTION: Elimina espacios en blanco innecesarios. 
 * Funcion util para titulos o descripciones.
 *                                                                                                                                                                                         
 *---------------------------------------------------------------------------*/
 function cleanUnnecessaryWhiteSpaces(inputText, idInputText) {

     let word = inputText.value;    
     word = word.replace(/\s{2,}/g, ' ').trim();     
     $(idInputText).val(word);

 }

/********************************************************************************
 * FUNCTION: Pagination(List, itemsxPage, numberPage, IdDiv)
 * 
 * PARAMETROS: 1) una Lista. 2) cantidad de items que deseo mostrar por página.
 *             3) La página que quiero mostrar. 4) el id del div donde quiero
 *                mostrar la paginación.
 *                
 * ACLARACIÓN: Esta funcion debe incorporar a la función "doPagination".
 * 
 * nota: la cantidad de itemsxPage elegidos debe ser menor o igual a la cantidad
 * total de items que hay en la Lista.
 * 
********************************************************************************/
function Pagination(originalList, booksxPage, numberPage, idDiv) {

    if (numberPage == 1) {

        doPagination(1);
    }
    else {
        
        doPagination(page);
    }

}

/********************************************************************************
 * FUNCTION: doPagination(page)
 * PARAMETROS: numero de página.
 * ACTION: Segun la página elegida va a determinar como recorrer la lista de items
 * 
 * ACLARACIÓN: Esta funcion necesita estar adentro de la funcion Pagination,
 *             ya que de la misma necesita utilizar "List, itemsxPage, numberPage, 
 *             idDiv".
 * 
 * nota: Esta funcíon es llamada desde la función "buttonsPagination"
 * 
********************************************************************************/

function doPagination(page) {

    var numberPage = 0;

    if (page == 1) {

        numberPage = 1
    }
    else {

        numberPage = page.value;//recibe el value del boton clickeado en la funcion  buttonsPagination()

    }

    //Cuento el total de libros que hay en la lista original
    var totalBooks = originalList.length;
    var desde = 0;
    var hasta = 0;

    if (booksxPage > totalBooks) {


        //alert("Error de paginación. La cantidad de items por pagina debe ser menor al total de items de la lista")
        //return;
        hasta = totalBooks - 1;
    }
    else {

        var pages = totalBooks % booksxPage; //obtengo el resto de la division

        if (pages != 0) // si de resto no da cero, es un numero decimal
        {
            //Math.ceil redondea hacia arriba ej 1,7 => lo redondeo a 2
            pages = Math.ceil(totalBooks / booksxPage);
        }
        else
            pages = totalBooks / booksxPage;

        var pos = [pages];
        var cont = 0;
        var librosAmostrar = 0;
        var librosListados = 0;

        //guardo en el vector las diferentes formas de iniciar el recorrido de la lista
        //segun la cantidad de booksxPage

        for (var i = 0; i < pages; i++) {

            if (i == 0) {

                pos.splice(0, 0, 0);//0: numero de indice, 0: elementos a borrar, 0: agrego un cero al array
                cont = booksxPage;
            }
            else {

                pos.splice(i, 0, cont);
                cont += booksxPage;
                librosListados += booksxPage;
                librosAmostrar = totalBooks - librosListados;
            }
        }

        //determinando los indices para recorrer la lista segun la pagina elegida
        if (numberPage == 1) {

            desde = pos[0];
            hasta = (desde + booksxPage) - 1;
        }

        else if (numberPage == pages) {

            desde = totalBooks - librosAmostrar;
            hasta = totalBooks - 1;
        }

        else {

            desde = pos[numberPage - 1];
            hasta = (desde + booksxPage) - 1;
        }

        //Creando la estructura para mostrar la lista de libros

        var data = "";

        for (var z = desde; z <= hasta; z++) {
            
            data += "<div class='container-image text-center fade-in'>";

            data += "<img src='/" + originalList[z].UrlImagen + "' alt='" + originalList[z].Nombre + "'>";

            data += "<div class='title-book text-center'>";

            data += '<a href="#" ' + 'value="' + originalList[z].IdLibro + '"' + ' onclick="sendToActionMostrarLibro(' + originalList[z].IdLibro + ');">' + originalList[z].Nombre + '(' + originalList[z].AnioDeLanzamiento + ')</a>';

            data += "</div>"

            data += "<div class='price-book text-center'>" + "$" + originalList[z].Precio + "</div>";

            data += "</div>";

        }
        //si previamente existen elementos en el div, ".html(data)" los borra y pone los nuevos elementos.
        $(idDiv).html(data);
    }

}

/********************************************************************************
 * FUNCTION: buttonsPagination(totalItems, itemsxPage, idDiv)
 * PARAMETROS: 1) cantidad de items totales.
 *             2) cantidad de items que se desea mostrar por página.
 *             3) id del div donde deseo mostrar los botones de la paginación.
 * 
 * ACTION: Crea los botones para hacer la paginación 
 * 
 * ACLARACIÓN: "totalItems" e "itemsxPage" deben ser los mismos que hay en la
 *             función Pagination.
 * 
********************************************************************************/

function buttonsPagination(totalBooks, booksxPage, idDiv) {

    var pages = totalBooks % booksxPage; //obtengo el resto de la division
    var buttons = "";
    if (pages != 0) // si de resto no da cero, es un numero decimal
    {
        //Math.ceil redondea hacia arriba ej 1,7 => lo redondeo a 2
        pages = Math.ceil(totalBooks / booksxPage);
    }
    else
        pages = totalBooks / booksxPage;

    //Creando los botones del pagination
    if (pages >= 1) {

        for (var d = 1; d <= pages; d++) {

            buttons += "<button type=button value='" + d + "' class='pagination-btns' onclick='doPagination(this);'>" + d + "</button>"

        }

        $(idDiv).html(buttons);
    }
    else {
        var button = '<button type=button value="1" class="pagination-btns" onclick="doPagination(this);">1</button>)';
        $(idDiv).html(button);
    }

}


function disabledInput(idInput) {
    
    $(idInput).val('');
    $(idInput).attr('disabled', 'disabled');
}

function enableInput(idInput) {

    $(idInput).removeAttr('disabled');
}



function CheckNombreCompuesto(nombre) {

    let regex = /^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$/g;

    if (!regex.test(nombre))  
        return false;          
}



