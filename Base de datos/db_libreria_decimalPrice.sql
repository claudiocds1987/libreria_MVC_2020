-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: localhost    Database: libreria
-- ------------------------------------------------------
-- Server version	5.7.26-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `admin`
--

DROP TABLE IF EXISTS `admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `admin` (
  `Email` varchar(45) NOT NULL,
  `Nombre` varchar(45) NOT NULL,
  `Apellido` varchar(45) NOT NULL,
  `Pass` varchar(45) NOT NULL,
  `Estado` tinyint(4) NOT NULL,
  PRIMARY KEY (`Email`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin`
--

LOCK TABLES `admin` WRITE;
/*!40000 ALTER TABLE `admin` DISABLE KEYS */;
INSERT INTO `admin` VALUES ('cla8787@gmail.com','Claudio','Schneider','admin',1);
/*!40000 ALTER TABLE `admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `autores`
--

DROP TABLE IF EXISTS `autores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `autores` (
  `idAutor` int(11) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`idAutor`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `autores`
--

LOCK TABLES `autores` WRITE;
/*!40000 ALTER TABLE `autores` DISABLE KEYS */;
INSERT INTO `autores` VALUES (1,'Felipe Pigna'),(2,'Stephen King'),(3,'Miguel De Cervantes'),(4,'George R. R. Martin'),(5,'J.K Rowling'),(6,'Neil Gaiman'),(7,'E.L. James '),(8,'The Crazy Haacks'),(9,'Paul Krugman'),(10,'Daniel López Rosetti');
/*!40000 ALTER TABLE `autores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categorias`
--

DROP TABLE IF EXISTS `categorias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `categorias` (
  `idCategoria` int(11) NOT NULL,
  `nombreCategoria` varchar(45) NOT NULL,
  PRIMARY KEY (`idCategoria`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorias`
--

LOCK TABLES `categorias` WRITE;
/*!40000 ALTER TABLE `categorias` DISABLE KEYS */;
INSERT INTO `categorias` VALUES (1,'Fantasia'),(2,'Terror'),(3,'Ciencia Ficcion'),(4,'Thriller'),(5,'Suspenso'),(6,'Accion'),(7,'Romance'),(8,'Historicos'),(9,'Biografias'),(10,'Infantiles'),(11,'Novela'),(12,'Economia'),(13,'Autoayuda');
/*!40000 ALTER TABLE `categorias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalleventas`
--

DROP TABLE IF EXISTS `detalleventas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `detalleventas` (
  `IdVenta` int(11) NOT NULL,
  `IdLibro` int(11) NOT NULL,
  `Cantidad` int(11) NOT NULL,
  `Precio` decimal(8,2) NOT NULL,
  PRIMARY KEY (`IdVenta`,`IdLibro`),
  KEY `FK_DetallexLibro_idx` (`IdLibro`),
  CONSTRAINT `FK_DetallexLibro` FOREIGN KEY (`IdLibro`) REFERENCES `libros` (`IdLibro`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_Venta_Detalle` FOREIGN KEY (`IdVenta`) REFERENCES `ventas` (`IdVenta`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalleventas`
--

LOCK TABLES `detalleventas` WRITE;
/*!40000 ALTER TABLE `detalleventas` DISABLE KEYS */;
INSERT INTO `detalleventas` VALUES (1,18,1,700.00),(2,23,1,500.00),(3,18,2,250.00),(4,24,2,450.00),(5,23,2,500.00),(6,23,1,500.00),(7,19,1,150.24),(7,23,1,500.00),(8,23,1,500.00),(9,23,1,500.00),(10,23,1,500.00),(11,45,1,990.00),(11,51,1,800.25),(12,18,1,700.00),(13,18,1,700.00),(13,23,1,500.00),(14,25,1,880.00),(14,39,1,300.00),(15,18,1,700.00),(15,39,4,300.00),(16,18,2,700.00),(16,19,1,150.24),(16,25,1,880.00),(16,39,1,300.00),(17,18,1,700.00),(17,25,1,880.00),(18,18,1,700.00),(18,19,1,150.24),(19,18,2,700.00),(20,19,2,1500.28),(20,23,1,500.00),(21,51,1,800.00),(22,45,1,990.00),(22,51,1,800.00),(23,63,2,900.98);
/*!40000 ALTER TABLE `detalleventas` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER tr_subtractBookStock
AFTER INSERT ON detalleventas
FOR EACH ROW
UPDATE libros
SET cantidad = cantidad - new.Cantidad
WHERE IdLibro = new.IdLibro */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `editoriales`
--

DROP TABLE IF EXISTS `editoriales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `editoriales` (
  `IdEditorial` int(11) NOT NULL,
  `nombreEditorial` varchar(45) NOT NULL,
  PRIMARY KEY (`IdEditorial`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `editoriales`
--

LOCK TABLES `editoriales` WRITE;
/*!40000 ALTER TABLE `editoriales` DISABLE KEYS */;
INSERT INTO `editoriales` VALUES (1,'Austral'),(2,'Alienta Editorial'),(3,'Black List'),(4,'Boocket'),(5,'Click Ediciones'),(6,'Ediciones Martinez Roca'),(7,'Ediciones Oniro'),(8,'Ediciones Peninsula'),(9,'Lectura Plus'),(10,'Vintage Books'),(11,'Montena'),(12,'Editorial Crítica'),(13,'Editorial Planeta'),(14,'Editorial Estrada'),(15,'Planeta Comic'),(16,'Planeta Diagostini');
/*!40000 ALTER TABLE `editoriales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `libros`
--

DROP TABLE IF EXISTS `libros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `libros` (
  `IdLibro` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `anioDeLanzamiento` int(11) NOT NULL,
  `idAutor` int(11) NOT NULL,
  `idCategoria` int(11) NOT NULL,
  `idEditorial` int(11) NOT NULL,
  `descripcion` mediumtext,
  `cantidad` int(11) NOT NULL,
  `precio` decimal(8,2) NOT NULL,
  `urlImagen` tinytext,
  `estado` tinyint(4) NOT NULL DEFAULT '1',
  PRIMARY KEY (`IdLibro`),
  KEY `FK_LibroXAutor_idx` (`idAutor`),
  KEY `FK_LibroXCategoria_idx` (`idCategoria`),
  KEY `FK_LibroXEditorial_idx` (`idEditorial`),
  CONSTRAINT `FK_LibroXAutor` FOREIGN KEY (`idAutor`) REFERENCES `autores` (`idAutor`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_LibroXCategoria` FOREIGN KEY (`idCategoria`) REFERENCES `categorias` (`idCategoria`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_LibroXEditorial` FOREIGN KEY (`idEditorial`) REFERENCES `editoriales` (`IdEditorial`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `libros`
--

LOCK TABLES `libros` WRITE;
/*!40000 ALTER TABLE `libros` DISABLE KEYS */;
INSERT INTO `libros` VALUES (18,'Los Mitos de la Historia Argentina 2',2011,1,8,2,'En este nuevo libro Felipe Pigna recorre una de las etapas más apasionantes de nuestra historia para entender la identidad argentina: los acontecimientos y los protagonistas fundamentales en el siglo que va desde la lucha emancipadora de San Martín.',48,700.00,'principal/imagenes/LosMitosDeLaHistoriaArgentina2.jpg',1),(19,'Don Quijote de la Mancha',1605,3,11,5,'El hidalgo manchego don Alonso Quijano  llamado el Bueno, enloquece leyendo libros de caballerías y, con el nombre de don Quijote de la Mancha y su viejo caballo Rocinante, se lanza por la Mancha guiado por nobles ideales',45,1700.00,'principal/imagenes/DonQuijote.jpg',1),(23,'Juego de tronos nueva edición parte uno ',2016,4,1,15,'Robert Baratheon, rey de los 7 Reinos, pide a Eddard Stark, sabio Señor de Invernalia, que ocupe el puesto vacante de consejero real, tras la misteriosa muerte del que hasta entonces tenía el cargo. Ello supondrá dejar atrás a su familia y que las intrigas palaciegas dominen su existencia.\r\nEn el Mar Angosto, una joven e inocente dama de nombre Daenerys Targaryen se ve obligada por su hermano a casarse con el implacable líder Dorthraki, Khal Drogo.Planeta Cómic tiene el placer de presentar la ad',41,500.00,'principal/imagenes/juego-de-tronos-nueva-edicion-0104.jpg',1),(24,'La caja de botones de Gwendy',2017,2,2,9,'La pequeña ciudad de Castle Rock, en Maine, ha sido testigo de algunos extraños sucesos, pero solo hay una historia que no se ha contado... hasta ahora.',50,450.00,'principal\\imagenes\\La caja de botones de Gwendy.jpg',1),(25,'La voz del Gran Jefe ',2014,1,8,4,'José de San Martín es uno de los hombres más nombrados y más homenajeados de nuestro país y a la vez, paradójicamente, uno de los menos conocidos en toda su dimensión',47,880.00,'principal/imagenes/LaVozDelGran Jefe.jpg',1),(26,'Apocalipsis',1978,2,2,1,'Esta narración cuenta cómo un virus gripal, creado artificialmente como posible arma bacteriológica, se extiende por Estados Unidos y provoca la muerte de millones de personas',20,1349.00,'principal/imagenes/Apocalipsis.jpg',1),(39,'Cincuenta Sombras De Grey',2011,7,11,10,'primera entrega de una trilogía que describe la relación entre una recién graduada de la universidad, Anastasia Steele, y el joven magnate de negocios Christian Grey. ',14,300.00,'principal/imagenes/CincuentaSombrasDeGrey.jpg',1),(40,'The Crazy Haacks Y La Camara Imposible',2018,8,10,11,'Hola, locos! Ya saben que a no hay NADA que se nos resista. Pero... ¿una cámara con PODERES? Eso no estaba previsto! Esta cámara es capaz de lo mejor (y de lo peor!). ¿Están preparados?.',20,589.00,'principal/imagenes/TheCrazyHaacksYLaCamaraImposible.jpg',1),(41,'asda',2019,1,1,1,'fsdfsd',20,1500.00,'principal/imagenes/Apocalipsis.jpg',1),(42,'Contra los zombis',2020,9,12,2,'fasfhjkhg',20,890.00,'principal/imagenes/ContraLosZombis.jpg',1),(43,'La vida por la patria',2017,1,9,5,'Mariano Moreno tiene la rara cualidad de ser alabado o atacado por ideas que nunca sostuvo y propuestas que nunca formuló. La imagen de un Moreno liberal, unitario o ¿porteñista¿, por la cual la historia oficial lo llevó al bronce de las estatuas y buena ',20,1200.00,'principal/imagenes/la_vida_por_la_patria_grande.jpg',1),(44,'Harry Potter and the sorcerer\'s stone',2019,2,1,1,'no se ni idea',20,1500.00,'principal/imagenes/Harry Potter and the sorcerer\'s stone.jpg',1),(45,'Equilibrio',2019,10,13,13,'Con rigor, erudición, y a la vez con didactismo y amenidad, armado de literaturas, pero también de estudios técnicos de última generación, López Rosetti nos explica cómo pensamos, cómo sentimos y cómo tomamos decisiones, en un largo y minucioso escaneo de',19,990.00,'principal/imagenes/Equilibrio.jpg',1),(51,' Mujeres tenian que ser',2011,1,8,4,'Charles Fourier aseguraba que “los progresos sociales y cambios de época se operan en proporción al progreso de las mujeres hacia la libertad”. Esta obra recorre el protagonismo de las mujeres en la historia argentina, desde las pobladoras originarias hasta quienes obtuvieron las primeras victorias en su lucha por la igualdad. También aborda la vida cotidiana, las condiciones legales, sociales y culturales, la participación femenina en los procesos históricos, políticos y económicos.',18,800.00,'principal/imagenes/mujeres-tenian-que-ser.jpg',1),(52,'Choque de reyes canción de hielo y fuego II',2020,4,1,15,'Después de los hechos de \"Juego de Tronos\", la guerra civil asoma en Poniente cuando Daenerys Targaryen, como heredera de la dinastía Targaryen, busca reclamar el Trono de hierro. Arya, con la ayuda de Yoren, un hermano de la Guardia de la Noche, ha huido de Desembarco del Rey pero el camino hasta el Muro está lleno de peligros. Mientras tanto, Sansa acude a un torneo en honor del Rey Joffrey y Bran, en Invernalia, sufre extraños sueños con lobos.',20,1500.00,'principal/imagenes/juego de tronos choque de reyes.jpg',1),(53,'Cambiar el título ',2020,1,1,1,'gdfgdfgdfg',1,1500.00,'principal/imagenes/configurar.png',1),(54,'Juego de tronos nueva edicion parte dos',2017,4,1,15,'En esta segunda parte, el argumento se intensifica y se comienza a desvelar las personalidades de los protagonistas principales y sus ansias de poder sobre los Siete Reinos. En el Mar Angosto, Daenerys, sufre los delirios de grandeza de su hermano.',0,1500.00,'principal/imagenes/juego-de-tronos-nueva-edicion-0204.jpg',1),(55,'juego de tronos nueva edicion parte tres',2018,4,1,15,'La vida de los Stark nada tiene que ver con su antigua existencia. Desde que su patricarca fuera nombrado Mano del Rey, traiciones, ataques y muertes acechan al clan, gracias a la implacable familia Lannister. Mientras, la bella e ingenua Danaerys va perdiendo su inocencia tras los últimos acontecimientos en el Mar Angosto.',0,1500.00,'principal/imagenes/juego-de-tronos-nueva-edicion-0304.jpg',1),(56,'juego de tronos nueva edicion parte cuatro',2019,4,1,15,'Después de una traición, siempre viene una venganza. Y ésta será temible e involucrará a los 7 Reinos. Una nueva vuelta de tuerca al argumento está servida. ¿El Bien logrará vencer al Mal? ¿Acaso todo es blanco o negro en un juego de tronos?.Este volumen cierra la adaptación de la novela Juego de tronos, la primera entrega de Canción de Hielo y Fuego, la saga bestseller en todo el mundo que ha ocupado los primeros cuatro volúmenes de esta serie de novelas gráficas.',0,1500.00,'principal/imagenes/juego-de-tronos-nueva-edicion-0404.jpg',1),(57,'dasdasdasa',2020,1,1,1,'asa canción',20,1500.00,'',1),(58,'prueba',2020,1,1,1,'fdssfas',20,1500.00,'principal/imagenes/carrito.jpg',1),(59,'esa eh',2020,1,1,1,'kjhkjhk',2,1.00,'',1),(60,'caca',2020,1,1,1,'fghfgh',25,2825.00,'',1),(61,'hfghdff sdasd asd',2020,1,1,1,'a',2,50010.00,'',1),(62,'Scooby Doo',2020,1,1,1,'dsgsdgsd',5,1200.00,'',1),(63,'Capitan America',2020,1,1,1,'afasfasfa',0,900.98,'',1);
/*!40000 ALTER TABLE `libros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `usuarios` (
  `Nombre` varchar(45) NOT NULL,
  `apellido` varchar(45) NOT NULL,
  `fechaNacimiento` date NOT NULL,
  `Email` varchar(45) NOT NULL,
  `NombreUsuario` varchar(45) NOT NULL,
  `pass` varchar(45) NOT NULL,
  `Domicilio` varchar(45) NOT NULL,
  `adminType` tinyint(4) NOT NULL,
  `estado` tinyint(4) DEFAULT '1',
  PRIMARY KEY (`NombreUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES ('caca','Gonzales','1998-10-10','skapp@gmail.com','a','jose ert','Av Perón 258',2,1),('cds','Schneider','1998-10-10','cds@gmail.com','cds','cds','Av.Peron 2046',2,1),('Claudio','Schneider','1987-09-16','cla8787@gmail.com','clau','admin','Quirno Costa 918 San Fernando',2,1),('ed','Gonzales','1998-10-10','skapp@gmail.com','clepto','12345','Av Perón 258',2,1),('ed','Gonzales','1987-10-10','skapp@gmail.com','dasdasdasd','12345','Av Perón 258',2,1),('Alejandro','Pederiva','1987-07-14','korto_77@gmail.com','korto','12345','Arias 1814',2,1);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ventas`
--

DROP TABLE IF EXISTS `ventas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `ventas` (
  `IdVenta` int(11) NOT NULL AUTO_INCREMENT,
  `NombreUsuario` varchar(45) NOT NULL,
  `PrecioTotal` decimal(8,2) NOT NULL,
  `Fecha` date NOT NULL,
  PRIMARY KEY (`IdVenta`),
  KEY `FK_VentasXUsuario_idx` (`NombreUsuario`),
  CONSTRAINT `FK_VentasXUsuario` FOREIGN KEY (`NombreUsuario`) REFERENCES `usuarios` (`NombreUsuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ventas`
--

LOCK TABLES `ventas` WRITE;
/*!40000 ALTER TABLE `ventas` DISABLE KEYS */;
INSERT INTO `ventas` VALUES (1,'cds',700.00,'2019-07-13'),(2,'cds',500.00,'2019-07-13'),(3,'cds',500.00,'2018-08-10'),(4,'cds',900.00,'2019-07-15'),(5,'clau',1000.00,'2019-07-15'),(6,'clau',500.00,'2019-07-15'),(7,'clau',650.24,'2019-07-16'),(8,'clau',500.00,'2020-04-28'),(9,'clau',500.00,'2020-04-28'),(10,'clau',500.00,'2020-04-28'),(11,'clau',1790.25,'2020-04-28'),(12,'clau',700.00,'2020-04-30'),(13,'clau',1200.00,'2020-04-30'),(14,'clau',1180.00,'2020-05-06'),(15,'clau',1900.00,'2020-05-07'),(16,'cds',2730.24,'2020-05-07'),(17,'clau',1580.00,'2020-05-10'),(18,'clau',850.24,'2020-05-12'),(19,'clau',1400.00,'2020-05-14'),(20,'clau',3500.56,'2020-05-19'),(21,'korto',800.00,'2020-05-21'),(22,'clau',1790.00,'2020-05-26'),(23,'clau',1801.96,'2020-05-27');
/*!40000 ALTER TABLE `ventas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'libreria'
--

--
-- Dumping routines for database 'libreria'
--
/*!50003 DROP PROCEDURE IF EXISTS `DeleteBook` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`admin`@`%` PROCEDURE `DeleteBook`(
_IdLibro int(11)
)
BEGIN
update libros set
estado = 0
where IdLibro = _idLibro;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertAdmin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertAdmin`(
_Email varchar(45),
_Nombre varchar(45),
_Apellido varchar(45),
_Pass varchar(45),
_Estado int(4)
)
BEGIN
INSERT INTO admin(
Email,
Nombre,
Apellido, 
Pass,
Estado
)
VALUES(
_Email,
_Nombre,
_Apellido,
_Pass,
_Estado 
);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertBook` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`admin`@`%` PROCEDURE `InsertBook`(
_nombre varchar(100), 
_anioDeLanzamiento int(11), 
_idAutor int(11),
_idCategoria int(11), 
_idEditorial int(11), 
_descripcion mediumtext, 
_cantidad int(11), 
_precio decimal(8,2), 
_urlImagen tinytext, 
_estado tinyint(4)
)
BEGIN
INSERT INTO libros(
nombre, 
anioDeLanzamiento, 
idAutor,
idCategoria, 
idEditorial, 
descripcion, 
cantidad, 
precio, 
urlImagen, 
estado
)
VALUES(
_nombre, 
_anioDeLanzamiento, 
_idAutor,
_idCategoria, 
_idEditorial, 
_descripcion, 
_cantidad, 
_precio, 
_urlImagen, 
_estado
);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertSale` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertSale`(
_NombreUsuario varchar(45),
_PrecioTotal decimal(8,2),
_Fecha datetime
)
BEGIN
INSERT INTO ventas(
NombreUsuario,
PrecioTotal,
Fecha
)
VALUES(
_NombreUsuario,
_PrecioTotal,
_Fecha
);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertSaleDetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertSaleDetail`(
_IdLibro int,
_Cantidad int,
_Precio decimal(8,2)
)
BEGIN
INSERT INTO detalleventas(
IdVenta, 
IdLibro,
Cantidad,
Precio)
SELECT(SELECT idVenta from ventas order by IdVenta Desc Limit 1),
_IdLibro,
_Cantidad,
_Precio;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `InsertUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`admin`@`%` PROCEDURE `InsertUser`(
_nombre varchar(45),
_apellido varchar(45),
_fechaNacimiento datetime,
_email varchar(45),
_nombreUsuario varchar(45),
_pass varchar(45),
_domicilio varchar(45),
_adminType int(4),
_estado int(4)
)
BEGIN
INSERT INTO usuarios(
Nombre,
apellido, 
fechaNacimiento, 
Email,
NombreUsuario,
pass,
Domicilio,
adminType,
estado
)
VALUES(
_nombre,
_apellido,
_fechaNacimiento,
_email,
_nombreUsuario,
_pass,
_domicilio,
_adminType,
_estado
);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UpdateBook` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`admin`@`%` PROCEDURE `UpdateBook`(
_IdLibro int(11),
_nombre varchar(100), 
_anioDeLanzamiento int(11), 
_idAutor int(11),
_idCategoria int(11), 
_idEditorial int(11), 
_descripcion mediumtext, 
_cantidad int(11), 
_precio decimal(8,2), 
_urlImagen tinytext, 
_estado tinyint(4)
)
BEGIN
update libros set
nombre = _nombre, 
anioDeLanzamiento = _anioDeLanzamiento,
idAutor = _idAutor,
idCategoria = _idCategoria,
idEditorial = _idEditorial,
descripcion = _descripcion,
cantidad = _cantidad,
precio = _precio,
urlImagen = _urlImagen,
estado = _estado
where IdLibro = _idLibro;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-28 14:04:15
