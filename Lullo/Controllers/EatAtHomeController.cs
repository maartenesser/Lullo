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
    public class EatAtHomeController : Controller
    {
        private EatAtHomeContext db = new EatAtHomeContext();

        // GET: EatAtHome
        public ActionResult Index()
        {
            return View(db.EatAtHomes.ToList());
        }

        // GET: EatAtHome/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EatAtHome eatAtHome = db.EatAtHomes.Find(id);
            if (eatAtHome == null)
            {
                return HttpNotFound();
            }
            return View(eatAtHome);
        }

        // GET: EatAtHome/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EatAtHome/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EatsAtHome,Guests")] EatAtHome eatAtHome)
        {
            if (ModelState.IsValid)
            {
                db.EatAtHomes.Add(eatAtHome);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eatAtHome);
        }

        // GET: EatAtHome/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EatAtHome eatAtHome = db.EatAtHomes.Find(id);
            if (eatAtHome == null)
            {
                return HttpNotFound();
            }
            return View(eatAtHome);
        }

        // POST: EatAtHome/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EatsAtHome,Guests")] EatAtHome eatAtHome)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eatAtHome).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eatAtHome);
        }

        // GET: EatAtHome/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EatAtHome eatAtHome = db.EatAtHomes.Find(id);
            if (eatAtHome == null)
            {
                return HttpNotFound();
            }
            return View(eatAtHome);
        }

        // POST: EatAtHome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EatAtHome eatAtHome = db.EatAtHomes.Find(id);
            db.EatAtHomes.Remove(eatAtHome);
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
