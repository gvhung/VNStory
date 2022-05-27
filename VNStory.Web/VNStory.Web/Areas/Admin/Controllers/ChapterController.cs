using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VNStory.Web.DataContexts;
using VNStory.Web.Models;

namespace VNStory.Web.Areas.Admin.Controllers
{
    // [Authorize(Roles = "Admin")]//authorize 3la admin 
    public class ChapterController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //Id của truyện
        public ActionResult Index(String id)
        {
            //Khai báo biến danh sách chương
            List<Chapter> _list = new List<Chapter>();

            //Kiểm tra xem biến Id có giá tị hay không
            if (string.IsNullOrEmpty(id) == false)
            {
                //Có giá trị, tìm truyện có Id = giá trị của biến Id
                var story = db.Stories.Find(id);

                if (story != null)
                {
                    //Lấy danh sách chương của truyện theo giá trị của Id
                    _list = db.Chapters.Where(p => p.StoryId == story.Id).ToList();
                }
            }

            return View(_list);
        }

        public ActionResult Details(String id)
        {
            var chapter = db.Chapters.Find(id);

            if (chapter == null)
            {
                return HttpNotFound();
            }

            return View(chapter);
        }

        public ActionResult Create(String id)
        {
            //Có giá trị, tìm truyện có Id = giá trị của biến Id
            var story = db.Stories.Find(id);

            return View(story);
        }

        [HttpPost]
        public ActionResult Create(Chapter chapter)
        {
            if (ModelState.IsValid)
            {
                db.Chapters.Add(chapter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(String id)
        {
            var chapter = db.Chapters.Find(id);
            if (chapter == null)
            {
                return HttpNotFound();
            }
            return View(chapter);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,NumberChapter,StoryId")] Chapter chapter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chapter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chapter);
        }

        public ActionResult Delete(String id)
        {
            var chapter = db.Chapters.Find(id);
            if (chapter == null)
            {
                return HttpNotFound();
            }
            return View(chapter);
        }

        [HttpPost]
        public ActionResult Delete(Chapter chapter)
        {
            if (ModelState.IsValid)
            {
                var myChapter = db.Chapters.Find(chapter.Id);
                db.Chapters.Remove(myChapter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chapter);
        }
    }
}
