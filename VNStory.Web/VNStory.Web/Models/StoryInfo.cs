using System;

namespace VNStory.Web.Models
{
    public class StoryInfo
    {
        public StoryInfo()
        {
            CreatedOnDate = System.DateTime.Now;
            LastModifiedOnDate = System.DateTime.Now;
        }

        public int Id { get; set; } = 0;

        public int CatId { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public int Views { get; set; } = 0;

        public DateTime CreatedOnDate { get; private set; }

        public DateTime LastModifiedOnDate { get; private set; }

    }
}
