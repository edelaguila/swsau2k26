using System;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_PY
{
    // Clase con las sentencias SQL del CRUD de tbl_proyecto
    public class Cls_Sentencias_PY
    {
        private readonly Cls_Conexion_PY cnxConexion = new Cls_Conexion_PY();

        public DataTable fun_obtener_proyectos()
        {
            DataTable dtProyectos = new DataTable();
            string sSql =
                "SELECT p.Pk_Id_Proyecto, p.Fk_Id_Proyecto_Estado, e.Cmp_Nombre_Proyecto_Estado, " +
                "p.Cmp_Nombre_Proyecto, p.Cmp_Descripcion_Proyecto, p.Cmp_Fecha_Inicio_Proyecto, " +
                "p.Cmp_Fecha_Fin_Proyecto, p.Cmp_Objetivo_Proyecto " +
                "FROM tbl_proyecto p " +
                "INNER JOIN tbl_proyecto_estado e ON e.Pk_Id_Proyecto_Estado = p.Fk_Id_Proyecto_Estado " +
                "ORDER BY p.Pk_Id_Proyecto";

            OdbcConnection conn = cnxConexion.conexion();
            try
            {
                OdbcDataAdapter adaptador = new OdbcDataAdapter(sSql, conn);
                adaptador.Fill(dtProyectos);
            }
            finally { cnxConexion.desconexion(conn); }
            return dtProyectos;
        }

        public DataTable fun_obtener_estados()
        {
            DataTable dtEstados = new DataTable();
            string sSql =
                "SELECT Pk_Id_Proyecto_Estado AS Id, Cmp_Nombre_Proyecto_Estado AS Nombre " +
                "FROM tbl_proyecto_estado ORDER BY Pk_Id_Proyecto_Estado";

            OdbcConnection conn = cnxConexion.conexion();
            try
            {
                OdbcDataAdapter adaptador = new OdbcDataAdapter(sSql, conn);
                adaptador.Fill(dtEstados);
            }
            finally { cnxConexion.desconexion(conn); }
            return dtEstados;
        }

        // Pk_Id_Proyecto no es AUTO_INCREMENT, se calcula el siguiente código
        public int fun_siguiente_id()
        {
            OdbcConnection conn = cnxConexion.conexion();
            try
            {
                OdbcCommand cmd = new OdbcCommand("SELECT IFNULL(MAX(Pk_Id_Proyecto), 0) + 1 FROM tbl_proyecto", conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            finally { cnxConexion.desconexion(conn); }
        }

        public bool fun_insertar_proyecto(int iId, int iEstado, string sNombre, string sDescripcion,
                                          DateTime? dInicio, DateTime? dFin, string sObjetivo)
        {
            string sSql =
                "INSERT INTO tbl_proyecto (Pk_Id_Proyecto, Fk_Id_Proyecto_Estado, Cmp_Nombre_Proyecto, " +
                "Cmp_Descripcion_Proyecto, Cmp_Fecha_Inicio_Proyecto, Cmp_Fecha_Fin_Proyecto, Cmp_Objetivo_Proyecto) " +
                "VALUES (?, ?, ?, ?, ?, ?, ?)";

            OdbcConnection conn = cnxConexion.conexion();
            try
            {
                OdbcCommand cmd = new OdbcCommand(sSql, conn);
                cmd.Parameters.Add("@id", OdbcType.Int).Value = iId;
                pro_asignar_parametros(cmd, iEstado, sNombre, sDescripcion, dInicio, dFin, sObjetivo);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally { cnxConexion.desconexion(conn); }
        }

        public bool fun_actualizar_proyecto(int iId, int iEstado, string sNombre, string sDescripcion,
                                            DateTime? dInicio, DateTime? dFin, string sObjetivo)
        {
            string sSql =
                "UPDATE tbl_proyecto SET Fk_Id_Proyecto_Estado = ?, Cmp_Nombre_Proyecto = ?, " +
                "Cmp_Descripcion_Proyecto = ?, Cmp_Fecha_Inicio_Proyecto = ?, " +
                "Cmp_Fecha_Fin_Proyecto = ?, Cmp_Objetivo_Proyecto = ? " +
                "WHERE Pk_Id_Proyecto = ?";

            OdbcConnection conn = cnxConexion.conexion();
            try
            {
                OdbcCommand cmd = new OdbcCommand(sSql, conn);
                pro_asignar_parametros(cmd, iEstado, sNombre, sDescripcion, dInicio, dFin, sObjetivo);
                cmd.Parameters.Add("@id", OdbcType.Int).Value = iId; // El id va al final por el orden del WHERE
                return cmd.ExecuteNonQuery() > 0;
            }
            finally { cnxConexion.desconexion(conn); }
        }

        public bool fun_eliminar_proyecto(int iId)
        {
            OdbcConnection conn = cnxConexion.conexion();
            try
            {
                OdbcCommand cmd = new OdbcCommand("DELETE FROM tbl_proyecto WHERE Pk_Id_Proyecto = ?", conn);
                cmd.Parameters.Add("@id", OdbcType.Int).Value = iId;
                return cmd.ExecuteNonQuery() > 0;
            }
            finally { cnxConexion.desconexion(conn); }
        }

        // Asigna los 6 parámetros comunes, EN ORDEN (ODBC usa ? posicionales)
        private void pro_asignar_parametros(OdbcCommand cmd, int iEstado, string sNombre, string sDescripcion,
                                            DateTime? dInicio, DateTime? dFin, string sObjetivo)
        {
            cmd.Parameters.Add("@estado", OdbcType.Int).Value = iEstado;
            cmd.Parameters.Add("@nombre", OdbcType.VarChar, 100).Value = sNombre;
            cmd.Parameters.Add("@descripcion", OdbcType.Text).Value = fun_texto_o_nulo(sDescripcion);
            cmd.Parameters.Add("@inicio", OdbcType.Date).Value = dInicio.HasValue ? (object)dInicio.Value.Date : DBNull.Value;
            cmd.Parameters.Add("@fin", OdbcType.Date).Value = dFin.HasValue ? (object)dFin.Value.Date : DBNull.Value;
            cmd.Parameters.Add("@objetivo", OdbcType.Text).Value = fun_texto_o_nulo(sObjetivo);
        }

        private object fun_texto_o_nulo(string sTexto)
        {
            return string.IsNullOrWhiteSpace(sTexto) ? (object)DBNull.Value : sTexto;
        }
    }
}