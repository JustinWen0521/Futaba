using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ftd.web;
using System.Collections.Generic;

namespace ftd.report
{
    public abstract class AppWebReportTask : FtdWebReportTask
    {
        protected override string getTaskHandlerUrl()
        {
            return FtdWebHelper.resolveUrl("~/webpage_public/AppReportHandler.aspx");           
        }

        /// <summary>
        /// 紀錄報表完成
        /// </summary>
        protected override void onClientDisplayOk()
        {
            //base.onClientDisplayOk();
        }             
    }
}
