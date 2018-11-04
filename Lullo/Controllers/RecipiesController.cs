using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Lullo.Models;
using Lullo.Models.Recepies;

namespace Lullo.Controllers
{
    public class RecipiesController : Controller
    {
        private RecipiesContext db = new RecipiesContext();

        // GET: Recipies
        [NoDirectAccess]
        public ActionResult Index(string search /*,string course*/)
        {
            var recip = from s in db.Recipies select s;


            //var courseList = new List<string>();
            //var courseNames = from c in db.Recipies
            //    orderby c.Course
            //    select c.Course;

            //courseList.AddRange(courseNames.Distinct());
            //ViewBag.city = new SelectList(courseList);


            //if (!string.IsNullOrWhiteSpace(course))
            //{
            //    recip = recip.Where(c => c.Course == course);
            //}

            //return View(recip.ToList());

            //var recip = from s in db.Recipies select s;

            if (!String.IsNullOrEmpty(search))
            {
                //Searches in multiple columns
                recip = recip.Where(s => s.Name.Contains(search) || s.Ingredients.Contains(search) || s.PrepareInstructions.Contains(search) || s.Kitchens.Contains(search) || s.Course.Contains(search));
            }

            return View(recip.ToList());
        }

        // GET: Recipies/Details/5
        [NoDirectAccess]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipies recipies = db.Recipies.Find(id);
            if (recipies == null)
            {
                return HttpNotFound();
            }
            return View(recipies);
        }

        // GET: Recipies/Create
        [NoDirectAccess]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [NoDirectAccess]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Ingredients,PrepareInstructions,Kitchens,Course,NumberOfPeople,PreparationTime")] Recipies recipies)
        {
            if (ModelState.IsValid)
            {
                db.Recipies.Add(recipies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipies);
        }

        // GET: Recipies/Edit/5
        [NoDirectAccess]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipies recipies = db.Recipies.Find(id);
            if (recipies == null)
            {
                return HttpNotFound();
            }
            return View(recipies);
        }

        // POST: Recipies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [NoDirectAccess]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Ingredients,PrepareInstructions,Kitchens,Course,NumberOfPeople,PreparationTime")] Recipies recipies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipies);
        }

        // GET: Recipies/Delete/5
        [NoDirectAccess]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipies recipies = db.Recipies.Find(id);
            if (recipies == null)
            {
                return HttpNotFound();
            }
            return View(recipies);
        }

        // POST: Recipies/Delete/5
        [NoDirectAccess]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipies recipies = db.Recipies.Find(id);
            db.Recipies.Remove(recipies);
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

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class NoDirectAccessAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (filterContext.HttpContext.Request.UrlReferrer == null ||
                    filterContext.HttpContext.Request.Url.Host != filterContext.HttpContext.Request.UrlReferrer.Host)
                {
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "Home", action = "Index", area = "" }));
                }
            }
        }
    }
}
