using System;
using System.Data;
using System.Data.Odbc;

//Inicio de código de Nelson Godínez carné 0901-22-3550 en la fecha de: "08/10/2026"
namespace Capa_Modelo_Recursos
{
    public class Cls_Conexion_Recursos
    {
        private readonly string gConexionOdbc = "Dsn=bd_auditoria"; // DSN de ODBC

        // Devuelve una conexión cerrada; el DAO la abre y la cierra con "using"
        public OdbcConnection conexion()
        {
            return new OdbcConnection(gConexionOdbc);
        }

        // Cierra la conexión si está abierta
        public void desconexion(OdbcConnection conn)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
//Fin de código de Nelson Godínez carné 0901-22-3550 en la fecha de: "08/10/2026"