// Codigo empezado por: Maria Morales 0901-22-1226 el día 19/10/2026
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Actividad
{
    public class Cls_Conexion_Actividad_Rubrica
    {
        private readonly string ConexionODBC = "Dsn=bd_auditoria"; // DSN de odbc

        //retorna conexion cerrada para que el DAO la abra y cierre cuando sea necesario
        public OdbcConnection conexion()
        {
            return new OdbcConnection(ConexionODBC); // crea una nueva conexión
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
// Codigo terminado por: Maria Morales 0901-22-1226 el día 19/10/2026