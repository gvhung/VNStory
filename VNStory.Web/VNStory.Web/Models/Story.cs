using System;
using System.Collections.Generic;
using System.Text;

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
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Tên tiếng việt không dấu (hỗ trợ Url thân thiện)
        /// </summary>
        public string Slug { get; set; } = string.Empty;
        
        /// <summary>
        /// Trạng thái của truyện
        /// </summary>
        public int Status { get; set; } = -1;
        
        /// <summary>
        /// Số lượt xem
        /// </summary>
        public int Views { get; set; } = 0;
        
        /// <summary>
        /// Tổng số Chương
        /// </summary>
        public int TotalChapter { get; set; } = 0;
        
        /// <summary>
        /// Hình ảnh đại diện
        /// </summary>
        public string Image { get; set; } = string.Empty;
        
        /// <summary>
        /// Nguồn truyện
        /// </summary>
        public string Source { get; set; } = string.Empty;
        
        /// <summary>
        /// Mổ tả Truyện
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Mã tác giả
        /// </summary>
        public int AuthorId { get; set; } = 0;

        /// <summary>
        /// Đối tượng Tác Giả
        /// </summary>
        public virtual Author Author { get; set; }
        
        /// <summary>
        /// Danh sách các Chương
        /// </summary>
        public virtual ICollection<Chapter> Chapters { get; set; }
        
        /// <summary>
        /// Danh sách các Thể loại
        /// </summary>
        public virtual ICollection<Category> Categories { get; set; }

        /// <summary>
        /// Danh sách Yêu Thích
        /// </summary>
        public virtual ICollection<Bookmark> Bookmarks { get; set; }

    }
}
