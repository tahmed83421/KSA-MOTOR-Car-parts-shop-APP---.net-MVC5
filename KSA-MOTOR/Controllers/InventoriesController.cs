using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace KSA_MOTOR.Controllers
{
    public class InventoriesController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            Inventory inventory = new Inventory();
            List<PartsInventory> Parts = inventory.Parts.ToList();
            return View(Parts);
        }
    }
}