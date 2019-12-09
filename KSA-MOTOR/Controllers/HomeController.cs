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
            parts.GetModelList = inventory.VModels.ToList();
            ViewBag.Years = new SelectList(Enumerable.Range(DateTime.Today.Year, 20).Select(x =>

           new SelectListItem()
           {
               Text = x.ToString(),
               Value = x.ToString()
           }), "Value", "Text");


            return View(parts);
        }


        public JsonResult GetModels(string selctedCarBrands)
        {
            Inventory inventory = new Inventory();
            List<Vehicle> vehicles = inventory.Vehicles.Where(x => x.Id == Convert.ToInt32(selctedCarBrands)).ToList();
            return Json(vehicles, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Index(PartsInventory parts)
        {
            ViewBag.Years = new SelectList(Enumerable.Range(DateTime.Today.Year, 20).Select(x =>

          new SelectListItem()
          {
              Text = x.ToString(),
              Value = x.ToString()
          }), "Value", "Text");

            if (parts.selctedCarBrands != null)
            {
                // int h = Convert.ToInt32(selctedCarBrands);
                Inventory inventory = new Inventory();

                Vehicle vehicle = new Vehicle();
                parts.GetVehivclesList = inventory.Vehicles.ToList();
                //  parts.GetModelList = inventory.VModels.ToList();

                parts.GetModelList = inventory.VModels.Where(x => x.MakerId == Convert.ToInt32(parts.selctedCarBrands)).ToList();

                return View(parts);
            }
            else
            {
                return View();
            }






        }

        Inventory inventory = new Inventory();
        public PartialViewResult All()
        {

            List<PartsInventory> parts = inventory.Parts.ToList();
            return PartialView("_Parts", parts);

        }

        public PartialViewResult AllTest(int NID, int id, int YID)
        {

            List<PartsInventory> parts = inventory.Parts.Where(x => x.VModelId == NID).ToList();
            return PartialView("_Parts", parts);

        }
        [HttpPost]
        public ActionResult PlaceOrder(int id,int? Qty)
        {

            return View();
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