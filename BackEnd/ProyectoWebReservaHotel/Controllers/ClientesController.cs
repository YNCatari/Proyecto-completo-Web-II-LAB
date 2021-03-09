using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWebReservaHotel.Models;
namespace ProyectoWebReservaHotel.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private cliente objCliente = new cliente();
        // GET: Clientes
        
        public ActionResult Index(String criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objCliente.Listar());
            }
            else
            {
                return View(objCliente.Buscar(criterio));
            }
            //prueba de commit 1
        }
        public ActionResult ActualizarCliente(int dni)
        {
            return View(objCliente.Obtener(dni));
        }
        public ActionResult Buscar(String criterio)
        {

            return View(criterio == null || criterio == "" ? objCliente.Listar() : objCliente.Buscar(criterio));
        }
        public ActionResult AgregarCliente(int id = 0)
        {
            return View(id == 0 ? new cliente()
                              : objCliente.Obtener(id));
        }


        public ActionResult Guardar(cliente model)

        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Clientes/Index");
            }
            else
            {
                return View("~/Views/Clientes/AgregarCliente.cshtml");
            }
        }
        public ActionResult Eliminar(int id)
        {
            objCliente.idcliente = id;
            objCliente.Eliminar();
            return Redirect("~/Clientes");
        }
    }
}