﻿using System;
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
            //Danh sách trạng thái truyện hiển thị cho người dùng chọn
            List<SelectListItem> listTrangThai = new List<SelectListItem>();

            //Khai báo biến phần tử trạng thái truyện
            SelectListItem selectListItem;

            //Duyệt các phần tử trạng thái truyện
            foreach (int item in Enum.GetValues(typeof(StatusInfor)))
            {
                //Khởi tạo phần tử trạng thái
                selectListItem = new SelectListItem();

                //Câu lệnh kiểm tra có điều kiện
                //Gán  giá trị cho phần tử trạng thái
                if (item == 0)//Nếu
                {
                    //Gán giá trị
                    selectListItem.Value = item.ToString();

                    //Gán nhãn
                    selectListItem.Text = "Mới cập nhật";
                }
                else if (item == 1)//Không thì nếu
                {
                    //Gán giá trị
                    selectListItem.Value = item.ToString();

                    //Gán nhãn
                    selectListItem.Text = "Yêu thích";
                }
                else if (item == 2)//Không thì nếu
                {
                    //Gán giá trị
                    selectListItem.Value = item.ToString();

                    //Gán nhãn
                    selectListItem.Text = "Đọc nhiều";
                }
                else if (item == 3)//Không thì nếu
                {
                    //Gán giá trị
                    selectListItem.Value = item.ToString();

                    //Gán nhãn
                    selectListItem.Text = "Hoàn thành";
                }

                //Kiểm tra trong list trạng thái xem đã thêm phần tử trạng thái vào hay chưa
                //Nếu chưa có thì thêm vào, có rồi thì bỏ qua
                if(listTrangThai.Any(p => p.Value == selectListItem.Value) == false)
                {
                    //Thêm phần tử trạng thái vào danh sách
                    listTrangThai.Add(selectListItem);
                }

            }

            //Lưu vào State của Server để hiển thị trên View
            //ViewBag.ListTrangThai = listTrangThai;
            ViewBag.ListTrangThai = new SelectList(listTrangThai, "Value", "Text");



            //List<SelectListItem> authorlist = new List<SelectListItem>();
            //authorlist.Add(new SelectListItem { Text = "Nguyễn Văn A", Value = "0" });
            //authorlist.Add(new SelectListItem { Text = "Nguyễn Văn B", Value = "1" });
            //authorlist.Add(new SelectListItem { Text = "Nguyễn Văn C", Value = "2", Selected = true });
            //authorlist.Add(new SelectListItem { Text = "Nguyễn Văn D", Value = "3" });                       
            //ViewBag.Authorlist = new SelectList(authorlist, "Value", "Text");




            return View();
        }

        [HttpPost]
        public ActionResult Create(Story storyItem)
        {
            if (ModelState.IsValid)
            {
                db.Stories.Add(storyItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            //Lấy bản ghi có Id = giá trị của param (biến, tham số) Id
            var storyItem = db.Stories.Find(id);

            if (storyItem == null)
            {
                return HttpNotFound();
            }

            #region Danh sách trạng thái truyện

            //Danh sách trạng thái truyện hiển thị cho người dùng chọn
            List<SelectListItem> listTrangThai = new List<SelectListItem>();

            //Khai báo biến phần tử trạng thái truyện
            SelectListItem selectListItem;

            //Duyệt các phần tử trạng thái truyện
            foreach (int item in Enum.GetValues(typeof(StatusInfor)))
            {
                //Khởi tạo phần tử trạng thái
                selectListItem = new SelectListItem();

                //Câu lệnh kiểm tra có điều kiện
                //Gán  giá trị cho phần tử trạng thái
                if (item == 0)//Nếu
                {
                    //Gán giá trị
                    selectListItem.Value = item.ToString();

                    //Gán nhãn
                    selectListItem.Text = "Mới cập nhật";
                }
                else if (item == 1)//Không thì nếu
                {
                    //Gán giá trị
                    selectListItem.Value = item.ToString();

                    //Gán nhãn
                    selectListItem.Text = "Yêu thích";
                }
                else if (item == 2)//Không thì nếu
                {
                    //Gán giá trị
                    selectListItem.Value = item.ToString();

                    //Gán nhãn
                    selectListItem.Text = "Đọc nhiều";
                }
                else if (item == 3)//Không thì nếu
                {
                    //Gán giá trị
                    selectListItem.Value = item.ToString();

                    //Gán nhãn
                    selectListItem.Text = "Hoàn thành";
                }

                //Kiểm tra trong list trạng thái xem đã thêm phần tử trạng thái vào hay chưa
                //Nếu chưa có thì thêm vào, có rồi thì bỏ qua
                if (listTrangThai.Any(p => p.Value == selectListItem.Value) == false)
                {
                    //Thêm phần tử trạng thái vào danh sách
                    listTrangThai.Add(selectListItem);
                }

            }

            //Lưu vào State của Server để hiển thị trên View
            //ViewBag.ListTrangThai = listTrangThai;
            ViewBag.ListTrangThai = new SelectList(listTrangThai, "Value", "Text");

            #endregion

            return View(storyItem);
        }

        /// <summary>
        /// Cập Nhật Truyện
        /// </summary>
        /// <param name="Story"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Status,Views,Image,Source,Description")] Story Story)
        {
            //Kiểm tra dữ liệu trước khi lưu vào cơ sở dữ liệu
            if (ModelState.IsValid)//Nếu hợp lệ
            {
                //Truyền vào đối tượng truyện cho db context
                db.Entry(Story).State = EntityState.Modified;

                //Lưu vào cơ sở dữ liệu
                db.SaveChanges();

                //Chuyển về trang danh sách truyện
                return RedirectToAction("Index");
            }

            //Nếu có lỗi (không hợp lệ) khi kiểm tra dữ liệu trước khi lưu thì vẫn ở trang hiện tại (trang chỉnh sửa truyện)            
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
        public ActionResult Delete(Story storyItem)
        {
            if (ModelState.IsValid)
            {
                var myStoryItem = db.Stories.Find(storyItem.Id);
                db.Stories.Remove(myStoryItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storyItem);
        }
    }
}
