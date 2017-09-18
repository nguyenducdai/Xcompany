using System;
using System.Collections.Generic;

namespace Portal.Data
{
    public partial class Posts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public string Alias { get; set; }
        public string Descaption { get; set; }
        public string BodyContent { get; set; }
        public string Image { get; set; }
        public bool? HomeFlag { get; set; }
        public int? ViewCount { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }

        public Categories Category { get; set; }
    }
}
