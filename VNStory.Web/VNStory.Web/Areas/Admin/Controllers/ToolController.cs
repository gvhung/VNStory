using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VNStory.Web.DataContexts;
using VNStory.Web.Models;

namespace VNStory.Web.Areas.Admin.Controllers
{
    public class ToolController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Stories.ToList());
        }

        //public ActionResult Details(String id)
        //{
        //    var role = db.Stories.Find(id);
        //    if (role == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(role);
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(StoryInfo role)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Stories.Add(role);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Edit(String id)
        //{
        //    var role = db.Stories.Find(id);
        //    if (role == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Edit([Bind(Include = "Id,Name")] StoryInfo role)
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
        //    var role = db.Stories.Find(id);
        //    if (role == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Delete(StoryInfo role)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var myRole = db.Stories.Find(role.Id);
        //        db.Stories.Remove(myRole);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(role);
        //}
    }
}
