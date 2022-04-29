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

        public ActionResult Details(int id)
        {
            var role = db.Categories.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category categoryItem)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(categoryItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var categoryItem = db.Categories.Find(id);
            if (categoryItem == null)
            {
                return HttpNotFound();
            }
            return View(categoryItem);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Index,ImagePath")] Category categoryItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryItem);
        }

        public ActionResult Delete(int id)
        {
            var role = db.Categories.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [HttpPost]
        public ActionResult Delete(Category categoryItem)
        {
            if (ModelState.IsValid)
            {
                var myCategoryItem = db.Categories.Find(categoryItem.Id);
                db.Categories.Remove(myCategoryItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryItem);
        }







    }
}
