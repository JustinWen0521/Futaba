using System;
using System.Collections.Generic;
using System.Text;
using ftd.service;
using ftd.dataaccess;
using ftd.data;

namespace ftd.report
{
    /// <summary>
    /// 站存檔
    /// </summary>
    public class AppTempFileDownloadTask : AppWebReportTask
    {
        protected override void createReportFile(out string reportFile, out string displayName)
        {
            string folderName = FtdConfigService.Instance.getAppSettingValue("WebData") + @"\temp";
            displayName = DisplayName;
            reportFile = folderName + @"\" + StorageName;
        }

        protected string DisplayName;
        protected string StorageName;     
        /// <summary>
        /// 設定報表參數
        /// </summary>            
        public AppWebReportTask Set(string displayName, string storageName)
        {
            DisplayName = displayName;
            StorageName = storageName;
            return this;
        }

        public override List<string> getReportParameter()
        {
            List<string> strs = new List<string>();
            strs.Add(DisplayName);
            strs.Add(StorageName);
            return strs;
        }

        public override void setReportParameter(List<string> parameters)
        {
            DisplayName = parameters[0];
            StorageName = parameters[1];
        }
    }
}
