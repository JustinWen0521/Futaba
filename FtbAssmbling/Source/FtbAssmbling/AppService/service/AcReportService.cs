using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ftd.nsql;
using ftd.data;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Reflection;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using System.Data.OracleClient;
using ftd.web;
using System.Web.Script.Serialization;

namespace ftd.service
{
    /// <summary>
    /// AC 市議員備詢管理系統
    /// </summary>
    public partial class AcReportService : AppReportService
    {
        public new static readonly AcReportService Instance;

        static AcReportService()
        {
            Instance = FtdCreatorService.Instance.createObject<AcReportService>();
        }

    }
}
