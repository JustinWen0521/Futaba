using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ftd.data;
using ftd.nsql;
using ftd.service;
using ftd.query.model;
using ftd.mvc.Extensions;
using ftd.mvc.Controllers;
using ftd.report;

namespace ftd.mvc.Areas.CR.Controllers
{
    public class CrReportController : AppBaseController
    {
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CRR010(FormCollection collection)
        {
            //查詢參數
            var token = collection["__RequestVerificationToken"];

            //塞入查詢參數
            var qm = new CrRegistrationQryModel();
            var isOK = this.TryUpdateModel(qm);

            qm.ReportId = "CRR010";
            qm.ExportName = "CRR010_教育訓練學員名冊.xlsx";
            qm.ReportSourceType = 0;
            qm.ReportType = FtbReportTypes.Xlsx;

            //直接列印
            string contentType = qm.ReportType.ToString(); 

            //取得報表資訊
            var rawData = CrReportService.Instance.CRR010(qm, ref contentType);
            if (rawData == null)
            {
                return View("NoData");
            }
            return File(rawData, contentType, qm.ExportName);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CRR020(FormCollection collection)
        {
            //查詢參數
            var token = collection["__RequestVerificationToken"];

            //塞入查詢參數
            var qm = new CrRegistrationQryModel();
            var isOK = this.TryUpdateModel(qm);

            qm.ReportId = "CRR020";
            qm.ExportName = "CRR020_教育訓練簽到表.xlsx";
            qm.ReportSourceType = 0;
            qm.ReportType = FtbReportTypes.Xlsx;

            //直接列印
            string contentType = qm.ReportType.ToString(); 

            //取得報表資訊
            var rawData = CrReportService.Instance.CRR020(qm, ref contentType);
            if (rawData == null)
            {
                return View("NoData");
            }
            return File(rawData, contentType, qm.ExportName);
        }        
    }
}
