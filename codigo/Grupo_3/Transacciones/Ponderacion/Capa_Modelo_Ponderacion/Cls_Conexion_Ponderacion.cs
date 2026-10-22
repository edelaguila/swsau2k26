// Juan Carlos Sandoval Quej, carné: 0901-22-4170 fecha de: "21/10/2026"
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Ponderacion
{
        // Aquí se abre la conexion a ODBC
    public class Cls_Conexion_Ponderacion
    {
        private readonly string gsConexionODBC = "Dsn=bd_auditoria"; 

        public OdbcConnection fun_conexion()
        {
            return new OdbcConnection(gsConexionODBC);
        }

        // Aquí se cierra la conexión si está abierta
        public void pro_desconexion(OdbcConnection conn)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
