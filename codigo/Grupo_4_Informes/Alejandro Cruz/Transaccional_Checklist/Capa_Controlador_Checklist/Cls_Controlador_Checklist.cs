using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Checklist;

namespace Capa_Controlador_Checklist
{
    //Datos que se envían a la Vista
    public class Cls_Checklist_DTO
    {
        //Para mostrar rubricas
        public int Pk_Id_Rubrica { get; set; }
        public string Cmp_Nombre_Rubrica { get; set; }
        public string TextoRubrica
        {
            get{return Pk_Id_Rubrica + " - " + Cmp_Nombre_Rubrica;}
        }
        //Para mostrar actividades
        public int Fk_id_actividad_rubrica { get; set; }
        public string Cmp_Nombre_Actividad_Proyecto { get; set; }

        //Para insertar
        public int Fk_id_informe { get; set; }
        public bool Entregado { get; set; }

        //Para mostrar checklist y su estado
        public int Pk_id_checklist { get; set; }
        public string EstadoTexto
        {
            get { return Entregado ? "Entregado" : "No entregado"; }
        }
    }

    //Datos de informes para los ComboBox (agregado; clase aparte para no agregar columnas a los DataGridView)
    public class Cls_Informe_DTO
    {
        public int Pk_Id_Informe { get; set; }
        public string Cmp_Titulo_Informe { get; set; }
        public string TextoInforme
        {
            get { return Pk_Id_Informe + " - " + Cmp_Titulo_Informe; }
        }
    }

    public class Cls_Controlador_Checklist
    {
        //Obtener todos los informes para los ComboBox (agregado)
        public List<Cls_Informe_DTO> ObtenerInformes()
        {
            Cls_Modelo_Checklist modelo = new Cls_Modelo_Checklist();
            List<Cls_Informe_DTO> lista = new List<Cls_Informe_DTO>();

            foreach (Cls_Modelo_Checklist informe in modelo.ListarInformes())
            {
                lista.Add(new Cls_Informe_DTO
                {
                    Pk_Id_Informe = informe.Pk_Id_Informe,
                    Cmp_Titulo_Informe = informe.Cmp_Titulo_Informe
                });
            }
            return lista;
        }

        //Obtener todas las rúbricas para el ComboBox
        public List<Cls_Checklist_DTO> ObtenerRubricas()
        {
            Cls_Modelo_Checklist modelo = new Cls_Modelo_Checklist();
            List<Cls_Modelo_Checklist> rubricas = modelo.ListarRubricas();
            List<Cls_Checklist_DTO> lista = new List<Cls_Checklist_DTO>();

            foreach (Cls_Modelo_Checklist rubrica in rubricas)
            {
                lista.Add(new Cls_Checklist_DTO
                {
                    Pk_Id_Rubrica = rubrica.Pk_Id_Rubrica,
                    Cmp_Nombre_Rubrica = rubrica.Cmp_Nombre_Rubrica
                });
            }
            return lista;
        }

        //Listar actividades pendientes según la rúbrica
        public List<Cls_Checklist_DTO> Listar(int idRubrica)
        {
            Cls_Modelo_Checklist modelo = new Cls_Modelo_Checklist();
            List<Cls_Modelo_Checklist> actividades = modelo.Mostar(idRubrica);
            List<Cls_Checklist_DTO> lista = new List<Cls_Checklist_DTO>();

            foreach (Cls_Modelo_Checklist actividad in actividades)
            {
                lista.Add(new Cls_Checklist_DTO
                {
                    Fk_id_actividad_rubrica = actividad.Fk_id_actividad_rubrica,

                    Cmp_Nombre_Actividad_Proyecto = actividad.Cmp_Nombre_Actividad_Proyecto
                });
            }
            return lista;
        }

        //Insertar actividad en el checklist
        public bool Insertar(Cls_Checklist_DTO datos)
        {
            Cls_Modelo_Checklist modelo = new Cls_Modelo_Checklist();

            modelo.Fk_id_informe = datos.Fk_id_informe;
            modelo.Fk_id_actividad_rubrica = datos.Fk_id_actividad_rubrica;
            modelo.Entregado = datos.Entregado;

            return modelo.Insertar(modelo);
        }

        //Listar los checklist de un informe
        public List<Cls_Checklist_DTO> ListarCKL(int idInforme)
        {
            Cls_Modelo_Checklist modelo = new Cls_Modelo_Checklist();

            List<Cls_Modelo_Checklist> checklist = modelo.MostarCheklist(idInforme);

            List<Cls_Checklist_DTO> lista = new List<Cls_Checklist_DTO>();

            foreach (Cls_Modelo_Checklist actividad in checklist)
            {
                lista.Add(new Cls_Checklist_DTO
                {
                    Pk_id_checklist = actividad.Pk_id_checklist,

                    Cmp_Nombre_Actividad_Proyecto = actividad.Cmp_Nombre_Actividad_Proyecto,

                    Entregado = actividad.Entregado
                });
            }
            return lista;
        }

        //Editar un checklist 
        public bool Editar(Cls_Checklist_DTO datos)
        {
            Cls_Modelo_Checklist modelo = new Cls_Modelo_Checklist();

            return modelo.Editar(new Cls_Modelo_Checklist
            {
                Pk_id_checklist = datos.Pk_id_checklist,
                Entregado = datos.Entregado
            });
        }

        //Eliminar un checklist
        public bool Eliminar(Cls_Checklist_DTO datos) {
            Cls_Modelo_Checklist modelo = new Cls_Modelo_Checklist();
            return modelo.Eliminar(datos.Pk_id_checklist);
        }
    }
}
