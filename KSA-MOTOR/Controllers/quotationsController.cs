using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KSA_MOTOR.Models;
using BusinessLayer;
using System.Data.Entity.Validation;
using System.Net.Mail;

namespace KSA_MOTOR.Controllers
{
    public class quotationsController : Controller
    {
        private QuotationDbContext db = new QuotationDbContext();

        // GET: quotations
        public ActionResult Index()
        {
            return View(db.quotations.ToList());
            
            
           
        }

        // GET: quotations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quotation quotation = db.quotations.Find(id);
            if (quotation == null)
            {
                return HttpNotFound();
            }
            return View(quotation);
        }


        public ActionResult Report(int? id)
        {
            MyViewModel myView = new MyViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quotation quotation = db.quotations.Find(id);

            myView.marketAnalyzes = db.MarketAnalyzes.Where(x => x.QuotationId == id).ToList();
            myView.quotationss = db.quotations.Find(id);
           
            if (quotation == null)
            {
                return HttpNotFound();
            }
            return View(myView);

           
        }

        private void SetStatus(string status)
        {
            
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public ActionResult ReportSubmit( int QuotationId ,string Price,string _Brand,string _Condition,string DeliveryTime,string Supplier,string Warranty,string Comment)
        {





            // market.ID = myView.marketAnalyze.ID;
            MarketAnalyze market = new MarketAnalyze();
            market.Price = Price;
            market.Brand = _Brand;
            market.Condition = _Condition;
            market.DeliveryTime = DeliveryTime;
            market.Supplier = Supplier;
            market.Warranty = Warranty;
            market.Comment = Comment;
            market.QuotationId = QuotationId;
                    db.MarketAnalyzes.Add(market);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
              
            

            //  return View(myView);
         


        }




        public ActionResult EditMarketOption( int id)
        {
            
            return View(db.MarketAnalyzes.Find(id));
        }

        [HttpPost]
      
        public ActionResult EditMarketOption(MarketAnalyze market)
        {


            if (ModelState.IsValid)
            {
                db.Entry(market).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Report",new { id=market.QuotationId});
            }
            return View(market);
        }



        [ActionName("DeleteMarketOption")]
        public ActionResult GETDeleteMarketOption(int id)
        {
            MarketAnalyze market = db.MarketAnalyzes.Find(id);

            return View(market);
        }
        [HttpPost]
        public ActionResult DeleteMarketOption(int id)
        {
            MarketAnalyze market = db.MarketAnalyzes.Find(id);
            db.MarketAnalyzes.Remove(market);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CommentSubmit(string Cmnt)
        {
          

            return View();
        }


     





        // GET: quotations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: quotations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Make,Year,Model,VIN,VPicture,PartsNumber,PartsName,PartsDescription,PPicture")] quotation quotation)
        {
            if (ModelState.IsValid)
            {
                Inventory inventory = new Inventory();  
                db.quotations.Add(quotation);
                db.SaveChanges();
                
                string Mail= inventory.GetEmailAddressByRole("Admin");
                // sending mial 
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("tanvir@jayariken.com");
                message.To.Add(new MailAddress("ahmed.tanvir83421@gmail.com"));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = "Hi you have got a new Quotation Request. Please Sign in to Care-n-Repair for more details.?";
                smtp.Port = 26;
                smtp.Host = "mail.jayariken.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("tanvir@jayariken.com", "7919raka");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            
            return RedirectToAction("Index");
             
            }

            return View(quotation);
        }

        // GET: quotations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quotation quotation = db.quotations.Find(id);
            if (quotation == null)
            {
                return HttpNotFound();
            }
            return View(quotation);
        }

        // POST: quotations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Make,Year,Model,VIN,VPicture,PartsNumber,PartsName,PartsDescription,PPicture")] quotation quotation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quotation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quotation);
        }

        // GET: quotations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quotation quotation = db.quotations.Find(id);
            if (quotation == null)
            {
                return HttpNotFound();
            }
            return View(quotation);
        }

        // POST: quotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            quotation quotation = db.quotations.Find(id);
            db.quotations.Remove(quotation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
