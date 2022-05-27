using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VNStory.Web.Commons;

namespace VNStory.Web.Models
{
    /// <summary>
    /// Đối tượng Truyện
    /// </summary>
    public class Story : BaseEntity
    {
        /// <summary>
        /// Tên truyện
        /// </summary>
        [Display(Name = "Tên truyện")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Tên tiếng việt không dấu (hỗ trợ Url thân thiện)
        /// </summary>
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// Trạng thái của truyện
        /// </summary>
        [Display(Name = "Trạng thái")]
        public int Status { get; set; } = -1;

        /// <summary>
        /// Số lượt xem
        /// </summary>
        [Display(Name = "Lượt xem")]
        public int Views { get; set; } = 0;

        /// <summary>
        /// Tổng số Chương
        /// </summary>
        public int TotalChapter { get; set; } = 0;

        /// <summary>
        /// Hình ảnh đại diện
        /// </summary>
        [DataType(DataType.Upload)]
        [Display(Name = "Ảnh đại diện")]
        public string ImagePath { get; set; } = string.Empty;


        /// <summary>
        /// Thứ tự hiển thị
        /// </summary>
        [Display(Name = "Thứ tự hiển thị")]
        public int Index { get; set; } = 0;

        /// <summary>
        /// Url của hình ảnh
        /// </summary>
        public string ImageUrl
        {
            get
            {
                string valReturn = string.Empty;
                if (string.IsNullOrEmpty(ImagePath) == false)
                {
                    valReturn = Globals.ApplicationPath + "/Uploads/Images/" + ImagePath;
                }
                return valReturn;
            }
        }

        /// <summary>
        /// Thứ tự hiển thị
        /// </summary>
        [NotMapped]
        [Display(Name = "Xóa ảnh hiển thị")]
        public bool RemoveImage { get; set; } = false;


        /// <summary>
        /// Nguồn truyện
        /// </summary>
        [Display(Name = "Nguồn truyện")]
        public string Source { get; set; } = string.Empty;

        /// <summary>
        /// Mổ tả Truyện
        /// </summary>
        [Display(Name = "Mô tả")]
        public string Description { get; set; } = string.Empty;

        ///// <summary>
        ///// Mã tác giả
        ///// </summary>
        //public int AuthorId { get; set; } = 0;

        ///// <summary>
        ///// Đối tượng Tác Giả
        ///// </summary>
        //public virtual Author Author { get; set; }

        ///// <summary>
        ///// Danh sách các Chương
        ///// </summary>
        //public virtual ICollection<Chapter> Chapters { get; set; }

        ///// <summary>
        ///// Danh sách các Thể loại
        ///// </summary>
        //public virtual ICollection<Category> Categories { get; set; }

        ///// <summary>
        ///// Danh sách Yêu Thích
        ///// </summary>
        //public virtual ICollection<Bookmark> Bookmarks { get; set; }

    }
}

