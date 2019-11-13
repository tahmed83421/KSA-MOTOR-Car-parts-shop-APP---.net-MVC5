using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using System.ComponentModel.DataAnnotations;
using static System.Net.WebRequestMethods;
using KSA_MOTOR.Models;
using System.Net;

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
            Inventory inventory = new Inventory();

            PartsInventory parts = new PartsInventory();
            parts.GetVehivclesList = inventory.Vehicles.Select(x => new Vehicle { Id = x.Id, Make = x.Make }).ToList();



            return View(parts);
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

        public ActionResult Details(int id)
        {
            Inventory inventory = new Inventory();
            PartsInventory parts= inventory.GetPartsById(id);
            return View(parts);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteDetails(int id)
        {
            Inventory inventory = new Inventory();
            PartsInventory parts = inventory.GetPartsById(id);
            return View(parts);
        }

        [HttpPost]
       
        public ActionResult Delete(int id)
        {
            Inventory inventory = new Inventory();
            inventory.DeleteParts(id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Inventory inventory = new Inventory();
            PartsInventory parts = inventory.GetPartsById(id);
            return View(parts);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditParts(PartsInventory part)
        {
         

            Inventory inventory = new Inventory();
            inventory.UpdateParts(part);
            return RedirectToAction("Index");
        }





    }
}