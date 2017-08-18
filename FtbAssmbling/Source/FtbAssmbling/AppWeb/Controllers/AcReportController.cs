using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ftd.mvc.Controllers
{
    /// <summary>
    /// AC 市議員備詢管理系統
    /// </summary>
    public class AcReportController : AppBaseController
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
