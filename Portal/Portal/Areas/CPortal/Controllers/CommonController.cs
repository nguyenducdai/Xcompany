using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.CPortal.Controllers
{
    [Area("CPortal")]
    public class CommonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryList()
        {
            return View();
        }

        public IActionResult PostList()
        {
            return View();
        }
    }
}