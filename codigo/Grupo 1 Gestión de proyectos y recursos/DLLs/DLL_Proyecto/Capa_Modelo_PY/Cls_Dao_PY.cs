using System;
using System.Data;
using System.Data.Odbc;

//Inicio de código de Paula Daniela Leonardo Paredes carné 0901-22-9580 en la fecha de: "20/10/2026"
namespace Capa_Modelo_PY
{
    public class Cls_Dao_PY
    {
        private readonly Cls_Conexion_PY gConexion = new Cls_Conexion_PY();

        public DataTable fun_listar_proyectos()
        {
            string sSql =
                "SELECT p.Pk_Id_Proyecto, p.Fk_Id_Proyecto_Estado, e.Cmp_Nombre_Proyecto_Estado, " +
                "p.Cmp_Nombre_Proyecto, p.Cmp_Descripcion_Proyecto, p.Cmp_Fecha_Inicio_Proyecto, " +
                "p.Cmp_Fecha_Fin_Proyecto, p.Cmp_Objetivo_Proyecto " +
                "FROM tbl_proyecto p " +
                "INNER JOIN tbl_proyecto_estado e ON e.Pk_Id_Proyecto_Estado = p.Fk_Id_Proyecto_Estado " +
                "ORDER BY p.Pk_Id_Proyecto";

            DataTable dtsProyectos = new DataTable();
            using (OdbcConnection conn = gConexion.conexion())
            {
                conn.Open();
                using (OdbcDataAdapter adaptador = new OdbcDataAdapter(sSql, conn))
                {
                    adaptador.Fill(dtsProyectos);
                }
            }
            return dtsProyectos;
        }

        public DataTable fun_listar_estados()
        {
            string sSql =
                "SELECT Pk_Id_Proyecto_Estado, Cmp_Nombre_Proyecto_Estado " +
                "FROM tbl_proyecto_estado ORDER BY Pk_Id_Proyecto_Estado";

            DataTable dtsEstados = new DataTable();
            using (OdbcConnection conn = gConexion.conexion())
            {
                conn.Open();
                using (OdbcDataAdapter adaptador = new OdbcDataAdapter(sSql, conn))
                {
                    adaptador.Fill(dtsEstados);
                }
            }
            return dtsEstados;
        }

        // Pk_Id_Proyecto no es AUTO_INCREMENT, por eso se calcula el siguiente código
        public int fun_siguiente_id()
        {
            using (OdbcConnection conn = gConexion.conexion())
            {
                conn.Open();
                using (OdbcCommand cmdId = new OdbcCommand(
                    "SELECT COALESCE(MAX(Pk_Id_Proyecto), 0) + 1 FROM tbl_proyecto", conn))
                {
                    return Convert.ToInt32(cmdId.ExecuteScalar());
                }
            }
        }

        public int fun_insertar_proyecto(int iIdEstado, string sNombre, string sDescripcion,
                                         DateTime? dInicio, DateTime? dFin, string sObjetivo)
        {
            using (OdbcConnection conn = gConexion.conexion())
            {
                conn.Open();
                using (OdbcTransaction trx = conn.BeginTransaction())
                {
                    int iNuevoId;
                    using (OdbcCommand cmdId = new OdbcCommand(
                        "SELECT COALESCE(MAX(Pk_Id_Proyecto), 0) + 1 FROM tbl_proyecto FOR UPDATE", conn, trx))
                    {
                        iNuevoId = Convert.ToInt32(cmdId.ExecuteScalar());
                    }

                    using (OdbcCommand cmdInsertar = new OdbcCommand(
                        "INSERT INTO tbl_proyecto " +
                        "(Pk_Id_Proyecto, Fk_Id_Proyecto_Estado, Cmp_Nombre_Proyecto, Cmp_Descripcion_Proyecto, " +
                        "Cmp_Fecha_Inicio_Proyecto, Cmp_Fecha_Fin_Proyecto, Cmp_Objetivo_Proyecto) " +
                        "VALUES (?, ?, ?, ?, ?, ?, ?)", conn, trx))
                    {
                        // ODBC usa parámetros posicionales (?), el orden es el que manda
                        cmdInsertar.Parameters.Add("@id", OdbcType.Int).Value = iNuevoId;
                        cmdInsertar.Parameters.Add("@estado", OdbcType.Int).Value = iIdEstado;
                        cmdInsertar.Parameters.Add("@nombre", OdbcType.VarChar, 100).Value = sNombre;
                        cmdInsertar.Parameters.Add("@descripcion", OdbcType.Text).Value = fun_texto_o_nulo(sDescripcion);
                        cmdInsertar.Parameters.Add("@inicio", OdbcType.Date).Value = fun_fecha_o_nulo(dInicio);
                        cmdInsertar.Parameters.Add("@fin", OdbcType.Date).Value = fun_fecha_o_nulo(dFin);
                        cmdInsertar.Parameters.Add("@objetivo", OdbcType.Text).Value = fun_texto_o_nulo(sObjetivo);
                        cmdInsertar.ExecuteNonQuery();
                    }

                    trx.Commit();
                    return iNuevoId;
                }
            }
        }

        public int fun_modificar_proyecto(int iIdProyecto, int iIdEstado, string sNombre, string sDescripcion,
                                          DateTime? dInicio, DateTime? dFin, string sObjetivo)
        {
            using (OdbcConnection conn = gConexion.conexion())
            {
                conn.Open();
                using (OdbcCommand cmdModificar = new OdbcCommand(
                    "UPDATE tbl_proyecto SET Fk_Id_Proyecto_Estado = ?, Cmp_Nombre_Proyecto = ?, " +
                    "Cmp_Descripcion_Proyecto = ?, Cmp_Fecha_Inicio_Proyecto = ?, " +
                    "Cmp_Fecha_Fin_Proyecto = ?, Cmp_Objetivo_Proyecto = ? " +
                    "WHERE Pk_Id_Proyecto = ?", conn))
                {
                    cmdModificar.Parameters.Add("@estado", OdbcType.Int).Value = iIdEstado;
                    cmdModificar.Parameters.Add("@nombre", OdbcType.VarChar, 100).Value = sNombre;
                    cmdModificar.Parameters.Add("@descripcion", OdbcType.Text).Value = fun_texto_o_nulo(sDescripcion);
                    cmdModificar.Parameters.Add("@inicio", OdbcType.Date).Value = fun_fecha_o_nulo(dInicio);
                    cmdModificar.Parameters.Add("@fin", OdbcType.Date).Value = fun_fecha_o_nulo(dFin);
                    cmdModificar.Parameters.Add("@objetivo", OdbcType.Text).Value = fun_texto_o_nulo(sObjetivo);
                    cmdModificar.Parameters.Add("@id", OdbcType.Int).Value = iIdProyecto; // el id va al final por el WHERE
                    return cmdModificar.ExecuteNonQuery();
                }
            }
        }

        public int fun_eliminar_proyecto(int iIdProyecto)
        {
            using (OdbcConnection conn = gConexion.conexion())
            {
                conn.Open();
                using (OdbcCommand cmdEliminar = new OdbcCommand(
                    "DELETE FROM tbl_proyecto WHERE Pk_Id_Proyecto = ?", conn))
                {
                    cmdEliminar.Parameters.Add("@id", OdbcType.Int).Value = iIdProyecto;
                    return cmdEliminar.ExecuteNonQuery();
                }
            }
        }

        // Los campos de texto aceptan nulo en la tabla
        private object fun_texto_o_nulo(string sTexto)
        {
            return string.IsNullOrWhiteSpace(sTexto) ? (object)DBNull.Value : sTexto;
        }

        // Las fechas son opcionales en la tabla
        private object fun_fecha_o_nulo(DateTime? dFecha)
        {
            return dFecha.HasValue ? (object)dFecha.Value.Date : DBNull.Value;
        }
    }
}
//Fin de código de Paula Daniela Leonardo Paredes carné 0901-22-9580 en la fecha de: "20/10/2026"
