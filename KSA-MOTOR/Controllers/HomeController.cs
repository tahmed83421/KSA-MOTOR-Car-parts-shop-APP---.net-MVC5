using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace KSA_MOTOR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Inventory inventory = new Inventory();

            PartsInventory parts = new PartsInventory();
            Vehicle vehicle = new Vehicle();
            parts.GetVehivclesList = inventory.Vehicles.ToList();



            return View(parts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}