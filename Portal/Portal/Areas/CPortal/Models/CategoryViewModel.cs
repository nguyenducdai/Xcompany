using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.CPortal.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageIcon { get; set; }
        public int? ParentId { get; set; }
        public string Alias { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public string SubText { get; set; }
        public string ParentName { get; set; }

    }
}
