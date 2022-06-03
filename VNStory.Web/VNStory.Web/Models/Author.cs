 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VNStory.Web.Commons;

namespace VNStory.Web.Models
{

    /// <summary>
    /// Thể loại truyện
    /// </summary>
    public class Author : BaseEntity
    {
        /// <summary>
        /// Tên thể loại
        /// </summary>
        [Display(Name = "Tên tác giả")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Tiểu sử tác giả")]
        public string Biography { get; set; } = string.Empty;

        /// <summary>
        /// Tên tiếng việt không dấu (hỗ trợ Url thân thiện)
        /// </summary>
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// Thứ tự hiển thị
        /// </summary>
        [Display(Name = "Tuổi")]
        public int Index { get; set; } = 0;

        /// <summary>
        /// Đường dẫn ảnh đại diện
        /// </summary>
        [DataType(DataType.Upload)]
        [Display(Name = "Ảnh đại diện")]
        public string ImagePath { get; set; } = string.Empty;

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
                    valReturn = Uri.EscapeDataString(Globals.ApplicationPath + "/Uploads/" + Utils.FolderAuthorImage);
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

    }
}

