using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWebReservaHotel.Models;
namespace ProyectoWebReservaHotel.Controllers
{
    [Authorize]
    public class ConsumosController : Controller
    {
        private consumo objConsumo = new consumo();
        private reserva objReserva = new reserva();
        private producto objProducto = new producto();

        // GET: Consumos
        public ActionResult Index(String criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objConsumo.Listar());
            }
            else
            {
                return View(objConsumo.Buscar(criterio));
            }
        }
        public ActionResult ActualizarConsumo(int id)
        {
            return View(objConsumo.Obtener(id));
        }
        public ActionResult Buscar(String criterio)
        {

            return View(criterio == null || criterio == "" ? objConsumo.Listar() : objConsumo.Buscar(criterio));
        }
        public ActionResult AgregarConsumo(int id = 0)
        {
            ViewBag.Reserva = objReserva.Listar();//Llenar el combo del Reserva
            ViewBag.Producto = objProducto.Listar();//Llenar el combo del Producto
            return View(id == 0 ? new consumo()
                              : objConsumo.Obtener(id));
        }
        public ActionResult BuscarProducto(String criterio)
        {

            return View(criterio == null || criterio == "" ? objProducto.Listar() : objProducto.Buscar(criterio));
        }

        public ActionResult Guardar(consumo model)

        {
            var stock = objProducto.Obtener(model.idproducto);
            
            foreach (string key in Request.Form.Keys)
            {
                Debug.WriteLine(key + " " + Request.Form[key]);
            }

            if (ModelState.IsValid && model.cantidad.ToString()!=null&& model.cantidad>0 && model.cantidad<stock.cantidad)
            {
                int total = stock.cantidad - Convert.ToInt32(model.cantidad);
                stock.cantidad = total;
                string ayuda = stock.nombre;
                stock.Guardar();
                model.Guardar();
                return Redirect("~/Consumos/Index");
            }
            else
            {
                return View("~/Views/Consumos/AgregarConsumo.cshtml");
            }
        }

        public ActionResult VerGraficosBarras()
        {
            return View(objConsumo.ObtenerConsumo());
        }
    }
}