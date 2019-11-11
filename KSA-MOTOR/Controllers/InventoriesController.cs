using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using static System.Net.WebRequestMethods;
using KSA_MOTOR.Models;


namespace KSA_MOTOR.Controllers
{
    public class InventoriesController : Controller
    {
        // GET: Inventory
        
        public ActionResult Index()
        {
           
            Inventory inventory = new Inventory();
            List<PartsInventory> Parts = inventory.Parts.ToList();
            ViewData["req"]= inventory.GetRequests();
            return View(Parts);
        }

        [HttpGet]
        public ActionResult Create()
        {
     
            
            return View();
        }
        [HttpPost]
        public ActionResult Create( PartsInventory parts)
        {
            Inventory inventory = new Inventory();
            var fileName = Path.GetFileName(parts.Picture.FileName);
            var path = Path.Combine(Server.MapPath("~/Images"), fileName);
            parts.Picture.SaveAs(path);
            string FileName = Path.GetFileNameWithoutExtension(parts.Picture.FileName);
            string FileExtension = Path.GetExtension(parts.Picture.FileName);
            parts.ImagePath = "~/Images/"+FileName+FileExtension;
            inventory.AddParts(parts);
            return RedirectToAction("Index");
        }
    }
}