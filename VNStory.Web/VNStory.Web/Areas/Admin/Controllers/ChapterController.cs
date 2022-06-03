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



        public ActionResult Create()
        {
            List<SelectListItem> listDoiTuong = new List<SelectListItem>();

            SelectListItem selectListItem;

            foreach (int item in Enum.GetValues(typeof(StatusInfor)))
            {
                selectListItem = new SelectListItem();

                if (item == 0)
                {
                    selectListItem.Value = item.ToString();

                    selectListItem.Text = "Thiếu Nhi";
                }
                else if (item == 1)
                {
                    selectListItem.Value = item.ToString();

                    selectListItem.Text = "Mới Lớn";
                }
                else if (item == 2)
                {
                    selectListItem.Value = item.ToString();

                    selectListItem.Text = "Tuổi Hồng";
                }
                else if (item == 3)
                {
                    selectListItem.Value = item.ToString();

                    selectListItem.Text = "Đọc Tạp";
                }

                if (listDoiTuong.Any(p => p.Value == selectListItem.Value) == false)
                {
                    listDoiTuong.Add(selectListItem);
                }

            }

            ViewBag.listDoiTuong = new SelectList(listDoiTuong, "Value", "Text");

            List<SelectListItem> chapterlist = new List<SelectListItem>();
            foreach (Chapter item in db.Chapters.ToList())
            {
                chapterlist.Add(new SelectListItem { Text = item.Title, Value = item.Id.ToString() });
            }
            ViewBag.chapterlist = new SelectList(chapterlist, "Value", "Text");

            return View();
        }

        //[HttpPost]
        //public ActionResult Create(Chapter chapter)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Chapters.Add(chapter);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}




        //public ActionResult Edit(String id)
        //{
        //    var chapter = db.Chapters.Find(id);
        //    if (chapter == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(chapter);
        //}



        public ActionResult Edit(int id)
        {
            var chapterItem = db.Chapters.Find(id);

            if (chapterItem == null)
            {
                return HttpNotFound();
            }

            #region Danh sách trạng thái truyện

            List<SelectListItem> listDoiTuong = new List<SelectListItem>();

            SelectListItem selectListItem;

            foreach (int item in Enum.GetValues(typeof(StatusInfor)))
            {
                selectListItem = new SelectListItem();

                if (item == 0)
                {
                    selectListItem.Value = item.ToString();

                    selectListItem.Text = "Thiếu Nhi";
                }
                else if (item == 1)
                {
                    selectListItem.Value = item.ToString();

                    selectListItem.Text = "Mới Lớn";
                }
                else if (item == 2)
                {
                    selectListItem.Value = item.ToString();

                    selectListItem.Text = "Tuổi Hồng";
                }
                else if (item == 3)
                {
                    selectListItem.Value = item.ToString();

                    selectListItem.Text = "Đọc Tạp";
                }

                if (listDoiTuong.Any(p => p.Value == selectListItem.Value) == false)
                {
                    listDoiTuong.Add(selectListItem);
                }

            }

            ViewBag.listDoiTuong = new SelectList(listDoiTuong, "Value", "Text");

            return View(chapterItem);
        }



        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,NumberChapter,Story,StoryId")] Chapter chapter)
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
