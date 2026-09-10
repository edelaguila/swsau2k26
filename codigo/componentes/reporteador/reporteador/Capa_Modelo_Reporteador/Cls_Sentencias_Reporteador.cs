using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //Paula Leonardo
using System.Data.Odbc; //Paula Leonardo

namespace Capa_Modelo_Reporteador
{
    //Clase Publica
    public class Cls_Sentencias_Reporteador
    {
        // ==========================
        // Métodos de creación
        // ==========================

        //Inicio de código de: Bárbara Saldaña 
        public void InsertarReporte(string sTitulo, string sRuta, DateTime dFecha)
        {
            Cls_Conexion_Reporteador cn = new Cls_Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = "INSERT INTO Tbl_Reportes (Cmp_Titulo_Reporte, Cmp_Ruta_Reporte, Cmp_Fecha_Reporte) VALUES (?,?,?)";
 
                using (OdbcCommand cmd = new OdbcCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("", sTitulo);
                    cmd.Parameters.AddWithValue("", sRuta);
                    cmd.Parameters.AddWithValue("", dFecha);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool ExisteTitulo(string sTitulo)
        {
            Cls_Conexion_Reporteador cn = new Cls_Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                con.Open();
                string sql = "SELECT 1 FROM Tbl_Reportes WHERE Cmp_Titulo_Reporte = ? LIMIT 1";
                using (OdbcCommand cmd = new OdbcCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("", sTitulo);
                    object result = cmd.ExecuteScalar();
                    return result != null;
                }
            }
        }
        //Fin código bárbara saldaña 0901-22-9136 --> 26/09/2025

        // ==========================
        // Métodos de modificación
        // ==========================

        // Inicio de código de: María Morales con carné: 0901-22-1226 en la fecha de: 11/09/2025
        public void ModificarRuta(int iIdReporte, string sNuevaRuta)
        {
            Cls_Conexion_Reporteador cn = new Cls_Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = "UPDATE Tbl_Reportes SET Cmp_Ruta_Reporte=? WHERE Pk_Id_Reporte=?";
                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("ruta", sNuevaRuta);
                cmd.Parameters.AddWithValue("id", iIdReporte);
                cmd.ExecuteNonQuery();
            }
        }
        // Fin de código de: María Morales con carné: 0901-22-1226 en la fecha de: 11/09/2025

        // Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha de: 23/09/2025
        public void ModificarTitulo(int iIdReporte, string sTitulo)
        {
            Cls_Conexion_Reporteador cn = new Cls_Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sqlTitulo = "UPDATE Tbl_Reportes SET Cmp_Titulo_Reporte=? WHERE Pk_Id_Reporte=?";
                OdbcCommand cmdActualizar = new OdbcCommand(sqlTitulo, con);
                cmdActualizar.Parameters.AddWithValue("", sTitulo);
                cmdActualizar.Parameters.AddWithValue("", iIdReporte);
                cmdActualizar.ExecuteNonQuery();
            }
        }
        // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha de: 23/09/2025

        // ==========================
        // Métodos de eliminación
        // ==========================

        // Inicio de código de: Leticia Sontay con carné: 9959-21-9664 en la fecha de: 12/09/2025
        public void EliminarReporte(int iIdReporte)
        {
            Cls_Conexion_Reporteador cn = new Cls_Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {

                string actualizarAplicacion = @"UPDATE Tbl_Aplicacion
                                               SET Fk_Id_Reporte_Aplicacion = NULL
                                               WHERE Fk_Id_Reporte_Aplicacion = ?";
                using (OdbcCommand cmd = new OdbcCommand(actualizarAplicacion, con))
                {
                    cmd.Parameters.AddWithValue("@id", iIdReporte);
                    cmd.ExecuteNonQuery();
                }
                string eliminarReporte = "DELETE FROM Tbl_Reportes WHERE Pk_Id_Reporte = ?";

                using (OdbcCommand cmd = new OdbcCommand(eliminarReporte, con))
                {
                    cmd.Parameters.AddWithValue("@id", iIdReporte);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Fin de código de: Leticia Sontay con carné: 9959-21-9664 en la fecha de: 12/09/2025

        // ==========================
        // Métodos de consulta
        // ==========================

        // Inicio de código de: Rocio Lopez con carné: 9959-23-740 en la fecha de: 11/09/2025
        public DataTable ObtenerReporte()
        {
            DataTable dtReportes = new DataTable();

            try
            {
                Cls_Conexion_Reporteador cn = new Cls_Conexion_Reporteador();
                using (OdbcConnection con = cn.conexion())
                {
                    string sql = "SELECT Pk_Id_Reporte, Cmp_Titulo_Reporte, Cmp_Ruta_Reporte, Cmp_Fecha_Reporte FROM Tbl_Reportes";
                    OdbcDataAdapter da = new OdbcDataAdapter(sql, con);
                    da.Fill(dtReportes);
                }
            }
            catch (Exception ex)
            {
                // Aquí mostrara mensaje de error 
                Console.WriteLine("Error al obtener reportes: " + ex.Message);
            }

            return dtReportes;
        }
        // Fin de código de: Rocio Lopez con carné: 9959-23-740 en la fecha de: 11/09/2025

        // ==========================
        // Métodos de verificación
        // ==========================

        // inicio codigo de: Sergio Izeppi 0901-22-8946 en la fecha de: 16/09/2025
        public int verificarExistencia(string sTitulo)
        {
            Cls_Conexion_Reporteador cn = new Cls_Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = "SELECT 1 FROM Tbl_Reportes WHERE Cmp_Titulo_Reporte = ? LIMIT 1";
                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("Cmp_Titulo_Reporte", sTitulo);

                object result = cmd.ExecuteScalar();
                return result != null ? 1 : 0;
            }
        }
        //fin de codigo de Sergio Izeppi
        // ==========================
        // APLICACIÓN

        // Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha de: 24/09/2025
        // Inicio de código de: Leticia Sontay con carné: 9959-21-9664 en la fecha de: 24/09/2025

        public string consultaReporteAplicacion(int iIdAplicacion)
        {
            Cls_Conexion_Reporteador cn = new Cls_Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = $@"SELECT R.Cmp_Ruta_Reporte
                                FROM Tbl_Aplicacion A
                                JOIN Tbl_Reportes R ON A.Fk_Id_Reporte_Aplicacion = R.Pk_Id_Reporte
                                WHERE A.Pk_Id_Aplicacion = ?";
                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("idAplicacion", iIdAplicacion);
                object resultadoConsulta = cmd.ExecuteScalar();
                if (resultadoConsulta != DBNull.Value && resultadoConsulta != null)
                {
                    return resultadoConsulta.ToString();
                }
                else
                {
                    return null;
                }
            }
        }
        // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha de: 24/09/2025
        // Fin de código de: Leticia Sontay con carné: 9959-21-9664  en la fecha de: 24/09/2025
        // ==========================
    }
}




