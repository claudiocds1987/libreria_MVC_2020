-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: localhost    Database: libreria
-- ------------------------------------------------------
-- Server version	5.7.26-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 /* SET NAMES utf8 ; */
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `admin`
--

DROP TABLE IF EXISTS [admin];
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET @character_set_client = utf8mb4 ;
CREATE TABLE admin (
  [Email] varchar(45) NOT NULL,
  [Nombre] varchar(45) NOT NULL,
  [Apellido] varchar(45) NOT NULL,
  [Pass] varchar(45) NOT NULL,
  [Estado] smallint NOT NULL,
  PRIMARY KEY ([Email])
) ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin`
--

LOCK TABLES [admin] WRITE;
/*!40000 ALTER TABLE `admin` DISABLE KEYS */;
INSERT INTO admin VALUES ('cla8787@gmail.com','Claudio','Schneider','admin',1),('crud@gmail.com','Camila','Stevens','hola',1),('paula@gmail.com','Paula','Fernandez','12345',1);
/*!40000 ALTER TABLE `admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `autores`
--

DROP TABLE IF EXISTS [autores];
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET @character_set_client = utf8mb4 ;
CREATE TABLE autores (
  [idAutor] int NOT NULL,
  [nombre] varchar(45) NOT NULL,
  PRIMARY KEY ([idAutor])
) ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `autores`
--

LOCK TABLES [autores] WRITE;
/*!40000 ALTER TABLE `autores` DISABLE KEYS */;
INSERT INTO autores VALUES (1,'Felipe Pigna'),(2,'Stephen King'),(3,'Miguel De Cervantes'),(4,'George R. R. Martin'),(5,'J.K Rowling'),(6,'Neil Gaiman'),(7,'E.L. James '),(8,'The Crazy Haacks'),(9,'Paul Krugman'),(10,'Daniel López Rosetti'),(11,'Gustavo Roldán'),(12,'Silvia Arazi'),(13,'Julie Camel'),(14,'Marvel'),(15,'Javier Valverde Ledesma'),(16,'Bernardo Stamateas');
/*!40000 ALTER TABLE `autores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categorias`
--

DROP TABLE IF EXISTS [categorias];
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET @character_set_client = utf8mb4 ;
CREATE TABLE categorias (
  [idCategoria] int NOT NULL,
  [nombreCategoria] varchar(45) NOT NULL,
  PRIMARY KEY ([idCategoria])
) ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorias`
--

LOCK TABLES [categorias] WRITE;
/*!40000 ALTER TABLE `categorias` DISABLE KEYS */;
INSERT INTO categorias VALUES (1,'Fantasia'),(2,'Terror'),(3,'Ciencia Ficcion'),(4,'Thriller'),(5,'Suspenso'),(6,'Accion'),(7,'Romance'),(8,'Historicos'),(9,'Biografias'),(10,'Infantiles'),(11,'Novela'),(12,'Economia'),(13,'Autoayuda');
/*!40000 ALTER TABLE `categorias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalleventas`
--

DROP TABLE IF EXISTS [detalleventas];
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET @character_set_client = utf8mb4 ;
CREATE TABLE detalleventas (
  [IdVenta] int NOT NULL,
  [IdLibro] int NOT NULL,
  [Cantidad] int NOT NULL,
  [Precio] decimal(8,2) NOT NULL,
  PRIMARY KEY ([IdVenta],[IdLibro])
 ,
  CONSTRAINT [FK_DetallexLibro] FOREIGN KEY ([IdLibro]) REFERENCES libros ([IdLibro]) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT [FK_Venta_Detalle] FOREIGN KEY ([IdVenta]) REFERENCES ventas ([IdVenta]) ON DELETE NO ACTION ON UPDATE NO ACTION
) ;

CREATE INDEX [FK_DetallexLibro_idx] ON detalleventas ([IdLibro]);
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalleventas`
--

LOCK TABLES [detalleventas] WRITE;
/*!40000 ALTER TABLE `detalleventas` DISABLE KEYS */;
INSERT INTO detalleventas VALUES (1,18,1,700.00),(2,23,1,500.00),(3,18,2,250.00),(4,24,2,450.00),(5,23,2,500.00),(6,23,1,500.00),(7,19,1,150.24),(7,23,1,500.00),(8,23,1,500.00),(9,23,1,500.00),(10,23,1,500.00),(11,45,1,990.00),(11,51,1,800.25),(12,18,1,700.00),(13,18,1,700.00),(13,23,1,500.00),(14,25,1,880.00),(14,39,1,300.00),(15,18,1,700.00),(15,39,4,300.00),(16,18,2,700.00),(16,19,1,150.24),(16,25,1,880.00),(16,39,1,300.00),(17,18,1,700.00),(17,25,1,880.00),(18,18,1,700.00),(18,19,1,150.24),(19,18,2,700.00),(20,19,2,1500.28),(20,23,1,500.00),(21,51,1,800.00),(22,45,1,990.00),(22,51,1,800.00),(23,63,2,900.98),(24,54,1,1500.00),(24,55,1,1500.00),(25,52,1,1500.00),(26,53,1,1500.00),(27,64,1,800.00),(28,57,1,1500.00),(29,58,1,1500.00),(30,75,1,1080.00),(31,71,1,900.00),(32,70,1,1200.00),(33,25,1,880.00),(34,25,1,880.00),(35,42,1,890.00),(36,45,2,990.00),(37,57,1,1500.00),(38,74,1,1500.00);
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER tr_subtractBookStock
AFTER INSERT ON detalleventas
FOR EACH ROW
UPDATE libros
SET cantidad = cantidad - new.Cantidad
WHERE IdLibro = new.IdLibro */;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `editoriales`
--

DROP TABLE IF EXISTS [editoriales];
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET @character_set_client = utf8mb4 ;
CREATE TABLE editoriales (
  [IdEditorial] int NOT NULL,
  [nombreEditorial] varchar(45) NOT NULL,
  PRIMARY KEY ([IdEditorial])
) ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `editoriales`
--

LOCK TABLES [editoriales] WRITE;
/*!40000 ALTER TABLE `editoriales` DISABLE KEYS */;
INSERT INTO editoriales VALUES (1,'Austral'),(2,'Alienta Editorial'),(3,'Black List'),(4,'Boocket'),(5,'Click Ediciones'),(6,'Ediciones Martinez Roca'),(7,'Ediciones Oniro'),(8,'Ediciones Peninsula'),(9,'Lectura Plus'),(10,'Vintage Books'),(11,'Montena'),(12,'Editorial Crítica'),(13,'Editorial Planeta'),(14,'Editorial Estrada'),(15,'Planeta Comic'),(16,'Planeta Diagostini'),(17,' V&R EDITORAS SA'),(18,' Planetalector Argentina'),(19,'Loqueleo'),(20,'Salamandra'),(21,'Planeta Junior'),(22,'Ediciones Internacionales Universitarias'),(23,'S.A. EDICIONES B');
/*!40000 ALTER TABLE `editoriales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `libros`
--

DROP TABLE IF EXISTS [libros];
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET @character_set_client = utf8mb4 ;
CREATE TABLE libros (
  [IdLibro] int NOT NULL IDENTITY,
  [nombre] varchar(100) NOT NULL,
  [anioDeLanzamiento] int NOT NULL,
  [idAutor] int NOT NULL,
  [idCategoria] int NOT NULL,
  [idEditorial] int NOT NULL,
  [descripcion] varchar(max),
  [cantidad] int NOT NULL,
  [precio] decimal(8,2) NOT NULL,
  [urlImagen] varchar(255),
  [estado] smallint NOT NULL DEFAULT '1',
  PRIMARY KEY ([IdLibro])
 ,
  CONSTRAINT [FK_LibroXAutor] FOREIGN KEY ([idAutor]) REFERENCES autores ([idAutor]) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT [FK_LibroXCategoria] FOREIGN KEY ([idCategoria]) REFERENCES categorias ([idCategoria]) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT [FK_LibroXEditorial] FOREIGN KEY ([idEditorial]) REFERENCES editoriales ([IdEditorial]) ON DELETE NO ACTION ON UPDATE NO ACTION
)  ;

CREATE INDEX [FK_LibroXAutor_idx] ON libros ([idAutor]);
CREATE INDEX [FK_LibroXCategoria_idx] ON libros ([idCategoria]);
CREATE INDEX [FK_LibroXEditorial_idx] ON libros ([idEditorial]);
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `libros`
--

LOCK TABLES [libros] WRITE;
/*!40000 ALTER TABLE `libros` DISABLE KEYS */;
INSERT INTO libros VALUES (18,'Los Mitos de la Historia Argentina 2',2011,1,8,2,'En este nuevo libro Felipe Pigna recorre una de las etapas más apasionantes de nuestra historia para entender la identidad argentina: los acontecimientos y los protagonistas fundamentales en el siglo que va desde la lucha emancipadora de San Martín.',48,700.00,'principal/imagenes/LosMitosDeLaHistoriaArgentina2.jpg',1),(19,'Don Quijote de la Mancha',1605,3,11,5,'El hidalgo manchego don Alonso Quijano  llamado el Bueno, enloquece leyendo libros de caballerías y, con el nombre de don Quijote de la Mancha y su viejo caballo Rocinante, se lanza por la Mancha guiado por nobles ideales',45,1700.00,'principal/imagenes/DonQuijote.jpg',1),(23,'Juego de tronos nueva edición parte uno ',2016,4,1,15,'Robert Baratheon, rey de los 7 Reinos, pide a Eddard Stark, sabio Señor de Invernalia, que ocupe el puesto vacante de consejero real, tras la misteriosa muerte del que hasta entonces tenía el cargo. Ello supondrá dejar atrás a su familia y que las intrigas palaciegas dominen su existencia.rnEn el Mar Angosto, una joven e inocente dama de nombre Daenerys Targaryen se ve obligada por su hermano a casarse con el implacable líder Dorthraki, Khal Drogo.Planeta Cómic tiene el placer de presentar la ad',41,500.00,'principal/imagenes/juego-de-tronos-nueva-edicion-0104.jpg',1),(24,'La caja de botones de Gwendy',2017,2,2,9,'La pequeña ciudad de Castle Rock, en Maine, ha sido testigo de algunos extraños sucesos, pero solo hay una historia que no se ha contado... hasta ahora.',50,450.00,'principal\imagenes\La caja de botones de Gwendy.jpg',1),(25,'La voz del Gran Jefe ',2014,1,8,4,'José de San Martín es uno de los hombres más nombrados y más homenajeados de nuestro país y a la vez, paradójicamente, uno de los menos conocidos en toda su dimensión',45,880.00,'principal/imagenes/LaVozDelGran Jefe.jpg',1),(26,'Apocalipsis',1978,2,2,1,'Esta narración cuenta cómo un virus gripal, creado artificialmente como posible arma bacteriológica, se extiende por Estados Unidos y provoca la muerte de millones de personas',20,1349.00,'principal/imagenes/Apocalipsis.jpg',1),(39,'Cincuenta Sombras De Grey',2011,7,11,10,'primera entrega de una trilogía que describe la relación entre una recién graduada de la universidad, Anastasia Steele, y el joven magnate de negocios Christian Grey. ',14,300.00,'principal/imagenes/CincuentaSombrasDeGrey.jpg',1),(40,'The Crazy Haacks Y La Camara Imposible',2018,8,10,11,'Hola, locos! Ya saben que a no hay NADA que se nos resista. Pero... ¿una cámara con PODERES? Eso no estaba previsto! Esta cámara es capaz de lo mejor (y de lo peor!). ¿Están preparados?.',20,589.00,'principal/imagenes/TheCrazyHaacksYLaCamaraImposible.jpg',1),(41,'Mitos de la historia Argentina 5',2013,1,8,4,'En Mitos 5, Felipe Pigna aporta una visión integral y renovada de la vida argentina entre 1955 y 1966, enmarcada en un tiempo de grandes transformaciones mundiales: la Guerra Fría, los movimientos de descolonización, la Revolución Cubana, la guerra de Vietnam y la irrupción de los jóvenes como protagonistas destacados en todo el mundo. Un tiempo de grandes convulsiones y cambios, que devela claves que atañen no sólo al pasado sino también a la actualidad de la Argentina.',4,1080.00,'principal/imagenes/Los-mitos-de-la-historia-argentina-5.jpg',1),(42,'Contra los zombis',2020,9,12,12,'Contra los zombis es Krugman en estado puro y una guía indispensable para el discurso político y económico de dos décadas en los Estados Unidos y en todo el mundo. Con pinceladas rápidas y vívidas, Krugman aporta a sus lectores las claves necesarias para desbloquear los conceptos ocultos tras los principales problemas de política económica de nuestro tiempo.',5,890.00,'principal/imagenes/ContraLosZombis.jpg',1),(43,'La vida por la patria',2017,1,9,5,'Mariano Moreno tiene la rara cualidad de ser alabado o atacado por ideas que nunca sostuvo y propuestas que nunca formuló. La imagen de un Moreno liberal, unitario o ¿porteñista¿, por la cual la historia oficial lo llevó al bronce de las estatuas y buena ',20,1200.00,'principal/imagenes/la_vida_por_la_patria_grande.jpg',1),(44,'Harry Potter Y La Orden Del Fenix',2017,5,1,20,'Las vacaciones de verano aún no han acabado y Harry se encuentra más inquieto que nunca. Apenas ha tenido noticias de Ron y Hermione, y presiente que algo extraño está sucediendo en Hogwarts. No bien empieza el nuevo curso, sus temores se vuelven realidad: el Ministerio de Magia ha iniciado una campaña de desprestigio contra él y Dumbledore, para lo cual ha asignado a la horrible profesora Dolores Umbridge la tarea de vigilar sus movimientos. Y por si fuera poco, Harry sospecha que Voldemort es ',1,2599.00,'principal/imagenes/Harry-Poter-Y-La-Orden-Del-Fenix.png',1),(45,'Equilibrio',2019,10,13,13,'Con rigor, erudición, y a la vez con didactismo y amenidad, armado de literaturas, pero también de estudios técnicos de última generación, López Rosetti nos explica cómo pensamos, cómo sentimos y cómo tomamos decisiones, en un largo y minucioso escaneo de',17,990.00,'principal/imagenes/Equilibrio.jpg',1),(51,'Mujeres tenian que ser',2011,1,8,4,'Charles Fourier aseguraba que “los progresos sociales y cambios de época se operan en proporción al progreso de las mujeres hacia la libertad”. Esta obra recorre el protagonismo de las mujeres en la historia argentina, desde las pobladoras originarias hasta quienes obtuvieron las primeras victorias en su lucha por la igualdad. También aborda la vida cotidiana, las condiciones legales, sociales y culturales, la participación femenina en los procesos históricos, políticos y económicos.',18,800.00,'principal/imagenes/mujeres-tenian-que-ser.jpg',1),(52,'Choque de reyes canción de hielo y fuego II',2020,4,1,15,'Después de los hechos de "Juego de Tronos", la guerra civil asoma en Poniente cuando Daenerys Targaryen, como heredera de la dinastía Targaryen, busca reclamar el Trono de hierro. Arya, con la ayuda de Yoren, un hermano de la Guardia de la Noche, ha huido de Desembarco del Rey pero el camino hasta el Muro está lleno de peligros. Mientras tanto, Sansa acude a un torneo en honor del Rey Joffrey y Bran, en Invernalia, sufre extraños sueños con lobos.',19,1500.00,'principal/imagenes/juego de tronos choque de reyes.jpg',1),(53,'Mujeres insolentes',2018,1,8,13,'Hicieron historia. Igual que muchos hombres.rnPero a ellas se les mezquinó la memoria de sus actos. Tardaron en aparecer en los libros, en las revistas, en los manuales de la escuela, en las conmemoraciones. Fueron mujeres valientes, arriesgadas, talentosas, capaces de ir contra lo que su época decía que había que hacer. Estuvieron a la altura de una historia que luego las arrumbó en un costado, fueron las “insolentes” en ese mundo.',1,1500.00,'principal/imagenes/Mujeres insolentes.jpg',1),(54,'Juego de tronos nueva edicion parte dos',2017,4,1,15,'En esta segunda parte, el argumento se intensifica y se comienza a desvelar las personalidades de los protagonistas principales y sus ansias de poder sobre los Siete Reinos. En el Mar Angosto, Daenerys, sufre los delirios de grandeza de su hermano.',9,1500.00,'principal/imagenes/juego-de-tronos-nueva-edicion-0204.jpg',1),(55,'juego de tronos nueva edicion parte tres',2018,4,1,15,'La vida de los Stark nada tiene que ver con su antigua existencia. Desde que su patricarca fuera nombrado Mano del Rey, traiciones, ataques y muertes acechan al clan, gracias a la implacable familia Lannister. Mientras, la bella e ingenua Danaerys va perdiendo su inocencia tras los últimos acontecimientos en el Mar Angosto.',9,1500.00,'principal/imagenes/juego-de-tronos-nueva-edicion-0304.jpg',1),(56,'juego de tronos nueva edicion parte cuatro',2019,4,1,15,'Después de una traición, siempre viene una venganza. Y ésta será temible e involucrará a los 7 Reinos. Una nueva vuelta de tuerca al argumento está servida. ¿El Bien logrará vencer al Mal? ¿Acaso todo es blanco o negro en un juego de tronos?.Este volumen cierra la adaptación de la novela Juego de tronos, la primera entrega de Canción de Hielo y Fuego, la saga bestseller en todo el mundo que ha ocupado los primeros cuatro volúmenes de esta serie de novelas gráficas.',10,1500.00,'principal/imagenes/juego-de-tronos-nueva-edicion-0404.jpg',1),(57,'Libertadores de América',2016,1,8,13,'En el curso de las guerras de la independencia americana se destacaron líderes, a quienes la historia bautizaría como los libertadores quizá para contraponerlos a las figuras de los conquistadores que, hasta entonces, habían sido los únicos protagonistas de los hechos del Nuevo Continente.rnEsta obra de Felipe Pigna toma las apasionantes vidas de Francisco de Miranda, Simón Bolívar, Bernardo OHiggins, José Miguel Carrera, Manuel Belgrano y José de San Martín.',2,1500.00,'principal/imagenes/Libertadores de America.jpg',1),(58,'Antidoto para personas toxicas',2020,15,13,22,'¿Para quién está escrito el libro? Para aquellos que están dispuestos a atreverse a ser felices en el trabajo. Los que intentan llevar una vida digna, quieren mejorar y a veces, no saben cómo. Para aquellos a los que no les importa preguntarse ¿qué harías si no tuvieses miedo? y están dispuestos a asumir el cambio. Para los que quieren creer que el recurso más importante que tienen las empresas son las personas y que gestionar su talento es un arte.',19,1500.00,'principal/imagenes/Antidoto para personas toxicas.jpg',1),(59,'Evita jirones de su vida',2012,1,8,13,'Con abundante documentación y testimonios, Felipe Pigna recorre la vida de "la mujer más amada y más odiada de la Argentina", las verdades, leyendas, mitos, amores y odios que se tejieron alrededor de su controvertida figura en las múltiples facetas públicas y privadas.rnLa dimensión del mito que se inició con su temprana y trágica muerte sólo puede compararse, por su alcance mundial, a la del Che Guevara.',2,1080.00,'principal/imagenes/Evita jirones de su vida.png',1),(60,'Emociones toxicas',2014,16,13,23,'La propuesta de este libro es otorgarle a cada emoción el verdadero significado que tiene. Las emociones no pueden ser controladas desde fuera sino que deben serlo desde dentro de nuestra vida. Vivir significa conocerse, y ese conocimiento es el que nos permite relacionarnos con el otro y con nosotros mismos.rn'Emociones tóxicas' te ayudará a descubrir herramientas para salir de la frustración, el enfado, el apego, la culpa, el rechazo, y alcanzarás, así, la paz interior que anhelas.»rnBernardo S',4,800.00,'principal/imagenes/Emociones Toxicas.jpg',1),(61,'La historieta Argentina de San Martin',2019,1,8,1,'Historia grafica de San Martin',2,900.00,'principal/imagenes/La historieta Argentina de San Martin.jpg',1),(62,'Los mitos de la historia Argentina 3',2004,1,8,4,'En este nuevo tomo de Los mitos de la historia argentina, el autor recorre una etapa marcada por hechos y procesos tan importantes como la llegada del radicalismo al gobierno; los conflidos sociales de la Semana Trágica; las huelgas patagónicas y los fusilamientos de más de mil quinientos trabajadores; la división del radicalismo entre alvearistas e yrigoyenistas; los avatares de la nacionalización del petróleo; el primer golpe de Estado de la Argentina en el siglo xx; la Década lnfame.',6,880.00,'principal/imagenes/Los mitos de la historia Argentina tres.jpg',1),(63,'Capitán América',2019,14,10,21,'Natasha Romanoff, la letal superespía conocida como Black Widow, está encerrada en una habitación dentro del Centro Común de Lucha contra el Terrorismo de Berlín, jugando al gato y al ratón con el agente Everett Ross. Nat se pregunta si Ross sabe por qué accedió a reunirse con él. Ross se pregunta... muchas cosas. ¿Por qué permitió que Steve Rogers escapara del hangar de aviones de Berlín con el fugitivo Bucky Barnes? ¿Bajo las órdenes de quién estuvo actuando? ¿Dónde está Rogers ahora?.',1,2350.00,'principal/imagenes/Capitan America odisea de un heroe.jpg',1),(64,'El cruce de los Andes',2018,1,8,13,'Historia argentina en historieta sobre el cruce de los Andes',1,800.00,'principal/imagenes/el-cruce-de-los-Andes.jpg',1),(65,'Historieta Argentina Sarmiento',2018,1,8,13,'Historia argentina en historieta sobre Sarmiento',2,800.00,'principal/imagenes/historieta-Argentina-Sarmiento.jpg',1),(66,'Historieta Argentina Revolucion de mayo',2018,1,8,13,'Historia argentina en historieta sobre la revolución de Mayo',2,800.00,'principal/imagenes/historieta-Argentina-revolucion-de-mayo.jpg',1),(67,'Historieta Argentina Invasiones inglesas',2018,1,8,13,'Historia argentina en historieta sobre invasiones Inglesas',2,800.00,'principal/imagenes/historieta-Argentina-invasiones-inglesas.jpg',1),(68,'Mujeres insolentes de la historia dos',2018,1,8,1,'Son necesarios muchos libros para contar las vidas de las mujeres que hicieron historia. Es por eso que Felipe Pigna nos entrega este segundo volumen de Mujeres insolentes.rnOtras veintinueve mujeres latinoamericanas a las que el relato oficial de los hechos dejó más o menos afuera.rnSin embargo este libro les abre una casa, aquí tienen un lugar esas vidas que seguramente inspirarán a lectoras y lectores de estos tiempos. Fueron mujeres valientes, arriesgadas, talentosas, capaces de ir contra lo ',2,800.00,'principal/imagenes/Mujeres-insolentes-de-la-historia-2.jpg',1),(69,'Manuel Belgrano Vida y pensamiento',2019,1,8,13,'La historia oficial relegó a Manuel Belgrano al papel de “creador de la bandera nacional”, a tal punto que hasta en el calendario la fecha de su muerte quedó asociada al símbolo patrio. Fue la forma de ocultar, por mucho tiempo, el pensamiento y la acción de uno de los más lúcidos innovadores y revolucionarios de nuestra historia.rnEn esta nueva obra, Felipe Pigna aborda el estudio integral de la agitada vida de Belgrano, tanto en lo público como en lo privado y familiar. Además de sus facetas má',2,900.00,'principal/imagenes/Manuel-Belgrano-vida-y-pensamiento-de-un-revolucionario.jpg',1),(70,'Lo pasado pensado',2014,1,8,4,'En estas apasionantes entrevistas Felipe Pigna da cuenta de los momentos clave de la historia argentina entre 1955 y 1983, un período crucial del siglo xx, que va desde el derrocamiento de Juan Domingo Perón por un golpe de Estado, que se autodenominó "Revolución Libertadora", hasta el retorno a la democracia, tras la noche negra de la peor dictadura que sufrió el país.rnLo pasado pensado nos convoca a conocer la historia de primera mano, a través de la voz directa de sus protagonistas o testigos',1,1200.00,'principal/imagenes/lo-pasado-pensado.jpg',1),(71,'Al gran pueblo argentino salud',2020,1,8,4,'Infaltable en el brindis, en los buenos momentos compartidos y en la mesa cotidiana, el vino argentino es nuestra bebida nacional, en los últimos tiempos reconocida, apreciada y premiada por los paladares más exigentes del mundo. Para ello ha sido necesaria una larga historia de casi cinco siglos, forjada por la labor de generaciones de mujeres y de hombres que arraigaron y adaptaron las vides provenientes del Viejo Mundo, las cultivaron e hicieron nuestros vinos, muchas veces en las condiciones',1,900.00,'principal/imagenes/al-gran-pueblo-Argentino-salud.jpg',1),(72,'Los vestidos de Kate',2019,13,10,1,'¡Descubre el Reino Unido con Kate! Visita el Big Ben y los grandes parques de Londres, comparte un cupcake con ella en un salón de té, y acompáñala a los castillos escoceses y a las playas inglesas. Cada libro contiene stickers con trajes típicos para vestir a las muñecas y, además, muestran lugares y costumbres tradicionales de cada país en amplios escenarios a todo color.',1,700.00,'principal/imagenes/Los-Vestidos-De-Kate.png',1),(73,'Sapo en Buenos Aires',2016,11,10,19,'Don sapo regresa al monte, después de su viaje a Buenos Aires, donde se dejó sorprender por la ciudad, sus habitantes y sus costumbres. Todos quieren oír las historias, que fascinan al bicherío: ¿esas personas no conocen a los animales del monte? ¿Viajan todo el día amontonados? ¿Se tapan el cuerpo con trapos de colores? Un retrato de los porteños desde la singular perspectiva de un sapo muy curioso.',1,1500.00,'principal/imagenes/Sapo-En-Buenos-Aires.jpg',1),(74,'Vidas de gatos',2019,12,10,18,'Al terminar de escribir los poemas de Vidas de gatos los dejé dormidos en su habitación, hasta que, en medio de la noche, me despertaron sus maullidos: ¡los poemas pedían ser canción! Ante semejante insistencia gatuna no me pude negar. Les puse música, y terminé cantando con ellos hasta el amanecer.rnOjalá ustedes puedan unir sus voces a nuestro canto.rnSi querés escuchar las canciones de Vidas de gatos en la voz de Silvia Arazi, podés buscarlas en las plataformas digitales: iTunes, Spotify, Youtu',1,1500.00,'principal/imagenes/Vidas-De-Gato.jpg',1),(75,'EVITA',2007,1,9,13,'Este libro recorre la vida y la presencia de Evita, Eva Perón, Eva Duarte, «esa mujer», sin duda uno de los mayores íconos, nacionales e internacionales, que ha dado la Argentina en toda su historia. Aparecen aquí las múltiples facetas públicas y privadas de la vida, intensa y breve, de la «abanderada de los humildes»: se retratan en un extenso y abarcador recorrido fotográfico y un texto escrito especialmente por Felipe Pigna, para dar cuenta de las verdades, leyendas, mitos, amores y odios.',0,1080.00,'principal/imagenes/Evita.jpg',1),(76,'Los mitos de la historia Argentina 4',2004,1,8,4,'Pocos procesos de la historia argentina despiertan tanto interés, local e internacional, como el que marca los orígenes, consolidación y perdurabilidad del peronismo. Es seguramente uno de los fenómenos históricos más particulares en América Latina y el mundo, y que despierta mayores polémicas, rodeadas aún por pasiones e interpretaciones cruzadas, a favor y en contra. Este libro recorre el apasionante período de 1943 a 1955, para develar los aspectos controversiales del movimiento.',1,880.00,'principal/imagenes/Los-Mitos-De-La-Historia-Argentina-4.jpg',1);
/*!40000 ALTER TABLE `libros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS [usuarios];
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET @character_set_client = utf8mb4 ;
CREATE TABLE usuarios (
  [Nombre] varchar(45) NOT NULL,
  [apellido] varchar(45) NOT NULL,
  [fechaNacimiento] date NOT NULL,
  [Email] varchar(45) NOT NULL,
  [NombreUsuario] varchar(45) NOT NULL,
  [pass] varchar(45) NOT NULL,
  [Domicilio] varchar(45) NOT NULL,
  [adminType] smallint NOT NULL,
  [estado] smallint DEFAULT '1',
  PRIMARY KEY ([NombreUsuario])
) ;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES [usuarios] WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO usuarios VALUES ('Leo','Gonzales','1998-10-10','skapp@gmail.com','a','jose ert','Av Perón 258',2,1),('cds','Schneider','1998-10-10','cds@gmail.com','cds','cds','Av.Peron 2046',2,1),('Claudio','Schneider','1987-09-16','cla8787@gmail.com','clau','admin','Quirno Costa 918 San Fernando',2,1),('ed','Gonzales','1998-10-10','skapp@gmail.com','clepto','12345','Av Perón 258',2,1),('ed','Gonzales','1987-10-10','skapp@gmail.com','dasdasdasd','12345','Av Perón 258',2,1),('Juan Manuel','Rodriguez Perez','1998-10-10','skapp@gmail.com','dfgdfg','12345','Av Perón 258',2,1),('Alejandro','Pederiva','1987-07-14','korto_77@gmail.com','korto','12345','Arias 1814',2,1),('Matias','Peralta','1987-10-10','mperalta@gmail.com','maty123','12345','Av Perón 1258',2,1),('Roberto','Schneider','1949-03-10','roberto.f.schneider@gmail.com','roberto','12345','Quirno Costa 918',2,1);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ventas`
--

DROP TABLE IF EXISTS [ventas];
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET @character_set_client = utf8mb4 ;
CREATE TABLE ventas (
  [IdVenta] int NOT NULL IDENTITY,
  [NombreUsuario] varchar(45) NOT NULL,
  [PrecioTotal] decimal(8,2) NOT NULL,
  [Fecha] date NOT NULL,
  PRIMARY KEY ([IdVenta])
 ,
  CONSTRAINT [FK_VentasXUsuario] FOREIGN KEY ([NombreUsuario]) REFERENCES usuarios ([NombreUsuario]) ON DELETE NO ACTION ON UPDATE NO ACTION
)  ;

CREATE INDEX [FK_VentasXUsuario_idx] ON ventas ([NombreUsuario]);
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ventas`
--

LOCK TABLES [ventas] WRITE;
/*!40000 ALTER TABLE `ventas` DISABLE KEYS */;
INSERT INTO ventas VALUES (1,'cds',700.00,'2019-07-13'),(2,'cds',500.00,'2019-07-13'),(3,'cds',500.00,'2019-07-14'),(4,'cds',900.00,'2019-07-15'),(5,'clau',1000.00,'2019-07-15'),(6,'clau',500.00,'2019-07-15'),(7,'clau',650.24,'2019-07-16'),(8,'clau',500.00,'2020-04-28'),(9,'clau',500.00,'2020-04-28'),(10,'clau',500.00,'2020-04-28'),(11,'clau',1790.25,'2020-04-28'),(12,'clau',700.00,'2020-04-30'),(13,'clau',1200.00,'2020-04-30'),(14,'clau',1180.00,'2020-05-06'),(15,'clau',1900.00,'2020-05-07'),(16,'cds',2730.24,'2020-05-07'),(17,'clau',1580.00,'2020-05-10'),(18,'clau',850.24,'2020-05-12'),(19,'clau',1400.00,'2020-05-14'),(20,'clau',3500.56,'2020-05-19'),(21,'korto',800.00,'2020-05-21'),(22,'clau',1790.00,'2020-05-26'),(23,'clau',1801.96,'2020-05-27'),(24,'clau',3000.00,'2020-05-28'),(25,'clau',1500.00,'2020-05-29'),(26,'clau',1500.00,'2020-07-02'),(27,'clau',800.00,'2020-07-02'),(28,'clau',1500.00,'2020-07-02'),(29,'clau',1500.00,'2020-07-02'),(30,'clau',1080.00,'2020-07-07'),(31,'clau',900.00,'2020-07-07'),(32,'clau',1200.00,'2020-07-07'),(33,'clau',880.00,'2020-07-07'),(34,'maty123',880.00,'2020-07-07'),(35,'maty123',890.00,'2020-07-07'),(36,'maty123',1980.00,'2020-07-07'),(37,'maty123',1500.00,'2020-07-07'),(38,'maty123',1500.00,'2020-07-07');
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
CREATE  PROCEDURE DeleteBook(
@_IdLibro int
)
AS
BEGIN
SET NOCOUNT ON;
update libros set
estado = 0
where IdLibro = @_IdLibro;
END ;
GO;
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
CREATE  PROCEDURE InsertAdmin(
@_Email varchar(45),
@_Nombre varchar(45),
@_Apellido varchar(45),
@_Pass varchar(45),
@_Estado int
)
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO admin(
Email,
Nombre,
Apellido, 
Pass,
Estado
)
VALUES(
@_Email,
@_Nombre,
@_Apellido,
@_Pass,
@_Estado 
);
END ;
GO;
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
CREATE  PROCEDURE InsertBook(
@_nombre varchar(100), 
@_anioDeLanzamiento int, 
@_idAutor int,
@_idCategoria int, 
@_idEditorial int, 
@_descripcion varchar(max), 
@_cantidad int, 
@_precio decimal(8,2), 
@_urlImagen varchar(255), 
@_estado smallint
)
AS
BEGIN
SET NOCOUNT ON;
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
@_nombre, 
@_anioDeLanzamiento, 
@_idAutor,
@_idCategoria, 
@_idEditorial, 
@_descripcion, 
@_cantidad, 
@_precio, 
@_urlImagen, 
@_estado
);
END ;
GO;
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
CREATE  PROCEDURE InsertSale(
@_NombreUsuario varchar(45),
@_PrecioTotal decimal(8,2),
@_Fecha datetime2(0)
)
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO ventas(
NombreUsuario,
PrecioTotal,
Fecha
)
VALUES(
@_NombreUsuario,
@_PrecioTotal,
@_Fecha
);
END ;
GO;
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
CREATE  PROCEDURE InsertSaleDetail(
@_IdLibro int,
@_Cantidad int,
@_Precio decimal(8,2)
)
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO detalleventas(
IdVenta, 
IdLibro,
Cantidad,
Precio)
SELECT(SELECT idVenta from ventas order by IdVenta Desc Limit 1),
@_IdLibro,
@_Cantidad,
@_Precio;
END ;
GO;
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
CREATE  PROCEDURE InsertUser(
@_nombre varchar(45),
@_apellido varchar(45),
@_fechaNacimiento datetime2(0),
@_email varchar(45),
@_nombreUsuario varchar(45),
@_pass varchar(45),
@_domicilio varchar(45),
@_adminType int,
@_estado int
)
AS
BEGIN
SET NOCOUNT ON;
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
@_nombre,
@_apellido,
@_fechaNacimiento,
@_email,
@_nombreUsuario,
@_pass,
@_domicilio,
@_adminType,
@_estado
);
END ;
GO;
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
CREATE  PROCEDURE UpdateBook(
@_IdLibro int,
@_nombre varchar(100), 
@_anioDeLanzamiento int, 
@_idAutor int,
@_idCategoria int, 
@_idEditorial int, 
@_descripcion varchar(max), 
@_cantidad int, 
@_precio decimal(8,2), 
@_urlImagen varchar(255), 
@_estado smallint
)
AS
BEGIN
SET NOCOUNT ON;
update libros set
nombre = @_nombre, 
anioDeLanzamiento = @_anioDeLanzamiento,
idAutor = @_idAutor,
idCategoria = @_idCategoria,
idEditorial = @_idEditorial,
descripcion = @_descripcion,
cantidad = @_cantidad,
precio = @_precio,
urlImagen = @_urlImagen,
estado = @_estado
where IdLibro = @_IdLibro;
END ;
GO;
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

-- Dump completed on 2020-08-19 19:00:15
