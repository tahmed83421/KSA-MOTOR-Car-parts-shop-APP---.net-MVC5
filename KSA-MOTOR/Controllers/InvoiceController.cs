using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace KSA_MOTOR.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index()
        {
            Inventory inventory = new Inventory();
            List<PartsInventory> parts = inventory.Parts.ToList();
            Invoice invoice = new Invoice();
            invoice.Invoice_ID = 1;
            invoice.Parts = parts;
            invoice.Payment_Terms = "VISA";
            invoice.Ship_Adress = "7913 Wedgewood street,BC,Canada";
            invoice.Ship_City = "Burnaby";
            invoice.Ship_CompanyName = "SkyWalk";
            invoice.Ship_Phone = "7785136565";
            invoice.Total_Price = 1000;
            invoice.To_Name = "Tanvir";
            
            return View(invoice);
        }
        public ActionResult Detail()
        {
            Inventory inventory = new Inventory();
            List<PartsInventory> parts = inventory.Parts.ToList();
            Invoice invoice = new Invoice();
            invoice.Invoice_ID = 1;
            invoice.Parts = parts;
            invoice.Payment_Terms = "VISA";
            invoice.Ship_Adress = "7913 Wedgewood street,BC,Canada";
            invoice.Ship_City = "Burnaby";
            invoice.Ship_CompanyName = "SkyWalk";
            invoice.Ship_Phone = "7785136565";
            invoice.Total_Price = 1000;
            invoice.To_Name = "Tanvir";
            

            return View(invoice);
        }


        public ActionResult Create()
        {
           


            return View();
        }
        [HttpPost]
        public ActionResult Create(Invoice invoice)
        {



            return View();
        }

    }
}