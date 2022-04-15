using System;
using System.Collections.Generic;
using System.Text;

namespace VNStory.Web.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public int Level { get; set; } = 0;

        public int Index { get; set; } = 0;

        public int ParentId { get; set; } = 0;
    }
}
