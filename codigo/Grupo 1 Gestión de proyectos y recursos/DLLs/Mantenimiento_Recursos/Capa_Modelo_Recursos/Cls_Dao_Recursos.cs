using System;
using System.Data;
using System.Data.Odbc;

//Inicio de código de Nelson Godínez carné 0901-22-3550 en la fecha de: "08/10/2026"
namespace Capa_Modelo_Recursos
{
    public class Cls_Dao_Recursos
    {
        private readonly Cls_Conexion_Recursos gConexion = new Cls_Conexion_Recursos();
        public DataTable fun_listar_recursos()
        {
            string sSql =
                "SELECT r.Pk_Id_Recurso, r.Fk_Id_Proyecto, p.Cmp_Nombre_Proyecto, " +
                "r.Cmp_Nombre_Recurso, r.Cmp_Tipo_Recurso, r.Cmp_Cantidad_Recurso, " +
                "r.Cmp_Fecha_Registro_Recurso " +
                "FROM tbl_recursos r " +
                "INNER JOIN tbl_proyecto p ON p.Pk_Id_Proyecto = r.Fk_Id_Proyecto " +
                "ORDER BY r.Pk_Id_Recurso";

            DataTable dtsRecursos = new DataTable();
            using (OdbcConnection conn = gConexion.conexion())
            {
                conn.Open();
                using (OdbcDataAdapter adaptador = new OdbcDataAdapter(sSql, conn))
                {
                    adaptador.Fill(dtsRecursos);
                }
            }
            return dtsRecursos;
        }
        public DataTable fun_listar_proyectos()
        {
            string sSql =
                "SELECT Pk_Id_Proyecto, Cmp_Nombre_Proyecto " +
                "FROM tbl_proyecto ORDER BY Cmp_Nombre_Proyecto";

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
        public int fun_insertar_recurso(int iIdProyecto, string sNombre, string sTipo, int iCantidad)
        {
            using (OdbcConnection conn = gConexion.conexion())
            {
                conn.Open();
                using (OdbcTransaction trx = conn.BeginTransaction())
                {
                    int iNuevoId;
                    using (OdbcCommand cmdId = new OdbcCommand(
                        "SELECT COALESCE(MAX(Pk_Id_Recurso), 0) + 1 FROM tbl_recursos FOR UPDATE", conn, trx))
                    {
                        iNuevoId = Convert.ToInt32(cmdId.ExecuteScalar());
                    }

                    using (OdbcCommand cmdInsertar = new OdbcCommand(
                        "INSERT INTO tbl_recursos " +
                        "(Pk_Id_Recurso, Fk_Id_Proyecto, Cmp_Nombre_Recurso, Cmp_Tipo_Recurso, Cmp_Cantidad_Recurso) " +
                        "VALUES (?, ?, ?, ?, ?)", conn, trx))
                    {
                        cmdInsertar.Parameters.AddWithValue("@id", iNuevoId);
                        cmdInsertar.Parameters.AddWithValue("@proyecto", iIdProyecto);
                        cmdInsertar.Parameters.AddWithValue("@nombre", sNombre);
                        cmdInsertar.Parameters.AddWithValue("@tipo", sTipo);
                        cmdInsertar.Parameters.AddWithValue("@cantidad", iCantidad);
                        cmdInsertar.ExecuteNonQuery();
                    }

                    trx.Commit();
                    return iNuevoId;
                }
            }
        }
        public int fun_modificar_recurso(int iIdRecurso, int iIdProyecto, string sNombre, string sTipo, int iCantidad)
        {
            using (OdbcConnection conn = gConexion.conexion())
            {
                conn.Open();
                using (OdbcCommand cmdModificar = new OdbcCommand(
                    "UPDATE tbl_recursos SET Fk_Id_Proyecto = ?, Cmp_Nombre_Recurso = ?, " +
                    "Cmp_Tipo_Recurso = ?, Cmp_Cantidad_Recurso = ? " +
                    "WHERE Pk_Id_Recurso = ?", conn))
                {
                    cmdModificar.Parameters.AddWithValue("@proyecto", iIdProyecto);
                    cmdModificar.Parameters.AddWithValue("@nombre", sNombre);
                    cmdModificar.Parameters.AddWithValue("@tipo", sTipo);
                    cmdModificar.Parameters.AddWithValue("@cantidad", iCantidad);
                    cmdModificar.Parameters.AddWithValue("@id", iIdRecurso);
                    return cmdModificar.ExecuteNonQuery();
                }
            }
        }
        public int fun_eliminar_recurso(int iIdRecurso)
        {
            using (OdbcConnection conn = gConexion.conexion())
            {
                conn.Open();
                using (OdbcCommand cmdEliminar = new OdbcCommand(
                    "DELETE FROM tbl_recursos WHERE Pk_Id_Recurso = ?", conn))
                {
                    cmdEliminar.Parameters.AddWithValue("@id", iIdRecurso);
                    return cmdEliminar.ExecuteNonQuery();
                }
            }
        }
    }
}
//Fi de código de Nelson Godínez carné 0901-22-3550 en la fecha de: "08/10/2026"