using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using Capa_Modelo_Seguridad;

namespace Capa_Modelo_Checklist
{
    public class Cls_Modelo_Checklist
    {
        //Variables para buscar y mostrar rubricas
        public int Pk_Id_Rubrica { get; set; }
        public string Cmp_Nombre_Rubrica { get; set; }

        //Variables para mostrar actividades 
        public string Cmp_Nombre_Actividad_Proyecto { get; set; }

        //Variables para insertar
        public int Fk_id_informe { get; set; }
        public int Fk_id_actividad_rubrica { get; set; }
        public bool Entregado { get; set; }
        
        //Variables para editar 
        public int Pk_id_checklist { get; set; }

        //Variables para mostrar estado de checklist
        public string EstadoTexto
        {
            get { return Entregado ? "Entregado" : "No entregado"; }
        }

        //Llamar a la conexion
        private readonly Cls_Conexion conexion = new Cls_Conexion();

        //Mostar todas las rubricas disponibles
        public List<Cls_Modelo_Checklist> ListarRubricas()
        {
            List<Cls_Modelo_Checklist> lista = new List<Cls_Modelo_Checklist>();

            using (OdbcConnection cn = conexion.AbrirConexion())
            {
                string sql = @"
                SELECT Pk_Id_Rubrica, Cmp_Nombre_Rubrica
                FROM tbl_rubrica
                ORDER BY Pk_Id_Rubrica";

                using (OdbcCommand cmd = new OdbcCommand(sql, cn))
                using (OdbcDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Cls_Modelo_Checklist
                        {
                            Pk_Id_Rubrica = Convert.ToInt32(dr["Pk_Id_Rubrica"]),
                            Cmp_Nombre_Rubrica = dr["Cmp_Nombre_Rubrica"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        //Mostrar actividades pendientes según la rúbrica
        public List<Cls_Modelo_Checklist> Mostar(int idRubrica)
        {
            List<Cls_Modelo_Checklist> lista = new List<Cls_Modelo_Checklist>();

            using (OdbcConnection cn = conexion.AbrirConexion())
            {
                string sql = @"
                    SELECT
                        ar.Pk_Id_Actividad_Rubrica,
                        ap.Cmp_Nombre_Actividad_Proyecto
                    FROM tbl_actividades_proyecto ap
                    INNER JOIN tbl_actividad_rubrica ar
                        ON ap.Pk_Id_Actividad_Proyecto =
                           ar.Fk_Id_Actividad_Proyecto
                    LEFT JOIN tbl_checklist c
                        ON ar.Pk_Id_Actividad_Rubrica =
                           c.Fk_id_actividad_rubrica
                    WHERE ar.Fk_Id_Rubrica = ?
                      AND c.Fk_id_actividad_rubrica IS NULL";

                using (OdbcCommand cmd = new OdbcCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idRubrica", idRubrica);

                    using (OdbcDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cls_Modelo_Checklist
                            {
                                Fk_id_actividad_rubrica = Convert.ToInt32(dr["Pk_Id_Actividad_Rubrica"]),

                                Cmp_Nombre_Actividad_Proyecto = dr["Cmp_Nombre_Actividad_Proyecto"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // Insertar una actividad en el checklist
        public bool Insertar(Cls_Modelo_Checklist checklist)
        {
            using (OdbcConnection cn = conexion.AbrirConexion())
            {
                string sql = @"
                INSERT INTO tbl_checklist
                (
                    Fk_id_informe,
                    Fk_id_actividad_rubrica,
                    Entregado
                )
                VALUES (?, ?, ?)";

                using (OdbcCommand cmd = new OdbcCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idInforme", checklist.Fk_id_informe);

                    cmd.Parameters.AddWithValue("@idActividad", checklist.Fk_id_actividad_rubrica);

                    cmd.Parameters.AddWithValue("@entregado", checklist.Entregado ? 1 : 0);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        //Mostrar todos los checklist de un informe
        public List<Cls_Modelo_Checklist> MostarCheklist(int idInforme)
        {
            List<Cls_Modelo_Checklist> lista = new List<Cls_Modelo_Checklist>();

            using (OdbcConnection cn = conexion.AbrirConexion())
            {
                string sql = @"
                    SELECT 
                        c.Pk_id_checklist, 
                        ap.Cmp_Nombre_Actividad_Proyecto AS Nombre_Actividad,
                        c.entregado
                    FROM 
                        tbl_checklist c
                    INNER JOIN 
                        tbl_actividad_rubrica ar ON c.Fk_id_actividad_rubrica = ar.Pk_Id_Actividad_Rubrica
                    INNER JOIN 
                        tbl_actividades_proyecto ap ON ar.Fk_Id_Actividad_Proyecto = ap.Pk_Id_Actividad_Proyecto
                    WHERE 
                        c.Fk_id_informe = ?;";

                using (OdbcCommand cmd = new OdbcCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idInforme", idInforme);

                    using (OdbcDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cls_Modelo_Checklist
                            {
                                Pk_id_checklist = Convert.ToInt32(dr["Pk_id_checklist"]),

                                Cmp_Nombre_Actividad_Proyecto = dr["Nombre_Actividad"].ToString(),

                                Entregado = Convert.ToBoolean(dr["entregado"])
                            }); 
                        }
                    }
                }
            }

            return lista;
        }

        //Editar un checklist 
        public bool Editar(Cls_Modelo_Checklist checklist)
        {
            try
            {
                using (OdbcConnection conn = new OdbcConnection(conexion.ObtenerCadenaConexion()))
                {
                    conn.Open();

                    string sql = @"UPDATE tbl_checklist
                           SET Entregado = ?
                           WHERE Pk_id_checklist = ?";

                    using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Entregado", checklist.Entregado ? 1 : 0);
                        cmd.Parameters.AddWithValue("@IdChecklist", checklist.Pk_id_checklist);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el checklist: " + ex.Message);
            }
        }

        //Eliminar un checklist
        public bool Eliminar(int idChecklist)
        {
            try
            {
                using (OdbcConnection conn = new OdbcConnection(conexion.ObtenerCadenaConexion()))
                {
                    conn.Open();

                    string sql = @"DELETE FROM tbl_checklist
                           WHERE Pk_id_checklist = ?";

                    using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdChecklist", idChecklist);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el checklist: " + ex.Message);
            }
        }
    }
}
