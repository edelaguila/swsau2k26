using System;
using System.Data.Odbc;

namespace Capa_Modelo_PY
{
    // Clase que administra la conexión ODBC a la base de datos
    internal class Cls_Conexion_PY
    {
        // Método de creación de la conexión vía ODBC
        public OdbcConnection conexion()
        {
            OdbcConnection conn = new OdbcConnection("Dsn=bd_auditoria");
            try
            {
                conn.Open();
            }
            catch (OdbcException ex)
            {
                throw new Exception("No se pudo conectar a la base de datos (DSN bd_auditoria): " + ex.Message);
            }
            return conn;
        }

        // Método para cerrar la conexión
        public void desconexion(OdbcConnection conn)
        {
            try
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
            catch (OdbcException)
            {
                Console.WriteLine("No se pudo cerrar la conexión");
            }
        }
    }
}