using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ftd.mvc.Extensions
{
    public enum FtdStatus
    {
        InsertSuccess,
        InsertFail,
        UpdateSuccess,
        UpdateFail,
        DeleteSuccess,
        DeleteFail
    }

    public class FwbMenu
    {
        public int level;
        public string title;
        public string parentTitle;
    }
}
