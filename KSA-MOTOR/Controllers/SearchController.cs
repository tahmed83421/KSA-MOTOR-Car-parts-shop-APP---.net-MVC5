using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KSA_MOTOR.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(int? NID, int? id, int? YID)
        {
            Inventory inventory = new Inventory();
            List<PartsInventory> parts;
            if (NID == null || id == null || YID == null)
            {
                parts = inventory.Parts.ToList();
            }
            else
            {
                parts = inventory.Parts.Where(x => x.VModelId == NID).ToList();
            }
            return View();
        }
    }
}