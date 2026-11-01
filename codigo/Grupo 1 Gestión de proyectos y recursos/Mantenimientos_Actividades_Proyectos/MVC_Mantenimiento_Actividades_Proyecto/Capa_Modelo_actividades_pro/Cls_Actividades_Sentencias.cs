
/*
 * ============================================================
 * Área       : Gestión de Proyectos y Recursos
 * Componente : Actividades del Proyecto
 * Capa       : Modelo
 * Autor      : Danilo Mazariegos
 * Carné      : 0901-19-25059
 * Fecha      : 08/10/2026
 * Estándar   : ES-01 versión 1.5
 * ============================================================
 * Propósito:
 * Realizar operaciones SQL mediante conexión ODBC.
 * ============================================================
 */

using Capa_Modelo_Seguridad;
using System;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_actividades_pro
{
    public class Cls_Actividades_Sentencias
    {
        private readonly Cls_Conexion gConexion =
            new Cls_Conexion();

        // Obtener actividades y nombre del proyecto.
        public DataTable fun_obtener_actividades()
        {
            string sSql = @"
                SELECT
                    a.Pk_Id_Actividad_Proyecto,
                    a.Fk_Id_Proyecto,
                    p.Cmp_Nombre_Proyecto,
                    a.Cmp_Nombre_Actividad_Proyecto,
                    a.Cmp_Descripcion_Actividad_Proyecto,
                    a.Cmp_Observaciones_Actividad_Proyecto
                FROM tbl_actividades_proyecto a
                INNER JOIN tbl_proyecto p
                    ON p.Pk_Id_Proyecto = a.Fk_Id_Proyecto
                ORDER BY a.Pk_Id_Actividad_Proyecto";

            using (OdbcConnection gConn =
                gConexion.AbrirConexion())
            using (OdbcDataAdapter gAdapter =
                new OdbcDataAdapter(sSql, gConn))
            {
                DataTable gDatos = new DataTable();
                gAdapter.Fill(gDatos);
                return gDatos;
            }
        }

        // Obtener proyectos para llenar ComboBox.
        public DataTable fun_obtener_proyectos()
        {
            string sSql = @"
                SELECT Pk_Id_Proyecto,
                       Cmp_Nombre_Proyecto
                FROM tbl_proyecto
                ORDER BY Cmp_Nombre_Proyecto";

            using (OdbcConnection gConn =
                gConexion.AbrirConexion())
            using (OdbcDataAdapter gAdapter =
                new OdbcDataAdapter(sSql, gConn))
            {
                DataTable gDatos = new DataTable();
                gAdapter.Fill(gDatos);
                return gDatos;
            }
        }

        // Comprobar si un proyecto existe.
        public bool fun_existe_proyecto(int iIdProyecto)
        {
            string sSql = @"
                SELECT COUNT(*)
                FROM tbl_proyecto
                WHERE Pk_Id_Proyecto = ?";

            using (OdbcConnection gConn =
                gConexion.AbrirConexion())
            using (OdbcCommand gCmd =
                new OdbcCommand(sSql, gConn))
            {
                gCmd.Parameters.Add(
                    "id", OdbcType.Int).Value = iIdProyecto;

                return Convert.ToInt32(
                    gCmd.ExecuteScalar()) > 0;
            }
        }

        // Comprobar si una actividad existe.
        public bool fun_existe_actividad(int iIdActividad)
        {
            string sSql = @"
                SELECT COUNT(*)
                FROM tbl_actividades_proyecto
                WHERE Pk_Id_Actividad_Proyecto = ?";

            using (OdbcConnection gConn =
                gConexion.AbrirConexion())
            using (OdbcCommand gCmd =
                new OdbcCommand(sSql, gConn))
            {
                gCmd.Parameters.Add(
                    "id", OdbcType.Int).Value = iIdActividad;

                return Convert.ToInt32(
                    gCmd.ExecuteScalar()) > 0;
            }
        }

        // Insertar actividad.
        public int fun_insertar_actividad(
            int iIdActividad,
            int iIdProyecto,
            string sNombre,
            string sDescripcion,
            string sObservaciones)
        {
            string sSql = @"
                INSERT INTO tbl_actividades_proyecto
                (
                    Pk_Id_Actividad_Proyecto,
                    Fk_Id_Proyecto,
                    Cmp_Nombre_Actividad_Proyecto,
                    Cmp_Descripcion_Actividad_Proyecto,
                    Cmp_Observaciones_Actividad_Proyecto
                )
                VALUES (?, ?, ?, ?, ?)";

            using (OdbcConnection gConn =
                gConexion.AbrirConexion())
            using (OdbcCommand gCmd =
                new OdbcCommand(sSql, gConn))
            {
                gCmd.Parameters.Add(
                    "id", OdbcType.Int).Value = iIdActividad;

                gCmd.Parameters.Add(
                    "proyecto", OdbcType.Int).Value = iIdProyecto;

                gCmd.Parameters.Add(
                    "nombre", OdbcType.VarChar, 100)
                    .Value = sNombre;

                gCmd.Parameters.Add(
                    "descripcion", OdbcType.Text)
                    .Value = fun_texto_opcional(sDescripcion);

                gCmd.Parameters.Add(
                    "observaciones", OdbcType.Text)
                    .Value = fun_texto_opcional(sObservaciones);

                return gCmd.ExecuteNonQuery();
            }
        }

        // Modificar una actividad.
        public int fun_modificar_actividad(
            int iIdActividad,
            int iIdProyecto,
            string sNombre,
            string sDescripcion,
            string sObservaciones)
        {
            string sSql = @"
                UPDATE tbl_actividades_proyecto
                SET Fk_Id_Proyecto = ?,
                    Cmp_Nombre_Actividad_Proyecto = ?,
                    Cmp_Descripcion_Actividad_Proyecto = ?,
                    Cmp_Observaciones_Actividad_Proyecto = ?
                WHERE Pk_Id_Actividad_Proyecto = ?";

            using (OdbcConnection gConn =
                gConexion.AbrirConexion())
            using (OdbcCommand gCmd =
                new OdbcCommand(sSql, gConn))
            {
                // Los parámetros ODBC son posicionales.
                gCmd.Parameters.Add(
                    "proyecto", OdbcType.Int).Value = iIdProyecto;

                gCmd.Parameters.Add(
                    "nombre", OdbcType.VarChar, 100)
                    .Value = sNombre;

                gCmd.Parameters.Add(
                    "descripcion", OdbcType.Text)
                    .Value = fun_texto_opcional(sDescripcion);

                gCmd.Parameters.Add(
                    "observaciones", OdbcType.Text)
                    .Value = fun_texto_opcional(sObservaciones);

                gCmd.Parameters.Add(
                    "id", OdbcType.Int).Value = iIdActividad;

                return gCmd.ExecuteNonQuery();
            }
        }

        // Eliminar una actividad.
        public int fun_eliminar_actividad(int iIdActividad)
        {
            string sSql = @"
                DELETE FROM tbl_actividades_proyecto
                WHERE Pk_Id_Actividad_Proyecto = ?";

            using (OdbcConnection gConn =
                gConexion.AbrirConexion())
            using (OdbcCommand gCmd =
                new OdbcCommand(sSql, gConn))
            {
                gCmd.Parameters.Add(
                    "id", OdbcType.Int).Value = iIdActividad;

                return gCmd.ExecuteNonQuery();
            }
        }

        // Convertir textos vacíos a NULL.
        private object fun_texto_opcional(string sTexto)
        {
            return string.IsNullOrWhiteSpace(sTexto)
                ? (object)DBNull.Value
                : sTexto.Trim();
        }
    }
}
