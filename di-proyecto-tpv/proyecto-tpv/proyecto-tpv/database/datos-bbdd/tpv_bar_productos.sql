-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: tpv_bar
-- ------------------------------------------------------
-- Server version	9.1.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productos` (
  `id_producto` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `precio` decimal(10,2) NOT NULL,
  `id_categoria` int NOT NULL,
  PRIMARY KEY (`id_producto`),
  KEY `id_categoria` (`id_categoria`),
  CONSTRAINT `productos_ibfk_1` FOREIGN KEY (`id_categoria`) REFERENCES `categorias` (`id_categoria`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES (1,'Cafe Americano',1.50,1),(2,'Capuchino',2.50,1),(3,'Te Verde',1.80,1),(4,'Agua Mineral',1.00,2),(5,'Zumo de Naranja',2.00,2),(6,'Refresco de Cola',1.50,2),(7,'Sopa del Dia',3.50,3),(8,'Ensalada Cesar',4.50,3),(9,'Pan de Ajo',2.00,3),(10,'Hamburguesa Clasica',8.00,4),(11,'Pasta Alfredo',7.50,4),(12,'Pollo a la Parrilla',9.00,4),(13,'Tarta de Queso',3.00,5),(14,'Helado de Vainilla',2.50,5),(15,'Brownie de Chocolate',3.50,5),(16,'Cerveza Artesanal',4.00,6),(17,'Copa de Vino Tinto',5.00,6),(18,'Whisky con Hielo',6.50,6),(19,'Patatas Fritas',2.00,7),(20,'Nachos con Queso',3.50,7),(22,'Espresso',1.30,1),(23,'Latte',2.80,1),(24,'Chocolate Caliente',2.50,1),(25,'Macchiato',2.70,1),(26,'Te Negro',1.70,1),(27,'Cafe Descafeinado',1.60,1),(28,'Batido de Fresa',3.00,2),(29,'Limonada',2.20,2),(30,'Agua con Gas',1.20,2),(31,'Batido de Platano',3.00,2),(32,'Tonica',1.50,2),(33,'Refresco de Naranja',1.50,2),(34,'Croquetas de Jamon',4.00,3),(35,'Bruschetta',3.50,3),(36,'Rollitos Primavera',3.80,3),(37,'Hummus con Pan Pita',4.50,3),(38,'Mejillones al Vapor',5.00,3),(39,'Tostadas con Tomate',2.50,3),(40,'Pizza Margarita',7.50,4),(41,'Lasagna de Carne',8.50,4),(42,'Filete de Res',12.00,4),(43,'Risotto de Champiñones',9.00,4),(44,'Tacos de Pollo',7.00,4),(45,'Costillas BBQ',11.50,4),(46,'Crema Catalana',3.50,5),(47,'Mousse de Chocolate',3.00,5),(48,'Gelatina de Frutas',2.00,5),(49,'Flan de Caramelo',2.50,5),(50,'Pastel de Zanahoria',3.50,5),(51,'Cupcake de Vainilla',2.80,5),(52,'Ron con Coca-Cola',5.00,6),(53,'Mojito',6.00,6),(54,'Tequila Sunrise',6.50,6),(55,'Gin Tonic',6.00,6),(56,'Sangria',4.50,6),(57,'Cerveza Lager',3.50,6),(58,'Aceitunas',1.80,7),(59,'Almendras Tostadas',2.20,7),(60,'Tortilla de Patatas',3.00,7),(61,'Queso Manchego',3.50,7),(62,'Calamares Fritos',4.00,7),(63,'Mini Sandwiches',3.00,7);
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-12-10 20:13:38
