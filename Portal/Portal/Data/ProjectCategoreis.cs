using System;
using System.Collections.Generic;

namespace Portal.Data
{
    public partial class ProjectCategoreis
    {
        public ProjectCategoreis()
        {
            PostProject = new HashSet<PostProject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Descaption { get; set; }
        public string ImageIcon { get; set; }
        public int? ParentId { get; set; }
        public string Alias { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescaption { get; set; }

        public ICollection<PostProject> PostProject { get; set; }
    }
}
