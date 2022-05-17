using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VNStory.Web.Commons;
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
            //Kiểm tra lỗi, nếu ok thì tiếp tục thực hiện, không thì chuyển về trang danh sách các thể loại
            if (ModelState.IsValid)
            {
                //Tạo thư mục
                //string path = HttpContext.Server.MapPath("~/Uploads/");
                string path = Path.Combine(Globals.UploadFolderMapPath, "Images");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //Kiểm tra xem có file tải lên server hay không
                if (HttpContext.Request.Files.Count > 0)
                {
                    //Lấy file từ client gửi lên
                    HttpPostedFileBase postedFile = HttpContext.Request.Files[0];

                    //Lấy tên file
                    string fileName = Path.GetFileName(postedFile.FileName);

                    //Lưu ở máy chủ (Server)
                    postedFile.SaveAs(Path.Combine(path, fileName));

                    //Gán tên file vào đối tượng category
                    categoryItem.ImagePath = fileName;
                }

                //Tạo chuỗi tiếng việt không dấu từ tên thê loại
                categoryItem.Slug = Globals.CreateSlug(categoryItem.Name);

                //Thêm vào danh sách thể loại
                db.Categories.Add(categoryItem);

                //Lưu vào cơ sở dữ liệu
                db.SaveChanges();

                //Chuyển vê trang danh sách thể loạih
                return RedirectToAction("Index");
            }

            //Chuyển vê trang danh sách thể loạih
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
        public ActionResult Edit([Bind(Include = "Id,Name,Index,ImagePath,RemoveImage")] Category categoryItem)
        {
            if (ModelState.IsValid)
            {
                //string path = HttpContext.Server.MapPath("~/Uploads/");
                string path = Path.Combine(Globals.UploadFolderMapPath, "Images");
                if (categoryItem.RemoveImage == true)
                {
                    if (string.IsNullOrEmpty(categoryItem.ImagePath) == false)
                    {
                        if (System.IO.File.Exists(Path.Combine(path, categoryItem.ImagePath)))
                        {
                            System.IO.File.Delete(Path.Combine(path, categoryItem.ImagePath));
                        }
                        categoryItem.ImagePath = string.Empty;
                    }

                }
                else
                {

                    if (HttpContext.Request.Files.Count > 0)
                    {

                        HttpPostedFileBase postedFile = HttpContext.Request.Files[0];

                        string fileName = Path.GetFileName(postedFile.FileName);

                        postedFile.SaveAs(Path.Combine(path, fileName));

                        categoryItem.ImagePath = fileName;

                    }
                }
                categoryItem.Slug = Globals.CreateSlug(categoryItem.Name);

                db.Entry(categoryItem).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(categoryItem).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(categoryItem);
        //}

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
                string path = Path.Combine(Globals.UploadFolderMapPath, "Images");
                if (string.IsNullOrEmpty(categoryItem.ImagePath) == false)
                {
                    if (System.IO.File.Exists(Path.Combine(path, categoryItem.ImagePath)))
                    {
                        System.IO.File.Delete(Path.Combine(path, categoryItem.ImagePath));
                    }
                }
                var myCategoryItem = db.Categories.Find(categoryItem.Id);
                db.Categories.Remove(myCategoryItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryItem);
        }
    }
}
