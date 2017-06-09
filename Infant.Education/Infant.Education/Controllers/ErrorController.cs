﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infant.Education.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/
        public ActionResult Index(HandleErrorInfo handleError, bool isCustomError = false)
        {
            ViewBag.IsDebug = HttpContext.IsDebuggingEnabled;
            ViewBag.IsCustomError = isCustomError;
            return View(handleError);
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}