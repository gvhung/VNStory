using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VNStory.Web.Commons;
using VNStory.Web.DataContexts;
using VNStory.Web.Models;

namespace VNStory.Web.Areas.Admin.Controllers
{
    public class StoryController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Stories.ToList());
        }

        public ActionResult Details(int id)
        {
            var story = db.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }



        public ActionResult Create()
        {

            
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (int item in Enum.GetValues(typeof(StatusInfor)))
            {
                if (item == 0){
                
                }

            }
            //items.Add(new SelectListItem { Text = "đang cập nhật", Value = "0" });

            //items.Add(new SelectListItem { Text = "drop", Value = "1" });

            //items.Add(new SelectListItem { Text = "chuẩn bị ra mắt", Value = "2", Selected = true });

            //items.Add(new SelectListItem { Text = "hoàn thành", Value = "3" });

            ViewBag.MovieType = items;

            List<SelectListItem> Authorlist = new List<SelectListItem>();

            Authorlist.Add(new SelectListItem { Text = "đang cập nhật", Value = "0" });

            Authorlist.Add(new SelectListItem { Text = "drop", Value = "1" });

            Authorlist.Add(new SelectListItem { Text = "chuẩn bị ra mắt", Value = "2", Selected = true });

            Authorlist.Add(new SelectListItem { Text = "hoàn thành", Value = "3" });

            ViewBag.Authorlist = Authorlist;

            return View();
        }


        [HttpPost]
        public ActionResult Create(Story role)
        {
            if (ModelState.IsValid)
            {
                db.Stories.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var role = db.Stories.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Status,Views,Image,Source,Description")] Story Story)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Story).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Story);
        }

        public ActionResult Delete(int id)
        {
            var role = db.Stories.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Story role)
        {
            if (ModelState.IsValid)
            {
                var myRole = db.Stories.Find(role.Id);
                db.Stories.Remove(myRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }
    }
}
