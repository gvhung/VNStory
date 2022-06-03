using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VNStory.Web.Commons;
using VNStory.Web.DataContexts;
using VNStory.Web.Models;

namespace VNStory.Web.Areas.Admin.Controllers
{
    // [Authorize(Roles = "Admin")]//authorize 3la admin 
    public class ChapterController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //Id của truyện
        public ActionResult Index(string storyId)
        {
            //Cờ cho phép tạo mới hay không
            bool enableCreateNew = false;//Mặc định là có

            //Khai báo biến danh sách chương
            List<Chapter> _list = new List<Chapter>();

            //Kiểm tra xem biến Id có giá tị hay không
            if (string.IsNullOrEmpty(storyId) == false)
            {
                //Đánh dấu cho phép tạo mới
                enableCreateNew = true;

                //Có giá trị, tìm truyện có Id = giá trị của biến Id
                var story = db.Stories.Find(int.Parse(storyId));

                if (story != null)
                {
                    ViewBag.StoryName = story.Name;
                    ViewBag.StoryId = story.Id.ToString();

                    //Lấy danh sách chương của truyện theo giá trị của Id
                    _list = db.Chapters.Where(p => p.StoryId == story.Id).ToList();

                    //Gán giá trị cho thuộc tính Story
                    foreach (Chapter chapter in _list)
                    {
                        chapter.Story = story;
                    }

                }
            }

            ViewBag.EnableCreateNew = enableCreateNew;

            return View(_list);
        }

        public ActionResult Details(string chapterId, string storyId)
        {
            var chapter = db.Chapters.Find(chapterId);

            if (chapter == null)
            {
                return HttpNotFound();
            }

            return View(chapter);
        }

        public ActionResult Create(string storyId)
        {
            //Kiểm tra xem biến Id có giá tị hay không
            if (string.IsNullOrEmpty(storyId) == false)
            {
                //Có giá trị, tìm truyện có Id = giá trị của biến Id
                var story = db.Stories.Find(int.Parse(storyId));
                if (story != null)
                {
                    ViewBag.StoryName = story.Name;
                    ViewBag.StoryId = story.Id;
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(Chapter chapter)
        {
            int storyId = chapter.StoryId;

            if (ModelState.IsValid)
            {
                db.Chapters.Add(chapter);
                db.SaveChanges();


                return RedirectToAction("Index", new { storyId = storyId });
            }
            return RedirectToAction("Index", new { storyId = storyId });
        }

        public ActionResult Edit(string chapterId)
        {
            var chapterItem = db.Chapters.Find(int.Parse(chapterId));

            if (chapterItem == null)
            {
                return HttpNotFound();
            }

            return View(chapterItem);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,NumberChapter,StoryId")] Chapter chapter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chapter).State = EntityState.Modified;
                db.SaveChanges();

                int storyId = chapter.StoryId;

                return RedirectToAction("Index", new { storyId = storyId });
            }
            return View(chapter);
        }

        public ActionResult Delete(string chapterId)
        {
            var chapter = db.Chapters.Find(chapterId);
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
                int storyId = myChapter.StoryId;
                db.Chapters.Remove(myChapter);
                db.SaveChanges();
                return RedirectToAction("Index", new { storyId = storyId });
            }
            return View(chapter);
        }
    }
}
