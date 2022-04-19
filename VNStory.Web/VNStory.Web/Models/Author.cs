using System;
using System.Collections.Generic;
using System.Text;

namespace VNStory.Web.Models
{
    /// <summary>
    /// Tác giả
    /// </summary>
    public class Author : BaseEntity
    {
        /// <summary>
        /// Tên Tác Giả
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Danh sách truyện
        /// </summary>
        public virtual ICollection<Story> Stories { get; set; }
    }
}
