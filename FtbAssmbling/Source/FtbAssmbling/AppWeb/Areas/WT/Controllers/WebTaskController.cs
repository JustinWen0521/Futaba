using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ftd.data;
using ftd.query.model;
using ftd.service;
using ftd.nsql;
using ftd.mvc.Controllers;

namespace ftd.mvc.Areas.WT.Controllers
{
    public class WebTaskController : AppBaseController
    {

        #region [WTP010 - 工作排程管理]
        public ActionResult WTP010()
        {
            //var qm = new WtScheduleTaskQryModel();
            //var bln = this.TryUpdateModel(qm);
            //ViewBag.RequestKey = qm.RequestKey;
            return View();
        }

        //[ValidateAntiForgeryToken]
        public ActionResult WTP010Edit(string id)
        {
            var viewMode = "update";
            WT_ScheduleTaskRow row = null;
            if (id.isNullOrEmpty())
            {
                row = WtDataService.Instance.WtScheduleTask_create().FirstRow;
                viewMode = "create";
            }
            else
            {
                row = WtDataService.Instance.WtScheduleTask_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }
        #endregion

        #region [WTP011 - 工作排程時間]
        public ActionResult WTP011Create(string taskId)
        {
            var viewMode = "update";
            var dt = WtDataService.Instance.WtScheduleDate_createWithTaskId(taskId);
            var row = dt.FirstRow;
            row.WTSD_ScheduleTaskId = taskId;
            row.WTSD_EveryDayHour = 0;
            row.WTSD_EveryDayMiniute = 0;
            viewMode = "create";
            ViewBag.ViewMode = viewMode;
            return View("WTP011Edit", row);
        }

        //[ValidateAntiForgeryToken]
        public ActionResult WTP011Edit(string id)
        {
            var viewMode = "update";
            WT_ScheduleDateRow row = null;
            if (id.isNullOrEmpty())
            {
                row = WtDataService.Instance.WtScheduleDate_create().FirstRow;
                viewMode = "create";
            }
            else
            {
                row = WtDataService.Instance.WtScheduleDate_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }
        #endregion

        #region [WTI010 - 系統事件查詢]
        public ActionResult WTI010()
        {
            //var qm = new EoUserEventLogQryModel();
            //qm.Q_EventDateFrom = DateTime.Today;
            //qm.Q_EventDateTo = DateTime.Today;
            //return View(qm);
            return View();
        }

        //[ValidateAntiForgeryToken]
        public ActionResult WTI010Edit(string id)
        {
            var viewMode = "update";
            EO_UserEventLogRow row = null;
            if (id.isNullOrEmpty())
            {
                row = EoDataService.Instance.EoUserEventLog_create().FirstRow;
                viewMode = "create";
            }
            else
            {
                row = EoDataService.Instance.EoUserEventLog_getById(id).FirstRow;
                viewMode = "update";
            }
            ViewBag.ViewMode = viewMode;
            return View(row);
        }
        #endregion
    }
}
