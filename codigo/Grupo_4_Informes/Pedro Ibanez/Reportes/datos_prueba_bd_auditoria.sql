-- =====================================================================
-- Datos de prueba para bd_auditoria: 5 registros nuevos por tabla.
-- Ejecutar UNA sola vez, despues del script de creacion de la BD.
-- Los ids no chocan con los registros que ya trae el script original.
-- Usuarios de prueba (24-28): contrasena 'admin123' (mismo hash que admin).
-- =====================================================================
USE bd_auditoria;

START TRANSACTION;

-- ---------------------------------------------------------------------
-- Seguridad
-- ---------------------------------------------------------------------
INSERT INTO tbl_reportes (Pk_Id_Reporte, Cmp_Titulo_Reporte, Cmp_Ruta_Reporte, Cmp_Fecha_Reporte) VALUES
(6,  'Reporte de proyectos',   'C:\\reportes\\Reporte_proyectos.rpt',   '2026-10-01'),
(7,  'Reporte de auditores',   'C:\\reportes\\Reporte_auditores.rpt',   '2026-10-02'),
(8,  'Reporte de rubricas',    'C:\\reportes\\Reporte_rubricas.rpt',    '2026-10-03'),
(9,  'Reporte de informes',    'C:\\reportes\\Reporte_informes.rpt',    '2026-10-04'),
(10, 'Reporte de checklist',   'C:\\reportes\\Reporte_checklist.rpt',   '2026-10-05');

INSERT INTO tbl_modulo (Pk_Id_Modulo, Cmp_Nombre_Modulo, Cmp_Descripcion_Modulo, Cmp_Estado_Modulo) VALUES
(20, 'Pruebas Proyectos',   'Modulo de prueba de proyectos',   b'1'),
(21, 'Pruebas Auditores',   'Modulo de prueba de auditores',   b'1'),
(22, 'Pruebas Rubricas',    'Modulo de prueba de rubricas',    b'1'),
(23, 'Pruebas Informes',    'Modulo de prueba de informes',    b'1'),
(24, 'Pruebas Reportes',    'Modulo de prueba de reportes',    b'1');

INSERT INTO tbl_aplicacion (Pk_Id_Aplicacion, Fk_Id_Reporte_Aplicacion, Cmp_Nombre_Aplicacion, Cmp_Descripcion_Aplicacion, Cmp_Estado_Aplicacion) VALUES
(600, 6,  'Consulta Proyectos',  'Consulta de proyectos de prueba',  b'1'),
(601, 7,  'Consulta Auditores',  'Consulta de auditores de prueba',  b'1'),
(602, 8,  'Consulta Rubricas',   'Consulta de rubricas de prueba',   b'1'),
(603, 9,  'Consulta Informes',   'Consulta de informes de prueba',   b'1'),
(604, 10, 'Consulta Checklist',  'Consulta de checklist de prueba',  b'1');

INSERT INTO tbl_asignacion_modulo_aplicacion (Fk_Id_Modulo, Fk_Id_Aplicacion) VALUES
(20, 600), (21, 601), (22, 602), (23, 603), (24, 604);

INSERT INTO tbl_perfil (Pk_Id_Perfil, Cmp_Puesto_Perfil, Cmp_Descripcion_Perfil, Cmp_Estado_Perfil, Cmp_Tipo_Perfil) VALUES
(2, 'Auditor Senior',   'Auditor con experiencia',        b'1', 2),
(3, 'Auditor Junior',   'Auditor en formacion',           b'1', 2),
(4, 'Supervisor',       'Supervisa proyectos de auditoria', b'1', 2),
(5, 'Consultor',        'Solo consulta informacion',      b'1', 3),
(6, 'Invitado',         'Acceso limitado de lectura',     b'0', 3);

-- ---------------------------------------------------------------------
-- Auditores y auditados
-- ---------------------------------------------------------------------
INSERT INTO tbl_estado_auditor (Pk_Id_Estado_Auditor, Cmp_Nombre_Estado_Auditor) VALUES
(3, 'Vacaciones'),
(4, 'Suspendido'),
(5, 'Capacitacion'),
(6, 'Licencia'),
(7, 'Retirado');

INSERT INTO tbl_auditor (Pk_Id_Auditor, Fk_Id_Estado_Auditor, Cmp_Nombre_Auditor, Cmp_Telefono_Auditor, Cmp_Email_Auditor, Cmp_Carnet_Auditor) VALUES
(4, 1, 'Maria Lopez Garcia',     '5555-2001', 'maria.lopez@ex.com',     'AUD-0004'),
(5, 1, 'Carlos Ramirez Soto',    '5555-2002', 'carlos.ramirez@ex.com',  'AUD-0005'),
(6, 1, 'Ana Martinez Ruiz',      '5555-2003', 'ana.martinez@ex.com',    'AUD-0006'),
(7, 1, 'Luis Hernandez Diaz',    '5555-2004', 'luis.hernandez@ex.com',  'AUD-0007'),
(8, 3, 'Sofia Castillo Mendez',  '5555-2005', 'sofia.castillo@ex.com',  'AUD-0008');

INSERT INTO tbl_usuario (Pk_Id_Usuario, Fk_Id_Auditor, Cmp_Nombre_Usuario, Cmp_Contrasena_Usuario, Cmp_Intentos_Fallidos_Usuario, Cmp_Estado_Usuario, Cmp_FechaCreacion_Usuario, Cmp_Ultimo_Cambio_Contrasenea, Cmp_Pidio_Cambio_Contrasenea) VALUES
(24, 4, 'mlopez',     '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 0, b'1', '2026-10-01 08:00:00', '2026-10-01 08:00:00', b'0'),
(25, 5, 'cramirez',   '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 0, b'1', '2026-10-01 08:05:00', '2026-10-01 08:05:00', b'0'),
(26, 6, 'amartinez',  '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 0, b'1', '2026-10-01 08:10:00', '2026-10-01 08:10:00', b'0'),
(27, 7, 'lhernandez', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 0, b'1', '2026-10-01 08:15:00', '2026-10-01 08:15:00', b'0'),
(28, 8, 'scastillo',  '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 0, b'1', '2026-10-01 08:20:00', '2026-10-01 08:20:00', b'0');

INSERT INTO tbl_usuario_perfil (Fk_Id_Usuario, Fk_Id_Perfil) VALUES
(24, 2), (25, 3), (26, 4), (27, 5), (28, 6);

INSERT INTO tbl_permiso_perfil_aplicacion (Fk_Id_Perfil, Fk_Id_Modulo, Fk_Id_Aplicacion, Cmp_Ingresar_Permisos_Aplicacion_Perfil, Cmp_Consultar_Permisos_Aplicacion_Perfil, Cmp_Modificar_Permisos_Aplicacion_Perfil, Cmp_Eliminar_Permisos_Aplicacion_Perfil, Cmp_Imprimir_Permisos_Aplicacion_Perfil) VALUES
(2, 20, 600, b'1', b'1', b'1', b'1', b'1'),
(3, 21, 601, b'1', b'1', b'1', b'0', b'1'),
(4, 22, 602, b'1', b'1', b'1', b'1', b'1'),
(5, 23, 603, b'0', b'1', b'0', b'0', b'1'),
(6, 24, 604, b'0', b'1', b'0', b'0', b'0');

INSERT INTO tbl_permiso_usuario_aplicacion (Fk_Id_Usuario, Fk_Id_Modulo, Fk_Id_Aplicacion, Cmp_Ingresar_Permiso_Aplicacion_Usuario, Cmp_Consultar_Permiso_Aplicacion_Usuario, Cmp_Modificar_Permiso_Aplicacion_Usuario, Cmp_Eliminar_Permiso_Aplicacion_Usuario, Cmp_Imprimir_Permiso_Aplicacion_Usuario) VALUES
(24, 20, 600, b'1', b'1', b'1', b'1', b'1'),
(25, 21, 601, b'1', b'1', b'1', b'0', b'1'),
(26, 22, 602, b'1', b'1', b'1', b'1', b'1'),
(27, 23, 603, b'0', b'1', b'0', b'0', b'1'),
(28, 24, 604, b'0', b'1', b'0', b'0', b'0');

INSERT INTO tbl_bitacora (Pk_Id_Bitacora, Fk_Id_Usuario, Fk_Id_Aplicacion, Cmp_Fecha, Cmp_Accion, Cmp_Ip, Cmp_Nombre_Pc, Cmp_Login_Estado) VALUES
(1, 24, 600, '2026-10-02 09:00:00', 'Inicio de sesion',            '192.168.1.10', 'PC-AUDIT-01', b'1'),
(2, 25, 601, '2026-10-02 09:15:00', 'Consulta de auditores',       '192.168.1.11', 'PC-AUDIT-02', b'1'),
(3, 26, 602, '2026-10-02 10:00:00', 'Modificacion de rubrica',     '192.168.1.12', 'PC-AUDIT-03', b'1'),
(4, 27, 603, '2026-10-02 10:30:00', 'Intento de sesion fallido',   '192.168.1.13', 'PC-AUDIT-04', b'0'),
(5, 28, 604, '2026-10-02 11:00:00', 'Intento de sesion fallido',   '192.168.1.14', 'PC-AUDIT-05', b'0');

INSERT INTO tbl_bloqueo_usuario (Pk_Id_Bloqueo, Fk_Id_Usuario, Fk_Id_Bitacora, Cmp_Fecha_Inicio_Bloqueo_Usuario, Cmp_Fecha_Fin_Bloqueo_Usuario, Cmp_Motivo__Bloqueo_Usuario) VALUES
(1, 24, 1, '2026-09-01 08:00:00', '2026-09-01 08:30:00', 'Intentos fallidos'),
(2, 25, 2, '2026-09-05 09:00:00', '2026-09-05 09:30:00', 'Intentos fallidos'),
(3, 26, 3, '2026-09-10 10:00:00', '2026-09-11 10:00:00', 'Bloqueo administrativo'),
(4, 27, 4, '2026-10-02 10:30:00', '2026-10-02 11:00:00', 'Intentos fallidos'),
(5, 28, 5, '2026-10-02 11:00:00', '2026-10-02 11:30:00', 'Intentos fallidos');

INSERT INTO tbl_token_restaurarcontrasena (Pk_Id_Token, Fk_Id_Usuario, Cmp_Token, Cmp_Fecha_Creacion_Restaurar_Contrasenea, Cmp_Expiracion_Restaurar_Contrasenea, Cmp_Utilizado_Restaurar_Contrasenea, Cmp_Fecha_Uso_Restaurar_Contrasenea) VALUES
(25, 24, 'A1B2C3D4', '2026-10-03 08:00:00', '2026-10-03 08:05:00', b'1', '2026-10-03 08:02:00'),
(26, 25, 'E5F6A7B8', '2026-10-03 09:00:00', '2026-10-03 09:05:00', b'1', '2026-10-03 09:03:00'),
(27, 26, 'C9D0E1F2', '2026-10-03 10:00:00', '2026-10-03 10:05:00', b'0', NULL),
(28, 27, 'A3B4C5D6', '2026-10-03 11:00:00', '2026-10-03 11:05:00', b'0', NULL),
(29, 28, 'E7F8A9B0', '2026-10-03 12:00:00', '2026-10-03 12:05:00', b'1', '2026-10-03 12:01:00');

INSERT INTO tbl_auditados (Pk_Id_Auditado, Cmp_Nombre_Auditado, Cmp_Cargo_Area_Auditado, Cmp_Correo_Auditado, Cmp_Telefono_Auditado, Cmp_Observaciones_Auditado) VALUES
(1, 'Roberto Gomez',    'Gerente de TI',          'roberto.gomez@empresa.com',    '5555-3001', 'Responsable de infraestructura'),
(2, 'Patricia Flores',  'Jefa de Contabilidad',   'patricia.flores@empresa.com',  '5555-3002', 'Atiende auditorias financieras'),
(3, 'Jorge Morales',    'Coordinador de RRHH',    'jorge.morales@empresa.com',    '5555-3003', NULL),
(4, 'Elena Vargas',     'Jefa de Compras',        'elena.vargas@empresa.com',     '5555-3004', 'Disponible por las tardes'),
(5, 'Diego Navarro',    'Encargado de Bodega',    'diego.navarro@empresa.com',    '5555-3005', NULL);

INSERT INTO tbl_perfil_auditor (Pk_Id_Perfil_Auditor, Cmp_Nombre_Perfil_Auditor, Cmp_Descripcion_Perfil) VALUES
(1, 'Auditor lider',      'Dirige el equipo de auditoria'),
(2, 'Auditor de campo',   'Recolecta evidencia en sitio'),
(3, 'Auditor de sistemas','Evalua controles de TI'),
(4, 'Auditor financiero', 'Revisa estados financieros'),
(5, 'Observador',         'Acompana sin emitir hallazgos');

INSERT INTO tbl_estado_asignacion (Pk_Id_Estado_Asignacion, Cmp_Nombre_Estado_Asignacion, Cmp_Descripcion_Estado_Asignacion) VALUES
(1, 'Pendiente',   'Asignacion creada sin iniciar'),
(2, 'En proceso',  'El auditor esta trabajando'),
(3, 'En revision', 'Pendiente de revision del lider'),
(4, 'Completada',  'Asignacion terminada'),
(5, 'Cancelada',   'Asignacion cancelada');

-- ---------------------------------------------------------------------
-- Proyectos
-- ---------------------------------------------------------------------
INSERT INTO tbl_proyecto_estado (Pk_Id_Proyecto_Estado, Cmp_Nombre_Proyecto_Estado, Cmp_Descripcion_Proyecto_Estado) VALUES
(1, 'Activo',      'Proyecto en ejecucion'),
(2, 'En pausa',    'Proyecto detenido temporalmente'),
(3, 'Finalizado',  'Proyecto concluido'),
(4, 'Cancelado',   'Proyecto cancelado'),
(5, 'Planificado', 'Proyecto aun no iniciado');

INSERT INTO tbl_proyecto (Pk_Id_Proyecto, Fk_Id_Proyecto_Estado, Cmp_Nombre_Proyecto, Cmp_Descripcion_Proyecto, Cmp_Fecha_Inicio_Proyecto, Cmp_Fecha_Fin_Proyecto, Cmp_Objetivo_Proyecto) VALUES
(1, 1, 'Auditoria de TI 2026',          'Revision de infraestructura y seguridad', '2026-08-01', '2026-12-15', 'Evaluar controles de seguridad informatica'),
(2, 1, 'Auditoria Financiera Q3',       'Revision de estados financieros',         '2026-07-01', '2026-11-30', 'Verificar la razonabilidad de las cifras'),
(3, 1, 'Auditoria de RRHH',             'Revision de procesos de contratacion',    '2026-09-01', '2026-12-31', 'Validar cumplimiento de politicas de personal'),
(4, 1, 'Auditoria de Compras',          'Revision del proceso de compras',         '2026-09-15', '2027-01-31', 'Detectar riesgos en adquisiciones'),
(5, 5, 'Auditoria de Inventarios',      'Conteo y control de bodega',              '2026-11-01', '2027-02-28', 'Asegurar la exactitud del inventario');

INSERT INTO tbl_actividades_proyecto (Pk_Id_Actividad_Proyecto, Fk_Id_Proyecto, Cmp_Nombre_Actividad_Proyecto, Cmp_Descripcion_Actividad_Proyecto, Cmp_Observaciones_Actividad_Proyecto) VALUES
(1, 1, 'Revision de firewall',         'Validar reglas del firewall perimetral',  NULL),
(2, 2, 'Conciliacion bancaria',        'Revisar conciliaciones del trimestre',    'Solicitar estados de cuenta'),
(3, 3, 'Revision de expedientes',      'Muestreo de expedientes de personal',     NULL),
(4, 4, 'Evaluacion de proveedores',    'Revisar proceso de seleccion',            'Incluir cotizaciones'),
(5, 5, 'Conteo fisico',                'Conteo ciclico de bodega principal',      NULL);

INSERT INTO tbl_areas (Pk_Id_Area, Fk_Id_Proyecto, Cmp_Nombre_Area, Cmp_Descripcion_Area, Cmp_Estado_Area) VALUES
(1, 1, 'Tecnologia',    'Departamento de TI',            'Activa'),
(2, 2, 'Finanzas',      'Departamento financiero',       'Activa'),
(3, 3, 'Recursos Humanos', 'Gestion de personal',        'Activa'),
(4, 4, 'Compras',       'Adquisiciones y proveedores',   'Activa'),
(5, 5, 'Bodega',        'Almacen principal',             'Inactiva');

INSERT INTO tbl_recursos (Pk_Id_Recurso, Fk_Id_Proyecto, Cmp_Nombre_Recurso, Cmp_Tipo_Recurso, Cmp_Cantidad_Recurso, Cmp_Fecha_Registro_Recurso) VALUES
(1, 1, 'Laptop de auditoria',     'Equipo',    2, '2026-08-01 08:00:00'),
(2, 2, 'Licencia de ERP',         'Software',  1, '2026-07-01 08:00:00'),
(3, 3, 'Sala de reuniones',       'Espacio',   1, '2026-09-01 08:00:00'),
(4, 4, 'Escaner de documentos',   'Equipo',    1, '2026-09-15 08:00:00'),
(5, 5, 'Lector de codigo de barras', 'Equipo', 3, '2026-10-01 08:00:00');

INSERT INTO tbl_planificacion (Pk_Id_Planificacion, Fk_Id_Proyecto, Cmp_Nombre_Plan_Planificacion, Cmp_Descripcion_Planificacion, Cmp_Fecha_Inicio_Planificacion, Cmp_Fecha_Fin_Planificacion, Cmp_Observaciones_Planificacion) VALUES
(1, 1, 'Plan TI 2026',            'Planificacion de la auditoria de TI',        '2026-08-01', '2026-08-31', NULL),
(2, 2, 'Plan Financiero Q3',      'Planificacion de la auditoria financiera',   '2026-07-01', '2026-07-31', NULL),
(3, 3, 'Plan RRHH',               'Planificacion de la auditoria de RRHH',      '2026-09-01', '2026-09-30', 'Coordinar con gerencia'),
(4, 4, 'Plan Compras',            'Planificacion de la auditoria de compras',   '2026-09-15', '2026-10-15', NULL),
(5, 5, 'Plan Inventarios',        'Planificacion del conteo de inventario',     '2026-11-01', '2026-11-30', 'Pendiente de aprobacion');

INSERT INTO tbl_cronograma (Pk_Id_Cronograma, Fk_Id_Planificacion, Fk_Id_Actividad_Proyecto, Cmp_Nombre_Tarea_Cronograma, Cmp_Descripcion_Cronograma, Cmp_Fecha_Inicio_Cronograma, Cmp_Fecha_Fin_Cronograma, Cmp_Responsable_Tarea_Cronograma, Cmp_Estado_Tarea_Cronograma, Cmp_Observaciones_Cronograma) VALUES
(1, 1, 1, 'Revisar reglas de firewall',  'Exportar y analizar reglas',       '2026-09-01', '2026-09-10', 'Maria Lopez Garcia',    'Completada', NULL),
(2, 2, 2, 'Conciliar cuentas',           'Conciliar 3 cuentas principales',  '2026-08-01', '2026-08-20', 'Carlos Ramirez Soto',   'Completada', NULL),
(3, 3, 3, 'Muestrear expedientes',       'Muestra de 30 expedientes',        '2026-10-01', '2026-10-20', 'Ana Martinez Ruiz',     'En proceso', NULL),
(4, 4, 4, 'Evaluar proveedores',         'Revisar 10 proveedores',           '2026-10-16', '2026-11-15', 'Luis Hernandez Diaz',   'Pendiente',  NULL),
(5, 5, 5, 'Conteo de bodega',            'Conteo ciclico inicial',           '2026-12-01', '2026-12-10', 'Sofia Castillo Mendez', 'Pendiente',  'Requiere personal extra');

INSERT INTO tbl_rubrica (Pk_Id_Rubrica, Fk_Id_Cronograma, Cmp_Nombre_Rubrica, Cmp_Descripcion_Rubrica, Cmp_Objetivo_Rubrica) VALUES
(1, 1, 'Rubrica de seguridad perimetral', 'Evalua la configuracion del firewall', 'Medir el nivel de proteccion'),
(2, 2, 'Rubrica de conciliaciones',       'Evalua la calidad de conciliaciones', 'Medir exactitud contable'),
(3, 3, 'Rubrica de expedientes',          'Evalua la completitud de expedientes', 'Medir cumplimiento documental'),
(4, 4, 'Rubrica de proveedores',          'Evalua el proceso de seleccion',       'Medir transparencia en compras'),
(5, 5, 'Rubrica de inventario',           'Evalua la exactitud del inventario',   'Medir diferencias de conteo');

INSERT INTO tbl_actividad_rubrica (Pk_Id_Actividad_Rubrica, Fk_Id_Actividad_Proyecto, Fk_Id_Rubrica, Cmp_Estado_Actividad_Rubrica) VALUES
(1, 1, 1, 1),
(2, 2, 2, 1),
(3, 3, 3, 1),
(4, 4, 4, 1),
(5, 5, 5, 1);

INSERT INTO tbl_criterios (Pk_Id_Criterio, Fk_Id_Rubrica, Cmp_Nombre_Criterio, Cmp_Porcentaje_Criterio, Cmp_Descripcion_Criterio, Cmp_Nivel_Importancia_Criterio) VALUES
(1, 1, 'Reglas documentadas',      30, 'Las reglas del firewall estan documentadas', 'Alta'),
(2, 2, 'Partidas conciliadas',     25, 'Todas las partidas estan conciliadas',       'Alta'),
(3, 3, 'Documentos completos',     20, 'Los expedientes tienen todos los documentos', 'Media'),
(4, 4, 'Cotizaciones suficientes', 15, 'Se solicitan al menos 3 cotizaciones',       'Media'),
(5, 5, 'Diferencias de conteo',    10, 'Las diferencias son menores al 2%',          'Baja');

INSERT INTO tbl_escala_descripcion (Pk_Id_Escala, Cmp_Porcentaje_Escala, Cmp_Nombre_Nivel_Escala, Cmp_Descripcion_General_Escala, Cmp_Color_Referencia_Escala) VALUES
(1, 20,  'Deficiente', 'No cumple con lo esperado',          'Rojo'),
(2, 40,  'Regular',    'Cumple parcialmente',                'Naranja'),
(3, 60,  'Bueno',      'Cumple con observaciones',           'Amarillo'),
(4, 80,  'Muy bueno',  'Cumple con observaciones menores',   'Verde claro'),
(5, 100, 'Excelente',  'Cumple totalmente',                  'Verde');

INSERT INTO tbl_descripcion_criterio (Pk_Id_Descripcion_Criterio, Fk_Id_Criterio, Fk_Id_Escala, Cmp_Descripcion_Detallada_Descripcion_Criterio, Cmp_Evidencia_Requerida_Descripcion_Criterio, Cmp_Observaciones_Descripcion_Criterio) VALUES
(1, 1, 1, 'Menos del 20% de reglas documentadas',      'Export de reglas',          NULL),
(2, 2, 2, 'Entre 20% y 40% de partidas conciliadas',   'Hojas de conciliacion',     NULL),
(3, 3, 3, 'Entre 40% y 60% de expedientes completos',  'Lista de verificacion',     NULL),
(4, 4, 4, 'Entre 60% y 80% de compras con 3 cotizaciones', 'Cotizaciones archivadas', NULL),
(5, 5, 5, 'Diferencias de conteo menores al 2%',       'Acta de conteo firmada',    NULL);

INSERT INTO tbl_proyecto_auditor (Pk_Id_Proyecto_Auditor, Fk_Id_Proyecto, Fk_Id_Auditor, Fk_Id_Perfil_Auditor, Cmp_Fecha_Asignacion_Proyecto) VALUES
(1, 1, 4, 1, '2026-08-01'),
(2, 2, 5, 4, '2026-07-01'),
(3, 3, 6, 2, '2026-09-01'),
(4, 4, 7, 2, '2026-09-15'),
(5, 5, 8, 5, '2026-11-01');

INSERT INTO tbl_proyecto_auditado (Pk_Id_Proyecto_Auditado, Fk_Id_Proyecto, Fk_Id_Auditado, Cmp_Fecha_Ingreso_Auditado) VALUES
(1, 1, 1, '2026-08-01'),
(2, 2, 2, '2026-07-01'),
(3, 3, 3, '2026-09-01'),
(4, 4, 4, '2026-09-15'),
(5, 5, 5, '2026-11-01');

INSERT INTO tbl_asignacion (Pk_Id_Asignacion, Fk_Id_Auditor, Fk_Id_Auditado, Fk_Id_Estado_Asignacion, Fk_Id_Actividad_Rubrica, Cmp_Nombre_Asignacion, Cmp_Fecha_Asignacion, Cmp_Fecha_Finalizacion_Asignacion, Cmp_Descripcion_Asignacion, Cmp_Evidencia_Asignacion, Cmp_Observaciones_Asignacion) VALUES
(1, 4, 1, 4, 1, 'Revision de firewall',       '2026-09-01', '2026-09-10', 'Revisar reglas del firewall',     'evidencia_firewall.pdf',   NULL),
(2, 5, 2, 4, 2, 'Conciliaciones Q3',          '2026-08-01', '2026-08-20', 'Revisar conciliaciones',          'conciliaciones_q3.xlsx',   NULL),
(3, 6, 3, 2, 3, 'Muestreo de expedientes',    '2026-10-01', NULL,         'Revisar 30 expedientes',          NULL,                       'En curso'),
(4, 7, 4, 1, 4, 'Evaluacion de proveedores',  '2026-10-16', NULL,         'Revisar 10 proveedores',          NULL,                       NULL),
(5, 8, 5, 1, 5, 'Conteo de inventario',       '2026-12-01', NULL,         'Conteo ciclico de bodega',        NULL,                       'Pendiente de inicio');

INSERT INTO tbl_tabla_ponderacion (Pk_Id_Ponderacion, Fk_Id_Auditado, Fk_Id_Cronograma, Fk_Id_Rubrica, Fk_Id_Criterio, Fk_Id_Escala, Cmp_Calificacion_Porcentaje_Ponderacion, Cmp_Calificacion_Ponderada_Ponderacion, Cmp_Comentarios_Auditor_Ponderacion, Cmp_Fecha_Evaluacion_Ponderacion) VALUES
(1, 1, 1, 1, 1, 1,  20.00,  6.00, 'Faltan reglas por documentar',   '2026-09-10 16:00:00'),
(2, 2, 2, 2, 2, 2,  40.00, 10.00, 'Varias partidas sin conciliar',  '2026-08-20 16:00:00'),
(3, 3, 3, 3, 3, 3,  60.00, 12.00, 'Expedientes con faltantes',      '2026-10-20 16:00:00'),
(4, 4, 4, 4, 4, 4,  80.00, 12.00, 'Buen proceso de cotizacion',     '2026-11-15 16:00:00'),
(5, 5, 5, 5, 5, 5, 100.00, 10.00, 'Sin diferencias relevantes',     '2026-12-10 16:00:00');

INSERT INTO tbl_grafica (Pk_id_grafica, Fk_id_proyecto, tipo_grafica, descripcion, datos_json_grafica) VALUES
(1, 1, 'Barras',   'Cumplimiento por criterio',   '{"labels": ["Reglas", "Accesos"], "valores": [20, 60]}'),
(2, 2, 'Pastel',   'Partidas conciliadas',        '{"labels": ["Conciliadas", "Pendientes"], "valores": [40, 60]}'),
(3, 3, 'Lineas',   'Avance de revision',          '{"labels": ["Semana 1", "Semana 2"], "valores": [30, 60]}'),
(4, 4, 'Barras',   'Cotizaciones por compra',     '{"labels": ["1", "2", "3"], "valores": [2, 3, 5]}'),
(5, 5, 'Pastel',   'Diferencias de inventario',   '{"labels": ["Sin diferencia", "Con diferencia"], "valores": [98, 2]}');

-- ---------------------------------------------------------------------
-- Informes, checklist y reportes
-- ---------------------------------------------------------------------
INSERT INTO tbl_estado_informe (Pk_Id_Estado_Informe, Cmp_Nombre_Estado_Informe, Cmp_Descripcion_Estado_Informe) VALUES
(1, 'Borrador',    'Informe en elaboracion'),
(2, 'En revision', 'Informe enviado a revision'),
(3, 'Aprobado',    'Informe aprobado por el lider'),
(4, 'Rechazado',   'Informe devuelto con observaciones'),
(5, 'Publicado',   'Informe entregado al auditado');

INSERT INTO tbl_informe (Pk_id_informe, Fk_id_auditor, Fk_id_estado_informe, Fk_id_proyecto, titulo_informe, fecha_creacion, fecha_actualizacion) VALUES
(1, 4, 5, 1, 'Informe de auditoria de TI',          '2026-09-12 10:00:00', '2026-09-15 10:00:00'),
(2, 5, 3, 2, 'Informe financiero Q3',               '2026-08-22 10:00:00', '2026-08-25 10:00:00'),
(3, 6, 2, 3, 'Informe de expedientes de RRHH',      '2026-10-21 10:00:00', '2026-10-21 10:00:00'),
(4, 7, 1, 4, 'Informe preliminar de compras',       '2026-10-18 10:00:00', '2026-10-18 10:00:00'),
(5, 8, 1, 5, 'Informe de planificacion inventario', '2026-10-19 10:00:00', '2026-10-19 10:00:00');

INSERT INTO tbl_checklist (Pk_id_checklist, Fk_id_informe, Fk_id_actividad_rubrica, Entregado) VALUES
(1, 1, 1, 1),
(2, 2, 2, 1),
(3, 3, 3, 0),
(4, 4, 4, 0),
(5, 5, 5, 0);

-- Las rutas de imagen van vacias: el formulario valida que el archivo exista
INSERT INTO tbl_reporte (Pk_id_reporte, Fk_id_informe, Fk_id_actividad_rubrica, aspectos_positivos, imagen_aspectos_positivos, correcciones, imagen_correcciones, recomendaciones, imagen_recomendaciones) VALUES
(1, 1, 1, 'El firewall tiene reglas de salida bien definidas.',  '', 'Documentar las reglas de entrada.',          '', 'Revisar las reglas cada trimestre.',          ''),
(2, 2, 2, 'Las conciliaciones se realizan mensualmente.',        '', 'Corregir partidas antiguas sin conciliar.',  '', 'Automatizar la conciliacion bancaria.',       ''),
(3, 3, 3, 'Los expedientes estan ordenados por fecha.',          '', 'Completar documentos faltantes.',            '', 'Usar una lista de verificacion digital.',     ''),
(4, 4, 4, 'Se solicitan cotizaciones en la mayoria de compras.', '', 'Exigir 3 cotizaciones en todas las compras.', '', 'Crear un registro de proveedores aprobados.', ''),
(5, 5, 5, 'La bodega esta ordenada y rotulada.',                 '', 'Actualizar el sistema tras cada conteo.',    '', 'Realizar conteos ciclicos mensuales.',        '');

COMMIT;
