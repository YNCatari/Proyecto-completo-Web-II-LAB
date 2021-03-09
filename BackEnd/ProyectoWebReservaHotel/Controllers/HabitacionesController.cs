using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWebReservaHotel.Models;

namespace ProyectoWebReservaHotel.Controllers
{
    [Authorize]
    public class HabitacionesController : Controller
    {
        private habitacion objHabitacion = new habitacion();
        private tipo_habitacion objth = new tipo_habitacion();
        // GET: Habitaciones

        public ActionResult Index(string criterio)
        {
                if (criterio == null || criterio == "")
                {
                    return View(objHabitacion.Listar());
                }
                else
                {
                    return View(objHabitacion.Buscar(criterio));
                }
            
        }
        public ActionResult AgregarModificarHabitaciones(int id = 0)
        {
            trabajador objTrabajador = new trabajador();
            var tra = objTrabajador.ObtenerDatos(User.Identity.Name);
            int idt = tra.idtipo_trabajador;
            if (idt == 1)
            {
                ViewBag.Tipo = objth.Listar();//Llenar el combo
                return View(id == 0 ?
                    new habitacion() :
                    objHabitacion.Obtener(id));
            }
            else
            {
                return Redirect("~/Habitaciones/Index");
            }
        }
        public ActionResult Guardar(habitacion model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Habitaciones/Index");
            }
            else
            {
                return View("~/Views/Habitaciones/AgregarModificarHabitaciones.cshtml", model);
            }
        }
        public ActionResult Eliminar(int id)
        {
            objHabitacion.idhabitacion = id;
            objHabitacion.Eliminar();
            return Redirect("~/Habitaciones/Index");
        }
    }

}