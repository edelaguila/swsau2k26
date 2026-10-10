// Empieza codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace Capa_Modelo_Rubrica
{
    public class Cls_Conexion_Rubrica
    {
        private readonly string ConexionODBC = "Dsn=bd_SIG"; // DSN de odbc

        public OdbcConnection conexion()
        {
            return new OdbcConnection(ConexionODBC); 
        }

        // Cierra la conexión si está abierta
        public void desconexion(OdbcConnection conn)
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
// Termina codigo hecho por Maria Morales 0901-22-1226 el dia 07/10/2026