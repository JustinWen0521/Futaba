using ftd.mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ftd.mvc.Areas.WT.Controllers
{
    public class WtReportController : AppBaseController
    {
        //
        // GET: /WtReport/

        public ActionResult Index()
        {
            return View();
        }

    }
}
