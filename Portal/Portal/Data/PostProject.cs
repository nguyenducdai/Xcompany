using System;
using System.Collections.Generic;

namespace Portal.Data
{
    public partial class PostProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descaption { get; set; }
        public string HtmlBody { get; set; }
        public string Image { get; set; }
        public string Alias { get; set; }
        public bool? HomeFlag { get; set; }
        public string MoreImage { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string CreadeBy { get; set; }
        public string UpdateBy { get; set; }
        public bool? Status { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescaption { get; set; }
        public int? ProjectCategoryId { get; set; }
        public int? ReviewId { get; set; }

        public ProjectCategoreis ProjectCategory { get; set; }
        public Review Review { get; set; }
    }
}
