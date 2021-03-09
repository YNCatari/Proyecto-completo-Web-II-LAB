using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoReservaFrontEnd.Models;
namespace ProyectoReservaFrontEnd.Controllers
{
    public class ReservacionesController : Controller
    {
        habitacion objhabitacion = new habitacion();
        cliente objCliente = new cliente();
        reserva objReserva = new reserva();
        int numeroDocum = 0;
        // GET: Reservaciones
        public ActionResult Index()
        {
            return View(new cliente());
        }
        public ActionResult Guardar(cliente model)
        {

            int id = Convert.ToInt32(model.numero_documento);
            var cli = objCliente.Obtener(id);
            foreach (string key in Request.Form.Keys)
            {
                Debug.WriteLine(key + " " + Request.Form[key]);
            }
            if (ModelState.IsValid)
            {
                if (cli==null)
                {
                    model.Guardar();
                    return RedirectToAction("ListarHabitacion/" + id);
                }
                else
                {
                    
                    return RedirectToAction("ListarHabitacion/" + id);
                }

            }
            else
            {
                return View("~/Views/Reservaciones/Index.cshtml");
            }

        }

        public ActionResult ListarHabitacion(int id =0)
        {
            ViewBag.cliente = objCliente.Obtener(id);
            ViewBag.habitaciones = objhabitacion.Listar();
            return View();
        }

        public ActionResult RegistroReserva(int idhabitacion =0, int idcliente=0)
        {
            

            ViewBag.habitaciones = objhabitacion.Obtener(idhabitacion);
            ViewBag.cliente = objCliente.Obteneridcliente(idcliente);


            return View();
        }
        
        public ActionResult GuardarReserva(reserva model)
        {
            //int id = model.idreserva;
            

            var costhabi = objhabitacion.Obtener(model.idhabitacion);
            int dia1 = model.fecha_ingreso.Day;
            int dia2 = model.fecha_salida.Day;
            model.costo_alojamiento = (dia2 - dia1) * costhabi.precio_diario;
            int id = 0;
            //int id = model.idreserva;

            ViewBag.monto = model.costo_alojamiento;

            foreach (string key in Request.Form.Keys)
            {
                Debug.WriteLine(key + " " + Request.Form[key]);
            }


            if (ModelState.IsValid)
            {
                id = Convert.ToInt32(model.costo_alojamiento);
                model.idtrabajador = 3;
                model.GuardarReserva();



                //return RedirectToAction("RegistroPago", "Reservaciones", new { idcli = idcliente, idhab = idhabitacion, feching = fechaing });

                return RedirectToAction("RegistroPago/"+ id);
            }
            else
            {
                return View("~/Views/Reservaciones/RegistroReserva.cshtml", model);
            }
        }

        public ActionResult RegistroPago(int id = 0)
        {
            ViewBag.monto = id;

           //ViewBag.reservasdatos = objReserva.ObtenerReserva(idcliente, idhabitacion, fechaing);
            return View();
        }
        public ActionResult CompletoReserva(int id = 0)
        {
            ViewBag.idreserva = id;
            return View();
        }
    }
}