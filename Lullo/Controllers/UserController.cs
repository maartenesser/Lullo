using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Lullo.Models;

namespace Lullo.Controllers
{
    public class UserController : Controller
    {
        private UserContext db = new UserContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (db)
            {
                var usr = db.Users.SingleOrDefault(x => x.Email == user.Email && x.Password == user.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.Id.ToString();
                    Session["UserFirstName"] = usr.FirstName;
                    Session["IsAdmin"] = usr.IsAdmin;
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong");
                }
            }

            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                if (Session["UserID"] == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(Convert.ToInt32(Session["UserID"]));
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult LogOut()
        {
            if (Session["UserID"] != null)
            {
                Session.Abandon();
            }

            return RedirectToAction("Login");
        }


        // GET: User
        [NoDirectAccess]
        public ActionResult Index(string search)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");

            }
            if ((bool)Session["IsAdmin"])
            {

                var usr = from u in db.Users select u;

                if (!String.IsNullOrEmpty(search))
                {
                    //Searches in multiple columns
                    usr = usr.Where(u => u.FirstName.Contains(search) || u.LastName.Contains(search) || u.Email.Contains(search));
                }

                return View(usr.ToList());

            }

            return RedirectToAction("Login");

        }

        // GET: User/Details/5
        [NoDirectAccess]
        public ActionResult Details(int? id)
        {
            // Zorgt ervoor dat als je ingelogged bent ook niet kan dieplinken.
            if (Convert.ToInt32(Session["UserID"]) != id)
            {
                return RedirectToAction("LoggedIn");
            }

            if ((bool)Session["IsAdmin"])
            {
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);

            }

            return RedirectToAction("Login");

        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Password,ValidatePassword,IsAdmin")] User user)
        {
            if (db.Users.Any(x => x.Email == user.Email))
            {
                ViewBag.DuplicateMessage = "Email is already in use";
                return View("Create", user);
            }

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                ViewBag.Message = user.FirstName + " " + user.LastName + " succesfully registerd.";
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Edit/5
        [NoDirectAccess]
        public ActionResult Edit(int? id)
        {
    

                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                return View(user);
            

        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NoDirectAccess]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Password,ValidatePassword,IsAdmin")] User user)
        {
            if (db.Users.Any(x => x.Id == user.Id))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("LoggedIn");
                }
            }

            return View(user);
        }

        // GET: User/Delete/5
        [NoDirectAccess]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [NoDirectAccess]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
