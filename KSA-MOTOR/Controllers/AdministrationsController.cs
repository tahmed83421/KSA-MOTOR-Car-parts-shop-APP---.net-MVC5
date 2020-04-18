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



namespace KSA_MOTOR.Controllers
{
    public class AdministrationsController : Controller
    {
        private QuotationDbContext db = new QuotationDbContext();


    



        // GET: Administrations
        public ActionResult Index()
        {

            return View();
        }
      
        [HttpPost]

       
        public ActionResult Index( string Password)
        {

            LoginCheck login = new LoginCheck();
           
            //if (login.LoginAuthorization(Password))
            //{
            //    Session["user"] = Password.ToString();
            //    return RedirectToAction("Index", "Inventories", new { area = "" });
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}
            // bypassing ... 
            Session["user"] = Password.ToString();
            return RedirectToAction("Index", "Inventories", new { area = "" });

        }

        // GET: Administrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administration administration = db.Administrations.Find(id);
            if (administration == null)
            {
                return HttpNotFound();
            }
            return View(administration);
        }

        // GET: Administrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstName,UserId,Password,Email,Phone")] Administration administration)
        {
            if (ModelState.IsValid)
            {
                db.Administrations.Add(administration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administration);
        }

        // GET: Administrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administration administration = db.Administrations.Find(id);
            if (administration == null)
            {
                return HttpNotFound();
            }
            return View(administration);
        }

        // POST: Administrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName,UserId,Password,Email,Phone")] Administration administration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administration);
        }

        // GET: Administrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administration administration = db.Administrations.Find(id);
            if (administration == null)
            {
                return HttpNotFound();
            }
            return View(administration);
        }

        // POST: Administrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administration administration = db.Administrations.Find(id);
            db.Administrations.Remove(administration);
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
