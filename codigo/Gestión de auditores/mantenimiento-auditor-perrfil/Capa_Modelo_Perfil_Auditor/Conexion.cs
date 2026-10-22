using System;
using System.Data.Odbc;

namespace Capa_Modelo_Perfil_Auditor
{
    internal class Conexion
    {
        private readonly string cadenaConexion = "Dsn=bd_auditoria;";

        public OdbcConnection AbrirConexion()
        {
            OdbcConnection conexion = new OdbcConnection(cadenaConexion);

            try
            {
                conexion.Open();
                Console.WriteLine("Conexión exitosa a la base de datos.");
                return conexion;
            }
            catch (OdbcException ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                throw;
            }
        }

        public void CerrarConexion(OdbcConnection conexion)
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}