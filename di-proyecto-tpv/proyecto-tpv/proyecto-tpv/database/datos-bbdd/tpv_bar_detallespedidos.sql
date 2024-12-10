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
-- Table structure for table `detallespedidos`
--

DROP TABLE IF EXISTS `detallespedidos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detallespedidos` (
  `id_detalle` int NOT NULL AUTO_INCREMENT,
  `id_pedido` int NOT NULL,
  `id_producto` int NOT NULL,
  `cantidad` int NOT NULL,
  `subtotal` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id_detalle`),
  KEY `id_pedido` (`id_pedido`),
  KEY `id_producto` (`id_producto`),
  CONSTRAINT `detallespedidos_ibfk_1` FOREIGN KEY (`id_pedido`) REFERENCES `pedidos` (`id_pedido`) ON DELETE CASCADE,
  CONSTRAINT `detallespedidos_ibfk_2` FOREIGN KEY (`id_producto`) REFERENCES `productos` (`id_producto`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detallespedidos`
--

LOCK TABLES `detallespedidos` WRITE;
/*!40000 ALTER TABLE `detallespedidos` DISABLE KEYS */;
INSERT INTO `detallespedidos` VALUES (1,1,2,3,45.67),(2,35,38,1,5.00),(3,36,6,2,1.50),(4,36,31,1,3.00),(5,36,55,1,6.00),(6,36,58,1,1.80),(7,36,34,2,4.00),(8,37,18,1,6.50),(9,38,17,1,5.00),(10,39,17,1,5.00),(11,40,23,1,2.80),(12,41,23,1,2.80),(13,42,17,1,5.00),(14,42,61,1,3.50),(15,42,27,1,1.60),(16,43,27,1,1.60),(17,44,38,1,5.00),(18,45,17,1,5.00),(19,46,6,3,1.50),(20,46,55,1,6.00),(21,46,25,1,2.70),(22,47,6,1,1.50),(23,48,6,1,1.50),(24,48,4,2,2.00),(25,48,23,1,2.80),(26,49,17,1,5.00),(27,49,18,1,6.50),(28,49,16,1,4.00),(29,49,55,1,6.00),(30,49,53,1,6.00),(31,49,52,1,5.00),(32,49,56,1,4.50),(33,49,54,1,6.50),(34,49,57,1,3.50),(35,50,56,1,4.50),(36,51,18,1,6.50),(37,52,24,1,2.50),(38,53,4,1,1.00),(39,54,6,1,1.50),(40,55,17,1,5.00),(41,55,18,1,6.50),(42,55,4,2,2.00),(43,55,61,2,7.00),(44,55,38,1,5.00),(45,55,43,1,9.00),(46,55,43,1,9.00);
/*!40000 ALTER TABLE `detallespedidos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-12-10 20:13:39
