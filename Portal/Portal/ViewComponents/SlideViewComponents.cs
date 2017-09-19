﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.ViewComponents
{
    [ViewComponent(Name = "Slide")]
    public class SlideViewComponents:ViewComponent 
    { 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}