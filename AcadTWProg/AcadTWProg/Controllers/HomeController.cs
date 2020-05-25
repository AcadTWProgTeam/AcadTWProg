﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AcadTWProg.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }
    }
}
