use Auditoria;

DROP TABLE IF EXISTS tbl_proyecto_estado;
CREATE TABLE tbl_proyecto_estado (
  Pk_id_proyecto_estado int NOT NULL,
  nombre_estado varchar(50) NOT NULL,
  descripcion_estado varchar(150) DEFAULT NULL,
  PRIMARY KEY (Pk_id_proyecto_estado)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_proyecto;
CREATE TABLE tbl_proyecto (
  Pk_id_proyecto int NOT NULL,
  Fk_id_proyecto_estado int NOT NULL,
  nombre_proyecto varchar(100) NOT NULL,
  descripcion text,
  fecha_inicio date DEFAULT NULL,
  fecha_fin date DEFAULT NULL,
  objetivo text,
  PRIMARY KEY (Pk_id_proyecto),
  KEY Fk_id_proyecto_estado (Fk_id_proyecto_estado),
  CONSTRAINT tbl_proyecto_estado_ibfk_1 FOREIGN KEY (Fk_id_proyecto_estado) REFERENCES tbl_proyecto_estado (Pk_id_proyecto_estado)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_actividades_proyecto;
CREATE TABLE tbl_actividades_proyecto (
  Pk_id_actividad_proyecto int NOT NULL,
  Fk_id_proyecto int NOT NULL,
  nombre_actividad varchar(100) NOT NULL,
  descripcion text,
  observaciones text,
  PRIMARY KEY (Pk_id_actividad_proyecto),
  KEY Fk_id_proyecto (Fk_id_proyecto),
  CONSTRAINT tbl_actividades_proyecto_ibfk_1 FOREIGN KEY (Fk_id_proyecto) REFERENCES tbl_proyecto (Pk_id_proyecto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_areas;
CREATE TABLE tbl_areas (
  Pk_id_area int NOT NULL,
  Fk_id_proyecto int NOT NULL,
  nombre_area varchar(100) NOT NULL,
  descripcion text,
  estado_area varchar(100) NOT NULL,
  PRIMARY KEY (Pk_id_area),
  KEY Fk_id_proyecto (Fk_id_proyecto),
  CONSTRAINT tbl_areas_ibfk_1 FOREIGN KEY (Fk_id_proyecto) REFERENCES tbl_proyecto (Pk_id_proyecto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_perfil_auditor;
CREATE TABLE tbl_perfil_auditor (
  Pk_id_perfil_auditor int NOT NULL,
  nombre_perfil varchar(50) NOT NULL,
  descripcion_perfil text,
  PRIMARY KEY (Pk_id_perfil_auditor)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_auditor;
CREATE TABLE tbl_auditor (
  Pk_id_auditor int NOT NULL,
  nombre_auditor varchar(45) DEFAULT NULL,
  telefono_auditor varchar(45) DEFAULT NULL,
  email_auditor varchar(20) DEFAULT NULL,
  carnet_auditor varchar(15) NOT NULL,
  Estado varchar(1) DEFAULT NULL,
  Fk_id_perfil_auditor int NOT NULL,
  Fk_id_proyecto int NOT NULL,
  PRIMARY KEY (Pk_id_auditor),
  KEY Fk_id_perfil_auditor (Fk_id_perfil_auditor),
  KEY Fk_id_proyecto (Fk_id_proyecto),
  CONSTRAINT tbl_perfil_auditor_ibfk_1 FOREIGN KEY (Fk_id_perfil_auditor) REFERENCES tbl_perfil_auditor (Pk_id_perfil_auditor),
  CONSTRAINT tbl_proyecto_ibfk_2 FOREIGN KEY (Fk_id_proyecto) REFERENCES tbl_proyecto (Pk_id_proyecto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_auditados;
CREATE TABLE tbl_auditados (
  Pk_id_auditado int NOT NULL,
  Fk_id_proyecto int NOT NULL,
  nombre_auditado varchar(100) NOT NULL,
  cargo_o_area varchar(100) DEFAULT NULL,
  correo varchar(100) DEFAULT NULL,
  telefono varchar(20) DEFAULT NULL,
  observaciones text,
  PRIMARY KEY (Pk_id_auditado),
  KEY Fk_id_proyecto (Fk_id_proyecto),
  CONSTRAINT tbl_proyecto_ibfk_1 FOREIGN KEY (Fk_id_proyecto) REFERENCES tbl_proyecto (Pk_id_proyecto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_estado_asignacion;
CREATE TABLE tbl_estado_asignacion (
  Pk_id_estado_asignacion int NOT NULL,
  estado_asignacion varchar(50) NOT NULL,
  descripcion_estado_asignacion text,
  PRIMARY KEY (Pk_id_estado_asignacion)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_asignacion;
CREATE TABLE tbl_asignacion (
  Pk_id_asignacion int NOT NULL,
  Fk_id_auditor int NOT NULL,
  Fk_id_estado_asignacion int NOT NULL,
  Fk_id_actividad_proyecto int NOT NULL,
  nombre_asignacion varchar(100) NOT NULL,
  fecha_asignacion date NOT NULL,
  fecha_finalizacion date DEFAULT NULL,
  descripcion text,
  evidencia varchar(255) DEFAULT NULL,
  observaciones text,
  PRIMARY KEY (Pk_id_asignacion),
  KEY Fk_id_auditor (Fk_id_auditor),
  KEY Fk_id_estado_asignacion (Fk_id_estado_asignacion),
  KEY Fk_id_actividad_proyecto (Fk_id_actividad_proyecto),
  CONSTRAINT tbl_asignacion_ibfk_1 FOREIGN KEY (Fk_id_auditor) REFERENCES tbl_auditor (Pk_id_auditor),
  CONSTRAINT tbl_asignacion_ibfk_2 FOREIGN KEY (Fk_id_estado_asignacion) REFERENCES tbl_estado_asignacion (Pk_id_estado_asignacion),
  CONSTRAINT tbl_asignacion_ibfk_3 FOREIGN KEY (Fk_id_actividad_proyecto) REFERENCES tbl_actividades_proyecto (Pk_id_actividad_proyecto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_estado_informe;
CREATE TABLE tbl_estado_informe (
  Pk_id_estado_informe int NOT NULL,
  nombre_estado varchar(50) NOT NULL,
  descripcion text,
  PRIMARY KEY (Pk_id_estado_informe)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_informe;
CREATE TABLE tbl_informe (
  Pk_id_informe int NOT NULL,
  Fk_id_auditor int NOT NULL,
  Fk_id_estado_informe int NOT NULL,
  titulo_informe varchar(150) NOT NULL,
  descripcion_general text,
  conclusiones text,
  fecha_creacion timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  fecha_actualizacion timestamp NULL DEFAULT NULL,
  PRIMARY KEY (Pk_id_informe),
  KEY Fk_id_auditor (Fk_id_auditor),
  KEY Fk_id_estado_informe (Fk_id_estado_informe),
  CONSTRAINT tbl_informe_ibfk_1 FOREIGN KEY (Fk_id_auditor) REFERENCES tbl_auditor (Pk_id_auditor),
  CONSTRAINT tbl_informe_ibfk_2 FOREIGN KEY (Fk_id_estado_informe) REFERENCES tbl_estado_informe (Pk_id_estado_informe)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_planificacion;
CREATE TABLE tbl_planificacion (
  Pk_id_planificacion int NOT NULL,
  Fk_id_proyecto int NOT NULL,
  nombre_plan varchar(100) NOT NULL,
  descripcion text,
  fecha_inicio date DEFAULT NULL,
  fecha_fin date DEFAULT NULL,
  observaciones text,
  PRIMARY KEY (Pk_id_planificacion),
  KEY Fk_id_proyecto (Fk_id_proyecto),
  CONSTRAINT tbl_planificacion_ibfk_1 FOREIGN KEY (Fk_id_proyecto) REFERENCES tbl_proyecto (Pk_id_proyecto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_cronograma;
CREATE TABLE tbl_cronograma (
  Pk_id_cronograma int NOT NULL,
  Fk_id_planificacion int NOT NULL,
  Fk_id_actividad_proyecto int NOT NULL,
  nombre_tarea varchar(100) NOT NULL,
  descripcion text,
  fecha_inicio date NOT NULL,
  fecha_fin date NOT NULL,
  responsable_tarea varchar(100) DEFAULT NULL,
  estado_tarea varchar(100) DEFAULT NULL,
  observaciones text,
  PRIMARY KEY (Pk_id_cronograma),
  KEY Fk_id_planificacion (Fk_id_planificacion),
  KEY Fk_id_actividad_proyecto (Fk_id_actividad_proyecto),
  CONSTRAINT tbl_cronograma_ibfk_1 FOREIGN KEY (Fk_id_planificacion) REFERENCES tbl_planificacion (Pk_id_planificacion),
  CONSTRAINT tbl_cronograma_ibfk_2 FOREIGN KEY (Fk_id_actividad_proyecto) REFERENCES tbl_actividades_proyecto (Pk_id_actividad_proyecto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_rubrica;
CREATE TABLE tbl_rubrica (
  Pk_id_rubrica int NOT NULL,
  Fk_id_cronograma int NOT NULL,
  nombre_rubrica varchar(100) NOT NULL,
  descripcion text,
  objetivo text,
  PRIMARY KEY (Pk_id_rubrica),
  KEY Fk_id_cronograma (Fk_id_cronograma),
  CONSTRAINT tbl_rubrica_ibfk_1 FOREIGN KEY (Fk_id_cronograma) REFERENCES tbl_cronograma (Pk_id_cronograma)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_criterios;
CREATE TABLE tbl_criterios (
  Pk_id_criterio int NOT NULL,
  Fk_id_rubrica int NOT NULL,
  nombre_criterio varchar(100) NOT NULL,
  porcentaje_criterio int DEFAULT NULL,
  descripcion text,
  nivel_importancia varchar(50) DEFAULT NULL,
  PRIMARY KEY (Pk_id_criterio),
  KEY Fk_id_rubrica (Fk_id_rubrica),
  CONSTRAINT tbl_criterios_ibfk_1 FOREIGN KEY (Fk_id_rubrica) REFERENCES tbl_rubrica (Pk_id_rubrica)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_escala_descripcion;
CREATE TABLE tbl_escala_descripcion (
  Pk_id_escala int NOT NULL,
  porcentaje int NOT NULL,
  nombre_nivel varchar(50) NOT NULL,
  descripcion_general text,
  color_referencia varchar(20) DEFAULT NULL,
  PRIMARY KEY (Pk_id_escala),
  CONSTRAINT tbl_escala_descripcion_chk_1 CHECK ((porcentaje in (0,20,40,60,80,100)))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_descripcion_criterio;
CREATE TABLE tbl_descripcion_criterio (
  Pk_id_descripcion_criterio int NOT NULL,
  Fk_id_criterio int NOT NULL,
  Fk_id_escala int NOT NULL,
  descripcion_detallada text NOT NULL,
  evidencia_requerida text,
  observaciones text,
  PRIMARY KEY (Pk_id_descripcion_criterio),
  KEY Fk_id_criterio (Fk_id_criterio),
  KEY Fk_id_escala (Fk_id_escala),
  CONSTRAINT tbl_descripcion_criterio_ibfk_1 FOREIGN KEY (Fk_id_criterio) REFERENCES tbl_criterios (Pk_id_criterio),
  CONSTRAINT tbl_descripcion_criterio_ibfk_2 FOREIGN KEY (Fk_id_escala) REFERENCES tbl_escala_descripcion (Pk_id_escala)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_checklist;
CREATE TABLE tbl_checklist (
  Pk_id_checklist int NOT NULL,
  Fk_id_informe int NOT NULL,
  Fk_id_criterio int NOT NULL,
  PRIMARY KEY (Pk_id_checklist),
  KEY Fk_id_informe (Fk_id_informe),
  KEY Fk_id_criterio (Fk_id_criterio),
  CONSTRAINT tbl_checklists_ibfk_1 FOREIGN KEY (Fk_id_informe) REFERENCES tbl_informe (Pk_id_informe),
  CONSTRAINT tbl_checklists_ibfk_2 FOREIGN KEY (Fk_id_criterio) REFERENCES tbl_criterios (Pk_id_criterio)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_grafica;
CREATE TABLE tbl_grafica (
  Pk_id_grafica int NOT NULL,
  Fk_id_informe int NOT NULL,
  tipo_grafica varchar(50) NOT NULL,
  descripcion text,
  datos_json_grafica json DEFAULT NULL,
  PRIMARY KEY (Pk_id_grafica),
  KEY Fk_id_informe (Fk_id_informe),
  CONSTRAINT tbl_grafica_ibfk_1 FOREIGN KEY (Fk_id_informe) REFERENCES tbl_informe (Pk_id_informe)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_proyecto_auditado;
CREATE TABLE tbl_proyecto_auditado (
  Pk_id_auditor_proyecto int NOT NULL,
  Fk_id_auditor int NOT NULL,
  Fk_id_proyecto int NOT NULL,
  rol_en_proyecto varchar(50) DEFAULT NULL,
  fecha_asignacion date DEFAULT (curdate()),
  observaciones text,
  PRIMARY KEY (Pk_id_auditor_proyecto),
  KEY Fk_id_auditor (Fk_id_auditor),
  KEY Fk_id_proyecto (Fk_id_proyecto),
  CONSTRAINT fk_auditor_proyecto_auditor FOREIGN KEY (Fk_id_auditor) REFERENCES tbl_auditor (Pk_id_auditor) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT fk_auditor_proyecto_proyecto FOREIGN KEY (Fk_id_proyecto) REFERENCES tbl_proyecto (Pk_id_proyecto) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_recursos;
CREATE TABLE tbl_recursos (
  Pk_id_recurso int NOT NULL,
  Fk_id_proyecto int NOT NULL,
  nombre_recurso varchar(100) NOT NULL,
  tipo_recurso varchar(100) NOT NULL,
  cantidad int DEFAULT '1',
  fecha_registro timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (Pk_id_recurso),
  KEY Fk_id_proyecto (Fk_id_proyecto),
  CONSTRAINT tbl_recursos_ibfk_1 FOREIGN KEY (Fk_id_proyecto) REFERENCES tbl_proyecto (Pk_id_proyecto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_reporte;
CREATE TABLE tbl_reporte (
  Pk_id_reporte int NOT NULL,
  Fk_id_informe int NOT NULL,
  Fk_id_criterio int NOT NULL,
  Fk_id_auditor int NOT NULL,
  aspectos_positivos text,
  correcciones text,
  recomendaciones text,
  PRIMARY KEY (Pk_id_reporte),
  KEY Fk_id_informe (Fk_id_informe),
  KEY Fk_id_criterio (Fk_id_criterio),
  KEY Fk_id_auditor (Fk_id_auditor),
  CONSTRAINT tbl_reporte_ibfk_1 FOREIGN KEY (Fk_id_informe) REFERENCES tbl_informe (Pk_id_informe),
  CONSTRAINT tbl_reporte_ibfk_2 FOREIGN KEY (Fk_id_criterio) REFERENCES tbl_criterios (Pk_id_criterio),
  CONSTRAINT tbl_reporte_ibfk_3 FOREIGN KEY (Fk_id_auditor) REFERENCES tbl_auditor (Pk_id_auditor)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS tbl_actividad_rubrica;
CREATE TABLE tbl_actividad_rubrica (
  pk_id_actividad_rubrica INT AUTO_INCREMENT PRIMARY KEY,
  fk_id_actividad_proyecto INT NOT NULL,
  fk_id_rubrica INT NOT NULL,
  estado TINYINT(1) DEFAULT 1,
  FOREIGN KEY (fk_id_actividad_proyecto) REFERENCES tbl_actividades_proyecto(Pk_id_actividad_proyecto),
  FOREIGN KEY (fk_id_rubrica) REFERENCES tbl_rubrica(Pk_id_rubrica)
);



DROP TABLE IF EXISTS tbl_tabla_ponderacion;
CREATE TABLE tbl_tabla_ponderacion (
  Pk_id_ponderacion int NOT NULL AUTO_INCREMENT,
  Fk_id_auditado int NOT NULL,
  Fk_id_cronograma int NOT NULL,
  Fk_id_rubrica int NOT NULL,
  Fk_id_criterio int NOT NULL,
  Fk_id_escala int NOT NULL,
  calificacion_porcentaje decimal(5,2) NOT NULL,
  calificacion_ponderada decimal(6,2) NOT NULL,
  comentarios_auditor text,
  fecha_evaluacion timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (Pk_id_ponderacion),
  KEY Fk_id_auditado (Fk_id_auditado),
  KEY Fk_id_cronograma (Fk_id_cronograma),
  KEY Fk_id_rubrica (Fk_id_rubrica),
  KEY Fk_id_criterio (Fk_id_criterio),
  KEY Fk_id_escala (Fk_id_escala),
  CONSTRAINT tbl_tabla_ponderacion_ibfk_1 FOREIGN KEY (Fk_id_auditado) REFERENCES tbl_auditados (Pk_id_auditado),
  CONSTRAINT tbl_tabla_ponderacion_ibfk_2 FOREIGN KEY (Fk_id_cronograma) REFERENCES tbl_cronograma (Pk_id_cronograma),
  CONSTRAINT tbl_tabla_ponderacion_ibfk_3 FOREIGN KEY (Fk_id_rubrica) REFERENCES tbl_rubrica (Pk_id_rubrica),
  CONSTRAINT tbl_tabla_ponderacion_ibfk_4 FOREIGN KEY (Fk_id_criterio) REFERENCES tbl_criterios (Pk_id_criterio),
  CONSTRAINT tbl_tabla_ponderacion_ibfk_5 FOREIGN KEY (Fk_id_escala) REFERENCES tbl_escala_descripcion (Pk_id_escala)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
