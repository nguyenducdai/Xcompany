using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using Portal.Data;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly PortalDatabaseContext _context;

        public HomeController(PortalDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var menu = _context.MenuItems;
            return View(menu);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
