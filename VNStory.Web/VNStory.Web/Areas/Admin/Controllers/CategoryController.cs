using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VNStory.Web.DataContexts;
using VNStory.Web.Models;

namespace VNStory.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        //public ActionResult Details(String id)
        //{
        //    var role = db.Categories.Find(id);
        //    if (role == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(role);
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category role)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        //public ActionResult Edit(String id)
        //{
        //    var role = db.Categories.Find(id);
        //    if (role == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Edit([Bind(Include = "Id,Name")] Category role)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(role).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(role);
        //}

        //public ActionResult Delete(String id)
        //{
        //    var role = db.Categories.Find(id);
        //    if (role == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Delete(CategoryInfo role)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var myRole = db.Categories.Find(role.Id);
        //        db.Categories.Remove(myRole);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(role);
        //}
    }
}
