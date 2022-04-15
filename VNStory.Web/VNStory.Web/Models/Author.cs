﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VNStory.Web.Models
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
    }
}
