using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ftd.report;

namespace ftd.query.model
{
    public class AppQryModel
    {
        public AppQryModel()
        {
        }

        public string RequestKey { get; set; }

        ///// <summary>
        ///// 機關代碼
        ///// </summary>
        //public string Q_EnterOrgId { get; set; }
        ///// <summary>
        ///// 機關簡稱
        ///// </summary>
        //public string Q_EnterOrgSName { get; set; }
        ///// <summary>
        ///// 機關全銜
        ///// </summary>
        //public string Q_EnterOrgAName { get; set; }
        ///// <summary>
        ///// 權屬
        ///// </summary>
        //public string Q_Ownership { get; set; }

        ///// <summary>
        ///// 儲存位置(Partition)
        ///// </summary>
        //public string StoreLoc { get; set; }

        public string Q_CreatorId { get; set; }
        public string Q_CreatorCode_XX { get; set; }
        public string Q_CreatorName_XX { get; set; }
        public DateTime? Q_CreateDate { get; set; }
        public DateTime? Q_CreateDateFrom { get; set; }
        public DateTime? Q_CreateDateTo { get; set; }

        public string Q_UpdaterId { get; set; }
        public string Q_UpdaterCode_XX { get; set; }
        public string Q_UpdaterName_XX { get; set; }
        public DateTime? Q_UpdateDate { get; set; }
        public DateTime? Q_UpdateDateFrom { get; set; }
        public DateTime? Q_UpdateDateTo { get; set; }

        /// <summary>
        /// 報表類型
        /// </summary>
        public FtbReportTypes ReportType { get; set; }
        /// <summary>
        /// 報表代號
        /// </summary>
        public string ReportId { get; set; }
        /// <summary>
        /// 下載檔案名稱
        /// </summary>
        public string ExportName { get; set; }
        /// <summary>
        /// 報表來源 0:RDLC 1:iTextSharp 2:NPOI
        /// </summary>
        public int ReportSourceType { get; set; }
        /// <summary>
        /// 報表列印方式 D：直接下載，S：排程
        /// </summary>
        public string ReportPrintMethod { get; set; }
        /// <summary>
        /// 報表排程日期，民國年 yyyMMdd
        /// </summary>
        public string ReportScheduleDate { get; set; }
        /// <summary>
        /// 報表排程時間 - 小時
        /// </summary>
        public int ReportScheduleHour { get; set; }
        /// <summary>
        /// 報表排程時間 - 分鐘
        /// </summary>
        public int ReportScheduleMin { get; set; }
        /// <summary>
        /// 前端顯示訊息
        /// </summary>
        public string ClientMessage { get; set; }
    }
}
