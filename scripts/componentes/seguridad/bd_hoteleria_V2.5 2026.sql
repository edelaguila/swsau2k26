-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: bd_hoteleria
-- ------------------------------------------------------
-- Server version	8.0.41

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
-- Table structure for table `tbl_aplicacion`
--

DROP TABLE IF EXISTS `tbl_aplicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_aplicacion` (
  `Pk_Id_Aplicacion` int NOT NULL,
  `Fk_Id_Reporte_Aplicacion` int DEFAULT NULL,
  `Cmp_Nombre_Aplicacion` varchar(50) DEFAULT NULL,
  `Cmp_Descripcion_Aplicacion` varchar(50) DEFAULT NULL,
  `Cmp_Estado_Aplicacion` bit(1) NOT NULL,
  PRIMARY KEY (`Pk_Id_Aplicacion`),
  KEY `Fk_Aplicacion_Reporte` (`Fk_Id_Reporte_Aplicacion`),
  CONSTRAINT `Fk_Aplicacion_Reporte` FOREIGN KEY (`Fk_Id_Reporte_Aplicacion`) REFERENCES `tbl_reportes` (`Pk_Id_Reporte`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_aplicacion`
--

LOCK TABLES `tbl_aplicacion` WRITE;
/*!40000 ALTER TABLE `tbl_aplicacion` DISABLE KEYS */;
INSERT INTO `tbl_aplicacion` VALUES (1,1,'Gestion de empleado','Se gestionan los empleados del hotel',_binary ''),(301,5,'Empleados','Control de empleados de la hoteleria',_binary ''),(302,NULL,'Usuarios','Control de usuarios de empleados',_binary ''),(303,3,'Perfiles','Perfiles que se asignan a usuarios',_binary ''),(304,NULL,'Modulos','Mantenimiento de modulos',_binary ''),(305,NULL,'Aplicacion','Mantenimiento de aplicaciones',_binary ''),(306,NULL,'Asig Aplicacion Usuario','Asigna permisos a usuarios',_binary ''),(307,NULL,'Asig aplicacion Perfil','Asigna permisos a perfiles',_binary ''),(308,NULL,'Asig Perfiles','Asigna los perfiles a usuarios',_binary ''),(309,NULL,'Bitacora','Da acceso a bitacora',_binary '');
/*!40000 ALTER TABLE `tbl_aplicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_asignacion_modulo_aplicacion`
--

DROP TABLE IF EXISTS `tbl_asignacion_modulo_aplicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_asignacion_modulo_aplicacion` (
  `Fk_Id_Modulo` int NOT NULL,
  `Fk_Id_Aplicacion` int NOT NULL,
  PRIMARY KEY (`Fk_Id_Modulo`,`Fk_Id_Aplicacion`),
  KEY `Fk_AsigAplicacion` (`Fk_Id_Aplicacion`),
  CONSTRAINT `Fk_AsigAplicacion` FOREIGN KEY (`Fk_Id_Aplicacion`) REFERENCES `tbl_aplicacion` (`Pk_Id_Aplicacion`),
  CONSTRAINT `Fk_AsigModulo` FOREIGN KEY (`Fk_Id_Modulo`) REFERENCES `tbl_modulo` (`Pk_Id_Modulo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_asignacion_modulo_aplicacion`
--

LOCK TABLES `tbl_asignacion_modulo_aplicacion` WRITE;
/*!40000 ALTER TABLE `tbl_asignacion_modulo_aplicacion` DISABLE KEYS */;
INSERT INTO `tbl_asignacion_modulo_aplicacion` VALUES (4,301),(4,302),(4,303),(4,304),(4,305),(4,306),(4,307),(4,308),(4,309);
/*!40000 ALTER TABLE `tbl_asignacion_modulo_aplicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_bitacora`
--

DROP TABLE IF EXISTS `tbl_bitacora`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_bitacora` (
  `Pk_Id_Bitacora` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Usuario` int DEFAULT NULL,
  `Fk_Id_Aplicacion` int DEFAULT NULL,
  `Cmp_Fecha` datetime DEFAULT NULL,
  `Cmp_Accion` varchar(255) DEFAULT NULL,
  `Cmp_Ip` varchar(50) DEFAULT NULL,
  `Cmp_Nombre_Pc` varchar(50) DEFAULT NULL,
  `Cmp_Login_Estado` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Bitacora`),
  KEY `Fk_Bitacora_Usuario` (`Fk_Id_Usuario`),
  KEY `Fk_Bitacora_Aplicacion` (`Fk_Id_Aplicacion`),
  CONSTRAINT `Fk_Bitacora_Aplicacion` FOREIGN KEY (`Fk_Id_Aplicacion`) REFERENCES `tbl_aplicacion` (`Pk_Id_Aplicacion`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `Fk_Bitacora_Usuario` FOREIGN KEY (`Fk_Id_Usuario`) REFERENCES `tbl_usuario` (`Pk_Id_Usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=4583 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_bitacora`
--

LOCK TABLES `tbl_bitacora` WRITE;
/*!40000 ALTER TABLE `tbl_bitacora` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_bitacora` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_bloqueo_usuario`
--

DROP TABLE IF EXISTS `tbl_bloqueo_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_bloqueo_usuario` (
  `Pk_Id_Bloqueo` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Usuario` int DEFAULT NULL,
  `Fk_Id_Bitacora` int DEFAULT NULL,
  `Cmp_Fecha_Inicio_Bloqueo_Usuario` datetime DEFAULT NULL,
  `Cmp_Fecha_Fin_Bloqueo_Usuario` datetime DEFAULT NULL,
  `Cmp_Motivo__Bloqueo_Usuario` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Bloqueo`),
  KEY `Fk_Bloqueo_Usuario` (`Fk_Id_Usuario`),
  KEY `Fk_Bloqueo_Bitacora` (`Fk_Id_Bitacora`),
  CONSTRAINT `Fk_Bloqueo_Bitacora` FOREIGN KEY (`Fk_Id_Bitacora`) REFERENCES `tbl_bitacora` (`Pk_Id_Bitacora`),
  CONSTRAINT `Fk_Bloqueo_Usuario` FOREIGN KEY (`Fk_Id_Usuario`) REFERENCES `tbl_usuario` (`Pk_Id_Usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_bloqueo_usuario`
--

LOCK TABLES `tbl_bloqueo_usuario` WRITE;
/*!40000 ALTER TABLE `tbl_bloqueo_usuario` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_bloqueo_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_empleado`
--

DROP TABLE IF EXISTS `tbl_empleado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_empleado` (
  `Pk_Id_Empleado` int NOT NULL AUTO_INCREMENT,
  `Cmp_Nombres_Empleado` varchar(50) DEFAULT NULL,
  `Cmp_Apellidos_Empleado` varchar(50) DEFAULT NULL,
  `Cmp_Dpi_Empleado` bigint DEFAULT NULL,
  `Cmp_Nit_Empleado` bigint DEFAULT NULL,
  `Cmp_Correo_Empleado` varchar(50) DEFAULT NULL,
  `Cmp_Telefono_Empleado` varchar(15) DEFAULT NULL,
  `Cmp_Genero_Empleado` varchar(10) DEFAULT NULL,
  `Cmp_Fecha_Nacimiento_Empleado` date DEFAULT NULL,
  `Cmp_Fecha_Contratacion__Empleado` date DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Empleado`)
) ENGINE=InnoDB AUTO_INCREMENT=10008 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_empleado`
--

LOCK TABLES `tbl_empleado` WRITE;
/*!40000 ALTER TABLE `tbl_empleado` DISABLE KEYS */;
INSERT INTO `tbl_empleado` VALUES (2,'Juan','Pérez López',1234567890101,9876542,'juan.perez@example.com','5555-1234','Masculino','1995-08-20','2025-09-21'),(3,'Juan','pruebas',1234,123,'@pruebas','1234','Masculino','2025-09-26','2025-09-26');
/*!40000 ALTER TABLE `tbl_empleado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_modulo`
--

DROP TABLE IF EXISTS `tbl_modulo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_modulo` (
  `Pk_Id_Modulo` int NOT NULL,
  `Cmp_Nombre_Modulo` varchar(50) DEFAULT NULL,
  `Cmp_Descripcion_Modulo` varchar(50) DEFAULT NULL,
  `Cmp_Estado_Modulo` bit(1) NOT NULL,
  PRIMARY KEY (`Pk_Id_Modulo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_modulo`
--

LOCK TABLES `tbl_modulo` WRITE;
/*!40000 ALTER TABLE `tbl_modulo` DISABLE KEYS */;
INSERT INTO `tbl_modulo` VALUES (2,'Navegador','Módulo de navegador',_binary ''),(4,'Seguridad','Modulo de seguridad de la hoteleria',_binary '');
/*!40000 ALTER TABLE `tbl_modulo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_perfil`
--

DROP TABLE IF EXISTS `tbl_perfil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_perfil` (
  `Pk_Id_Perfil` int NOT NULL AUTO_INCREMENT,
  `Cmp_Puesto_Perfil` varchar(50) DEFAULT NULL,
  `Cmp_Descripcion_Perfil` varchar(50) DEFAULT NULL,
  `Cmp_Estado_Perfil` bit(1) NOT NULL,
  `Cmp_Tipo_Perfil` int DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Perfil`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_perfil`
--

LOCK TABLES `tbl_perfil` WRITE;
/*!40000 ALTER TABLE `tbl_perfil` DISABLE KEYS */;
INSERT INTO `tbl_perfil` VALUES (1,'Administrador','Perfil con todos los permisos',_binary '',1);
/*!40000 ALTER TABLE `tbl_perfil` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_permiso_perfil_aplicacion`
--

DROP TABLE IF EXISTS `tbl_permiso_perfil_aplicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_permiso_perfil_aplicacion` (
  `Fk_Id_Perfil` int NOT NULL,
  `Fk_Id_Modulo` int NOT NULL,
  `Fk_Id_Aplicacion` int NOT NULL,
  `Cmp_Ingresar_Permisos_Aplicacion_Perfil` bit(1) DEFAULT NULL,
  `Cmp_Consultar_Permisos_Aplicacion_Perfil` bit(1) DEFAULT NULL,
  `Cmp_Modificar_Permisos_Aplicacion_Perfil` bit(1) DEFAULT NULL,
  `Cmp_Eliminar_Permisos_Aplicacion_Perfil` bit(1) DEFAULT NULL,
  `Cmp_Imprimir_Permisos_Aplicacion_Perfil` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Fk_Id_Perfil`,`Fk_Id_Modulo`,`Fk_Id_Aplicacion`),
  KEY `Fk_PermisoPerfil_ModuloAplicacion` (`Fk_Id_Modulo`,`Fk_Id_Aplicacion`),
  CONSTRAINT `Fk_PermisoPerfil` FOREIGN KEY (`Fk_Id_Perfil`) REFERENCES `tbl_perfil` (`Pk_Id_Perfil`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `Fk_PermisoPerfil_ModuloAplicacion` FOREIGN KEY (`Fk_Id_Modulo`, `Fk_Id_Aplicacion`) REFERENCES `tbl_asignacion_modulo_aplicacion` (`Fk_Id_Modulo`, `Fk_Id_Aplicacion`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_permiso_perfil_aplicacion`
--

LOCK TABLES `tbl_permiso_perfil_aplicacion` WRITE;
/*!40000 ALTER TABLE `tbl_permiso_perfil_aplicacion` DISABLE KEYS */;
INSERT INTO `tbl_permiso_perfil_aplicacion` VALUES (1,4,301,_binary '',_binary '',_binary '',_binary '',_binary ''),(1,4,305,_binary '',_binary '',_binary '',_binary '',_binary ''),(1,4,306,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(1,4,309,_binary '',_binary '',_binary '',_binary '',_binary '');
/*!40000 ALTER TABLE `tbl_permiso_perfil_aplicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_permiso_usuario_aplicacion`
--

DROP TABLE IF EXISTS `tbl_permiso_usuario_aplicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_permiso_usuario_aplicacion` (
  `Fk_Id_Usuario` int NOT NULL,
  `Fk_Id_Modulo` int NOT NULL,
  `Fk_Id_Aplicacion` int NOT NULL,
  `Cmp_Ingresar_Permiso_Aplicacion_Usuario` bit(1) DEFAULT NULL,
  `Cmp_Consultar_Permiso_Aplicacion_Usuario` bit(1) DEFAULT NULL,
  `Cmp_Modificar_Permiso_Aplicacion_Usuario` bit(1) DEFAULT NULL,
  `Cmp_Eliminar_Permiso_Aplicacion_Usuario` bit(1) DEFAULT NULL,
  `Cmp_Imprimir_Permiso_Aplicacion_Usuario` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Fk_Id_Usuario`,`Fk_Id_Modulo`,`Fk_Id_Aplicacion`),
  KEY `Fk_Permiso_Modulo_Aplicacion` (`Fk_Id_Modulo`,`Fk_Id_Aplicacion`),
  CONSTRAINT `Fk_Permiso_Modulo_Aplicacion` FOREIGN KEY (`Fk_Id_Modulo`, `Fk_Id_Aplicacion`) REFERENCES `tbl_asignacion_modulo_aplicacion` (`Fk_Id_Modulo`, `Fk_Id_Aplicacion`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `Fk_Permiso_Usuario` FOREIGN KEY (`Fk_Id_Usuario`) REFERENCES `tbl_usuario` (`Pk_Id_Usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_permiso_usuario_aplicacion`
--

LOCK TABLES `tbl_permiso_usuario_aplicacion` WRITE;
/*!40000 ALTER TABLE `tbl_permiso_usuario_aplicacion` DISABLE KEYS */;
INSERT INTO `tbl_permiso_usuario_aplicacion` VALUES (4,4,301,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,4,302,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,4,303,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,4,304,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,4,305,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,4,306,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,4,307,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,4,308,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,301,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,302,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,303,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,304,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,305,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,306,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,307,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,308,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,309,_binary '',_binary '',_binary '',_binary '',_binary '');
/*!40000 ALTER TABLE `tbl_permiso_usuario_aplicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_reportes`
--

DROP TABLE IF EXISTS `tbl_reportes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_reportes` (
  `Pk_Id_Reporte` int NOT NULL AUTO_INCREMENT,
  `Cmp_Titulo_Reporte` varchar(50) DEFAULT NULL,
  `Cmp_Ruta_Reporte` varchar(500) DEFAULT NULL,
  `Cmp_Fecha_Reporte` date DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Reporte`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_reportes`
--

LOCK TABLES `tbl_reportes` WRITE;
/*!40000 ALTER TABLE `tbl_reportes` DISABLE KEYS */;
INSERT INTO `tbl_reportes` VALUES (1,'Reporte final','C:\\Users\\lopez\\OneDrive\\Escritorio\\navegador\\asis2k25p2\\codigo\\componentes\\reporteador\\Base de Datos y Reporte Generado\\ReporteEmpleadosHSC.rpt','2025-01-01'),(2,'Reporte_Prueba','C:\\Users\\lopez\\OneDrive\\Escritorio\\navegador\\asis2k25p2\\codigo\\componentes\\reporteador\\Base de Datos y Reporte Generado\\ReporteEmpleadosHSC.rpt','2025-01-01'),(3,'Perfiles Reporte','C:\\is2k26pf\\codigo\\componentes\\seguridad\\SeguridadMVC\\SeguridadMVC\\CapaVista\\Reporte_perfiles.rpt','2026-02-03'),(5,'Empleados reporte','C:\\is2k26pf\\codigo\\componentes\\seguridad\\SeguridadMVC\\SeguridadMVC\\CapaVista\\Reporte_empleado.rpt','2026-02-05');
/*!40000 ALTER TABLE `tbl_reportes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_token_restaurarcontrasena`
--

DROP TABLE IF EXISTS `tbl_token_restaurarcontrasena`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_token_restaurarcontrasena` (
  `Pk_Id_Token` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Usuario` int DEFAULT NULL,
  `Cmp_Token` varchar(50) DEFAULT NULL,
  `Cmp_Fecha_Creacion_Restaurar_Contrasenea` datetime DEFAULT NULL,
  `Cmp_Expiracion_Restaurar_Contrasenea` datetime DEFAULT NULL,
  `Cmp_Utilizado_Restaurar_Contrasenea` bit(1) DEFAULT NULL,
  `Cmp_Fecha_Uso_Restaurar_Contrasenea` datetime DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Token`),
  KEY `Fk_Token_Usuario` (`Fk_Id_Usuario`),
  CONSTRAINT `Fk_Token_Usuario` FOREIGN KEY (`Fk_Id_Usuario`) REFERENCES `tbl_usuario` (`Pk_Id_Usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_token_restaurarcontrasena`
--

LOCK TABLES `tbl_token_restaurarcontrasena` WRITE;
/*!40000 ALTER TABLE `tbl_token_restaurarcontrasena` DISABLE KEYS */;
INSERT INTO `tbl_token_restaurarcontrasena` VALUES (1,2,'C43C63DA','2025-09-21 18:24:01','2025-09-21 18:29:01',_binary '','2025-09-21 18:24:38'),(2,1,'901DA0A1','2025-09-21 18:31:36','2025-09-21 18:36:36',_binary '','2025-09-21 18:32:15'),(3,1,'990DD530','2025-09-22 10:05:46','2025-09-22 10:10:46',_binary '\0',NULL),(4,1,'39C03B58','2025-09-24 20:53:40','2025-09-24 20:58:40',_binary '','2025-09-24 20:54:05'),(5,1,'21BE635F','2025-09-25 08:36:46','2025-09-25 08:41:46',_binary '','2025-09-25 08:37:06'),(6,7,'28F08413','2025-09-26 19:21:51','2025-09-26 19:26:51',_binary '\0',NULL),(7,24,'314418EF','2025-09-27 10:09:06','2025-09-27 10:14:06',_binary '','2025-09-27 10:09:27'),(8,7,'C30808F1','2025-09-27 12:22:20','2025-09-27 12:27:20',_binary '','2025-09-27 12:22:29'),(9,7,'B1AE042A','2025-09-27 12:22:53','2025-09-27 12:27:53',_binary '','2025-09-27 12:23:00'),(10,7,'183E762C','2025-09-27 12:30:45','2025-09-27 12:35:45',_binary '','2025-09-27 12:31:30'),(11,7,'AB7B8C02','2025-09-27 12:34:27','2025-09-27 12:39:27',_binary '','2025-09-27 12:34:54'),(12,7,'76A7D51E','2025-09-27 17:50:00','2025-09-27 17:55:00',_binary '\0',NULL),(13,7,'F8C4776A','2025-09-27 23:49:38','2025-09-27 23:54:38',_binary '','2025-09-27 23:49:52'),(14,1,'DE59E51C','2025-10-06 22:27:35','2025-10-06 22:32:35',_binary '','2025-10-06 22:27:56'),(15,29,'C577F481','2025-10-08 13:30:21','2025-10-08 13:35:21',_binary '','2025-10-08 13:31:09'),(16,12,'F7A08D82','2025-10-12 08:03:14','2025-10-12 08:08:14',_binary '','2025-10-12 08:03:29'),(17,12,'B1B0EC64','2025-10-12 08:05:58','2025-10-12 08:10:58',_binary '','2025-10-12 08:06:12'),(18,7,'A8806F00','2025-10-12 14:48:07','2025-10-12 14:53:07',_binary '\0',NULL),(19,7,'A02EE0D6','2025-10-12 14:57:40','2025-10-12 15:02:40',_binary '','2025-10-12 14:58:16'),(20,47,'C319527A','2025-10-13 17:23:42','2025-10-13 17:28:42',_binary '','2025-10-13 17:24:22'),(21,53,'18AE161D','2025-10-14 18:31:41','2025-10-14 18:36:41',_binary '','2025-10-14 18:32:04'),(22,2,'F1E15FAE','2025-10-18 11:49:09','2025-10-18 11:54:09',_binary '','2025-10-18 11:50:16'),(23,4,'B07EF449','2025-10-18 12:07:34','2025-10-18 12:12:34',_binary '','2025-10-18 12:08:27'),(24,4,'0C76A696','2025-10-18 17:08:53','2025-10-18 17:13:53',_binary '','2025-10-18 17:09:11'),(25,2,'9BAAF4CB','2025-10-21 13:44:20','2025-10-21 13:49:20',_binary '','2025-10-21 13:44:51'),(26,7,'46B0AC97','2025-10-25 14:48:38','2025-10-25 14:53:38',_binary '','2025-10-25 14:48:59');
/*!40000 ALTER TABLE `tbl_token_restaurarcontrasena` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_usuario`
--

DROP TABLE IF EXISTS `tbl_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_usuario` (
  `Pk_Id_Usuario` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Empleado` int DEFAULT NULL,
  `Cmp_Nombre_Usuario` varchar(50) DEFAULT NULL,
  `Cmp_Contrasena_Usuario` varchar(65) DEFAULT NULL,
  `Cmp_Intentos_Fallidos_Usuario` int DEFAULT NULL,
  `Cmp_Estado_Usuario` bit(1) DEFAULT NULL,
  `Cmp_FechaCreacion_Usuario` datetime DEFAULT NULL,
  `Cmp_Ultimo_Cambio_Contrasenea` datetime DEFAULT NULL,
  `Cmp_Pidio_Cambio_Contrasenea` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Usuario`),
  KEY `Fk_Usuario_Empleado` (`Fk_Id_Empleado`),
  CONSTRAINT `Fk_Usuario_Empleado` FOREIGN KEY (`Fk_Id_Empleado`) REFERENCES `tbl_empleado` (`Pk_Id_Empleado`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=69 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_usuario`
--

LOCK TABLES `tbl_usuario` WRITE;
/*!40000 ALTER TABLE `tbl_usuario` DISABLE KEYS */;
INSERT INTO `tbl_usuario` VALUES (4,2,'brandon','45297c633d331e6ac35169ebaaf75bc7fafd206ebb59ba4efd80566936e46eb0',0,_binary '','2025-09-21 20:49:54','2025-10-18 17:09:11',_binary '\0'),(23,3,'admin','240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9',0,_binary '','2025-09-26 20:45:53','2025-09-26 20:45:53',_binary '\0');
/*!40000 ALTER TABLE `tbl_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_usuario_perfil`
--

DROP TABLE IF EXISTS `tbl_usuario_perfil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_usuario_perfil` (
  `Fk_Id_Usuario` int NOT NULL,
  `Fk_Id_Perfil` int NOT NULL,
  PRIMARY KEY (`Fk_Id_Usuario`,`Fk_Id_Perfil`),
  KEY `Fk_UsuarioPerfil_Perfil` (`Fk_Id_Perfil`),
  CONSTRAINT `Fk_UsuarioPerfil_Perfil` FOREIGN KEY (`Fk_Id_Perfil`) REFERENCES `tbl_perfil` (`Pk_Id_Perfil`),
  CONSTRAINT `Fk_UsuarioPerfil_Usuario` FOREIGN KEY (`Fk_Id_Usuario`) REFERENCES `tbl_usuario` (`Pk_Id_Usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_usuario_perfil`
--

LOCK TABLES `tbl_usuario_perfil` WRITE;
/*!40000 ALTER TABLE `tbl_usuario_perfil` DISABLE KEYS */;
INSERT INTO `tbl_usuario_perfil` VALUES (4,1);
/*!40000 ALTER TABLE `tbl_usuario_perfil` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `vw_listado_cierres`
--

DROP TABLE IF EXISTS `vw_listado_cierres`;
/*!50001 DROP VIEW IF EXISTS `vw_listado_cierres`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vw_listado_cierres` AS SELECT 
 1 AS `id`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `vw_listado_cierres`
--

/*!50001 DROP VIEW IF EXISTS `vw_listado_cierres`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vw_listado_cierres` AS select 1 AS `id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-02-12 22:37:52
