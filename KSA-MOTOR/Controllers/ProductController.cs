using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KSA_MOTOR.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                // show an error page
            }

            return View();
        }
    }
}