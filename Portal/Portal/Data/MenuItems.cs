using System;
using System.Collections.Generic;

namespace Portal.Data
{
    public partial class MenuItems
    {
        public int Id { get; set; }
        public int? MenuId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string DataJson { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public Menus Menu { get; set; }
    }
}
