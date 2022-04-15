using System;
using System.Collections.Generic;
using System.Text;

namespace VNStory.Web.Models
{
    public class Story : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public int AuthorId { get; set; } = 0;
        public int Status { get; set; } = -1;
        public int Views { get; set; } = 0;
        public int TotalChapter { get; set; } = 0;
        public string Image { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual Author Author { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
