using System;
using System.Collections.Generic;
using System.Text;

namespace VNStory.Web.Models
{
    public class Subscription : BaseEntity
    {
        public Guid UserId { get; set; }
        public int StoryId { get; set; }
        public int ChapterId { get; set; }
        public bool IsNewest { get; set; }
    }
}
