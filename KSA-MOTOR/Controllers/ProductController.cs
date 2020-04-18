using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace KSA_MOTOR.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? id)
        {
            Inventory inventory = new Inventory();
        
            PartsInventory part;
            if ( id == null )
            {
                part = null;

            }
            else
            {
              
                part = inventory.Parts.FirstOrDefault(x => x.PartID == id);
            }
            return View("Index", part);
        }
    }
}