using System;
using System.Collections.Generic;
using System.Text;

namespace VNStory.Web.Models
{
    public class Chapter : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int StoryId { get; set; } = 0;
        public int NumberChapter { get; set; } = 0;
        public string Link { get; set; } = string.Empty;
        public virtual Story Story { get; set; }
    }
}
