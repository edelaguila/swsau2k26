using System;
using System.Data;
using System.Text.RegularExpressions;
using Capa_Modelo_Auditor;
// Erneto David Samayoa Jocol 0901-22-3415
namespace Capa_Controlador_Auditor
{
    public class Cls_auditor_controlador
    {
        private Cls_auditorDAO dao = new Cls_auditorDAO();

        public DataTable ObtenerAuditores()
        {
            return dao.ObtenerAuditores();
        }

        // Estados para el combobox
        public DataTable ObtenerEstados()
        {
            return dao.ObtenerEstados();
        }

        // Siguiente ID de auditor
        public int ObtenerSiguienteId()
        {
            return dao.ObtenerSiguienteId();
        }

        // Validaciones
        private (bool bValido, string sMensaje) ValidarAuditor(int iFkEstado,
            string sNombre, string sTelefono, string sEmail, string sCarnet)
        {
            // Carnet: obligatorio, maximo 15
            if (string.IsNullOrWhiteSpace(sCarnet))
                return (false, "El carnet es obligatorio.");

            if (sCarnet.Trim().Length > 15)
                return (false, "El carnet no puede tener más de 15 caracteres.");

            // Nombre: obligatorio, maximo 45
            if (string.IsNullOrWhiteSpace(sNombre))
                return (false, "El nombre es obligatorio.");

            if (sNombre.Trim().Length > 45)
                return (false, "El nombre no puede tener más de 45 caracteres.");

            // Nombre: solo letras (con tildes y ñ) y espacios
            if (!Regex.IsMatch(sNombre.Trim(), @"^[\p{L} ]+$"))
                return (false, "El nombre solo puede contener letras y espacios.");

            // Telefono: obligatorio, formato 0000-0000
            if (string.IsNullOrWhiteSpace(sTelefono))
                return (false, "El teléfono es obligatorio.");

            if (!Regex.IsMatch(sTelefono.Trim(), @"^\d{4}-\d{4}$"))
                return (false, "El teléfono debe tener el formato 0000-0000.");

            // Email: obligatorio, maximo 100, formato valido
            if (string.IsNullOrWhiteSpace(sEmail))
                return (false, "El email es obligatorio.");

            if (sEmail.Trim().Length > 100)
                return (false, "El email no puede tener más de 100 caracteres.");

            if (!Regex.IsMatch(sEmail.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return (false, "El email no tiene un formato válido (ejemplo1@gmail.com).");

            // Estado: obligatorio
            if (iFkEstado <= 0)
                return (false, "Debe seleccionar un estado.");

            return (true, "");
        }

        // Insertar un nuevo auditor
        public (bool bExito, string sMensaje) InsertarAuditor(int iFkEstado,
            string sNombre, string sTelefono, string sEmail, string sCarnet)
        {
            try
            {
                var validacion = ValidarAuditor(iFkEstado, sNombre, sTelefono, sEmail, sCarnet);
                if (!validacion.bValido)
                    return (false, validacion.sMensaje);

                if (dao.ExisteCarnet(sCarnet.Trim(), 0))
                    return (false, "Ya existe un auditor con el carnet " + sCarnet.Trim() + ".");

                Cls_auditor auditor = new Cls_auditor
                {
                    Fk_Id_Estado_Auditor = iFkEstado,
                    Cmp_Nombre_Auditor = sNombre.Trim(),
                    Cmp_Telefono_Auditor = sTelefono.Trim(),
                    Cmp_Email_Auditor = sEmail.Trim(),
                    Cmp_Carnet_Auditor = sCarnet.Trim()
                };

                //Guardar
                int iNuevoId = dao.InsertarAuditor(auditor);

                return (true, "Auditor guardado correctamente con ID " + iNuevoId + ".");
            }
            catch (Exception ex)
            {
                return (false, "Error al guardar el auditor:\n" + ex.Message);
            }
        }

        // Modificar un auditor existente
        public (bool bExito, string sMensaje) ModificarAuditor(int iIdAuditor, int iFkEstado,
            string sNombre, string sTelefono, string sEmail, string sCarnet)
        {
            try
            {
                if (iIdAuditor <= 0)
                    return (false, "Seleccione un auditor válido para modificar.");

                var validacion = ValidarAuditor(iFkEstado, sNombre, sTelefono, sEmail, sCarnet);
                if (!validacion.bValido)
                    return (false, validacion.sMensaje);

                if (dao.ExisteCarnet(sCarnet.Trim(), iIdAuditor))
                    return (false, "Ya existe otro auditor con el carnet " + sCarnet.Trim() + ".");

                Cls_auditor auditor = new Cls_auditor
                {
                    Pk_Id_Auditor = iIdAuditor,
                    Fk_Id_Estado_Auditor = iFkEstado,
                    Cmp_Nombre_Auditor = sNombre.Trim(),
                    Cmp_Telefono_Auditor = sTelefono.Trim(),
                    Cmp_Email_Auditor = sEmail.Trim(),
                    Cmp_Carnet_Auditor = sCarnet.Trim()
                };

                //Guardar
                dao.ActualizarAuditor(auditor);

                return (true, "Auditor con ID " + iIdAuditor + " modificado correctamente.");
            }
            catch (Exception ex)
            {
                return (false, "Error al modificar el auditor:\n" + ex.Message);
            }
        }

        // Eliminar un auditor existente
        public (bool bExito, string sMensaje) EliminarAuditor(int iIdAuditor)
        {
            try
            {
                if (iIdAuditor <= 0)
                    return (false, "Seleccione un auditor válido para eliminar.");

                int iFilas = dao.EliminarAuditor(iIdAuditor);

                if (iFilas == 0)
                    return (false, "No se encontró el auditor con ID " + iIdAuditor + ".");

                return (true, "Auditor con ID " + iIdAuditor + " eliminado correctamente.");
            }
            catch (Exception ex)
            {
                //el auditor esta siendo usado en otra tabla (llave foranea)
                if (ex.Message.Contains("1451") || ex.Message.ToLower().Contains("foreign key"))
                    return (false, "No se puede eliminar el auditor porque tiene registros relacionados.\n" +
                                   "Puede cambiar su estado a Inactivo en su lugar.");

                return (false, "Error al eliminar el auditor:\n" + ex.Message);
            }
        }
    }
    //Ernesto David Samayoa Jocol 0901-22-3415 17/10/2026
}