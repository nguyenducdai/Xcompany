using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.CPortal.Controllers
{
    [Area("CPortal")]
    public class CPortalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}