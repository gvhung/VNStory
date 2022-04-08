using System;

namespace VNStory.Web.Models
{

    public class CategoryInfo
    {

        public CategoryInfo()
        {
            CreatedOnDate = System.DateTime.Now;
            LastModifiedOnDate = System.DateTime.Now;
        }

        public int Id { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string IconPath { get; set; } = string.Empty;

        public string IconBase64 { get; set; } = string.Empty;

        public int Ordering { get; set; } = 0;

        public int Stories { get; set; } = 0;

        public string Title
        {
            get
            {
                if (Id == 0)
                {
                    return Name;
                }
                else
                {
                    return Name + " (" + Stories + ")";
                }
            }
        }

        public DateTime CreatedOnDate { get; private set; }

        public DateTime LastModifiedOnDate { get; private set; }


    }
}
