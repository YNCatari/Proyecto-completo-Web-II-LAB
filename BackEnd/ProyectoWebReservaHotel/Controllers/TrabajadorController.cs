using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWebReservaHotel.Models;
namespace ProyectoWebReservaHotel.Controllers
{
    [Authorize]
    public class TrabajadorController : Controller
    {
        private trabajador objUsuario = new trabajador();
        private tipo_trabajador objTipo = new tipo_trabajador();
        // GET: Trabajador
        
        public ActionResult Index(string criterio)
        {
            trabajador objTrabajador = new trabajador();
            var tra = objTrabajador.ObtenerDatos(User.Identity.Name);
            int idt = tra.idtipo_trabajador;
            if (idt == 1)
            {
                if (criterio == null || criterio == "")
                {
                    return View(objUsuario.Listar());
                }
                else
                {
                    return View(objUsuario.Buscar(criterio));
                }
            } else { return Redirect("~/Home/Index"); }
        }

        
        public ActionResult AgregarModificarTrabajador(int id = 0)
        {
            trabajador objTrabajador = new trabajador();
            var tra = objTrabajador.ObtenerDatos(User.Identity.Name);
            int idt = tra.idtipo_trabajador;
            if (idt == 1)
            {
                ViewBag.Tipo = objTipo.Listar();//Llenar el combo
                return View(id == 0 ?
                    new trabajador() :
                    objUsuario.Obtener(id));
            }
            else
            {
                return Redirect("~/Home/Index");
            }
        }
        
        public ActionResult Guardar(trabajador model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Trabajador/Index");
            }
            else
            {
                return View("~/Views/Trabajador/AgregarModificarTrabajador.cshtml",model);
            }

        }
        
        public ActionResult Eliminar(int id)
        {
            objUsuario.idtrabajador = id;
            objUsuario.Eliminar();
            return Redirect("~/Trabajador/Index");
        }
    }
}