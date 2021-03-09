using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWebReservaHotel.Models;
using System.Web.Security;


namespace ProyectoWebReservaHotel.Controllers
{
   
    public class LoginController : Controller
    {
        // GET: Login
       
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Index(trabajador trabajador, string ReturnUrl)
        {
            HomeController obj = new HomeController();
            if (IsValid(trabajador))
            {
                Session["Trabajador"] = trabajador.idtrabajador;//obtener el id del trabajador
                
                FormsAuthentication.SetAuthCookie(trabajador.email, false);
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            TempData["mensaje"] = "Credenciales Incorrectas";
            
            return View(trabajador);
        }
        
        private bool IsValid(trabajador trabajador)
        {
            //Session["Trabajador"] = trabajador.Autenticar();
            
            return trabajador.Autenticar();
        }

        public ActionResult LogOut()
        {
            
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult RecuperarContrasena()
        {
            return View();
        }
        public ActionResult ConfirmarContrasena()
        {
            return View();
        }
    }
}