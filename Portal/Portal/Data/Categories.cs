using System;
using System.Collections.Generic;

namespace Portal.Data
{
    public partial class Categories
    {
        public Categories()
        {
            Posts = new HashSet<Posts>();
        }

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

        public ICollection<Posts> Posts { get; set; }
    }
}
