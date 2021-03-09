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
    public class ReservasController : Controller
    {
        private trabajador objTrabajador = new trabajador();
        private cliente objCliente = new cliente();
        private habitacion objHabitacion = new habitacion();
        private reserva objReserva = new reserva();
        private pago objPago = new pago();
        // GET: Reservas
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objReserva.ListarReservasfinal());
            }
            else
            {
                return View(objReserva.Buscar(criterio));
            }
            
        }
        public ActionResult AgregarModificarReservas(int id = 0)
        {
            //string email=TempData["emailIndex"].ToString();
            trabajador objTrabajador = new trabajador();           
            var tra = objTrabajador.ObtenerDatos(User.Identity.Name);
            ViewBag.idTra = tra.idtrabajador;
            ViewBag.NomTra = tra.nombres + "," + tra.apellidos;
            ViewBag.TipoTra = tra.tipo_trabajador;
            ViewBag.Cliente = objCliente.Listar();//Llenar el combo del cliente
            if (id > 0)
            {
                ViewBag.Habitaciones = objHabitacion.Listar();//Llenar el combo del habitaciones
            }
            else
            {
                ViewBag.Habitaciones = objHabitacion.ListarDiponibles();//Llenar el combo del habitaciones
            }
          

            //DateTime ayuda =new DateTime("mm/dd/")
            // D  ayuda = objReserva.fecha_ingreso
            return View(id == 0 ? new reserva()
                              : objReserva.Obtener(id));
        }

        public ActionResult Guardar(reserva model)
        {
            foreach (string key in Request.Form.Keys)
            {
                Debug.WriteLine(key+ " " + Request.Form[key]);
            }
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Reservas/Index");
            }
            else
            {
                return View("~/Views/Reservas/AgregarModificarReservas.cshtml");
            }
        }
        public ActionResult RealizarPago(int id = 0)
        {
            var reserva = objReserva.Obtener(id);

            int dia1 = reserva.fecha_ingreso.Day;
            int dia2 = reserva.fecha_salida.Day;
            decimal cantDias = (dia2 - dia1)*reserva.costo_alojamiento;
            pago objpago = new pago();
            ViewBag.Total = cantDias.ToString();
            ViewBag.Igv = 0.18;
            ViewBag.reserva = objReserva.Obtener(id);
            ViewBag.cliente = objCliente.Obtener(id);
            return View(new pago());
        }
        public ActionResult GuardarPago(pago model)
        {
            var reserva = objReserva.Obtener(model.idreserva);
            var habitacion = objHabitacion.Obtener(reserva.idhabitacion);
            foreach (string key in Request.Form.Keys)
            {
                Debug.WriteLine(key + " " + Request.Form[key]);
            }
            
            if (ModelState.IsValid )
            {
                if (model.estado.Equals("2"))
                {
                    habitacion.estado = "4";
                    habitacion.Guardar();
                    reserva.estado = "3";
                    reserva.Guardar();
                }
                else if (model.estado.Equals("1"))
                {
                    habitacion.estado = "3";
                    habitacion.Guardar();
                    reserva.estado = "1";
                    reserva.Guardar();
                }
                model.Guardar();
                return Redirect("~/Reservas/Index");
            }
            else
            {
                return View("~/Views/Reservas/RealizarPago.cshtml", model);
            }
        }
        public ActionResult VerGraficosBarras()
        {
            return View(objReserva.ObtenerReservas());
        }
        public ActionResult VerGraficosBarrasPago()
        {
            return View(objPago.ObtenerPago());
        }
        public ActionResult ReservasPorConfirmar(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objReserva.ListarReservasPorConfirmar());
            }
            else
            {
                return View(objReserva.Buscar(criterio));
            }
        }
        public ActionResult ReservaConfirmada(int id = 0)
        {
            reserva model = new reserva();
            
            foreach (string key in Request.Form.Keys)
            {
                Debug.WriteLine(key + " " + Request.Form[key]);
            }
            trabajador objTrabajador = new trabajador();
            var tra = objTrabajador.ObtenerDatos(User.Identity.Name);
            if (ModelState.IsValid)
            {
                var reserva = objReserva.Obtener(id);
                var habitacion = objHabitacion.Obtener(reserva.idhabitacion);
                habitacion.estado = "4";
                model.idreserva = reserva.idreserva;
                model.idcliente = reserva.idcliente;
                model.idhabitacion = reserva.idhabitacion;
                model.idtrabajador = tra.idtrabajador;
                model.tipo_reserva = reserva.tipo_reserva;
                model.fecha_ingreso = reserva.fecha_ingreso;
                model.fecha_salida = reserva.fecha_salida;
                model.costo_alojamiento = reserva.costo_alojamiento;
                model.observacion = reserva.observacion;
                model.estado = "3";
                habitacion.Guardar();
                model.Guardar();
                return Redirect("~/Reservas/ReservasPorConfirmar");
            }
            else
            {
                return View("~/Views/Reservas/ReservasPorConfirmar.cshtml", model);
            }
        }
        public ActionResult RealizarChecking(int id=0)

        {
             var reserva =objReserva.Obtener(id);
            var habitacion = objHabitacion.Obtener(reserva.idhabitacion);
            foreach (string key in Request.Form.Keys)
            {
                Debug.WriteLine(key + " " + Request.Form[key]);
            }
            //var stock = objProducto.Obtener(model.idproducto);
            string estado = reserva.estado;
            if (reserva.estado.Equals("3"))
            {
                habitacion.estado = "5";
                habitacion.Guardar();
                DateTime fecha = DateTime.Now;
                reserva.fecha_ingreso = fecha;
                reserva.estado = "4";
                reserva.Guardar();
                return Redirect("~/Reservas/Index");
            }
            else if (reserva.estado.Equals("4"))
            {
                habitacion.estado = "3";
                habitacion.Guardar();
                DateTime fecha = DateTime.Now;
                reserva.fecha_salida = fecha;
                reserva.estado = "5";
                reserva.Guardar();
                return Redirect("~/Reservas/Index");
            }
            else
            {                  
                return Redirect("~/Reservas/Index");
            }

        }
        public ActionResult Detalle(int id)
        {
            var reserva =objReserva.Obtener(id);
            
            if (reserva.estado.Equals("1")|| reserva.estado.Equals("2"))
            {

                ViewBag.idPago = "No tiene Pago";
                ViewBag.tipo = "";
                ViewBag.num = "";
                ViewBag.igv = "";
                ViewBag.emision = "";
                ViewBag.pago = "";
                ViewBag.total = "";
                ViewBag.estado = "";
            }
            else
            {
                var pago = objPago.ObtenerPagoReserva(id);
                ViewBag.idPago = pago.idpago;
                ViewBag.tipo = pago.tipo_comprobante;
                ViewBag.num = pago.num_comprobante;
                ViewBag.igv = pago.igv;                
                ViewBag.emision = pago.fecha_emision;
                ViewBag.pago = pago.fecha_pago;
                ViewBag.total = pago.total_pago;
                ViewBag.estado = pago.estado;
            }           
            return View(objReserva.Obtener(id));
        }
    }
}