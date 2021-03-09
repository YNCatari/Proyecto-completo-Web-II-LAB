using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoReservaFrontEnd.Models;
using Rotativa;

namespace ProyectoReservaFrontEnd.Controllers
{
    public class GenerarComprobanteController : Controller
    {
        pago objpago= new pago();
        reserva objreserva = new reserva();
        habitacion objhabitacion = new habitacion();
        cliente objcliente = new cliente();
        trabajador objtrabajador = new trabajador();
        // GET: GenerarComprobante
        public ActionResult Index(int id = 0)
        {
            var reserva = objreserva.Obtener(id);
            ViewBag.reserva = objreserva.Obtener(id);
            ViewBag.cliente = objcliente.Obteneridcliente(reserva.idcliente);
            ViewBag.pago = objpago.ObtenerPagoReserva(reserva.idreserva);
            ViewBag.habitacion = objhabitacion.Obtener(reserva.idhabitacion);
            ViewBag.trabajador = objtrabajador.Obtener(reserva.idtrabajador);
            return View();
        }
        public ActionResult Print(int id = 0)
        {
            return new ActionAsPdf("Index", new { id = id })
            { FileName="ComprobanteHotelSantaMaria.pdf"};
        }
    }
}