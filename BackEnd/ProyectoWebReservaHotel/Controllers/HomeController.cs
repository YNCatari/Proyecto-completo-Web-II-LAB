using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWebReservaHotel.Models;
namespace ProyectoWebReservaHotel.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public string email;
        public ActionResult Index()
        {          
            return View();
        }
    }
}