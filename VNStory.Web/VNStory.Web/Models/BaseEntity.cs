using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VNStory.Web.Models
{
    public class BaseEntity
    {        
        /// <summary>
        /// Mã đối tượng
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Tạo bởi
        /// </summary>
        public Guid CreatedBy { get; set; }
        
        /// <summary>
        /// Sửa đổi bởi
        /// </summary>
        public Guid ModifiedBy { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        /// <summary>
        /// Ngày sửa đổi
        /// </summary>
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
