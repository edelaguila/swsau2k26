// Arón Esquit 0901-22-13036 29/10/2026
using System;
using System.Collections.Generic;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
    public class Cls_AuditorControlador
    {
        private Cls_AuditorDAO gDaoAuditor = new Cls_AuditorDAO();

        public List<(int Id, string Display)> fun_ObtenerAuditoresParaComboBox()
        {
            List<(int Id, string Display)> gLstAuditores =
                new List<(int Id, string Display)>();

            var gDatosAuditores = gDaoAuditor.fun_ObtenerAuditores();

            foreach (var gAuditor in gDatosAuditores)
            {
                gLstAuditores.Add((
                    gAuditor.Id,
                    gAuditor.Nombre
                ));
            }

            return gLstAuditores;
        }
    }
}
