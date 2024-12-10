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
-- Table structure for table `pedidos`
--

DROP TABLE IF EXISTS `pedidos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pedidos` (
  `id_pedido` int NOT NULL AUTO_INCREMENT,
  `fecha_hora` datetime NOT NULL,
  `id_mesa` int NOT NULL,
  `id_usuario` int NOT NULL,
  `estado` enum('pendiente','pagado','cancelado') NOT NULL,
  PRIMARY KEY (`id_pedido`),
  KEY `id_mesa` (`id_mesa`),
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `pedidos_ibfk_1` FOREIGN KEY (`id_mesa`) REFERENCES `mesas` (`id_mesa`) ON DELETE CASCADE,
  CONSTRAINT `pedidos_ibfk_2` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=56 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pedidos`
--

LOCK TABLES `pedidos` WRITE;
/*!40000 ALTER TABLE `pedidos` DISABLE KEYS */;
INSERT INTO `pedidos` VALUES (1,'2024-12-10 17:32:52',1,1,'pendiente'),(2,'2024-12-10 17:34:11',2,1,'pendiente'),(3,'2024-12-10 17:35:11',1,1,'pendiente'),(4,'2024-12-10 17:38:09',1,1,'pendiente'),(5,'2024-12-10 17:43:05',3,1,'pendiente'),(6,'2024-12-10 17:47:32',3,1,'pendiente'),(7,'2024-12-10 17:48:41',4,1,'pendiente'),(8,'2024-12-10 17:50:58',2,1,'pendiente'),(9,'2024-12-10 17:52:55',3,1,'pendiente'),(10,'2024-12-10 17:54:45',1,1,'pendiente'),(11,'2024-12-10 17:56:58',3,1,'pendiente'),(12,'2024-12-10 17:58:05',3,1,'pendiente'),(13,'2024-12-10 17:58:40',3,1,'pendiente'),(14,'2024-12-10 17:59:07',5,1,'pendiente'),(15,'2024-12-10 18:01:58',4,1,'pendiente'),(16,'2024-12-10 18:02:17',3,1,'pendiente'),(17,'2024-12-10 18:04:49',2,1,'pendiente'),(18,'2024-12-10 18:07:21',3,1,'pendiente'),(19,'2024-12-10 18:10:47',3,1,'pendiente'),(20,'2024-12-10 18:13:15',3,1,'pendiente'),(21,'2024-12-10 18:14:12',4,1,'pendiente'),(22,'2024-12-10 18:17:32',3,1,'pendiente'),(23,'2024-12-10 18:19:32',3,1,'pendiente'),(24,'2024-12-10 18:22:00',4,1,'pendiente'),(25,'2024-12-10 18:23:50',3,1,'pendiente'),(26,'2024-12-10 18:24:23',3,1,'pendiente'),(27,'2024-12-10 18:25:49',3,1,'pendiente'),(28,'2024-12-10 18:32:53',3,1,'pendiente'),(29,'2024-12-10 18:33:13',4,1,'pendiente'),(30,'2024-12-10 18:35:37',4,1,'pendiente'),(31,'2024-12-10 18:36:36',3,1,'pendiente'),(32,'2024-12-10 18:39:59',3,1,'pendiente'),(33,'2024-12-10 18:42:47',2,1,'pendiente'),(34,'2024-12-10 18:43:19',3,1,'pendiente'),(35,'2024-12-10 18:45:12',2,1,'pendiente'),(36,'2024-12-10 18:46:31',3,1,'pendiente'),(37,'2024-12-10 18:48:05',4,1,'pendiente'),(38,'2024-12-10 18:48:42',3,1,'pendiente'),(39,'2024-12-10 18:50:10',4,1,'pendiente'),(40,'2024-12-10 18:52:09',3,1,'pendiente'),(41,'2024-12-10 18:52:33',3,1,'pendiente'),(42,'2024-12-10 18:58:48',2,1,'pendiente'),(43,'2024-12-10 18:59:08',1,1,'pendiente'),(44,'2024-12-10 18:59:23',2,1,'pendiente'),(45,'2024-12-10 19:04:17',2,1,'pendiente'),(46,'2024-12-10 19:04:36',4,1,'pendiente'),(47,'2024-12-10 19:05:27',1,1,'pendiente'),(48,'2024-12-10 19:05:40',2,1,'pendiente'),(49,'2024-12-10 19:06:26',4,1,'pendiente'),(50,'2024-12-10 19:06:40',4,1,'pendiente'),(51,'2024-12-10 19:08:19',1,1,'pendiente'),(52,'2024-12-10 19:09:12',1,1,'pendiente'),(53,'2024-12-10 19:09:50',3,1,'pendiente'),(54,'2024-12-10 19:11:19',2,1,'pendiente'),(55,'2024-12-10 19:11:47',4,1,'pendiente');
/*!40000 ALTER TABLE `pedidos` ENABLE KEYS */;
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
