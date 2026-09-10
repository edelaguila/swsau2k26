using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Componente_Consultas
{
    class Cls_Conexion
    {
        public OdbcConnection conexion()
        {
            //creacion de la conexion via ODBC
            OdbcConnection con = new OdbcConnection("Dsn=bd_SIG");
            try
            {
                con.Open();
            }
            catch (OdbcException)
            {
                Console.WriteLine("No Conectó");
            }
            return con;
        }

        //metodo para cerrar la conexion
        public void desconexion(OdbcConnection con)
        {
            try
            {
                con.Close();
            }
            catch (OdbcException)
            {
                Console.WriteLine("No Conectó");
            }
        }

    }
}
