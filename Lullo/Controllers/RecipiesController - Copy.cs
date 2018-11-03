//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Diagnostics.Tracing;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using Lullo.Models;
//using Lullo.Models.Recepies;

//namespace Lullo.Controllers
//{
//    public class RecipiesController : Controller
//    {
//        private RecipiesContext db = new RecipiesContext();

//        // GET: Recipies
//        public ActionResult Index(string search)
//        {
//            //return View(db.Recipies.ToList());

//            Recipies model = new Recipies();
//            model.CourseProperty = GetCourseDetails();

//            var recip = from s in db.Recipies select s;

//            if (!String.IsNullOrEmpty(search))
//            {
//                //Searches in multiple columns
//                recip = recip.Where(s => s.Name.Contains(search) || s.Ingredients.Contains(search) || s.PrepareInstructions.Contains(search) || s.Kitchens.Contains(search) || s.Course.Contains(search));
//            }

//            return View(recip.ToList());
//        }

//        public List<Course> GetCourseDetails()
//        {
//            List<Course> result = new List<Course>();

//            var obj = db.Recipies.Select(c => c).ToList();
//            if (obj != null && obj.Count() > 0)
//            {
//                foreach (var data in obj)
//                {
//                    Course model = new Course {CourseId = data.Id, CourseName = data.Course};
//                    result.Add(model);

//                }
//            }

//            return result;
//        }
//        // GET: Recipies/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Recipies recipies = db.Recipies.Find(id);
//            if (recipies == null)
//            {
//                return HttpNotFound();
//            }
//            return View(recipies);
//        }

//        // GET: Recipies/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Recipies/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,Name,Ingredients,PrepareInstructions,Kitchens,Course,NumberOfPeople,PreparationTime")] Recipies recipies)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Recipies.Add(recipies);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(recipies);
//        }

//        // GET: Recipies/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Recipies recipies = db.Recipies.Find(id);
//            if (recipies == null)
//            {
//                return HttpNotFound();
//            }
//            return View(recipies);
//        }

//        // POST: Recipies/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,Name,Ingredients,PrepareInstructions,Kitchens,Course,NumberOfPeople,PreparationTime")] Recipies recipies)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(recipies).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(recipies);
//        }

//        // GET: Recipies/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Recipies recipies = db.Recipies.Find(id);
//            if (recipies == null)
//            {
//                return HttpNotFound();
//            }
//            return View(recipies);
//        }

//        // POST: Recipies/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Recipies recipies = db.Recipies.Find(id);
//            db.Recipies.Remove(recipies);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
