﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBridge.Controllers
{
    public class GallaryController : Controller
    {
        // GET: Gallary
        public ActionResult Index()
        {
            return View("Maintenance");
        }
    }
}