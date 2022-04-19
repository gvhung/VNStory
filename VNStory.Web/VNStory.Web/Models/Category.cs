using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
        [Display(Name = "Ảnh đại diện")]
        public string ImagePath { get; set; } = string.Empty;

    }
}
