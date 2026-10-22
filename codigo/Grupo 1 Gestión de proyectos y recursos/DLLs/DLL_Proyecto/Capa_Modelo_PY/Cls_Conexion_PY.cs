using System;
using System.Data;
using System.Data.Odbc;

//Inicio de código de Paula Daniela Leonardo Paredes carné 0901-22-9580 en la fecha de: "20/10/2026"
namespace Capa_Modelo_PY
{
    public class Cls_Conexion_PY
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
//Fin de código de Paula Daniela Leonardo Paredes carné 0901-22-9580 en la fecha de: "20/10/2026"
