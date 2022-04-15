using System;
using System.Collections.Generic;
using System.Text;

namespace VNStory.Web.Models
{
    public class Reading : BaseEntity
    {
        public Guid UserId { get; set; }
        public int StoryId { get; set; } = 0;
        public int ChapterId { get; set; } = 0;
    }
}
