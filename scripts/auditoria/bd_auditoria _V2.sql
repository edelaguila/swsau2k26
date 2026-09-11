-- ---------------------------------------Versión 2---------------------------------------

DROP DATABASE IF EXISTS bd_auditoria;


CREATE DATABASE IF NOT EXISTS bd_auditoria;
USE bd_auditoria;


-- ---------------------------------------Auditoria---------------------------------------

DROP TABLE IF EXISTS tbl_proyecto_estado;
CREATE TABLE tbl_proyecto_estado (
  Pk_Id_Proyecto_Estado int NOT NULL,
  Cmp_Nombre_Proyecto_Estado varchar(50) NOT NULL,
  Cmp_Descripcion_Proyecto_Estado varchar(150) DEFAULT NULL,
  PRIMARY KEY (Pk_Id_Proyecto_Estado)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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


-- ---------------------------------------Seguridad---------------------------------------

-- Esta tabla es para los reportes generados con crystal report
DROP TABLE IF EXISTS tbl_reportes;
CREATE TABLE tbl_reportes (
  Pk_Id_Reporte int NOT NULL AUTO_INCREMENT,
  Cmp_Titulo_Reporte varchar(50) DEFAULT NULL,
  Cmp_Ruta_Reporte varchar(500) DEFAULT NULL,
  Cmp_Fecha_Reporte date DEFAULT NULL,
  PRIMARY KEY (Pk_Id_Reporte)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_modulo;
CREATE TABLE tbl_modulo (
  Pk_Id_Modulo int NOT NULL,
  Cmp_Nombre_Modulo varchar(50) DEFAULT NULL,
  Cmp_Descripcion_Modulo varchar(50) DEFAULT NULL,
  Cmp_Estado_Modulo bit(1) NOT NULL,
  PRIMARY KEY (Pk_Id_Modulo)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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

DROP TABLE IF EXISTS tbl_asignacion_modulo_aplicacion;
CREATE TABLE tbl_asignacion_modulo_aplicacion (
  Fk_Id_Modulo int NOT NULL,
  Fk_Id_Aplicacion int NOT NULL,
  PRIMARY KEY (Fk_Id_Modulo, Fk_Id_Aplicacion),
  KEY Fk_AsigAplicacion (Fk_Id_Aplicacion),
  CONSTRAINT Fk_AsigAplicacion FOREIGN KEY (Fk_Id_Aplicacion) REFERENCES tbl_aplicacion (Pk_Id_Aplicacion),
  CONSTRAINT Fk_AsigModulo FOREIGN KEY (Fk_Id_Modulo) REFERENCES tbl_modulo (Pk_Id_Modulo)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_perfil;
CREATE TABLE tbl_perfil (
  Pk_Id_Perfil int NOT NULL AUTO_INCREMENT,
  Cmp_Puesto_Perfil varchar(50) DEFAULT NULL,
  Cmp_Descripcion_Perfil varchar(50) DEFAULT NULL,
  Cmp_Estado_Perfil bit(1) NOT NULL,
  Cmp_Tipo_Perfil int DEFAULT NULL,
  PRIMARY KEY (Pk_Id_Perfil)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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

DROP TABLE IF EXISTS tbl_usuario_perfil;
CREATE TABLE tbl_usuario_perfil (
  Fk_Id_Usuario int NOT NULL,
  Fk_Id_Perfil int NOT NULL,
  PRIMARY KEY (Fk_Id_Usuario, Fk_Id_Perfil),
  KEY Fk_UsuarioPerfil_Perfil (Fk_Id_Perfil),
  CONSTRAINT Fk_UsuarioPerfil_Perfil FOREIGN KEY (Fk_Id_Perfil) REFERENCES tbl_perfil (Pk_Id_Perfil),
  CONSTRAINT Fk_UsuarioPerfil_Usuario FOREIGN KEY (Fk_Id_Usuario) REFERENCES tbl_usuario (Pk_Id_Usuario)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
