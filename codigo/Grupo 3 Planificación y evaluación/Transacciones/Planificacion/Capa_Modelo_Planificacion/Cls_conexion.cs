
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Planificacion
{
    public class Cls_conexion
    {
        private readonly string ConexionODBC = "Dsn=bd_auditoria"; // 

        
        public OdbcConnection conexion()
        {
            return new OdbcConnection(ConexionODBC);
        }

        // Cierra la conexion si esta abierta
        public void desconexion(OdbcConnection conn)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
