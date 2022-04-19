using System;
using System.Collections.Generic;
using System.Text;

namespace VNStory.Web.Models
{

    /// <summary>
    /// Truyện Yêu Thích
    /// </summary>
    public class Bookmark : BaseEntity
    {
        /// <summary>
        /// Mã thành viên
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Mã Truyện
        /// </summary>
        public int StoryId { get; set; } = 0;

        /// <summary>
        /// Mã Chương
        /// </summary>
        public int ChapterId { get; set; } = 0;

        ///// <summary>
        ///// Đối tượng Truyện
        ///// </summary>
        //public virtual Story Story { get; set; }

        ///// <summary>
        ///// Đối tượng Chương
        ///// </summary>
        //public virtual Chapter Chapter { get; set; }
    }
}
