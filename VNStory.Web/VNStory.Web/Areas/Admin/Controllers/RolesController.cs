using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VNStory.Web.DataContexts;

namespace VNStory.Web.Areas.Admin.Controllers
{
    // [Authorize(Roles = "Admin")]//authorize 3la admin 
    public class RolesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Roles
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(String id)
        {
            var role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(String id)
        {
            var role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(String id)
        {
            var role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }

            if (role.Name == "Administrators" || role.Name == "Users")
            {
                return HttpNotFound("Can not delete role name: [Administrators] or [Users]");
            }
            else
            {
                return View(role);
            }            
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                var myRole = db.Roles.Find(role.Id);
                db.Roles.Remove(myRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }
    }
}
