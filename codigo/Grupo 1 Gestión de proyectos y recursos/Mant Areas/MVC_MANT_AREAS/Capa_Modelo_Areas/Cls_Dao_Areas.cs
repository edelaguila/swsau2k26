using System;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Areas
{
    public class Cls_Dao_Areas
    {
        private string conexion = "DSN=bd_auditoria;";

        public DataTable funcObtenerAreas()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Pk_Id_Area, Fk_Id_Proyecto, Cmp_Nombre_Area, Cmp_Descripcion_Area, Cmp_Estado_Area FROM tbl_areas;";
            try
            {
                using (OdbcConnection conn = new OdbcConnection(conexion))
                {
                    OdbcDataAdapter da = new OdbcDataAdapter(query, conn);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener áreas: " + ex.Message);
            }
            return dt;
        }

        public DataTable funcObtenerProyectos()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Pk_Id_Proyecto, Cmp_Nombre_Proyecto FROM tbl_proyecto;";
            try
            {
                using (OdbcConnection conn = new OdbcConnection(conexion))
                {
                    OdbcDataAdapter da = new OdbcDataAdapter(query, conn);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener proyectos: " + ex.Message);
            }
            return dt;
        }

        public bool funcGuardarArea(Cls_Area area)
        {
            string query = "INSERT INTO tbl_areas (Pk_Id_Area, Fk_Id_Proyecto, Cmp_Nombre_Area, Cmp_Descripcion_Area, Cmp_Estado_Area) VALUES (?, ?, ?, ?, ?);";
            try
            {
                using (OdbcConnection conn = new OdbcConnection(conexion))
                {
                    conn.Open();
                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                        cmd.Parameters.Add("Pk_Id_Area", OdbcType.Int).Value = area.Pk_Id_Area;
                        cmd.Parameters.Add("Fk_Id_Proyecto", OdbcType.Int).Value = area.Fk_Id_Proyecto;
                        cmd.Parameters.Add("Cmp_Nombre_Area", OdbcType.VarChar).Value = area.Cmp_Nombre_Area;
                        cmd.Parameters.Add("Cmp_Descripcion_Area", OdbcType.Text).Value = area.Cmp_Descripcion_Area;
                        cmd.Parameters.Add("Cmp_Estado_Area", OdbcType.VarChar).Value = area.Cmp_Estado_Area;
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar área: " + ex.Message);
                return false;
            }
        }

        public bool funcActualizarArea(Cls_Area area)
        {
            string query = "UPDATE tbl_areas SET Fk_Id_Proyecto = ?, Cmp_Nombre_Area = ?, Cmp_Descripcion_Area = ?, Cmp_Estado_Area = ? WHERE Pk_Id_Area = ?;";
            try
            {
                using (OdbcConnection conn = new OdbcConnection(conexion))
                {
                    conn.Open();
                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                        cmd.Parameters.Add("Fk_Id_Proyecto", OdbcType.Int).Value = area.Fk_Id_Proyecto;
                        cmd.Parameters.Add("Cmp_Nombre_Area", OdbcType.VarChar).Value = area.Cmp_Nombre_Area;
                        cmd.Parameters.Add("Cmp_Descripcion_Area", OdbcType.Text).Value = area.Cmp_Descripcion_Area;
                        cmd.Parameters.Add("Cmp_Estado_Area", OdbcType.VarChar).Value = area.Cmp_Estado_Area;
                        cmd.Parameters.Add("Pk_Id_Area", OdbcType.Int).Value = area.Pk_Id_Area;
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar área: " + ex.Message);
                return false;
            }
        }

        public bool funcBorrarArea(int idArea)
        {
            string query = "DELETE FROM tbl_areas WHERE Pk_Id_Area = ?;";
            try
            {
                using (OdbcConnection conn = new OdbcConnection(conexion))
                {
                    conn.Open();
                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                        cmd.Parameters.Add("Pk_Id_Area", OdbcType.Int).Value = idArea;
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al borrar área: " + ex.Message);
                return false;
            }
        }
    }
}