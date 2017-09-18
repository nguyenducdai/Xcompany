using System;
using System.Collections.Generic;

namespace Portal.Data
{
    public partial class Review
    {
        public Review()
        {
            PostProject = new HashSet<PostProject>();
        }

        public int Id { get; set; }
        public string Content { get; set; }

        public ICollection<PostProject> PostProject { get; set; }
    }
}
