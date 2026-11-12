CREATE DATABASE IF NOT EXISTS bd_auditoria;
USE bd_auditoria;

SET FOREIGN_KEY_CHECKS=0;

DROP TABLE IF EXISTS `tbl_actividad_rubrica`;
CREATE TABLE `tbl_actividad_rubrica` (
  `Pk_Id_Actividad_Rubrica` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Actividad_Proyecto` int NOT NULL,
  `Fk_Id_Rubrica` int NOT NULL,
  `Cmp_Estado_Actividad_Rubrica` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`Pk_Id_Actividad_Rubrica`),
  UNIQUE KEY `Uq_ActividadRubrica` (`Fk_Id_Actividad_Proyecto`,`Fk_Id_Rubrica`),
  KEY `Fk_ActividadRubrica_Rubrica` (`Fk_Id_Rubrica`),
  CONSTRAINT `Fk_ActividadRubrica_ActividadProyecto` FOREIGN KEY (`Fk_Id_Actividad_Proyecto`) REFERENCES `tbl_actividades_proyecto` (`Pk_Id_Actividad_Proyecto`),
  CONSTRAINT `Fk_ActividadRubrica_Rubrica` FOREIGN KEY (`Fk_Id_Rubrica`) REFERENCES `tbl_rubrica` (`Pk_Id_Rubrica`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_actividades_proyecto`;
CREATE TABLE `tbl_actividades_proyecto` (
  `Pk_Id_Actividad_Proyecto` int NOT NULL,
  `Fk_Id_Proyecto` int NOT NULL,
  `Cmp_Nombre_Actividad_Proyecto` varchar(100) NOT NULL,
  `Cmp_Descripcion_Actividad_Proyecto` text,
  `Cmp_Observaciones_Actividad_Proyecto` text,
  PRIMARY KEY (`Pk_Id_Actividad_Proyecto`),
  KEY `Fk_ActividadProyecto_Proyecto` (`Fk_Id_Proyecto`),
  CONSTRAINT `Fk_ActividadProyecto_Proyecto` FOREIGN KEY (`Fk_Id_Proyecto`) REFERENCES `tbl_proyecto` (`Pk_Id_Proyecto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_aplicacion`;
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

INSERT INTO `tbl_aplicacion` VALUES (1,1,'Gestion de empleado','Se gestionan los empleados del hotel',b'1'),(301,5,'Empleados','Control de empleados de la hoteleria',b'1'),(302,NULL,'Usuarios','Control de usuarios de empleados',b'1'),(303,3,'Perfiles','Perfiles que se asignan a usuarios',b'1'),(304,NULL,'Modulos','Mantenimiento de modulos',b'1'),(305,NULL,'Aplicacion','Mantenimiento de aplicaciones',b'1'),(306,NULL,'Asig Aplicacion Usuario','Asigna permisos a usuarios',b'1'),(307,NULL,'Asig aplicacion Perfil','Asigna permisos a perfiles',b'1'),(308,NULL,'Asig Perfiles','Asigna los perfiles a usuarios',b'1'),(309,NULL,'Bitacora','Da acceso a bitacora',b'1'),(500,NULL,'Proyectos','Mantenimiento de proyectos',b'1'),(501,NULL,'Estados de Proyecto','Estados que tiene un proyecto',b'1'),(502,NULL,'Actividades','Actividades de cada proyecto',b'1'),(503,NULL,'Areas','Areas a auditar',b'1'),(504,NULL,'Recursos','Recursos del proyecto',b'1'),(505,NULL,'Perfiles de Auditor','Perfiles que puede tener un auditor',b'1'),(506,NULL,'Estados de Auditor','Estados de un auditor',b'1'),(507,NULL,'Auditores','Mantenimiento de auditores',b'1'),(508,NULL,'Proyecto Auditor','Asigna auditores a un proyecto',b'1'),(509,NULL,'Auditados','Mantenimiento de auditados',b'1'),(510,NULL,'Proyecto Auditado','Asigna auditados a un proyecto',b'1'),(511,NULL,'Estados de Asignacion','Estados de una asignacion',b'1'),(512,NULL,'Asignaciones','Asignaciones de actividades',b'1'),(513,NULL,'Planificacion','Planificacion de la auditoria',b'1'),(514,NULL,'Cronograma','Cronograma de la auditoria',b'1'),(515,NULL,'Rubricas','Mantenimiento de rubricas',b'1'),(516,NULL,'Criterios','Criterios de una rubrica',b'1'),(517,NULL,'Escalas de Descripcion','Escalas de calificacion',b'1'),(518,NULL,'Descripcion de Criterios','Descripcion de cada criterio por escala',b'1'),(519,NULL,'Actividad Rubrica','Relaciona actividades con rubricas',b'1'),(520,NULL,'Ponderacion','Tabla de ponderacion',b'1'),(521,NULL,'Estados de Informe','Estados de un informe',b'1'),(522,NULL,'Informes','Mantenimiento de informes',b'1'),(523,NULL,'Checklist','Checklist de entregables',b'1'),(524,NULL,'Reportes','Reportes de auditoria',b'1'),(525,NULL,'Graficas','Graficas de resultados',b'1');

DROP TABLE IF EXISTS `tbl_areas`;
CREATE TABLE `tbl_areas` (
  `Pk_Id_Area` int NOT NULL,
  `Fk_Id_Proyecto` int NOT NULL,
  `Cmp_Nombre_Area` varchar(100) NOT NULL,
  `Cmp_Descripcion_Area` text,
  `Cmp_Estado_Area` varchar(100) NOT NULL,
  PRIMARY KEY (`Pk_Id_Area`),
  KEY `Fk_Area_Proyecto` (`Fk_Id_Proyecto`),
  CONSTRAINT `Fk_Area_Proyecto` FOREIGN KEY (`Fk_Id_Proyecto`) REFERENCES `tbl_proyecto` (`Pk_Id_Proyecto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_asignacion`;
CREATE TABLE `tbl_asignacion` (
  `Pk_Id_Asignacion` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Auditor` int NOT NULL,
  `Fk_Id_Auditado` int NOT NULL,
  `Fk_Id_Estado_Asignacion` int NOT NULL,
  `Fk_Id_Actividad_Rubrica` int NOT NULL,
  `Cmp_Nombre_Asignacion` varchar(100) NOT NULL,
  `Cmp_Fecha_Asignacion` date NOT NULL,
  `Cmp_Fecha_Finalizacion_Asignacion` date DEFAULT NULL,
  `Cmp_Descripcion_Asignacion` text,
  `Cmp_Evidencia_Asignacion` varchar(255) DEFAULT NULL,
  `Cmp_Observaciones_Asignacion` text,
  PRIMARY KEY (`Pk_Id_Asignacion`),
  KEY `Fk_Asignacion_Auditor` (`Fk_Id_Auditor`),
  KEY `Fk_Asignacion_Auditado` (`Fk_Id_Auditado`),
  KEY `Fk_Asignacion_EstadoAsignacion` (`Fk_Id_Estado_Asignacion`),
  KEY `Fk_Asignacion_ActividadRubrica` (`Fk_Id_Actividad_Rubrica`),
  CONSTRAINT `Fk_Asignacion_ActividadRubrica` FOREIGN KEY (`Fk_Id_Actividad_Rubrica`) REFERENCES `tbl_actividad_rubrica` (`Pk_Id_Actividad_Rubrica`),
  CONSTRAINT `Fk_Asignacion_Auditado` FOREIGN KEY (`Fk_Id_Auditado`) REFERENCES `tbl_auditados` (`Pk_Id_Auditado`),
  CONSTRAINT `Fk_Asignacion_Auditor` FOREIGN KEY (`Fk_Id_Auditor`) REFERENCES `tbl_auditor` (`Pk_Id_Auditor`),
  CONSTRAINT `Fk_Asignacion_EstadoAsignacion` FOREIGN KEY (`Fk_Id_Estado_Asignacion`) REFERENCES `tbl_estado_asignacion` (`Pk_Id_Estado_Asignacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_asignacion_modulo_aplicacion`;
CREATE TABLE `tbl_asignacion_modulo_aplicacion` (
  `Fk_Id_Modulo` int NOT NULL,
  `Fk_Id_Aplicacion` int NOT NULL,
  PRIMARY KEY (`Fk_Id_Modulo`,`Fk_Id_Aplicacion`),
  KEY `Fk_AsigAplicacion` (`Fk_Id_Aplicacion`),
  CONSTRAINT `Fk_AsigAplicacion` FOREIGN KEY (`Fk_Id_Aplicacion`) REFERENCES `tbl_aplicacion` (`Pk_Id_Aplicacion`),
  CONSTRAINT `Fk_AsigModulo` FOREIGN KEY (`Fk_Id_Modulo`) REFERENCES `tbl_modulo` (`Pk_Id_Modulo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `tbl_asignacion_modulo_aplicacion` VALUES (4,301),(4,302),(4,303),(4,304),(4,305),(4,306),(4,307),(4,308),(4,309),(10,500),(10,501),(10,502),(10,503),(10,504),(11,505),(11,506),(11,507),(11,508),(11,509),(11,510),(11,511),(11,512),(12,513),(12,514),(12,515),(12,516),(12,517),(12,518),(12,519),(12,520),(13,521),(13,522),(13,523),(13,524),(13,525);

DROP TABLE IF EXISTS `tbl_auditados`;
CREATE TABLE `tbl_auditados` (
  `Pk_Id_Auditado` int NOT NULL AUTO_INCREMENT,
  `Cmp_Nombre_Auditado` varchar(100) NOT NULL,
  `Cmp_Cargo_Area_Auditado` varchar(100) DEFAULT NULL,
  `Cmp_Correo_Auditado` varchar(100) DEFAULT NULL,
  `Cmp_Telefono_Auditado` varchar(20) DEFAULT NULL,
  `Cmp_Observaciones_Auditado` text,
  PRIMARY KEY (`Pk_Id_Auditado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_auditor`;
CREATE TABLE `tbl_auditor` (
  `Pk_Id_Auditor` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Estado_Auditor` int NOT NULL,
  `Cmp_Nombre_Auditor` varchar(45) DEFAULT NULL,
  `Cmp_Telefono_Auditor` varchar(45) DEFAULT NULL,
  `Cmp_Email_Auditor` varchar(100) DEFAULT NULL,
  `Cmp_Carnet_Auditor` varchar(15) NOT NULL,
  PRIMARY KEY (`Pk_Id_Auditor`),
  KEY `Fk_Auditor_EstadoAuditor` (`Fk_Id_Estado_Auditor`),
  CONSTRAINT `Fk_Auditor_EstadoAuditor` FOREIGN KEY (`Fk_Id_Estado_Auditor`) REFERENCES `tbl_estado_auditor` (`Pk_Id_Estado_Auditor`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `tbl_auditor` VALUES (2,1,'Juan Perez Lopez','5555-1234','juan.perez@ex.com','AUD-0002'),(3,1,'Juan Pruebas','1234','@pruebas','AUD-0003');

DROP TABLE IF EXISTS `tbl_bitacora`;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_bloqueo_usuario`;
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

DROP TABLE IF EXISTS `tbl_checklist`;
CREATE TABLE `tbl_checklist` (
  `Pk_id_checklist` int NOT NULL AUTO_INCREMENT,
  `Fk_id_informe` int NOT NULL,
  `Fk_id_actividad_rubrica` int NOT NULL,
  `Entregado` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Pk_id_checklist`),
  UNIQUE KEY `uq_informe_actividad` (`Fk_id_informe`,`Fk_id_actividad_rubrica`),
  KEY `Fk_Checklist_Informe` (`Fk_id_informe`),
  KEY `Fk_Checklist_ActividadRubrica` (`Fk_id_actividad_rubrica`),
  CONSTRAINT `Fk_Checklist_ActividadRubrica` FOREIGN KEY (`Fk_id_actividad_rubrica`) REFERENCES `tbl_actividad_rubrica` (`Pk_Id_Actividad_Rubrica`),
  CONSTRAINT `Fk_Checklist_Informe` FOREIGN KEY (`Fk_id_informe`) REFERENCES `tbl_informe` (`Pk_id_informe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_criterios`;
CREATE TABLE `tbl_criterios` (
  `Pk_Id_Criterio` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Rubrica` int NOT NULL,
  `Cmp_Nombre_Criterio` varchar(100) NOT NULL,
  `Cmp_Porcentaje_Criterio` int DEFAULT NULL,
  `Cmp_Descripcion_Criterio` text,
  `Cmp_Nivel_Importancia_Criterio` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Criterio`),
  UNIQUE KEY `Uq_Criterio_Rubrica_Nombre` (`Fk_Id_Rubrica`,`Cmp_Nombre_Criterio`),
  CONSTRAINT `Fk_Criterio_Rubrica` FOREIGN KEY (`Fk_Id_Rubrica`) REFERENCES `tbl_rubrica` (`Pk_Id_Rubrica`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `Chk_Criterio_Importancia` CHECK (((`Cmp_Nivel_Importancia_Criterio` is null) or (`Cmp_Nivel_Importancia_Criterio` in (_utf8mb4'Alta',_utf8mb4'Media',_utf8mb4'Baja')))),
  CONSTRAINT `Chk_Criterio_Porcentaje` CHECK (((`Cmp_Porcentaje_Criterio` is null) or (`Cmp_Porcentaje_Criterio` between 0 and 100)))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_cronograma`;
CREATE TABLE `tbl_cronograma` (
  `Pk_Id_Cronograma` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Planificacion` int NOT NULL,
  `Fk_Id_Actividad_Proyecto` int NOT NULL,
  `Cmp_Nombre_Tarea_Cronograma` varchar(100) NOT NULL,
  `Cmp_Descripcion_Cronograma` text,
  `Cmp_Fecha_Inicio_Cronograma` date NOT NULL,
  `Cmp_Fecha_Fin_Cronograma` date NOT NULL,
  `Cmp_Responsable_Tarea_Cronograma` varchar(100) DEFAULT NULL,
  `Cmp_Estado_Tarea_Cronograma` varchar(100) DEFAULT 'Pendiente',
  `Cmp_Observaciones_Cronograma` text,
  PRIMARY KEY (`Pk_Id_Cronograma`),
  KEY `Fk_Cronograma_Planificacion` (`Fk_Id_Planificacion`),
  KEY `Fk_Cronograma_ActividadProyecto` (`Fk_Id_Actividad_Proyecto`),
  CONSTRAINT `Fk_Cronograma_ActividadProyecto` FOREIGN KEY (`Fk_Id_Actividad_Proyecto`) REFERENCES `tbl_actividades_proyecto` (`Pk_Id_Actividad_Proyecto`),
  CONSTRAINT `Fk_Cronograma_Planificacion` FOREIGN KEY (`Fk_Id_Planificacion`) REFERENCES `tbl_planificacion` (`Pk_Id_Planificacion`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `Chk_Cronograma_Estado` CHECK (((`Cmp_Estado_Tarea_Cronograma` is null) or (`Cmp_Estado_Tarea_Cronograma` in (_utf8mb4'Pendiente',_utf8mb4'En proceso',_utf8mb4'Completada',_utf8mb4'Cancelada')))),
  CONSTRAINT `Chk_Cronograma_Fechas` CHECK ((`Cmp_Fecha_Fin_Cronograma` >= `Cmp_Fecha_Inicio_Cronograma`))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_descripcion_criterio`;
CREATE TABLE `tbl_descripcion_criterio` (
  `Pk_Id_Descripcion_Criterio` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Criterio` int NOT NULL,
  `Fk_Id_Escala` int NOT NULL,
  `Cmp_Descripcion_Detallada_Descripcion_Criterio` text NOT NULL,
  `Cmp_Evidencia_Requerida_Descripcion_Criterio` text,
  `Cmp_Observaciones_Descripcion_Criterio` text,
  PRIMARY KEY (`Pk_Id_Descripcion_Criterio`),
  UNIQUE KEY `Uq_DescripcionCriterio_Criterio_Escala` (`Fk_Id_Criterio`,`Fk_Id_Escala`),
  KEY `Fk_DescripcionCriterio_Criterio` (`Fk_Id_Criterio`),
  KEY `Fk_DescripcionCriterio_Escala` (`Fk_Id_Escala`),
  CONSTRAINT `Fk_DescripcionCriterio_Criterio` FOREIGN KEY (`Fk_Id_Criterio`) REFERENCES `tbl_criterios` (`Pk_Id_Criterio`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `Fk_DescripcionCriterio_Escala` FOREIGN KEY (`Fk_Id_Escala`) REFERENCES `tbl_escala_descripcion` (`Pk_Id_Escala`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_escala_descripcion`;
CREATE TABLE `tbl_escala_descripcion` (
  `Pk_Id_Escala` int NOT NULL AUTO_INCREMENT,
  `Cmp_Porcentaje_Escala` int NOT NULL,
  `Cmp_Nombre_Nivel_Escala` varchar(50) NOT NULL,
  `Cmp_Descripcion_General_Escala` text,
  `Cmp_Color_Referencia_Escala` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Escala`),
  UNIQUE KEY `Uq_Escala_Porcentaje` (`Cmp_Porcentaje_Escala`),
  CONSTRAINT `Chk_Escala_Porcentaje` CHECK ((`Cmp_Porcentaje_Escala` in (0,20,40,60,80,100)))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_estado_asignacion`;
CREATE TABLE `tbl_estado_asignacion` (
  `Pk_Id_Estado_Asignacion` int NOT NULL,
  `Cmp_Nombre_Estado_Asignacion` varchar(50) NOT NULL,
  `Cmp_Descripcion_Estado_Asignacion` text,
  PRIMARY KEY (`Pk_Id_Estado_Asignacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_estado_auditor`;
CREATE TABLE `tbl_estado_auditor` (
  `Pk_Id_Estado_Auditor` int NOT NULL AUTO_INCREMENT,
  `Cmp_Nombre_Estado_Auditor` varchar(45) NOT NULL,
  PRIMARY KEY (`Pk_Id_Estado_Auditor`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `tbl_estado_auditor` VALUES (1,'1'),(2,'0');

DROP TABLE IF EXISTS `tbl_estado_informe`;
CREATE TABLE `tbl_estado_informe` (
  `Pk_Id_Estado_Informe` int NOT NULL,
  `Cmp_Nombre_Estado_Informe` varchar(50) NOT NULL,
  `Cmp_Descripcion_Estado_Informe` text,
  PRIMARY KEY (`Pk_Id_Estado_Informe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_grafica`;
CREATE TABLE `tbl_grafica` (
  `Pk_id_grafica` int NOT NULL AUTO_INCREMENT,
  `Fk_id_proyecto` int NOT NULL,
  `tipo_grafica` varchar(50) NOT NULL,
  `descripcion` text,
  `datos_json_grafica` json DEFAULT NULL,
  PRIMARY KEY (`Pk_id_grafica`),
  KEY `Fk_Grafica_Proyecto` (`Fk_id_proyecto`),
  CONSTRAINT `Fk_Grafica_Proyecto` FOREIGN KEY (`Fk_id_proyecto`) REFERENCES `tbl_proyecto` (`Pk_Id_Proyecto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_informe`;
CREATE TABLE `tbl_informe` (
  `Pk_id_informe` int NOT NULL AUTO_INCREMENT,
  `Fk_id_auditor` int NOT NULL,
  `Fk_id_estado_informe` int NOT NULL,
  `Fk_id_proyecto` int NOT NULL,
  `titulo_informe` varchar(150) NOT NULL,
  `fecha_creacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `fecha_actualizacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Pk_id_informe`),
  KEY `Fk_Informe_Auditor` (`Fk_id_auditor`),
  KEY `Fk_Informe_EstadoInforme` (`Fk_id_estado_informe`),
  KEY `Fk_Informe_Proyecto` (`Fk_id_proyecto`),
  CONSTRAINT `Fk_Informe_Auditor` FOREIGN KEY (`Fk_id_auditor`) REFERENCES `tbl_auditor` (`Pk_Id_Auditor`),
  CONSTRAINT `Fk_Informe_EstadoInforme` FOREIGN KEY (`Fk_id_estado_informe`) REFERENCES `tbl_estado_informe` (`Pk_Id_Estado_Informe`),
  CONSTRAINT `Fk_Informe_Proyecto` FOREIGN KEY (`Fk_id_proyecto`) REFERENCES `tbl_proyecto` (`Pk_Id_Proyecto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_modulo`;
CREATE TABLE `tbl_modulo` (
  `Pk_Id_Modulo` int NOT NULL,
  `Cmp_Nombre_Modulo` varchar(50) DEFAULT NULL,
  `Cmp_Descripcion_Modulo` varchar(50) DEFAULT NULL,
  `Cmp_Estado_Modulo` bit(1) NOT NULL,
  PRIMARY KEY (`Pk_Id_Modulo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `tbl_modulo` VALUES (2,'Navegador','Modulo de navegador',b'1'),(4,'Seguridad','Modulo de seguridad de la hoteleria',b'1'),(10,'Proyectos','Gestion de proyectos de auditoria',b'1'),(11,'Auditores y Asignaciones','Auditores, auditados y asignaciones',b'1'),(12,'Planificacion y Rubricas','Planificacion, cronograma y rubricas',b'1'),(13,'Informes','Informes, checklist, reportes y graficas',b'1');

DROP TABLE IF EXISTS `tbl_perfil`;
CREATE TABLE `tbl_perfil` (
  `Pk_Id_Perfil` int NOT NULL AUTO_INCREMENT,
  `Cmp_Puesto_Perfil` varchar(50) DEFAULT NULL,
  `Cmp_Descripcion_Perfil` varchar(50) DEFAULT NULL,
  `Cmp_Estado_Perfil` bit(1) NOT NULL,
  `Cmp_Tipo_Perfil` int DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Perfil`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `tbl_perfil` VALUES (1,'Administrador','Perfil con todos los permisos',b'1',1);

DROP TABLE IF EXISTS `tbl_perfil_auditor`;
CREATE TABLE `tbl_perfil_auditor` (
  `Pk_Id_Perfil_Auditor` int NOT NULL AUTO_INCREMENT,
  `Cmp_Nombre_Perfil_Auditor` varchar(50) NOT NULL,
  `Cmp_Descripcion_Perfil` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Perfil_Auditor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_permiso_perfil_aplicacion`;
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

INSERT INTO `tbl_permiso_perfil_aplicacion` VALUES (1,4,301,b'1',b'1',b'1',b'1',b'1'),(1,4,305,b'1',b'1',b'1',b'1',b'1'),(1,4,306,b'0',b'1',b'0',b'0',b'0'),(1,4,309,b'1',b'1',b'1',b'1',b'1');

DROP TABLE IF EXISTS `tbl_permiso_usuario_aplicacion`;
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

INSERT INTO `tbl_permiso_usuario_aplicacion` VALUES (4,4,301,b'1',b'1',b'1',b'1',b'1'),(4,4,302,b'1',b'1',b'1',b'1',b'1'),(4,4,303,b'1',b'1',b'1',b'1',b'1'),(4,4,304,b'1',b'1',b'1',b'1',b'1'),(4,4,305,b'1',b'1',b'1',b'1',b'1'),(4,4,306,b'1',b'1',b'1',b'1',b'1'),(4,4,307,b'1',b'1',b'1',b'1',b'1'),(4,4,308,b'1',b'1',b'1',b'1',b'1'),(23,4,301,b'1',b'1',b'1',b'1',b'1'),(23,4,302,b'1',b'1',b'1',b'1',b'1'),(23,4,303,b'1',b'1',b'1',b'1',b'1'),(23,4,304,b'1',b'1',b'1',b'1',b'1'),(23,4,305,b'1',b'1',b'1',b'1',b'1'),(23,4,306,b'1',b'1',b'1',b'1',b'1'),(23,4,307,b'1',b'1',b'1',b'1',b'1'),(23,4,308,b'1',b'1',b'1',b'1',b'1'),(23,4,309,b'1',b'1',b'1',b'1',b'1');

DROP TABLE IF EXISTS `tbl_planificacion`;
CREATE TABLE `tbl_planificacion` (
  `Pk_Id_Planificacion` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Proyecto` int NOT NULL,
  `Cmp_Nombre_Plan_Planificacion` varchar(100) NOT NULL,
  `Cmp_Descripcion_Planificacion` text,
  `Cmp_Fecha_Inicio_Planificacion` date DEFAULT NULL,
  `Cmp_Fecha_Fin_Planificacion` date DEFAULT NULL,
  `Cmp_Observaciones_Planificacion` text,
  PRIMARY KEY (`Pk_Id_Planificacion`),
  KEY `Fk_Planificacion_Proyecto` (`Fk_Id_Proyecto`),
  CONSTRAINT `Fk_Planificacion_Proyecto` FOREIGN KEY (`Fk_Id_Proyecto`) REFERENCES `tbl_proyecto` (`Pk_Id_Proyecto`),
  CONSTRAINT `Chk_Planificacion_Fechas` CHECK (((`Cmp_Fecha_Fin_Planificacion` is null) or (`Cmp_Fecha_Inicio_Planificacion` is null) or (`Cmp_Fecha_Fin_Planificacion` >= `Cmp_Fecha_Inicio_Planificacion`)))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_proyecto`;
CREATE TABLE `tbl_proyecto` (
  `Pk_Id_Proyecto` int NOT NULL,
  `Fk_Id_Proyecto_Estado` int NOT NULL,
  `Cmp_Nombre_Proyecto` varchar(100) NOT NULL,
  `Cmp_Descripcion_Proyecto` text,
  `Cmp_Fecha_Inicio_Proyecto` date DEFAULT NULL,
  `Cmp_Fecha_Fin_Proyecto` date DEFAULT NULL,
  `Cmp_Objetivo_Proyecto` text,
  PRIMARY KEY (`Pk_Id_Proyecto`),
  KEY `Fk_Proyecto_ProyectoEstado` (`Fk_Id_Proyecto_Estado`),
  CONSTRAINT `Fk_Proyecto_ProyectoEstado` FOREIGN KEY (`Fk_Id_Proyecto_Estado`) REFERENCES `tbl_proyecto_estado` (`Pk_Id_Proyecto_Estado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_proyecto_auditado`;
CREATE TABLE `tbl_proyecto_auditado` (
  `Pk_Id_Proyecto_Auditado` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Proyecto` int NOT NULL,
  `Fk_Id_Auditado` int NOT NULL,
  `Cmp_Fecha_Ingreso_Auditado` date DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Proyecto_Auditado`),
  KEY `Fk_ProyectoAuditado_Proyecto` (`Fk_Id_Proyecto`),
  KEY `Fk_ProyectoAuditado_Auditado` (`Fk_Id_Auditado`),
  CONSTRAINT `Fk_ProyectoAuditado_Auditado` FOREIGN KEY (`Fk_Id_Auditado`) REFERENCES `tbl_auditados` (`Pk_Id_Auditado`),
  CONSTRAINT `Fk_ProyectoAuditado_Proyecto` FOREIGN KEY (`Fk_Id_Proyecto`) REFERENCES `tbl_proyecto` (`Pk_Id_Proyecto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_proyecto_auditor`;
CREATE TABLE `tbl_proyecto_auditor` (
  `Pk_Id_Proyecto_Auditor` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Proyecto` int NOT NULL,
  `Fk_Id_Auditor` int NOT NULL,
  `Fk_Id_Perfil_Auditor` int NOT NULL,
  `Cmp_Fecha_Asignacion_Proyecto` date DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Proyecto_Auditor`),
  KEY `Fk_ProyectoAuditor_Proyecto` (`Fk_Id_Proyecto`),
  KEY `Fk_ProyectoAuditor_Auditor` (`Fk_Id_Auditor`),
  KEY `Fk_ProyectoAuditor_Perfil` (`Fk_Id_Perfil_Auditor`),
  CONSTRAINT `Fk_ProyectoAuditor_Auditor` FOREIGN KEY (`Fk_Id_Auditor`) REFERENCES `tbl_auditor` (`Pk_Id_Auditor`),
  CONSTRAINT `Fk_ProyectoAuditor_Perfil` FOREIGN KEY (`Fk_Id_Perfil_Auditor`) REFERENCES `tbl_perfil_auditor` (`Pk_Id_Perfil_Auditor`),
  CONSTRAINT `Fk_ProyectoAuditor_Proyecto` FOREIGN KEY (`Fk_Id_Proyecto`) REFERENCES `tbl_proyecto` (`Pk_Id_Proyecto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_proyecto_estado`;
CREATE TABLE `tbl_proyecto_estado` (
  `Pk_Id_Proyecto_Estado` int NOT NULL,
  `Cmp_Nombre_Proyecto_Estado` varchar(50) NOT NULL,
  `Cmp_Descripcion_Proyecto_Estado` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Proyecto_Estado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_recursos`;
CREATE TABLE `tbl_recursos` (
  `Pk_Id_Recurso` int NOT NULL,
  `Fk_Id_Proyecto` int NOT NULL,
  `Cmp_Nombre_Recurso` varchar(100) NOT NULL,
  `Cmp_Tipo_Recurso` varchar(100) NOT NULL,
  `Cmp_Cantidad_Recurso` int DEFAULT '1',
  `Cmp_Fecha_Registro_Recurso` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Pk_Id_Recurso`),
  KEY `Fk_Recurso_Proyecto` (`Fk_Id_Proyecto`),
  CONSTRAINT `Fk_Recurso_Proyecto` FOREIGN KEY (`Fk_Id_Proyecto`) REFERENCES `tbl_proyecto` (`Pk_Id_Proyecto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_reporte`;
CREATE TABLE `tbl_reporte` (
  `Pk_id_reporte` int NOT NULL AUTO_INCREMENT,
  `Fk_id_informe` int NOT NULL,
  `Fk_id_actividad_rubrica` int NOT NULL,
  `aspectos_positivos` text NOT NULL,
  `imagen_aspectos_positivos` varchar(500) NOT NULL,
  `correcciones` text NOT NULL,
  `imagen_correcciones` varchar(500) NOT NULL,
  `recomendaciones` text NOT NULL,
  `imagen_recomendaciones` varchar(500) NOT NULL,
  PRIMARY KEY (`Pk_id_reporte`),
  KEY `Fk_Reporte_Informe` (`Fk_id_informe`),
  KEY `Fk_Reporte_ActividadRubrica` (`Fk_id_actividad_rubrica`),
  CONSTRAINT `Fk_Reporte_ActividadRubrica` FOREIGN KEY (`Fk_id_actividad_rubrica`) REFERENCES `tbl_actividad_rubrica` (`Pk_Id_Actividad_Rubrica`),
  CONSTRAINT `Fk_Reporte_Informe` FOREIGN KEY (`Fk_id_informe`) REFERENCES `tbl_informe` (`Pk_id_informe`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_reportes`;
CREATE TABLE `tbl_reportes` (
  `Pk_Id_Reporte` int NOT NULL AUTO_INCREMENT,
  `Cmp_Titulo_Reporte` varchar(50) DEFAULT NULL,
  `Cmp_Ruta_Reporte` varchar(500) DEFAULT NULL,
  `Cmp_Fecha_Reporte` date DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Reporte`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `tbl_reportes` VALUES (1,'Reporte final','C:\\Users\\lopez\\OneDrive\\Escritorio\\navegador\\asis2k25p2\\codigo\\componentes\\reporteador\\Base de Datos y Reporte Generado\\ReporteEmpleadosHSC.rpt','2025-01-01'),(2,'Reporte_Prueba','C:\\Users\\lopez\\OneDrive\\Escritorio\\navegador\\asis2k25p2\\codigo\\componentes\\reporteador\\Base de Datos y Reporte Generado\\ReporteEmpleadosHSC.rpt','2025-01-01'),(3,'Perfiles Reporte','C:\\is2k26pf\\codigo\\componentes\\seguridad\\SeguridadMVC\\SeguridadMVC\\CapaVista\\Reporte_perfiles.rpt','2026-02-03'),(5,'Empleados reporte','C:\\is2k26pf\\codigo\\componentes\\seguridad\\SeguridadMVC\\SeguridadMVC\\CapaVista\\Reporte_empleado.rpt','2026-02-05');

DROP TABLE IF EXISTS `tbl_rubrica`;
CREATE TABLE `tbl_rubrica` (
  `Pk_Id_Rubrica` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Cronograma` int NOT NULL,
  `Cmp_Nombre_Rubrica` varchar(100) NOT NULL,
  `Cmp_Descripcion_Rubrica` text,
  `Cmp_Objetivo_Rubrica` text,
  PRIMARY KEY (`Pk_Id_Rubrica`),
  KEY `Fk_Rubrica_Cronograma` (`Fk_Id_Cronograma`),
  CONSTRAINT `Fk_Rubrica_Cronograma` FOREIGN KEY (`Fk_Id_Cronograma`) REFERENCES `tbl_cronograma` (`Pk_Id_Cronograma`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_tabla_ponderacion`;
CREATE TABLE `tbl_tabla_ponderacion` (
  `Pk_Id_Ponderacion` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Auditado` int NOT NULL,
  `Fk_Id_Cronograma` int NOT NULL,
  `Fk_Id_Rubrica` int NOT NULL,
  `Fk_Id_Criterio` int NOT NULL,
  `Fk_Id_Escala` int NOT NULL,
  `Cmp_Calificacion_Porcentaje_Ponderacion` decimal(5,2) NOT NULL DEFAULT '0.00',
  `Cmp_Calificacion_Ponderada_Ponderacion` decimal(6,2) NOT NULL DEFAULT '0.00',
  `Cmp_Comentarios_Auditor_Ponderacion` text,
  `Cmp_Fecha_Evaluacion_Ponderacion` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Pk_Id_Ponderacion`),
  UNIQUE KEY `Uq_Ponderacion_Auditado_Criterio` (`Fk_Id_Auditado`,`Fk_Id_Criterio`),
  KEY `Fk_Ponderacion_Auditado` (`Fk_Id_Auditado`),
  KEY `Fk_Ponderacion_Cronograma` (`Fk_Id_Cronograma`),
  KEY `Fk_Ponderacion_Rubrica` (`Fk_Id_Rubrica`),
  KEY `Fk_Ponderacion_Criterio` (`Fk_Id_Criterio`),
  KEY `Fk_Ponderacion_Escala` (`Fk_Id_Escala`),
  CONSTRAINT `Fk_Ponderacion_Auditado` FOREIGN KEY (`Fk_Id_Auditado`) REFERENCES `tbl_auditados` (`Pk_Id_Auditado`),
  CONSTRAINT `Fk_Ponderacion_Criterio` FOREIGN KEY (`Fk_Id_Criterio`) REFERENCES `tbl_criterios` (`Pk_Id_Criterio`),
  CONSTRAINT `Fk_Ponderacion_Cronograma` FOREIGN KEY (`Fk_Id_Cronograma`) REFERENCES `tbl_cronograma` (`Pk_Id_Cronograma`),
  CONSTRAINT `Fk_Ponderacion_Escala` FOREIGN KEY (`Fk_Id_Escala`) REFERENCES `tbl_escala_descripcion` (`Pk_Id_Escala`),
  CONSTRAINT `Fk_Ponderacion_Rubrica` FOREIGN KEY (`Fk_Id_Rubrica`) REFERENCES `tbl_rubrica` (`Pk_Id_Rubrica`),
  CONSTRAINT `Chk_Ponderacion_Ponderada` CHECK ((`Cmp_Calificacion_Ponderada_Ponderacion` between 0 and 100)),
  CONSTRAINT `Chk_Ponderacion_Porcentaje` CHECK ((`Cmp_Calificacion_Porcentaje_Ponderacion` between 0 and 100))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `tbl_token_restaurarcontrasena`;
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
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `tbl_token_restaurarcontrasena` VALUES (23,4,'B07EF449','2025-10-18 12:07:34','2025-10-18 12:12:34',b'1','2025-10-18 12:08:27'),(24,4,'0C76A696','2025-10-18 17:08:53','2025-10-18 17:13:53',b'1','2025-10-18 17:09:11');

DROP TABLE IF EXISTS `tbl_usuario`;
CREATE TABLE `tbl_usuario` (
  `Pk_Id_Usuario` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Auditor` int DEFAULT NULL,
  `Cmp_Nombre_Usuario` varchar(50) DEFAULT NULL,
  `Cmp_Contrasena_Usuario` varchar(65) DEFAULT NULL,
  `Cmp_Intentos_Fallidos_Usuario` int DEFAULT NULL,
  `Cmp_Estado_Usuario` bit(1) DEFAULT NULL,
  `Cmp_FechaCreacion_Usuario` datetime DEFAULT NULL,
  `Cmp_Ultimo_Cambio_Contrasenea` datetime DEFAULT NULL,
  `Cmp_Pidio_Cambio_Contrasenea` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Usuario`),
  KEY `Fk_Usuario_Auditor` (`Fk_Id_Auditor`),
  CONSTRAINT `Fk_Usuario_Auditor` FOREIGN KEY (`Fk_Id_Auditor`) REFERENCES `tbl_auditor` (`Pk_Id_Auditor`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `tbl_usuario` VALUES (4,2,'brandon','45297c633d331e6ac35169ebaaf75bc7fafd206ebb59ba4efd80566936e46eb0',0,b'1','2025-09-21 20:49:54','2025-10-18 17:09:11',b'0'),(23,3,'admin','240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9',0,b'1','2025-09-26 20:45:53','2025-09-26 20:45:53',b'0');

DROP TABLE IF EXISTS `tbl_usuario_perfil`;
CREATE TABLE `tbl_usuario_perfil` (
  `Fk_Id_Usuario` int NOT NULL,
  `Fk_Id_Perfil` int NOT NULL,
  PRIMARY KEY (`Fk_Id_Usuario`,`Fk_Id_Perfil`),
  KEY `Fk_UsuarioPerfil_Perfil` (`Fk_Id_Perfil`),
  CONSTRAINT `Fk_UsuarioPerfil_Perfil` FOREIGN KEY (`Fk_Id_Perfil`) REFERENCES `tbl_perfil` (`Pk_Id_Perfil`),
  CONSTRAINT `Fk_UsuarioPerfil_Usuario` FOREIGN KEY (`Fk_Id_Usuario`) REFERENCES `tbl_usuario` (`Pk_Id_Usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `tbl_usuario_perfil` VALUES (4,1);


INSERT INTO tbl_permiso_usuario_aplicacion
  (Fk_Id_Usuario, Fk_Id_Modulo, Fk_Id_Aplicacion,
   Cmp_Ingresar_Permiso_Aplicacion_Usuario, Cmp_Consultar_Permiso_Aplicacion_Usuario,
   Cmp_Modificar_Permiso_Aplicacion_Usuario, Cmp_Eliminar_Permiso_Aplicacion_Usuario,
   Cmp_Imprimir_Permiso_Aplicacion_Usuario)
SELECT u.Pk_Id_Usuario, am.Fk_Id_Modulo, am.Fk_Id_Aplicacion, b'1', b'1', b'1', b'1', b'1'
FROM tbl_usuario u
JOIN tbl_asignacion_modulo_aplicacion am ON am.Fk_Id_Modulo IN (10,11,12,13)
WHERE u.Pk_Id_Usuario IN (4,23);


SET FOREIGN_KEY_CHECKS=1;
-- ------------------------------------------- DATOS PRUEBA ------------------------------------------------
USE bd_auditoria;
INSERT IGNORE INTO tbl_proyecto_estado
  (Pk_Id_Proyecto_Estado, Cmp_Nombre_Proyecto_Estado, Cmp_Descripcion_Proyecto_Estado)
VALUES
  (1, 'En curso',   'Proyecto en ejecución'),
  (2, 'Finalizado', 'Proyecto terminado');

INSERT IGNORE INTO tbl_proyecto
  (Pk_Id_Proyecto, Fk_Id_Proyecto_Estado, Cmp_Nombre_Proyecto, Cmp_Descripcion_Proyecto,
   Cmp_Fecha_Inicio_Proyecto, Cmp_Fecha_Fin_Proyecto, Cmp_Objetivo_Proyecto)
VALUES
  (1, 1, 'Auditoría de infraestructura', 'Revisión de servidores y red', '2026-10-01', '2026-12-15', 'Evaluar la infraestructura de TI'),
  (2, 1, 'Auditoría de capacitación',   'Revisión del plan de capacitación', '2026-11-01', '2027-01-31', 'Evaluar la formación del personal');