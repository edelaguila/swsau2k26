using System;

//Erneto David Samayoa Jocol 0901-22-3415
namespace Capa_Modelo_Auditor
{
    public class Cls_auditor
    {
        public int Pk_Id_Auditor { get; set; }
        public int Fk_Id_Estado_Auditor { get; set; }
        public string Cmp_Nombre_Auditor { get; set; }
        public string Cmp_Telefono_Auditor { get; set; }
        public string Cmp_Email_Auditor { get; set; }
        public string Cmp_Carnet_Auditor { get; set; }

        public Cls_auditor() { }

        public Cls_auditor(int iPk_Id_Auditor, int iFk_Id_Estado_Auditor,
            string sCmp_Nombre_Auditor, string sCmp_Telefono_Auditor,
            string sCmp_Email_Auditor, string sCmp_Carnet_Auditor)
        {
            Pk_Id_Auditor = iPk_Id_Auditor;
            Fk_Id_Estado_Auditor = iFk_Id_Estado_Auditor;
            Cmp_Nombre_Auditor = sCmp_Nombre_Auditor;
            Cmp_Telefono_Auditor = sCmp_Telefono_Auditor;
            Cmp_Email_Auditor = sCmp_Email_Auditor;
            Cmp_Carnet_Auditor = sCmp_Carnet_Auditor;
        }
    }
    //Erneto David Samayoa Jocol 0901-22-3415 17/10/2026
}
