//Inicio de código de "Pablo José Quiroa Martínez" con carné: "0901-22-2929" en la fecha de: "20/10/2026"
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Cronograma
{
    // Clase encargada de crear y cerrar la conexion ODBC a la base de datos
    public class Cls_Conexion
    {
        private readonly string sConexionOdbc = "Dsn=bd_auditoria"; 

        
        public OdbcConnection fun_conexion()
        {
            return new OdbcConnection(sConexionOdbc);
        }

        // Cierra la conexion si esta abierta
        public void pro_desconexion(OdbcConnection conn)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
//Fin del código de "Pablo José Quiroa Martínez" con carné: "0901-22-2929" en la fecha de: "20/10/2026"