using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWebReservaHotel.Models;
namespace ProyectoWebReservaHotel.Controllers
{
    [Authorize]
    public class TipoTrabajadorController : Controller
    {
        private tipo_trabajador objTipoTrabajador = new tipo_trabajador();
        // GET: TipoTrabajador
        [Authorize(Users = "admin@upt.pe")]
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objTipoTrabajador.Listar());
            }
            else
            {
                return View(objTipoTrabajador.Buscar(criterio));
            }
        }
        [Authorize(Users = "admin@upt.pe")]
        public ActionResult AgregarTipoTrabajador(int id = 0)
        {
            return View(id == 0 ?
                   new tipo_trabajador() :
                   objTipoTrabajador.Obtener(id));

        }
        [Authorize(Users = "admin@upt.pe")]
        public ActionResult ActualizarTipoTrabajador()
        {
            return View();
        }
        [Authorize(Users = "admin@upt.pe")]
        public ActionResult Guardar(tipo_trabajador model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/TipoTrabajador/Index");
            }
            else
            {
                return View("~/Views/TipoTrabajador/AgregarTipoTrabajador");
            }
        }
        [Authorize(Users = "admin@upt.pe")]
        public ActionResult BuscarTipoTrabajador(string criterio)
        {
            return View(criterio == null || criterio == "" ?
                objTipoTrabajador.Listar() :
                objTipoTrabajador.Buscar(criterio));
        }
        [Authorize(Users = "admin@upt.pe")]
        public ActionResult Eliminar(int id)
        {
            objTipoTrabajador.idtipo_trabajador = id;
            objTipoTrabajador.Eliminar();
            return Redirect("~/TipoTrabajador/Index");
        }
    }
}