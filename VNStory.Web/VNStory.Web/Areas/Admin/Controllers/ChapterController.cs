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
                //Có giá trị, tìm truyện có Id = giá trị của biến Id
                var story = db.Stories.Find(int.Parse(storyId));
                if (story == null)
                {
                    //Thông báo không tìm thấy truyện
                    return HttpNotFound();
                }
                else
                {
                    //Đánh dấu cho phép tạo mới
                    enableCreateNew = true;

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

        public ActionResult Details(string id, string storyId)
        {
            if (string.IsNullOrEmpty(id) == true)
            {
                return HttpNotFound();
            }

            int _id = 0;

            int.TryParse(id, out _id);

            var chapterItem = db.Chapters.Find(_id);

            if (chapterItem == null)
            {
                return HttpNotFound();
            }

            if (string.IsNullOrEmpty(storyId) == false)
            {
                int _storyId = 0;

                int.TryParse(storyId, out _storyId);

                if (chapterItem.StoryId != _storyId)
                {
                    return HttpNotFound();
                }
                else
                {
                    var story = db.Stories.Find(_storyId);
                    if (story != null)
                    {
                        chapterItem.Story = story;
                    }
                }
                 
            }
            var chapter = db.Chapters.Find(int.Parse(id));

            if (chapter == null)
            {
                return HttpNotFound();
            }

            //Kiểm tra xem parameter storyId trên Url hay không
            if (string.IsNullOrEmpty(storyId) == false)
            {
                //Kiểm tra xem giá trị StoryId của cương có bằng giá trị của param StoryId trên Url hay không
                if (chapter.StoryId != int.Parse(storyId))
                {
                    //giá trị StoryId không bằng nhau
                    return HttpNotFound();
                }
                else
                {
                    //Lấy đối tượng truyện có mã Id = giá trị của param StoryId trên Url
                    var story = db.Stories.Find(int.Parse(storyId));
                    if (story != null)
                    {
                        chapter.Story = story;
                    }
                }
            }
            else
            {
                //Lấy đối tượng truyện có mã Id = giá trị của StoryId thuộc đối tượng Chương
                var story = db.Stories.Find(chapter.StoryId);
                if (story != null)
                {
                    chapter.Story = story;
                }
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
                if (story == null)
                {
                    //Thông báo không tìm thấy truyện
                    return HttpNotFound();
                }
                else
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

        //public ActionResult Edit(string id, string storyId)
        //{
        //    var chapterItem = db.Chapters.Find(int.Parse(id));

        //    if (chapterItem == null)
        //    {
        //        //Thông báo không tìm thấy chương
        //        return HttpNotFound();
        //    }

        //    //Kiểm tra xem parameter storyId trên Url hay không
        //    if (string.IsNullOrEmpty(storyId) == false)
        //    {
        //        //Kiểm tra xem giá trị StoryId của cương có bằng giá trị của param StoryId trên Url hay không
        //        if (chapterItem.StoryId != int.Parse(storyId))
        //        {
        //            //giá trị StoryId không bằng nhau
        //            return HttpNotFound();
        //        }
        //        else
        //        {
        //            //Lấy đối tượng truyện có mã Id = giá trị của param StoryId trên Url
        //            var story = db.Stories.Find(int.Parse(storyId));
        //            if (story != null)
        //            {
        //                chapterItem.Story = story;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //Lấy đối tượng truyện có mã Id = giá trị của StoryId thuộc đối tượng Chương
        //        var story = db.Stories.Find(chapterItem.StoryId);
        //        if (story != null)
        //        {
        //            chapterItem.Story = story;
        //        }
        //    }

        //    return View(chapterItem);
        //}

        public ActionResult Edit(string id, string storyId)
        {
            if (string.IsNullOrEmpty(id) == true)
            {
                return HttpNotFound();
            }

            int _id = 0;

            int.TryParse(id, out _id);

            var chapterItem = db.Chapters.Find(_id);

            if (chapterItem == null)
            {
                return HttpNotFound();
            }

            if (string.IsNullOrEmpty(storyId) == false)
            {
                int _storyId = 0;

                int.TryParse(storyId, out _storyId);

                if (chapterItem.StoryId != _storyId)
                {
                    return HttpNotFound();
                }
                else
                {
                    var story = db.Stories.Find(_storyId);
                    if (story != null)
                    {
                        chapterItem.Story = story;
                    }
                }

            }
            else
            {
                var story = db.Stories.Find(chapterItem.StoryId);
                if (story != null)
                {
                    chapterItem.Story = story;
                }
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

        public ActionResult Delete(string id, string storyId)
        {
            //Kiểm tra xem param Id có trên Url hay không
            if (string.IsNullOrEmpty(id) == true)
            {
                return HttpNotFound();
            }
            
            //Khai báo biến tạm (biến cục bộ)
            int _id = 0;

            //Chuyển đổi param Id từ kiểu dữ liệu String sang kiểu Int
            int.TryParse(id, out _id);

            //Lấy đối tượng Chương theo Id có giá trị = biến _id
            var chapter = db.Chapters.Find(_id);

            //Kiểm tra xem có tìm thấy đối tượng Chương hay không
            if (chapter == null)
            {
                //Hiển thị thông báo không tìm thấy
                return HttpNotFound();
            }

            //Kiểm tra xem parameter storyId trên Url hay không
            if (string.IsNullOrEmpty(storyId) == false)
            {
                //Khai báo biến tạm (biến cục bộ)
                int _storyId = 0;

                //Chuyển đổi param storyId từ kiểu dữ liệu String sang kiểu Int
                int.TryParse(storyId, out _storyId);

                //Kiểm tra xem giá trị StoryId của cương có bằng giá trị của param StoryId trên Url hay không
                if (chapter.StoryId != _storyId)
                {
                    //giá trị StoryId không bằng nhau
                    return HttpNotFound();
                }
                else
                {
                    //Lấy đối tượng truyện có mã Id = giá trị của param StoryId trên Url
                    var story = db.Stories.Find(_storyId);
                    if (story != null)
                    {
                        chapter.Story = story;
                    }
                }
            }
            else
            {
                //Lấy đối tượng truyện có mã Id = giá trị của StoryId thuộc đối tượng Chương
                var story = db.Stories.Find(chapter.StoryId);
                if (story != null)
                {
                    chapter.Story = story;
                }
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
