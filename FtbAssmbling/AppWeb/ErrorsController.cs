﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ftd.mvc
{
    public class ErrorsController : Controller
    {
        public ActionResult General(Exception exception)
        {
            return View("Exception", exception);
        }

        public ActionResult Http404()
        {
            return View("404");
        }

        public ActionResult Http403()
        {
            return View("403");
        }
    }
}
