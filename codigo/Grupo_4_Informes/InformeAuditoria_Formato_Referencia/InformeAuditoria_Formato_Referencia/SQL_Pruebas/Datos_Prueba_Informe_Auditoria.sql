-- DATOS DE PRUEBA PARA InformeAuditoriaODBC (MySQL 8)
-- Ejecutar UNA sola vez en bd_auditoria, preferiblemente en una copia de la BD.
-- No modifica ni elimina registros existentes. IDs reservados: 910001-910099.
USE bd_auditoria;
START TRANSACTION;

INSERT INTO tbl_proyecto_estado (Pk_Id_Proyecto_Estado,Cmp_Nombre_Proyecto_Estado,Cmp_Descripcion_Proyecto_Estado)
VALUES (910001,'En revision (prueba)','Estado de prueba para generacion de PDF');

INSERT INTO tbl_estado_informe (Pk_Id_Estado_Informe,Cmp_Nombre_Estado_Informe,Cmp_Descripcion_Estado_Informe)
VALUES (910001,'Borrador de prueba','Informe de prueba sin aprobacion');

INSERT INTO tbl_estado_auditor (Pk_Id_Estado_Auditor,Cmp_Nombre_Estado_Auditor)
VALUES (910001,'Activo (prueba)');

INSERT INTO tbl_auditor (Pk_Id_Auditor,Fk_Id_Estado_Auditor,Cmp_Nombre_Auditor,Cmp_Telefono_Auditor,Cmp_Email_Auditor,Cmp_Carnet_Auditor)
VALUES (910001,910001,'Auditor de Prueba','5555-0000','prueba@example.com','TEST-910001');

INSERT INTO tbl_auditados (Pk_Id_Auditado,Cmp_Nombre_Auditado,Cmp_Cargo_Area_Auditado,Cmp_Correo_Auditado)
VALUES (910001,'Equipo de Compras (Prueba)','Area de compras','compras-prueba@example.com');

INSERT INTO tbl_proyecto (Pk_Id_Proyecto,Fk_Id_Proyecto_Estado,Cmp_Nombre_Proyecto,Cmp_Descripcion_Proyecto,
 Cmp_Fecha_Inicio_Proyecto,Cmp_Fecha_Fin_Proyecto,Cmp_Objetivo_Proyecto)
VALUES (910001,910001,'Auditoria de Compras - DEMO ODBC',
 'Proyecto de prueba del modulo de compras para verificar la generacion automatica del informe PDF.',
 '2026-11-01','2026-11-30','Evaluar entregables, revision y calificaciones del modulo de compras.');

INSERT INTO tbl_actividades_proyecto
(Pk_Id_Actividad_Proyecto,Fk_Id_Proyecto,Cmp_Nombre_Actividad_Proyecto,Cmp_Descripcion_Actividad_Proyecto)
VALUES
(910001,910001,'Pagos a proveedores','Revision del prototipo de pagos'),
(910002,910001,'Aprobacion financiera','Revision de aprobacion de ordenes'),
(910003,910001,'Cierre de movimientos','Revision de cierre');

INSERT INTO tbl_planificacion
(Pk_Id_Planificacion,Fk_Id_Proyecto,Cmp_Nombre_Plan_Planificacion,Cmp_Descripcion_Planificacion,Cmp_Fecha_Inicio_Planificacion,Cmp_Fecha_Fin_Planificacion)
VALUES (910001,910001,'Plan de primera revision','Plan de prueba del modulo de compras','2026-11-01','2026-11-30');

INSERT INTO tbl_cronograma
(Pk_Id_Cronograma,Fk_Id_Planificacion,Fk_Id_Actividad_Proyecto,Cmp_Nombre_Tarea_Cronograma,
 Cmp_Descripcion_Cronograma,Cmp_Fecha_Inicio_Cronograma,Cmp_Fecha_Fin_Cronograma,Cmp_Responsable_Tarea_Cronograma,Cmp_Estado_Tarea_Cronograma)
VALUES (910001,910001,910001,'Evaluacion de primera entrega','Revision de los tres entregables','2026-11-05','2026-11-10','Auditor de Prueba','Completada');

INSERT INTO tbl_rubrica
(Pk_Id_Rubrica,Fk_Id_Cronograma,Cmp_Nombre_Rubrica,Cmp_Descripcion_Rubrica,Cmp_Objetivo_Rubrica)
VALUES (910001,910001,'Rubrica de primera revision','Criterios para la primera entrega','Comprobar resultados PDF');

INSERT INTO tbl_actividad_rubrica
(Pk_Id_Actividad_Rubrica,Fk_Id_Actividad_Proyecto,Fk_Id_Rubrica,Cmp_Estado_Actividad_Rubrica)
VALUES (910001,910001,910001,1),(910002,910002,910001,1),(910003,910003,910001,1);

INSERT INTO tbl_informe
(Pk_id_informe,Fk_id_auditor,Fk_id_estado_informe,Fk_id_proyecto,titulo_informe,fecha_creacion)
VALUES (910001,910001,910001,910001,'INFORME DE REVISION - PRUEBA ODBC', '2026-11-07 10:30:00');

INSERT INTO tbl_checklist (Pk_id_checklist,Fk_id_informe,Fk_id_actividad_rubrica,Entregado)
VALUES (910001,910001,910001,1),(910002,910001,910002,1),(910003,910001,910003,0);

-- Rutas vacias: no se esperan fotos reales en la prueba.
INSERT INTO tbl_reporte
(Pk_id_reporte,Fk_id_informe,Fk_id_actividad_rubrica,aspectos_positivos,imagen_aspectos_positivos,
 correcciones,imagen_correcciones,recomendaciones,imagen_recomendaciones)
VALUES
(910001,910001,910001,
 'El formulario presenta un diseño uniforme y una descripcion clara de su objetivo.','',
 'Faltan controles visibles para registrar pagos y seleccionar proveedores.','',
 'Agregar campos de monto, fecha y proveedor antes de la entrega final.',''),
(910002,910001,910002,
 'La interfaz mantiene colores y navegacion consistentes.','',
 'No se visualizan los detalles de la orden antes de aprobarla.','',
 'Mostrar el resumen de la orden y una confirmacion antes de aprobar.',''),
(910003,910001,910003,
 'El formulario identifica el proceso de cierre de movimientos.','',
 'Falta indicar que movimientos estan pendientes de cierre.','',
 'Agregar una tabla de movimientos y validar el cierre del periodo.','');

INSERT INTO tbl_criterios
(Pk_Id_Criterio,Fk_Id_Rubrica,Cmp_Nombre_Criterio,Cmp_Porcentaje_Criterio,Cmp_Descripcion_Criterio,Cmp_Nivel_Importancia_Criterio)
VALUES
(910001,910001,'Diseño del prototipo',40,'Diseno y claridad de interfaz','Alta'),
(910002,910001,'Funcionalidad propuesta',35,'Elementos de funcionamiento','Alta'),
(910003,910001,'Documentacion',25,'Calidad documental','Media');

-- Reutiliza una escala de 80% si ya existe (por el UNIQUE del esquema).
INSERT INTO tbl_escala_descripcion
(Pk_Id_Escala,Cmp_Porcentaje_Escala,Cmp_Nombre_Nivel_Escala,Cmp_Descripcion_General_Escala,Cmp_Color_Referencia_Escala)
SELECT 910001,80,'Bueno (prueba)','Nivel de prueba para la evaluacion','#72B7D2'
WHERE NOT EXISTS (SELECT 1 FROM tbl_escala_descripcion WHERE Cmp_Porcentaje_Escala=80);
SET @escala_test = (SELECT Pk_Id_Escala FROM tbl_escala_descripcion WHERE Cmp_Porcentaje_Escala=80 LIMIT 1);

INSERT INTO tbl_tabla_ponderacion
(Pk_Id_Ponderacion,Fk_Id_Auditado,Fk_Id_Cronograma,Fk_Id_Rubrica,Fk_Id_Criterio,Fk_Id_Escala,
 Cmp_Calificacion_Porcentaje_Ponderacion,Cmp_Calificacion_Ponderada_Ponderacion,Cmp_Comentarios_Auditor_Ponderacion)
VALUES
(910001,910001,910001,910001,910001,@escala_test,80.00,32.00,'Diseño adecuado'),
(910002,910001,910001,910001,910002,@escala_test,60.00,21.00,'Faltan controles'),
(910003,910001,910001,910001,910003,@escala_test,100.00,25.00,'Documentacion completa');

INSERT INTO tbl_grafica (Pk_id_grafica,Fk_id_proyecto,tipo_grafica,descripcion,datos_json_grafica)
VALUES (910001,910001,'Barras','Porcentajes por criterio (datos de prueba)',
 JSON_OBJECT('criterios',JSON_ARRAY('Diseño del prototipo','Funcionalidad propuesta','Documentacion'),
 'porcentajes',JSON_ARRAY(80,60,100)));

COMMIT;

-- CONFIRMACION: debe devolver titulo y auditor, y conteos 3 / 3 / 3.
SELECT i.Pk_id_informe, i.titulo_informe, a.Cmp_Nombre_Auditor,
 (SELECT COUNT(*) FROM tbl_checklist WHERE Fk_id_informe=i.Pk_id_informe) AS checklist,
 (SELECT COUNT(*) FROM tbl_reporte WHERE Fk_id_informe=i.Pk_id_informe) AS revisiones,
 (SELECT COUNT(*) FROM tbl_tabla_ponderacion WHERE Fk_Id_Cronograma=910001) AS calificaciones
FROM tbl_informe i JOIN tbl_auditor a ON a.Pk_Id_Auditor=i.Fk_id_auditor
WHERE i.Pk_id_informe=910001;
