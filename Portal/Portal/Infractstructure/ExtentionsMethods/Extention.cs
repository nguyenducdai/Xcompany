using Portal.Areas.CPortal.Models;
using Portal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Infractstructure.ExtentionsMethods
{
    public static class Extention
    {
        // update menu extention method 
        public static void UpdateMenu(this Menus menu, MenuViewModel menuVM)
        {
            menu.Id = menuVM.Id;
            menu.Name = menu.Name;
            menu.Status = menu.Status;
            menu.CreateAt = menu.CreateAt;
            menu.UpdateAt = menu.UpdateAt;
        }
    }
}
