﻿using System;
using System.Collections.Generic;
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
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Tên tiếng việt không dấu (hỗ trợ Url thân thiện)
        /// </summary>
        public string Slug { get; set; } = string.Empty;
        
        /// <summary>
        /// Nội dung truyện
        /// </summary>
        public string Content { get; set; } = string.Empty;
                
        /// <summary>
        /// Số Chương
        /// </summary>
        public int NumberChapter { get; set; } = 0;

        /// <summary>
        /// Mã Truyện
        /// </summary>
        public int StoryId { get; set; } = 0;

        /// <summary>
        /// Đối tượng Truyện
        /// </summary>
        public virtual Story Story { get; set; }

        ///// <summary>
        ///// Danh sách Yêu Thích
        ///// </summary>
        //public virtual ICollection<Bookmark> Bookmarks { get; set; }
    }
}
