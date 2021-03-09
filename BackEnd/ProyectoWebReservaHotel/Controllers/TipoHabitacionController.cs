using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWebReservaHotel.Models;

namespace ProyectoWebReservaHotel.Controllers
{
    [Authorize]
    public class TipoHabitacionController : Controller
    {
        private tipo_habitacion objth = new tipo_habitacion();
        // GET: TipoHabitacion
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objth.Listar());
            }
            else
            {
                return View(objth.Buscar(criterio));
            }
        }
       
        public ActionResult AgregarTipoHabitacion(int id = 0)
        {
            trabajador objTrabajador = new trabajador();
            var tra = objTrabajador.ObtenerDatos(User.Identity.Name);
            int idt = tra.idtipo_trabajador;
            if (idt == 1)
            {
                return View(id == 0 ?
                   new tipo_habitacion() :
                   objth.Obtener(id));
            }
            else
            {
                return  Redirect("~/TipoHabitacion/Index");
            }
        }
        
        public ActionResult ActualizarTipoTrabajador()
        {
            return View();
        }
        
        public ActionResult Guardar(tipo_habitacion model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/TipoHabitacion/Index");
            }
            else
            {
                return View("~/Views/TipoHabitacion/AgregarTipoHabitacion");
            }
        }
        
        public ActionResult BuscarTipoHabitacion(string criterio)
        {
            return View(criterio == null || criterio == "" ?
                objth.Listar() :
                objth.Buscar(criterio));
        }
        
        public ActionResult Eliminar(int id)
        {
            objth.idtipo_habitacion = id;
            objth.Eliminar();
            return Redirect("~/TipoHabitacion/Index");
        }
    }
}