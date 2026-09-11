-- ------------------------------------------V2------------------------------------------
-- Este script tiene algunos datos en seguridad y en la tabla de auditor(porque el usuarios esta conectado al auditor)

DROP DATABASE IF EXISTS bd_auditoria;

CREATE DATABASE IF NOT EXISTS bd_auditoria;
USE bd_auditoria;

-- ------------------------------------------Auditoria------------------------------------------
DROP TABLE IF EXISTS tbl_proyecto_estado;
CREATE TABLE tbl_proyecto_estado (
  Pk_Id_Proyecto_Estado int NOT NULL,
  Cmp_Nombre_Proyecto_Estado varchar(50) NOT NULL,
  Cmp_Descripcion_Proyecto_Estado varchar(150) DEFAULT NULL,
  PRIMARY KEY (Pk_Id_Proyecto_Estado)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO tbl_proyecto_estado (Pk_Id_Proyecto_Estado, Cmp_Nombre_Proyecto_Estado, Cmp_Descripcion_Proyecto_Estado) VALUES
  (1, 'En progreso', 'El proyecto se encuentra actualmente en fase de auditoria');

DROP TABLE IF EXISTS tbl_proyecto;
CREATE TABLE tbl_proyecto (
  Pk_Id_Proyecto int NOT NULL,
  Fk_Id_Proyecto_Estado int NOT NULL,
  Cmp_Nombre_Proyecto varchar(100) NOT NULL,
  Cmp_Descripcion_Proyecto text,
  Cmp_Fecha_Inicio_Proyecto date DEFAULT NULL,
  Cmp_Fecha_Fin_Proyecto date DEFAULT NULL,
  Cmp_Objetivo_Proyecto text,
  PRIMARY KEY (Pk_Id_Proyecto),
  KEY Fk_Proyecto_ProyectoEstado (Fk_Id_Proyecto_Estado),
  CONSTRAINT Fk_Proyecto_ProyectoEstado FOREIGN KEY (Fk_Id_Proyecto_Estado) REFERENCES tbl_proyecto_estado (Pk_Id_Proyecto_Estado)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO tbl_proyecto (Pk_Id_Proyecto, Fk_Id_Proyecto_Estado, Cmp_Nombre_Proyecto, Cmp_Descripcion_Proyecto, Cmp_Fecha_Inicio_Proyecto, Cmp_Fecha_Fin_Proyecto, Cmp_Objetivo_Proyecto) VALUES
  (1, 1, 'Sistema de Hoteleria', 'Auditoria del sistema de gestion hotelera (seguridad y modulos)', '2026-01-01', NULL, 'Evaluar la calidad y seguridad del sistema de hoteleria');

DROP TABLE IF EXISTS tbl_actividades_proyecto;
CREATE TABLE tbl_actividades_proyecto (
  Pk_Id_Actividad_Proyecto int NOT NULL,
  Fk_Id_Proyecto int NOT NULL,
  Cmp_Nombre_Actividad_Proyecto varchar(100) NOT NULL,
  Cmp_Descripcion_Actividad_Proyecto text,
  Cmp_Observaciones_Actividad_Proyecto text,
  PRIMARY KEY (Pk_Id_Actividad_Proyecto),
  KEY Fk_ActividadProyecto_Proyecto (Fk_Id_Proyecto),
  CONSTRAINT Fk_ActividadProyecto_Proyecto FOREIGN KEY (Fk_Id_Proyecto) REFERENCES tbl_proyecto (Pk_Id_Proyecto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_areas;
CREATE TABLE tbl_areas (
  Pk_Id_Area int NOT NULL,
  Fk_Id_Proyecto int NOT NULL,
  Cmp_Nombre_Area varchar(100) NOT NULL,
  Cmp_Descripcion_Area text,
  Cmp_Estado_Area varchar(100) NOT NULL,
  PRIMARY KEY (Pk_Id_Area),
  KEY Fk_Area_Proyecto (Fk_Id_Proyecto),
  CONSTRAINT Fk_Area_Proyecto FOREIGN KEY (Fk_Id_Proyecto) REFERENCES tbl_proyecto (Pk_Id_Proyecto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_perfil_auditor;
CREATE TABLE tbl_perfil_auditor (
  Pk_Id_Perfil_Auditor int NOT NULL,
  Cmp_Nombre_Perfil_Auditor varchar(50) NOT NULL,
  Cmp_Descripcion_Perfil_Auditor text,
  PRIMARY KEY (Pk_Id_Perfil_Auditor)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO tbl_perfil_auditor (Pk_Id_Perfil_Auditor, Cmp_Nombre_Perfil_Auditor, Cmp_Descripcion_Perfil_Auditor) VALUES
  (1, 'Auditor de Software', 'Responsable de calificar el software entregado');

DROP TABLE IF EXISTS tbl_auditor;
CREATE TABLE tbl_auditor (
  Pk_Id_Auditor int NOT NULL,
  Cmp_Nombre_Auditor varchar(45) DEFAULT NULL,
  Cmp_Telefono_Auditor varchar(45) DEFAULT NULL,
  Cmp_Email_Auditor varchar(20) DEFAULT NULL,
  Cmp_Carnet_Auditor varchar(15) NOT NULL,
  Cmp_Estado_Auditor varchar(1) DEFAULT NULL,
  Fk_Id_Perfil_Auditor int NOT NULL,
  Fk_Id_Proyecto int NOT NULL,
  PRIMARY KEY (Pk_Id_Auditor),
  KEY Fk_Auditor_PerfilAuditor (Fk_Id_Perfil_Auditor),
  KEY Fk_Auditor_Proyecto (Fk_Id_Proyecto),
  CONSTRAINT Fk_Auditor_PerfilAuditor FOREIGN KEY (Fk_Id_Perfil_Auditor) REFERENCES tbl_perfil_auditor (Pk_Id_Perfil_Auditor),
  CONSTRAINT Fk_Auditor_Proyecto FOREIGN KEY (Fk_Id_Proyecto) REFERENCES tbl_proyecto (Pk_Id_Proyecto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


INSERT INTO tbl_auditor (Pk_Id_Auditor, Cmp_Nombre_Auditor, Cmp_Telefono_Auditor, Cmp_Email_Auditor, Cmp_Carnet_Auditor, Cmp_Estado_Auditor, Fk_Id_Perfil_Auditor, Fk_Id_Proyecto) VALUES
  (2, 'Juan Perez Lopez', '5555-1234', 'juan.perez@ex.com', 'AUD-0002', 'A', 1, 1),
  (3, 'Juan Pruebas', '1234', '@pruebas', 'AUD-0003', 'A', 1, 1);

DROP TABLE IF EXISTS tbl_auditados;
CREATE TABLE tbl_auditados (
  Pk_Id_Auditado int NOT NULL,
  Fk_Id_Proyecto int NOT NULL,
  Cmp_Nombre_Auditado varchar(100) NOT NULL,
  Cmp_Cargo_Area_Auditado varchar(100) DEFAULT NULL,
  Cmp_Correo_Auditado varchar(100) DEFAULT NULL,
  Cmp_Telefono_Auditado varchar(20) DEFAULT NULL,
  Cmp_Observaciones_Auditado text,
  PRIMARY KEY (Pk_Id_Auditado),
  KEY Fk_Auditado_Proyecto (Fk_Id_Proyecto),
  CONSTRAINT Fk_Auditado_Proyecto FOREIGN KEY (Fk_Id_Proyecto) REFERENCES tbl_proyecto (Pk_Id_Proyecto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_estado_asignacion;
CREATE TABLE tbl_estado_asignacion (
  Pk_Id_Estado_Asignacion int NOT NULL,
  Cmp_Nombre_Estado_Asignacion varchar(50) NOT NULL,
  Cmp_Descripcion_Estado_Asignacion text,
  PRIMARY KEY (Pk_Id_Estado_Asignacion)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_asignacion;
CREATE TABLE tbl_asignacion (
  Pk_Id_Asignacion int NOT NULL,
  Fk_Id_Auditor int NOT NULL,
  Fk_Id_Estado_Asignacion int NOT NULL,
  Fk_Id_Actividad_Proyecto int NOT NULL,
  Cmp_Nombre_Asignacion varchar(100) NOT NULL,
  Cmp_Fecha_Asignacion date NOT NULL,
  Cmp_Fecha_Finalizacion_Asignacion date DEFAULT NULL,
  Cmp_Descripcion_Asignacion text,
  Cmp_Evidencia_Asignacion varchar(255) DEFAULT NULL,
  Cmp_Observaciones_Asignacion text,
  PRIMARY KEY (Pk_Id_Asignacion),
  KEY Fk_Asignacion_Auditor (Fk_Id_Auditor),
  KEY Fk_Asignacion_EstadoAsignacion (Fk_Id_Estado_Asignacion),
  KEY Fk_Asignacion_ActividadProyecto (Fk_Id_Actividad_Proyecto),
  CONSTRAINT Fk_Asignacion_Auditor FOREIGN KEY (Fk_Id_Auditor) REFERENCES tbl_auditor (Pk_Id_Auditor),
  CONSTRAINT Fk_Asignacion_EstadoAsignacion FOREIGN KEY (Fk_Id_Estado_Asignacion) REFERENCES tbl_estado_asignacion (Pk_Id_Estado_Asignacion),
  CONSTRAINT Fk_Asignacion_ActividadProyecto FOREIGN KEY (Fk_Id_Actividad_Proyecto) REFERENCES tbl_actividades_proyecto (Pk_Id_Actividad_Proyecto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_estado_informe;
CREATE TABLE tbl_estado_informe (
  Pk_Id_Estado_Informe int NOT NULL,
  Cmp_Nombre_Estado_Informe varchar(50) NOT NULL,
  Cmp_Descripcion_Estado_Informe text,
  PRIMARY KEY (Pk_Id_Estado_Informe)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_informe;
CREATE TABLE tbl_informe (
  Pk_Id_Informe int NOT NULL,
  Fk_Id_Auditor int NOT NULL,
  Fk_Id_Estado_Informe int NOT NULL,
  Cmp_Titulo_Informe varchar(150) NOT NULL,
  Cmp_Descripcion_General_Informe text,
  Cmp_Conclusiones_Informe text,
  Cmp_Fecha_Creacion_Informe timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  Cmp_Fecha_Actualizacion_Informe timestamp NULL DEFAULT NULL,
  PRIMARY KEY (Pk_Id_Informe),
  KEY Fk_Informe_Auditor (Fk_Id_Auditor),
  KEY Fk_Informe_EstadoInforme (Fk_Id_Estado_Informe),
  CONSTRAINT Fk_Informe_Auditor FOREIGN KEY (Fk_Id_Auditor) REFERENCES tbl_auditor (Pk_Id_Auditor),
  CONSTRAINT Fk_Informe_EstadoInforme FOREIGN KEY (Fk_Id_Estado_Informe) REFERENCES tbl_estado_informe (Pk_Id_Estado_Informe)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_planificacion;
CREATE TABLE tbl_planificacion (
  Pk_Id_Planificacion int NOT NULL,
  Fk_Id_Proyecto int NOT NULL,
  Cmp_Nombre_Plan_Planificacion varchar(100) NOT NULL,
  Cmp_Descripcion_Planificacion text,
  Cmp_Fecha_Inicio_Planificacion date DEFAULT NULL,
  Cmp_Fecha_Fin_Planificacion date DEFAULT NULL,
  Cmp_Observaciones_Planificacion text,
  PRIMARY KEY (Pk_Id_Planificacion),
  KEY Fk_Planificacion_Proyecto (Fk_Id_Proyecto),
  CONSTRAINT Fk_Planificacion_Proyecto FOREIGN KEY (Fk_Id_Proyecto) REFERENCES tbl_proyecto (Pk_Id_Proyecto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_cronograma;
CREATE TABLE tbl_cronograma (
  Pk_Id_Cronograma int NOT NULL,
  Fk_Id_Planificacion int NOT NULL,
  Fk_Id_Actividad_Proyecto int NOT NULL,
  Cmp_Nombre_Tarea_Cronograma varchar(100) NOT NULL,
  Cmp_Descripcion_Cronograma text,
  Cmp_Fecha_Inicio_Cronograma date NOT NULL,
  Cmp_Fecha_Fin_Cronograma date NOT NULL,
  Cmp_Responsable_Tarea_Cronograma varchar(100) DEFAULT NULL,
  Cmp_Estado_Tarea_Cronograma varchar(100) DEFAULT NULL,
  Cmp_Observaciones_Cronograma text,
  PRIMARY KEY (Pk_Id_Cronograma),
  KEY Fk_Cronograma_Planificacion (Fk_Id_Planificacion),
  KEY Fk_Cronograma_ActividadProyecto (Fk_Id_Actividad_Proyecto),
  CONSTRAINT Fk_Cronograma_Planificacion FOREIGN KEY (Fk_Id_Planificacion) REFERENCES tbl_planificacion (Pk_Id_Planificacion),
  CONSTRAINT Fk_Cronograma_ActividadProyecto FOREIGN KEY (Fk_Id_Actividad_Proyecto) REFERENCES tbl_actividades_proyecto (Pk_Id_Actividad_Proyecto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_rubrica;
CREATE TABLE tbl_rubrica (
  Pk_Id_Rubrica int NOT NULL,
  Fk_Id_Cronograma int NOT NULL,
  Cmp_Nombre_Rubrica varchar(100) NOT NULL,
  Cmp_Descripcion_Rubrica text,
  Cmp_Objetivo_Rubrica text,
  PRIMARY KEY (Pk_Id_Rubrica),
  KEY Fk_Rubrica_Cronograma (Fk_Id_Cronograma),
  CONSTRAINT Fk_Rubrica_Cronograma FOREIGN KEY (Fk_Id_Cronograma) REFERENCES tbl_cronograma (Pk_Id_Cronograma)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_criterios;
CREATE TABLE tbl_criterios (
  Pk_Id_Criterio int NOT NULL,
  Fk_Id_Rubrica int NOT NULL,
  Cmp_Nombre_Criterio varchar(100) NOT NULL,
  Cmp_Porcentaje_Criterio int DEFAULT NULL,
  Cmp_Descripcion_Criterio text,
  Cmp_Nivel_Importancia_Criterio varchar(50) DEFAULT NULL,
  PRIMARY KEY (Pk_Id_Criterio),
  KEY Fk_Criterio_Rubrica (Fk_Id_Rubrica),
  CONSTRAINT Fk_Criterio_Rubrica FOREIGN KEY (Fk_Id_Rubrica) REFERENCES tbl_rubrica (Pk_Id_Rubrica)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_escala_descripcion;
CREATE TABLE tbl_escala_descripcion (
  Pk_Id_Escala int NOT NULL,
  Cmp_Porcentaje_Escala int NOT NULL,
  Cmp_Nombre_Nivel_Escala varchar(50) NOT NULL,
  Cmp_Descripcion_General_Escala text,
  Cmp_Color_Referencia_Escala varchar(20) DEFAULT NULL,
  PRIMARY KEY (Pk_Id_Escala),
  CONSTRAINT Chk_Escala_Porcentaje CHECK ((Cmp_Porcentaje_Escala in (0,20,40,60,80,100)))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_descripcion_criterio;
CREATE TABLE tbl_descripcion_criterio (
  Pk_Id_Descripcion_Criterio int NOT NULL,
  Fk_Id_Criterio int NOT NULL,
  Fk_Id_Escala int NOT NULL,
  Cmp_Descripcion_Detallada_Descripcion_Criterio text NOT NULL,
  Cmp_Evidencia_Requerida_Descripcion_Criterio text,
  Cmp_Observaciones_Descripcion_Criterio text,
  PRIMARY KEY (Pk_Id_Descripcion_Criterio),
  KEY Fk_DescripcionCriterio_Criterio (Fk_Id_Criterio),
  KEY Fk_DescripcionCriterio_Escala (Fk_Id_Escala),
  CONSTRAINT Fk_DescripcionCriterio_Criterio FOREIGN KEY (Fk_Id_Criterio) REFERENCES tbl_criterios (Pk_Id_Criterio),
  CONSTRAINT Fk_DescripcionCriterio_Escala FOREIGN KEY (Fk_Id_Escala) REFERENCES tbl_escala_descripcion (Pk_Id_Escala)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_checklist;
CREATE TABLE tbl_checklist (
  Pk_Id_Checklist int NOT NULL,
  Fk_Id_Informe int NOT NULL,
  Fk_Id_Criterio int NOT NULL,
  PRIMARY KEY (Pk_Id_Checklist),
  KEY Fk_Checklist_Informe (Fk_Id_Informe),
  KEY Fk_Checklist_Criterio (Fk_Id_Criterio),
  CONSTRAINT Fk_Checklist_Informe FOREIGN KEY (Fk_Id_Informe) REFERENCES tbl_informe (Pk_Id_Informe),
  CONSTRAINT Fk_Checklist_Criterio FOREIGN KEY (Fk_Id_Criterio) REFERENCES tbl_criterios (Pk_Id_Criterio)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_grafica;
CREATE TABLE tbl_grafica (
  Pk_Id_Grafica int NOT NULL,
  Fk_Id_Informe int NOT NULL,
  Cmp_Tipo_Grafica varchar(50) NOT NULL,
  Cmp_Descripcion_Grafica text,
  Cmp_Datos_Json_Grafica json DEFAULT NULL,
  PRIMARY KEY (Pk_Id_Grafica),
  KEY Fk_Grafica_Informe (Fk_Id_Informe),
  CONSTRAINT Fk_Grafica_Informe FOREIGN KEY (Fk_Id_Informe) REFERENCES tbl_informe (Pk_Id_Informe)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_proyecto_auditado;
CREATE TABLE tbl_proyecto_auditado (
  Pk_Id_Auditor_Proyecto int NOT NULL,
  Fk_Id_Auditor int NOT NULL,
  Fk_Id_Proyecto int NOT NULL,
  Cmp_Rol_En_Proyecto_Auditor_Proyecto varchar(50) DEFAULT NULL,
  Cmp_Fecha_Asignacion_Auditor_Proyecto date DEFAULT (curdate()),
  Cmp_Observaciones_Auditor_Proyecto text,
  PRIMARY KEY (Pk_Id_Auditor_Proyecto),
  KEY Fk_AuditorProyecto_Auditor (Fk_Id_Auditor),
  KEY Fk_AuditorProyecto_Proyecto (Fk_Id_Proyecto),
  CONSTRAINT Fk_AuditorProyecto_Auditor FOREIGN KEY (Fk_Id_Auditor) REFERENCES tbl_auditor (Pk_Id_Auditor) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT Fk_AuditorProyecto_Proyecto FOREIGN KEY (Fk_Id_Proyecto) REFERENCES tbl_proyecto (Pk_Id_Proyecto) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_recursos;
CREATE TABLE tbl_recursos (
  Pk_Id_Recurso int NOT NULL,
  Fk_Id_Proyecto int NOT NULL,
  Cmp_Nombre_Recurso varchar(100) NOT NULL,
  Cmp_Tipo_Recurso varchar(100) NOT NULL,
  Cmp_Cantidad_Recurso int DEFAULT '1',
  Cmp_Fecha_Registro_Recurso timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (Pk_Id_Recurso),
  KEY Fk_Recurso_Proyecto (Fk_Id_Proyecto),
  CONSTRAINT Fk_Recurso_Proyecto FOREIGN KEY (Fk_Id_Proyecto) REFERENCES tbl_proyecto (Pk_Id_Proyecto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Esta tabla es para los reportes de auditoria
DROP TABLE IF EXISTS tbl_reporte;
CREATE TABLE tbl_reporte (
  Pk_Id_Reporte int NOT NULL,
  Fk_Id_Informe int NOT NULL,
  Fk_Id_Criterio int NOT NULL,
  Fk_Id_Auditor int NOT NULL,
  Cmp_Aspectos_Positivos_Reporte text,
  Cmp_Correcciones_Reporte text,
  Cmp_Recomendaciones_Reporte text,
  PRIMARY KEY (Pk_Id_Reporte),
  KEY Fk_Reporte_Informe (Fk_Id_Informe),
  KEY Fk_Reporte_Criterio (Fk_Id_Criterio),
  KEY Fk_Reporte_Auditor (Fk_Id_Auditor),
  CONSTRAINT Fk_Reporte_Informe FOREIGN KEY (Fk_Id_Informe) REFERENCES tbl_informe (Pk_Id_Informe),
  CONSTRAINT Fk_Reporte_Criterio FOREIGN KEY (Fk_Id_Criterio) REFERENCES tbl_criterios (Pk_Id_Criterio),
  CONSTRAINT Fk_Reporte_Auditor FOREIGN KEY (Fk_Id_Auditor) REFERENCES tbl_auditor (Pk_Id_Auditor)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_actividad_rubrica;
CREATE TABLE tbl_actividad_rubrica (
  Pk_Id_Actividad_Rubrica int NOT NULL AUTO_INCREMENT,
  Fk_Id_Actividad_Proyecto int NOT NULL,
  Fk_Id_Rubrica int NOT NULL,
  Cmp_Estado_Actividad_Rubrica tinyint(1) DEFAULT 1,
  PRIMARY KEY (Pk_Id_Actividad_Rubrica),
  KEY Fk_ActividadRubrica_ActividadProyecto (Fk_Id_Actividad_Proyecto),
  KEY Fk_ActividadRubrica_Rubrica (Fk_Id_Rubrica),
  CONSTRAINT Fk_ActividadRubrica_ActividadProyecto FOREIGN KEY (Fk_Id_Actividad_Proyecto) REFERENCES tbl_actividades_proyecto (Pk_Id_Actividad_Proyecto),
  CONSTRAINT Fk_ActividadRubrica_Rubrica FOREIGN KEY (Fk_Id_Rubrica) REFERENCES tbl_rubrica (Pk_Id_Rubrica)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_tabla_ponderacion;
CREATE TABLE tbl_tabla_ponderacion (
  Pk_Id_Ponderacion int NOT NULL AUTO_INCREMENT,
  Fk_Id_Auditado int NOT NULL,
  Fk_Id_Cronograma int NOT NULL,
  Fk_Id_Rubrica int NOT NULL,
  Fk_Id_Criterio int NOT NULL,
  Fk_Id_Escala int NOT NULL,
  Cmp_Calificacion_Porcentaje_Ponderacion decimal(5,2) NOT NULL,
  Cmp_Calificacion_Ponderada_Ponderacion decimal(6,2) NOT NULL,
  Cmp_Comentarios_Auditor_Ponderacion text,
  Cmp_Fecha_Evaluacion_Ponderacion timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (Pk_Id_Ponderacion),
  KEY Fk_Ponderacion_Auditado (Fk_Id_Auditado),
  KEY Fk_Ponderacion_Cronograma (Fk_Id_Cronograma),
  KEY Fk_Ponderacion_Rubrica (Fk_Id_Rubrica),
  KEY Fk_Ponderacion_Criterio (Fk_Id_Criterio),
  KEY Fk_Ponderacion_Escala (Fk_Id_Escala),
  CONSTRAINT Fk_Ponderacion_Auditado FOREIGN KEY (Fk_Id_Auditado) REFERENCES tbl_auditados (Pk_Id_Auditado),
  CONSTRAINT Fk_Ponderacion_Cronograma FOREIGN KEY (Fk_Id_Cronograma) REFERENCES tbl_cronograma (Pk_Id_Cronograma),
  CONSTRAINT Fk_Ponderacion_Rubrica FOREIGN KEY (Fk_Id_Rubrica) REFERENCES tbl_rubrica (Pk_Id_Rubrica),
  CONSTRAINT Fk_Ponderacion_Criterio FOREIGN KEY (Fk_Id_Criterio) REFERENCES tbl_criterios (Pk_Id_Criterio),
  CONSTRAINT Fk_Ponderacion_Escala FOREIGN KEY (Fk_Id_Escala) REFERENCES tbl_escala_descripcion (Pk_Id_Escala)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


-- ------------------------------------------Seguridad------------------------------------------

-- Esta tabla es para los reportes con crystal report
DROP TABLE IF EXISTS tbl_reportes;
CREATE TABLE tbl_reportes (
  Pk_Id_Reporte int NOT NULL AUTO_INCREMENT,
  Cmp_Titulo_Reporte varchar(50) DEFAULT NULL,
  Cmp_Ruta_Reporte varchar(500) DEFAULT NULL,
  Cmp_Fecha_Reporte date DEFAULT NULL,
  PRIMARY KEY (Pk_Id_Reporte)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO tbl_reportes (Pk_Id_Reporte, Cmp_Titulo_Reporte, Cmp_Ruta_Reporte, Cmp_Fecha_Reporte) VALUES
  (1, 'Reporte final', 'C:\\Users\\lopez\\OneDrive\\Escritorio\\navegador\\asis2k25p2\\codigo\\componentes\\reporteador\\Base de Datos y Reporte Generado\\ReporteEmpleadosHSC.rpt', '2025-01-01'),
  (2, 'Reporte_Prueba', 'C:\\Users\\lopez\\OneDrive\\Escritorio\\navegador\\asis2k25p2\\codigo\\componentes\\reporteador\\Base de Datos y Reporte Generado\\ReporteEmpleadosHSC.rpt', '2025-01-01'),
  (3, 'Perfiles Reporte', 'C:\\is2k26pf\\codigo\\componentes\\seguridad\\SeguridadMVC\\SeguridadMVC\\CapaVista\\Reporte_perfiles.rpt', '2026-02-03'),
  (5, 'Empleados reporte', 'C:\\is2k26pf\\codigo\\componentes\\seguridad\\SeguridadMVC\\SeguridadMVC\\CapaVista\\Reporte_empleado.rpt', '2026-02-05');

DROP TABLE IF EXISTS tbl_modulo;
CREATE TABLE tbl_modulo (
  Pk_Id_Modulo int NOT NULL,
  Cmp_Nombre_Modulo varchar(50) DEFAULT NULL,
  Cmp_Descripcion_Modulo varchar(50) DEFAULT NULL,
  Cmp_Estado_Modulo bit(1) NOT NULL,
  PRIMARY KEY (Pk_Id_Modulo)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO tbl_modulo (Pk_Id_Modulo, Cmp_Nombre_Modulo, Cmp_Descripcion_Modulo, Cmp_Estado_Modulo) VALUES
  (2, 'Navegador', 'Modulo de navegador', b'1'),
  (4, 'Seguridad', 'Modulo de seguridad de la hoteleria', b'1');

DROP TABLE IF EXISTS tbl_aplicacion;
CREATE TABLE tbl_aplicacion (
  Pk_Id_Aplicacion int NOT NULL,
  Fk_Id_Reporte_Aplicacion int DEFAULT NULL,
  Cmp_Nombre_Aplicacion varchar(50) DEFAULT NULL,
  Cmp_Descripcion_Aplicacion varchar(50) DEFAULT NULL,
  Cmp_Estado_Aplicacion bit(1) NOT NULL,
  PRIMARY KEY (Pk_Id_Aplicacion),
  KEY Fk_Aplicacion_Reporte (Fk_Id_Reporte_Aplicacion),
  CONSTRAINT Fk_Aplicacion_Reporte FOREIGN KEY (Fk_Id_Reporte_Aplicacion) REFERENCES tbl_reportes (Pk_Id_Reporte)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO tbl_aplicacion (Pk_Id_Aplicacion, Fk_Id_Reporte_Aplicacion, Cmp_Nombre_Aplicacion, Cmp_Descripcion_Aplicacion, Cmp_Estado_Aplicacion) VALUES
  (1, 1, 'Gestion de empleado', 'Se gestionan los empleados del hotel', b'1'),
  (301, 5, 'Empleados', 'Control de empleados de la hoteleria', b'1'),
  (302, NULL, 'Usuarios', 'Control de usuarios de empleados', b'1'),
  (303, 3, 'Perfiles', 'Perfiles que se asignan a usuarios', b'1'),
  (304, NULL, 'Modulos', 'Mantenimiento de modulos', b'1'),
  (305, NULL, 'Aplicacion', 'Mantenimiento de aplicaciones', b'1'),
  (306, NULL, 'Asig Aplicacion Usuario', 'Asigna permisos a usuarios', b'1'),
  (307, NULL, 'Asig aplicacion Perfil', 'Asigna permisos a perfiles', b'1'),
  (308, NULL, 'Asig Perfiles', 'Asigna los perfiles a usuarios', b'1'),
  (309, NULL, 'Bitacora', 'Da acceso a bitacora', b'1');

DROP TABLE IF EXISTS tbl_asignacion_modulo_aplicacion;
CREATE TABLE tbl_asignacion_modulo_aplicacion (
  Fk_Id_Modulo int NOT NULL,
  Fk_Id_Aplicacion int NOT NULL,
  PRIMARY KEY (Fk_Id_Modulo, Fk_Id_Aplicacion),
  KEY Fk_AsigAplicacion (Fk_Id_Aplicacion),
  CONSTRAINT Fk_AsigAplicacion FOREIGN KEY (Fk_Id_Aplicacion) REFERENCES tbl_aplicacion (Pk_Id_Aplicacion),
  CONSTRAINT Fk_AsigModulo FOREIGN KEY (Fk_Id_Modulo) REFERENCES tbl_modulo (Pk_Id_Modulo)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO tbl_asignacion_modulo_aplicacion (Fk_Id_Modulo, Fk_Id_Aplicacion) VALUES
  (4,301),(4,302),(4,303),(4,304),(4,305),(4,306),(4,307),(4,308),(4,309);

DROP TABLE IF EXISTS tbl_perfil;
CREATE TABLE tbl_perfil (
  Pk_Id_Perfil int NOT NULL AUTO_INCREMENT,
  Cmp_Puesto_Perfil varchar(50) DEFAULT NULL,
  Cmp_Descripcion_Perfil varchar(50) DEFAULT NULL,
  Cmp_Estado_Perfil bit(1) NOT NULL,
  Cmp_Tipo_Perfil int DEFAULT NULL,
  PRIMARY KEY (Pk_Id_Perfil)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO tbl_perfil (Pk_Id_Perfil, Cmp_Puesto_Perfil, Cmp_Descripcion_Perfil, Cmp_Estado_Perfil, Cmp_Tipo_Perfil) VALUES
  (1, 'Administrador', 'Perfil con todos los permisos', b'1', 1);

DROP TABLE IF EXISTS tbl_usuario;
CREATE TABLE tbl_usuario (
  Pk_Id_Usuario int NOT NULL AUTO_INCREMENT,
  Fk_Id_Auditor int DEFAULT NULL,
  Cmp_Nombre_Usuario varchar(50) DEFAULT NULL,
  Cmp_Contrasena_Usuario varchar(65) DEFAULT NULL,
  Cmp_Intentos_Fallidos_Usuario int DEFAULT NULL,
  Cmp_Estado_Usuario bit(1) DEFAULT NULL,
  Cmp_FechaCreacion_Usuario datetime DEFAULT NULL,
  Cmp_Ultimo_Cambio_Contrasenea datetime DEFAULT NULL,
  Cmp_Pidio_Cambio_Contrasenea bit(1) DEFAULT NULL,
  PRIMARY KEY (Pk_Id_Usuario),
  KEY Fk_Usuario_Auditor (Fk_Id_Auditor),
  CONSTRAINT Fk_Usuario_Auditor FOREIGN KEY (Fk_Id_Auditor) REFERENCES tbl_auditor (Pk_Id_Auditor) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


INSERT INTO tbl_usuario (Pk_Id_Usuario, Fk_Id_Auditor, Cmp_Nombre_Usuario, Cmp_Contrasena_Usuario, Cmp_Intentos_Fallidos_Usuario, Cmp_Estado_Usuario, Cmp_FechaCreacion_Usuario, Cmp_Ultimo_Cambio_Contrasenea, Cmp_Pidio_Cambio_Contrasenea) VALUES
  (4, 2, 'brandon', '45297c633d331e6ac35169ebaaf75bc7fafd206ebb59ba4efd80566936e46eb0', 0, b'1', '2025-09-21 20:49:54', '2025-10-18 17:09:11', b'0'),
  (23, 3, 'admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 0, b'1', '2025-09-26 20:45:53', '2025-09-26 20:45:53', b'0');

DROP TABLE IF EXISTS tbl_usuario_perfil;
CREATE TABLE tbl_usuario_perfil (
  Fk_Id_Usuario int NOT NULL,
  Fk_Id_Perfil int NOT NULL,
  PRIMARY KEY (Fk_Id_Usuario, Fk_Id_Perfil),
  KEY Fk_UsuarioPerfil_Perfil (Fk_Id_Perfil),
  CONSTRAINT Fk_UsuarioPerfil_Perfil FOREIGN KEY (Fk_Id_Perfil) REFERENCES tbl_perfil (Pk_Id_Perfil),
  CONSTRAINT Fk_UsuarioPerfil_Usuario FOREIGN KEY (Fk_Id_Usuario) REFERENCES tbl_usuario (Pk_Id_Usuario)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO tbl_usuario_perfil (Fk_Id_Usuario, Fk_Id_Perfil) VALUES
  (4, 1);

DROP TABLE IF EXISTS tbl_permiso_perfil_aplicacion;
CREATE TABLE tbl_permiso_perfil_aplicacion (
  Fk_Id_Perfil int NOT NULL,
  Fk_Id_Modulo int NOT NULL,
  Fk_Id_Aplicacion int NOT NULL,
  Cmp_Ingresar_Permisos_Aplicacion_Perfil bit(1) DEFAULT NULL,
  Cmp_Consultar_Permisos_Aplicacion_Perfil bit(1) DEFAULT NULL,
  Cmp_Modificar_Permisos_Aplicacion_Perfil bit(1) DEFAULT NULL,
  Cmp_Eliminar_Permisos_Aplicacion_Perfil bit(1) DEFAULT NULL,
  Cmp_Imprimir_Permisos_Aplicacion_Perfil bit(1) DEFAULT NULL,
  PRIMARY KEY (Fk_Id_Perfil, Fk_Id_Modulo, Fk_Id_Aplicacion),
  KEY Fk_PermisoPerfil_ModuloAplicacion (Fk_Id_Modulo, Fk_Id_Aplicacion),
  CONSTRAINT Fk_PermisoPerfil FOREIGN KEY (Fk_Id_Perfil) REFERENCES tbl_perfil (Pk_Id_Perfil) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT Fk_PermisoPerfil_ModuloAplicacion FOREIGN KEY (Fk_Id_Modulo, Fk_Id_Aplicacion) REFERENCES tbl_asignacion_modulo_aplicacion (Fk_Id_Modulo, Fk_Id_Aplicacion) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO tbl_permiso_perfil_aplicacion (Fk_Id_Perfil, Fk_Id_Modulo, Fk_Id_Aplicacion, Cmp_Ingresar_Permisos_Aplicacion_Perfil, Cmp_Consultar_Permisos_Aplicacion_Perfil, Cmp_Modificar_Permisos_Aplicacion_Perfil, Cmp_Eliminar_Permisos_Aplicacion_Perfil, Cmp_Imprimir_Permisos_Aplicacion_Perfil) VALUES
  (1, 4, 301, b'1', b'1', b'1', b'1', b'1'),
  (1, 4, 305, b'1', b'1', b'1', b'1', b'1'),
  (1, 4, 306, b'0', b'1', b'0', b'0', b'0'),
  (1, 4, 309, b'1', b'1', b'1', b'1', b'1');

DROP TABLE IF EXISTS tbl_permiso_usuario_aplicacion;
CREATE TABLE tbl_permiso_usuario_aplicacion (
  Fk_Id_Usuario int NOT NULL,
  Fk_Id_Modulo int NOT NULL,
  Fk_Id_Aplicacion int NOT NULL,
  Cmp_Ingresar_Permiso_Aplicacion_Usuario bit(1) DEFAULT NULL,
  Cmp_Consultar_Permiso_Aplicacion_Usuario bit(1) DEFAULT NULL,
  Cmp_Modificar_Permiso_Aplicacion_Usuario bit(1) DEFAULT NULL,
  Cmp_Eliminar_Permiso_Aplicacion_Usuario bit(1) DEFAULT NULL,
  Cmp_Imprimir_Permiso_Aplicacion_Usuario bit(1) DEFAULT NULL,
  PRIMARY KEY (Fk_Id_Usuario, Fk_Id_Modulo, Fk_Id_Aplicacion),
  KEY Fk_Permiso_Modulo_Aplicacion (Fk_Id_Modulo, Fk_Id_Aplicacion),
  CONSTRAINT Fk_Permiso_Modulo_Aplicacion FOREIGN KEY (Fk_Id_Modulo, Fk_Id_Aplicacion) REFERENCES tbl_asignacion_modulo_aplicacion (Fk_Id_Modulo, Fk_Id_Aplicacion) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT Fk_Permiso_Usuario FOREIGN KEY (Fk_Id_Usuario) REFERENCES tbl_usuario (Pk_Id_Usuario)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO tbl_permiso_usuario_aplicacion (Fk_Id_Usuario, Fk_Id_Modulo, Fk_Id_Aplicacion, Cmp_Ingresar_Permiso_Aplicacion_Usuario, Cmp_Consultar_Permiso_Aplicacion_Usuario, Cmp_Modificar_Permiso_Aplicacion_Usuario, Cmp_Eliminar_Permiso_Aplicacion_Usuario, Cmp_Imprimir_Permiso_Aplicacion_Usuario) VALUES
  (4, 4, 301, b'1', b'1', b'1', b'1', b'1'),
  (4, 4, 302, b'1', b'1', b'1', b'1', b'1'),
  (4, 4, 303, b'1', b'1', b'1', b'1', b'1'),
  (4, 4, 304, b'1', b'1', b'1', b'1', b'1'),
  (4, 4, 305, b'1', b'1', b'1', b'1', b'1'),
  (4, 4, 306, b'1', b'1', b'1', b'1', b'1'),
  (4, 4, 307, b'1', b'1', b'1', b'1', b'1'),
  (4, 4, 308, b'1', b'1', b'1', b'1', b'1'),
  (23, 4, 301, b'1', b'1', b'1', b'1', b'1'),
  (23, 4, 302, b'1', b'1', b'1', b'1', b'1'),
  (23, 4, 303, b'1', b'1', b'1', b'1', b'1'),
  (23, 4, 304, b'1', b'1', b'1', b'1', b'1'),
  (23, 4, 305, b'1', b'1', b'1', b'1', b'1'),
  (23, 4, 306, b'1', b'1', b'1', b'1', b'1'),
  (23, 4, 307, b'1', b'1', b'1', b'1', b'1'),
  (23, 4, 308, b'1', b'1', b'1', b'1', b'1'),
  (23, 4, 309, b'1', b'1', b'1', b'1', b'1');

DROP TABLE IF EXISTS tbl_bitacora;
CREATE TABLE tbl_bitacora (
  Pk_Id_Bitacora int NOT NULL AUTO_INCREMENT,
  Fk_Id_Usuario int DEFAULT NULL,
  Fk_Id_Aplicacion int DEFAULT NULL,
  Cmp_Fecha datetime DEFAULT NULL,
  Cmp_Accion varchar(255) DEFAULT NULL,
  Cmp_Ip varchar(50) DEFAULT NULL,
  Cmp_Nombre_Pc varchar(50) DEFAULT NULL,
  Cmp_Login_Estado bit(1) DEFAULT NULL,
  PRIMARY KEY (Pk_Id_Bitacora),
  KEY Fk_Bitacora_Usuario (Fk_Id_Usuario),
  KEY Fk_Bitacora_Aplicacion (Fk_Id_Aplicacion),
  CONSTRAINT Fk_Bitacora_Aplicacion FOREIGN KEY (Fk_Id_Aplicacion) REFERENCES tbl_aplicacion (Pk_Id_Aplicacion) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT Fk_Bitacora_Usuario FOREIGN KEY (Fk_Id_Usuario) REFERENCES tbl_usuario (Pk_Id_Usuario)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;



DROP TABLE IF EXISTS tbl_bloqueo_usuario;
CREATE TABLE tbl_bloqueo_usuario (
  Pk_Id_Bloqueo int NOT NULL AUTO_INCREMENT,
  Fk_Id_Usuario int DEFAULT NULL,
  Fk_Id_Bitacora int DEFAULT NULL,
  Cmp_Fecha_Inicio_Bloqueo_Usuario datetime DEFAULT NULL,
  Cmp_Fecha_Fin_Bloqueo_Usuario datetime DEFAULT NULL,
  Cmp_Motivo__Bloqueo_Usuario varchar(50) DEFAULT NULL,
  PRIMARY KEY (Pk_Id_Bloqueo),
  KEY Fk_Bloqueo_Usuario (Fk_Id_Usuario),
  KEY Fk_Bloqueo_Bitacora (Fk_Id_Bitacora),
  CONSTRAINT Fk_Bloqueo_Bitacora FOREIGN KEY (Fk_Id_Bitacora) REFERENCES tbl_bitacora (Pk_Id_Bitacora),
  CONSTRAINT Fk_Bloqueo_Usuario FOREIGN KEY (Fk_Id_Usuario) REFERENCES tbl_usuario (Pk_Id_Usuario)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;



DROP TABLE IF EXISTS tbl_token_restaurarcontrasena;
CREATE TABLE tbl_token_restaurarcontrasena (
  Pk_Id_Token int NOT NULL AUTO_INCREMENT,
  Fk_Id_Usuario int DEFAULT NULL,
  Cmp_Token varchar(50) DEFAULT NULL,
  Cmp_Fecha_Creacion_Restaurar_Contrasenea datetime DEFAULT NULL,
  Cmp_Expiracion_Restaurar_Contrasenea datetime DEFAULT NULL,
  Cmp_Utilizado_Restaurar_Contrasenea bit(1) DEFAULT NULL,
  Cmp_Fecha_Uso_Restaurar_Contrasenea datetime DEFAULT NULL,
  PRIMARY KEY (Pk_Id_Token),
  KEY Fk_Token_Usuario (Fk_Id_Usuario),
  CONSTRAINT Fk_Token_Usuario FOREIGN KEY (Fk_Id_Usuario) REFERENCES tbl_usuario (Pk_Id_Usuario)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO tbl_token_restaurarcontrasena (Pk_Id_Token, Fk_Id_Usuario, Cmp_Token, Cmp_Fecha_Creacion_Restaurar_Contrasenea, Cmp_Expiracion_Restaurar_Contrasenea, Cmp_Utilizado_Restaurar_Contrasenea, Cmp_Fecha_Uso_Restaurar_Contrasenea) VALUES
  (23, 4, 'B07EF449', '2025-10-18 12:07:34', '2025-10-18 12:12:34', b'1', '2025-10-18 12:08:27'),
  (24, 4, '0C76A696', '2025-10-18 17:08:53', '2025-10-18 17:13:53', b'1', '2025-10-18 17:09:11');
