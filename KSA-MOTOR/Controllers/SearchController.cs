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
        public ActionResult Index(string s)
        {
            return View();
        }
    }
}