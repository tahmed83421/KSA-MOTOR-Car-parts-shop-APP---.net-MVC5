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
            ViewBag.parrt = inventory.Parts.ToList();
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



        public ActionResult Invoice()
        {
            return View();
        }


        [HttpPost]

        public ActionResult UpdateCart( PartsInventory parts,int? IDD)
        {
            List<PartsInventory> lis= (List<PartsInventory>)Session["cart"];
            if (Session["Cart"] != null)
            {
                foreach (var listy in (List<PartsInventory>)Session["cart"])
                {
                    if (listy.PartID == parts.PartID)
                    {
                        listy.Qty = parts.Qty;
                    }
                }

            }

            return RedirectToAction("CheckOut");
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
                Inventory inventory = new Inventory();
                Vehicle vehicle = new Vehicle();
                parts.GetVehivclesList = inventory.Vehicles.ToList();
                parts.GetModelList = inventory.VModels.Where(x => x.MakerId == Convert.ToInt32(parts.selctedCarBrands)).ToList();
                return View(parts);
            }
            else
            {
                return View();
            }

        }

      
 

        public PartialViewResult AllTest(int? NID, int? id, int? YID)
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
           
            return PartialView("_Parts", parts);

        }


        public ActionResult CheckOut()
       {
           
            List<PartsInventory> parts = (List<PartsInventory>)Session["cart"];
           return View(parts);
        }
        [HttpPost]
        public ActionResult CheckOut(IEnumerable<PartsInventory> partsc)
        {
            Inventory inventory = new Inventory();
            foreach ( var item in (List<PartsInventory>)Session["cart"])
            {
                
                inventory.AddOrder(item);
            }
            List<PartsInventory> parts = (List<PartsInventory>)Session["cart"];
            Session.Clear();
            return View(parts);

        }



        public ActionResult PlaceOrder(int? IDD)
        {

            return RedirectToAction("Index");


            /*
            List<int> Pid = new List<int>();
            OrderDetailDB orderDetailDB = new OrderDetailDB();
            // orderDetailDB.AddOrder(id,qty);
            Pid.Add(id);
            

            Response.Cookies["cookie"].Value = Convert.ToString(Convert.ToInt32(Request.Cookies["cookie"].Value.ToString()) + 1);
            return RedirectToAction("Index");
            */
        }
      
        public ActionResult RemoveItemFromCart(int id)
        {
            List<PartsInventory> li = (List<PartsInventory>)Session["cart"];
            li.RemoveAll(x => x.PartID == id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("CheckOut", "Home");
        }

        [HttpPost]
        public ActionResult PlaceOrder(PartsInventory parts,int? IDD)
        {
            if (Session["cart"] == null)
            {
                List<PartsInventory> li = new List<PartsInventory>();

                li.Add(parts);
                Session["cart"] = li;
                ViewBag.cart = li.Count();


                Session["count"] = 1;


            }
            else
            {
                List<PartsInventory> li = (List<PartsInventory>)Session["cart"];
                li.Add(parts);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            }

            return RedirectToAction("Index");
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