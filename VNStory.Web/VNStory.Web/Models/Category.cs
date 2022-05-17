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
    public class Category : BaseEntity
    {
        /// <summary>
        /// Tên thể loại
        /// </summary>
        [Display(Name = "Tên thể loại")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Tên tiếng việt không dấu (hỗ trợ Url thân thiện)
        /// </summary>
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// Thứ tự hiển thị
        /// </summary>
        [Display(Name = "Thứ tự hiển thị")]
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

    }
}
