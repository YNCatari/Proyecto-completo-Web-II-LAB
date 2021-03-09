using culqi.net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoReservaFrontEnd.Models;

namespace ProyectoReservaFrontEnd.Controllers
{
    public class PagoController : Controller
    {
        // GET: Pago
        public ActionResult Index()
        {

            pago objPagar = new pago();

            string email = Request.Form["email"];
            string idcard = Request.Form["card_number"];
            string cvv = Request.Form["cvv"];
            string monthaexp = Request.Form["expiration_month"];
            string añoaexp = Request.Form["expiration_year"];
            string descripcion = Request.Form["descripcion"];
            string monto = Request.Form["total_pago"];
            
            try
            {
                Security security = new Security();
                security.public_key = "pk_test_28ecd396922fc884";
                security.secret_key = "sk_test_d6b76d37e02daa06";

                Dictionary<string, object> token = new Dictionary<string, object>
                {
                {"card_number", idcard},
                {"cvv", cvv},
                {"expiration_month", monthaexp},
                {"expiration_year", añoaexp},
                {"email", email}
                };
                string token_created = new Token(security).Create(token);

                var json_token = JObject.Parse(token_created);

                Dictionary<string, object> metadata = new Dictionary<string, object>
                {
                {"order_id", "777"}
                 };

                Dictionary<string, object> charge = new Dictionary<string, object>
            {
                {"amount", monto},
                {"capture", true},
                {"currency_code", "PEN"},
                {"description", descripcion},
                {"email", email},
                {"installments", 0},
                {"metadata", metadata},
                {"source_id", (string)json_token["id"]}
            };

                string charge_created = new Charge(security).Create(charge);
            }
            catch (Exception e)
            {

                Debug.Fail(e.Message);
            }

            
            objPagar.idpago = 0;
            objPagar.idreserva = Convert.ToInt32(Request.Form["idreserva"]);
            objPagar.tipo_comprobante = Request.Form["tipo_comprobante"];
            objPagar.num_comprobante = Request.Form["num_comprobante"];
            objPagar.igv = Convert.ToDecimal(Request.Form["igv"]);
            objPagar.total_pago = Convert.ToDecimal(Request.Form["total_pago"]);
            objPagar.fecha_emision = Convert.ToDateTime(Request.Form["fecha_emision"]);
            objPagar.fecha_pago= Convert.ToDateTime(Request.Form["fecha_pago"]);
            objPagar.estado = "P";
            int id = objPagar.idreserva;


            foreach (string key in Request.Form.Keys)
            {
                Debug.WriteLine(key + " " + Request.Form[key]);
            }
                     
            if (ModelState.IsValid)
            {

                objPagar.Guardar();
                return Redirect("~/Reservaciones/CompletoReserva/" + id);
            }
            else
            {
                return View("~/Views/Reservaciones/RegistroPago.cshtml");
            }





            
        }
    }
}