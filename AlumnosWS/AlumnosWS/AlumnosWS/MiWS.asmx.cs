using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AlumnosWS
{
    /// <summary>
    /// Descripción breve de MiWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class MiWS : System.Web.Services.WebService
    {

        [WebMethod]
        public bool GuardarAlum(string nombre,string apellidoPat, string apellidoMat,string mail, int matricula )
        {
            try
            {
                Alumnos_y_Asignaturas_RemotoEntities ctx = new Alumnos_y_Asignaturas_RemotoEntities();
                Alumnos alumnos = new Alumnos();
                alumnos.Nombre = nombre;
                alumnos.ApellidoPAt = apellidoPat;
                alumnos.ApellidoMat = apellidoMat;
                alumnos.Email = mail;
                alumnos.NumeroMatricula = matricula;
                ctx.Alumnos.Add(alumnos);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        [WebMethod]
        public bool GuardarAsig(string nombre, int creditos)
        {
            try
            {
                Alumnos_y_Asignaturas_RemotoEntities ctx = new Alumnos_y_Asignaturas_RemotoEntities();
                Asignaturas asignaturas = new Asignaturas();
                asignaturas.NombreAsignatura = nombre;
                asignaturas.Creditos = creditos;
                ctx.Asignaturas.Add(asignaturas);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        [WebMethod]
        public List<Alumnos> listarAlumn()
        {
            Alumnos_y_Asignaturas_RemotoEntities ctx = new Alumnos_y_Asignaturas_RemotoEntities();
            return ctx.Alumnos.ToList();
        }
        [WebMethod]
        public List<Asignaturas> listarAsig()
        {
            Alumnos_y_Asignaturas_RemotoEntities ctx = new Alumnos_y_Asignaturas_RemotoEntities();
            return ctx.Asignaturas.ToList();
        }
    }
}
