using System;
using System.Collections.Generic;

namespace Portal.Data
{
    public partial class Menus
    {
        public Menus()
        {
            MenuItems = new HashSet<MenuItems>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public ICollection<MenuItems> MenuItems { get; set; }
    }
}
