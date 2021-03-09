using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWebReservaHotel.Models;

namespace ProyectoWebReservaHotel.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {
        private producto objproducto = new producto();
        // GET: Productos
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objproducto.Listar());
            }
            else
            {
                return View(objproducto.Buscar(criterio));
            }
        }
        public ActionResult AgregarProducto(int id = 0)
        {
            return View(id == 0 ?
                   new producto() :
                   objproducto.Obtener(id));
            
        }
        public ActionResult ActualizarProducto()
        {
            return View();
        }
        public ActionResult Guardar(producto model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Productos/Index");
            }
            else
            {
                return View("~/Views/Productos/AgregarProducto");
            }
        }
        public ActionResult BuscarProducto(string criterio)
        {
            return View(criterio == null || criterio == "" ?
                objproducto.Listar() :
                objproducto.Buscar(criterio));
        }
        public ActionResult Eliminar(int id)
        {
            objproducto.idproducto = id;
            objproducto.Eliminar();
            return Redirect("~/Productos/Index");
        }
        public ActionResult VerGraficosCircular()
        {
            return View(objproducto.ObtenerProductos());
        }
    }
}