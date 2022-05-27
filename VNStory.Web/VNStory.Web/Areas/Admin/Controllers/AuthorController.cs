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
    public class AuthorController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()       
        {
            return View(db.Authors.ToList());
        }

        public ActionResult Details(int id)
        {
            var role = db.Authors.Find(id);
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
        public ActionResult Create(Author authorItem)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Request.Files.Count > 0)
                {                    
                    HttpPostedFileBase postedFile = HttpContext.Request.Files[0];

                    if (postedFile != null && postedFile.ContentLength > 0)
                    {
                        string path = Path.Combine(Globals.UploadFolderMapPath, Utils.FolderAuthorImage);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        string fileName = Path.GetFileName(postedFile.FileName);

                        postedFile.SaveAs(Path.Combine(path, fileName));

                        authorItem.ImagePath = fileName;
                    }                        
                }

                authorItem.Slug = Globals.CreateSlug(authorItem.Name);

                db.Authors.Add(authorItem);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var authorItem = db.Authors.Find(id);
            if (authorItem == null)
            {
                return HttpNotFound();
            }
            return View(authorItem);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Biography,Index,ImagePaths,RemoveImage")] Author authorItem)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Globals.UploadFolderMapPath, Utils.FolderAuthorImage);

                if (authorItem.RemoveImage == true)
                {
                    if (string.IsNullOrEmpty(authorItem.ImagePath) == false)
                    {
                        if (System.IO.File.Exists(Path.Combine(path, authorItem.ImagePath)))
                        {
                            System.IO.File.Delete(Path.Combine(path, authorItem.ImagePath));
                        }
                        authorItem.ImagePath = string.Empty;
                    }

                }
                else
                {

                    if (HttpContext.Request.Files.Count > 0)
                    {
                        HttpPostedFileBase postedFile = HttpContext.Request.Files[0];

                        if (postedFile != null && postedFile.ContentLength > 0)
                        {
                            string fileName = Path.GetFileName(postedFile.FileName);

                            postedFile.SaveAs(Path.Combine(path, fileName));

                            authorItem.ImagePath = fileName;

                        }
                    }
                }
                authorItem.Slug = Globals.CreateSlug(authorItem.Name);

                db.Entry(authorItem).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var role = db.Authors.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [HttpPost]
        public ActionResult Delete(Author authorItem)
        {
            if (ModelState.IsValid)
            {                
                if (string.IsNullOrEmpty(authorItem.ImagePath) == false)
                {
                    string path = Path.Combine(Globals.UploadFolderMapPath, Utils.FolderAuthorImage);

                    if (System.IO.File.Exists(Path.Combine(path, authorItem.ImagePath)))
                    {
                        System.IO.File.Delete(Path.Combine(path, authorItem.ImagePath));
                    }
                }
                var myAuthorItem = db.Authors.Find(authorItem.Id);
                db.Authors.Remove(myAuthorItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorItem);
        }
    }
}