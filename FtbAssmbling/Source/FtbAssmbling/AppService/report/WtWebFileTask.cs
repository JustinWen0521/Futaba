using System;
using System.Collections.Generic;
using System.Text;
using ftd.web;
using ftd.dataaccess;
using ftd.data;
using ftd.service;
using ftd.nsql;

namespace ftd.report
{
    /// <summary>
    /// 檔案下載
    /// </summary>
    public class WtWebFileTask : FtdWebReportTask
    {
        protected override string getTaskHandlerUrl()
        {
            return FtdWebHelper.resolveUrl("~/AppReportHandler.aspx");
        }

        protected override void createReportFile(out string reportFile, out string displayName)
        {
            var rowf = NsDmHelper.WT_WebFile.wherepk(WTWF_WebFileId).selectAll(AppDataName.WTWF_StorageFullName_XX ).queryFirst();
            displayName = rowf.WTWF_FileName;
            reportFile = rowf.WTWF_StorageFullName_XX;
        }

        private string WTWF_WebFileId;
        public WtWebFileTask setWTWF_WebFileId(string fileId)
        {
            WTWF_WebFileId = fileId;
            return this;
        }

        public override List<string> getReportParameter()
        {
            List<string> list = new List<string>();
            list.Add(WTWF_WebFileId);
            return list;
        }

        public override void setReportParameter(List<string> parameters)
        {
            WTWF_WebFileId = parameters[0];
        }
    }
}
