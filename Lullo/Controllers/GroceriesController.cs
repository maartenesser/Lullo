using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lullo.Models;

namespace Lullo.Controllers
{
    public class GroceriesController : Controller
    {
        private GroceriesContext db = new GroceriesContext();

        // GET: Groceries
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View(db.Groceries.ToList());
            }

            return RedirectToAction("Login", "User");
        }

        // GET: Groceries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groceries groceries = db.Groceries.Find(id);
            if (groceries == null)
            {
                return HttpNotFound();
            }
            return View(groceries);
        }

        // GET: Groceries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Groceries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Quantity")] Groceries groceries)
        {
            if (ModelState.IsValid)
            {
                db.Groceries.Add(groceries);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groceries);
        }

        // GET: Groceries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groceries groceries = db.Groceries.Find(id);
            if (groceries == null)
            {
                return HttpNotFound();
            }
            return View(groceries);
        }

        // POST: Groceries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Quantity")] Groceries groceries)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groceries).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groceries);
        }

        // GET: Groceries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groceries groceries = db.Groceries.Find(id);
            if (groceries == null)
            {
                return HttpNotFound();
            }
            return View(groceries);
        }

        // POST: Groceries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Groceries groceries = db.Groceries.Find(id);
            db.Groceries.Remove(groceries);
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
