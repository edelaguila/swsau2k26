using System;
using System.Collections.Generic;
using System.Data.Odbc;
using Capa_Modelo_Seguridad;

namespace Capa_Modelo_Informe
{
    // Única capa que conoce las tablas y ejecuta SELECT mediante ODBC.
    public class Cls_Modelo_Informe
    {
        private readonly Cls_Conexion conexion = new Cls_Conexion();


        public void ProbarConexion()
        {
            using (OdbcConnection cn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand("SELECT DATABASE()", cn))
            {
                string baseActual = Convert.ToString(cmd.ExecuteScalar());
                if (!string.Equals(baseActual, "bd_auditoria", StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException("El DSN apunta a '" + baseActual +
                        "'. Configura bd_auditoria como base predeterminada.");
            }
        }

        public List<Cls_Informe_Resumen> ListarInformes()
        {
            List<Cls_Informe_Resumen> lista = new List<Cls_Informe_Resumen>();
            using (OdbcConnection cn = conexion.AbrirConexion())
            using (OdbcCommand cmd = new OdbcCommand(
                "SELECT Pk_id_informe, titulo_informe FROM tbl_informe ORDER BY Pk_id_informe DESC", cn))
            using (OdbcDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                    lista.Add(new Cls_Informe_Resumen {
                        Id = Convert.ToInt32(dr.GetValue(0)), Titulo = Valor(dr, 1)
                    });
            }
            return lista;
        }

        public Cls_Datos_Informe ObtenerInforme(int idInforme)
        {
            if (idInforme <= 0) throw new ArgumentException("Selecciona un informe válido.");
            Cls_Datos_Informe datos = new Cls_Datos_Informe();
            using (OdbcConnection cn = conexion.AbrirConexion())
            {
                const string cabecera = @"
                    SELECT i.Pk_id_informe, i.Fk_id_proyecto, i.titulo_informe, i.fecha_creacion,
                           e.Cmp_Nombre_Estado_Informe, p.Cmp_Nombre_Proyecto,
                           p.Cmp_Descripcion_Proyecto, p.Cmp_Objetivo_Proyecto,
                           a.Cmp_Nombre_Auditor
                    FROM tbl_informe i
                    INNER JOIN tbl_proyecto p ON p.Pk_Id_Proyecto = i.Fk_id_proyecto
                    INNER JOIN tbl_auditor a ON a.Pk_Id_Auditor = i.Fk_id_auditor
                    INNER JOIN tbl_estado_informe e ON e.Pk_Id_Estado_Informe = i.Fk_id_estado_informe
                    WHERE i.Pk_id_informe = ?";
                using (OdbcCommand cmd = Comando(cn, cabecera, idInforme))
                using (OdbcDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read()) throw new InvalidOperationException("No se encontró el informe.");
                    datos.Id = Convert.ToInt32(dr.GetValue(0));
                    datos.ProyectoId = Convert.ToInt32(dr.GetValue(1));
                    datos.Titulo = Valor(dr, 2);
                    datos.Fecha = dr.IsDBNull(3) ? (DateTime?)null : Convert.ToDateTime(dr.GetValue(3));
                    datos.Estado = Valor(dr, 4);
                    datos.Proyecto = Valor(dr, 5);
                    datos.DescripcionProyecto = Valor(dr, 6);
                    datos.ObjetivoProyecto = Valor(dr, 7);
                    datos.Auditor = Valor(dr, 8);
                }

                const string checklist = @"
                    SELECT ap.Cmp_Nombre_Actividad_Proyecto, ch.Entregado
                    FROM tbl_checklist ch
                    INNER JOIN tbl_actividad_rubrica ar ON ar.Pk_Id_Actividad_Rubrica = ch.Fk_id_actividad_rubrica
                    INNER JOIN tbl_actividades_proyecto ap ON ap.Pk_Id_Actividad_Proyecto = ar.Fk_Id_Actividad_Proyecto
                    WHERE ch.Fk_id_informe = ? AND ap.Fk_Id_Proyecto = ?
                    ORDER BY ap.Pk_Id_Actividad_Proyecto";
                using (OdbcCommand cmd = Comando(cn, checklist, idInforme, datos.ProyectoId))
                using (OdbcDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        datos.Checklist.Add(new Cls_Checklist_Informe {
                            Actividad = Valor(dr, 0), Entregado = Convert.ToInt32(dr.GetValue(1)) != 0
                        });
                }

                const string revisiones = @"
                    SELECT ap.Cmp_Nombre_Actividad_Proyecto, r.aspectos_positivos, r.imagen_aspectos_positivos,
                           r.correcciones, r.imagen_correcciones, r.recomendaciones, r.imagen_recomendaciones
                    FROM tbl_reporte r
                    INNER JOIN tbl_actividad_rubrica ar ON ar.Pk_Id_Actividad_Rubrica = r.Fk_id_actividad_rubrica
                    INNER JOIN tbl_actividades_proyecto ap ON ap.Pk_Id_Actividad_Proyecto = ar.Fk_Id_Actividad_Proyecto
                    WHERE r.Fk_id_informe = ? AND ap.Fk_Id_Proyecto = ?
                    ORDER BY ap.Pk_Id_Actividad_Proyecto, r.Pk_id_reporte";
                using (OdbcCommand cmd = Comando(cn, revisiones, idInforme, datos.ProyectoId))
                using (OdbcDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        datos.Revisiones.Add(new Cls_Revision_Informe {
                            Actividad = Valor(dr, 0), Positivos = Valor(dr, 1),
                            ImagenPositivos = Valor(dr, 2), Correcciones = Valor(dr, 3),
                            ImagenCorrecciones = Valor(dr, 4), Recomendaciones = Valor(dr, 5),
                            ImagenRecomendaciones = Valor(dr, 6)
                        });
                }

                // Estas evaluaciones están vinculadas al PROYECTO, no directamente al informe.
                // No se recalculan: los porcentajes se obtienen tal como se almacenaron.
                const string ponderaciones = @"
                    SELECT au.Cmp_Nombre_Auditado, cr.Cmp_Nombre_Criterio,
                           cr.Cmp_Porcentaje_Criterio,
                           t.Cmp_Calificacion_Porcentaje_Ponderacion,
                           t.Cmp_Calificacion_Ponderada_Ponderacion,
                           t.Cmp_Comentarios_Auditor_Ponderacion
                    FROM tbl_tabla_ponderacion t
                    INNER JOIN tbl_auditados au ON au.Pk_Id_Auditado = t.Fk_Id_Auditado
                    INNER JOIN tbl_criterios cr ON cr.Pk_Id_Criterio = t.Fk_Id_Criterio
                    INNER JOIN tbl_rubrica ru ON ru.Pk_Id_Rubrica = t.Fk_Id_Rubrica
                    INNER JOIN tbl_cronograma cro ON cro.Pk_Id_Cronograma = t.Fk_Id_Cronograma
                    INNER JOIN tbl_planificacion pl ON pl.Pk_Id_Planificacion = cro.Fk_Id_Planificacion
                    WHERE pl.Fk_Id_Proyecto = ?
                      AND ru.Fk_Id_Cronograma = cro.Pk_Id_Cronograma
                      AND cr.Fk_Id_Rubrica = ru.Pk_Id_Rubrica
                    ORDER BY au.Cmp_Nombre_Auditado, cr.Pk_Id_Criterio";
                using (OdbcCommand cmd = Comando(cn, ponderaciones, datos.ProyectoId))
                using (OdbcDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        datos.Ponderaciones.Add(new Cls_Ponderacion_Informe {
                            Auditado = Valor(dr, 0), Criterio = Valor(dr, 1),
                            PesoEsperado = dr.IsDBNull(2) ? (decimal?)null : Convert.ToDecimal(dr.GetValue(2)),
                            CalificacionPorcentaje = Convert.ToDecimal(dr.GetValue(3)),
                            CalificacionPonderada = Convert.ToDecimal(dr.GetValue(4)),
                            Comentarios = Valor(dr, 5)
                        });
                }

                const string graficas = @"
                    SELECT tipo_grafica, descripcion, CAST(datos_json_grafica AS CHAR)
                    FROM tbl_grafica WHERE Fk_id_proyecto = ? ORDER BY Pk_id_grafica";
                using (OdbcCommand cmd = Comando(cn, graficas, datos.ProyectoId))
                using (OdbcDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        datos.Graficas.Add(new Cls_Grafica_Informe {
                            Tipo = Valor(dr, 0), Descripcion = Valor(dr, 1), DatosJson = Valor(dr, 2)
                        });
                }
            }
            return datos;
        }

        private static OdbcCommand Comando(OdbcConnection cn, string sql, params object[] parametros)
        {
            OdbcCommand cmd = new OdbcCommand(sql, cn);
            // Los ? de ODBC usan orden posicional, no nombres de parámetros.
            foreach (object parametro in parametros) cmd.Parameters.AddWithValue("?", parametro);
            return cmd;
        }

        private static string Valor(OdbcDataReader dr, int columna)
        {
            return dr.IsDBNull(columna) ? "" : Convert.ToString(dr.GetValue(columna));
        }
    }
}
