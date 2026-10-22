//Inicio del código de "Barbara Saldaña" con carné: "0901-22-9136" en la fecha de : "16/10/26"
using System;
using System.Data;
using System.Data.Odbc;
using Capa_Modelo_Seguridad;

namespace Capa_Modelo_ProAuditor
{

    public class Cls_Dao_ProyectoAuditor
    {
        private Cls_Conexion gConexion = new Cls_Conexion();

        private OdbcConnection fun_obtener_conexion()
        {
            return gConexion.AbrirConexion();
        }

        public DataTable fun_listar(string sFiltro)
        {
            DataTable Dts_Resultado = new DataTable();
            string sSql =
                "SELECT pa.Pk_Id_Proyecto_Auditor, pa.Fk_Id_Proyecto, p.Cmp_Nombre_Proyecto AS Proyecto, " +
                "pa.Fk_Id_Auditor, CONCAT(IFNULL(a.Cmp_Nombre_Auditor,'Sin nombre'),' (',a.Cmp_Carnet_Auditor,')') AS Auditor, " +
                "pa.Fk_Id_Perfil_Auditor, pf.Cmp_Nombre_Perfil_Auditor AS Perfil, " +
                "pa.Cmp_Fecha_Asignacion_Proyecto AS Fecha_Asignacion " +
                "FROM tbl_proyecto_auditor pa " +
                "INNER JOIN tbl_proyecto p ON p.Pk_Id_Proyecto = pa.Fk_Id_Proyecto " +
                "INNER JOIN tbl_auditor a ON a.Pk_Id_Auditor = pa.Fk_Id_Auditor " +
                "INNER JOIN tbl_perfil_auditor pf ON pf.Pk_Id_Perfil_Auditor = pa.Fk_Id_Perfil_Auditor " +
                "WHERE p.Cmp_Nombre_Proyecto LIKE ? OR a.Cmp_Nombre_Auditor LIKE ? " +
                "OR a.Cmp_Carnet_Auditor LIKE ? OR pf.Cmp_Nombre_Perfil_Auditor LIKE ? " +
                "ORDER BY pa.Pk_Id_Proyecto_Auditor DESC";

            string sLike = "%" + sFiltro + "%";
            using (OdbcConnection Conexion = fun_obtener_conexion())
            using (OdbcDataAdapter Adaptador = new OdbcDataAdapter(sSql, Conexion))
            {
                for (int iContador = 0; iContador < 4; iContador++)
                    Adaptador.SelectCommand.Parameters.AddWithValue("@Filtro" + iContador, sLike);
                Adaptador.Fill(Dts_Resultado);
            }
            return Dts_Resultado;
        }

        // Catálogo de proyectos
        public DataTable fun_combo_proyectos()
        {
            return fun_catalogo("SELECT Pk_Id_Proyecto AS Id, Cmp_Nombre_Proyecto AS Nombre " +
                                "FROM tbl_proyecto ORDER BY Cmp_Nombre_Proyecto");
        }

        // Catálogo de auditores 
        public DataTable fun_combo_auditores()
        {
            return fun_catalogo("SELECT Pk_Id_Auditor AS Id, " +
                                "CONCAT(IFNULL(Cmp_Nombre_Auditor,'Sin nombre'),' (',Cmp_Carnet_Auditor,')') AS Nombre " +
                                "FROM tbl_auditor WHERE Fk_Id_Estado_Auditor = 1 ORDER BY Cmp_Nombre_Auditor");
        }

        // Catálogo de perfiles 
        public DataTable fun_combo_perfiles()
        {
            return fun_catalogo("SELECT Pk_Id_Perfil_Auditor AS Id, Cmp_Nombre_Perfil_Auditor AS Nombre " +
                    "FROM tbl_perfil_auditor ORDER BY Cmp_Nombre_Perfil_Auditor");
        }

        private DataTable fun_catalogo(string sSql)
        {
            DataTable Dts_Catalogo = new DataTable();
            using (OdbcConnection Conexion = fun_obtener_conexion())
            using (OdbcDataAdapter Adaptador = new OdbcDataAdapter(sSql, Conexion))
            {
                Adaptador.Fill(Dts_Catalogo);
            }
            return Dts_Catalogo;
        }

        // Verifica si el auditor ya está asignado al proyecto 
        public bool fun_existe_asignacion(int iProyecto, int iAuditor, int iIdExcluir)
        {
            string sSql = "SELECT COUNT(*) FROM tbl_proyecto_auditor " +
                          "WHERE Fk_Id_Proyecto = ? AND Fk_Id_Auditor = ? AND Pk_Id_Proyecto_Auditor <> ?";
            using (OdbcConnection Conexion = fun_obtener_conexion())
            using (OdbcCommand Comando = new OdbcCommand(sSql, Conexion))
            {
                Comando.Parameters.AddWithValue("@Proyecto", iProyecto);
                Comando.Parameters.AddWithValue("@Auditor", iAuditor);
                Comando.Parameters.AddWithValue("@IdExcluir", iIdExcluir);
                return Convert.ToInt32(Comando.ExecuteScalar()) > 0;
            }
        }

        // Inserta una asignación
        public int fun_insertar(int iProyecto, int iAuditor, int iPerfil, DateTime dFecha)
        {
            string sSql = "INSERT INTO tbl_proyecto_auditor " +
                          "(Fk_Id_Proyecto, Fk_Id_Auditor, Fk_Id_Perfil_Auditor, Cmp_Fecha_Asignacion_Proyecto) " +
                          "VALUES (?, ?, ?, ?)";
            return fun_ejecutar(sSql, iProyecto, iAuditor, iPerfil, dFecha.Date);
        }

        // Modifica una asignación 
        public int fun_modificar(int iId, int iProyecto, int iAuditor, int iPerfil, DateTime dFecha)
        {
            string sSql = "UPDATE tbl_proyecto_auditor SET Fk_Id_Proyecto = ?, Fk_Id_Auditor = ?, " +
                          "Fk_Id_Perfil_Auditor = ?, Cmp_Fecha_Asignacion_Proyecto = ? " +
                          "WHERE Pk_Id_Proyecto_Auditor = ?";
            return fun_ejecutar(sSql, iProyecto, iAuditor, iPerfil, dFecha.Date, iId);
        }

        // Elimina una asignación
        public int fun_eliminar(int iId)
        {
            string sSql = "DELETE FROM tbl_proyecto_auditor WHERE Pk_Id_Proyecto_Auditor = ?";
            return fun_ejecutar(sSql, iId);
        }

        private int fun_ejecutar(string sSql, params object[] arrValores)
        {
            using (OdbcConnection Conexion = fun_obtener_conexion())
            using (OdbcCommand Comando = new OdbcCommand(sSql, Conexion))
            {
                for (int iContador = 0; iContador < arrValores.Length; iContador++)
                    Comando.Parameters.AddWithValue("@Valor" + iContador, arrValores[iContador]);
                return Comando.ExecuteNonQuery();
            }
        }
    }
}
//Fin del código de "Barbara Saldaña" con carné: "0901-22-9136" en la fecha de : "16/10/26"