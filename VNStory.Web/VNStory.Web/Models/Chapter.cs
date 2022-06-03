using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNStory.Web.Models
{
    /// <summary>
    /// Chương Truyện
    /// </summary>
    public class Chapter : BaseEntity
    {
        /// <summary>
        /// Tên Chương
        /// </summary>
        [Display(Name = "Tên Chương")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Tên tiếng việt không dấu (hỗ trợ Url thân thiện)
        /// </summary>
        [Display(Name = "")]
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// Nội dung truyện
        /// </summary>
        [Display(Name = "Nội Dung Truyện")]
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Số Chương
        /// </summary>
        [Display(Name = "Số Chương")]
        public int NumberChapter { get; set; } = 0;

        /// <summary>
        /// Mã Truyện
        /// </summary>
        [Display(Name = "Mã Truyện")]
        public int StoryId { get; set; } = 0;

        /// <summary>
        /// Đối tượng Truyện
        /// </summary>
        [Display(Name = "Đối Tượng Đọc")]
        public virtual Story Story { get; set; }

        ///// <summary>
        ///// Danh sách Yêu Thích
        ///// </summary>
        //public virtual ICollection<Bookmark> Bookmarks { get; set; }
    }
}
