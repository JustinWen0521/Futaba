using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ftd.nsql;
using ftd.data;
using Microsoft.Reporting.WebForms;
using System.Reflection;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using System.Data.OracleClient;
using ftd.web;
using System.Web.Script.Serialization;
using ftd.query.model;
using ftd.dataset;

namespace ftd.service
{
    /// <summary>
    /// CXR 教育訓練報名系統
    /// </summary>
    public partial class CrReportService : AppReportService
    {
        public new static readonly CrReportService Instance;

        static CrReportService()
        {
            Instance = FtdCreatorService.Instance.createObject<CrReportService>();
        }

        public override byte[] processReport<T>(T para)
        {
            if (para == null || para.ReportId.isNullOrEmpty())
                throw new Exception("無效的參數");

            string contentType = para.ReportType.ToString();
            byte[] rawData = null;

            switch (para.ReportId.ToUpper())
            {
                case "CRR010":  //學員名冊
                    var paraCRR010 = para as CrRegistrationQryModel;
                    if (paraCRR010 == null)
                        throw new Exception("無效的參數");
                    rawData = CRR010(paraCRR010, ref contentType);
                    break;
                case "CRR020":  //簽到表
                    var paraCRR020 = para as CrRegistrationQryModel;
                    if (paraCRR020 == null)
                        throw new Exception("無效的參數");
                    rawData = CRR020(paraCRR020, ref contentType);
                    break;
                case "CRR030":  //時數申報表
                    var paraCRR030 = para as CrRegistrationQryModel;
                    if (paraCRR030 == null)
                        throw new Exception("無效的參數");
                    rawData = CRR030(paraCRR030, ref contentType);
                    break;
                default:
                    throw new Exception("未定義的報表");
            }

            return rawData;
        }

        //學員名冊
        public byte[] CRR010(CrRegistrationQryModel qm, ref string contenttype)
        {
            var dt = NsDmHelper.CR_Registration
                .selectAll(t => t.AllExt)
                .where(t => t.CRR_CourseId_XX == qm.Q_CourseId.toConstReq1())
                .orderby(t => new[] {
                    t.CRR_ClassDate_XX.Asc,
                    t.CRR_ClassTime_XX.Asc,
                    t.CRR_CreateDate.Asc
                })
                .query();

            //無資料
            if (dt == null)
                dt = new CR_RegistrationDataTable();

            ReportViewer reportViewer1 = new ReportViewer();
            reportViewer1.LocalReport.DataSources.Clear();

            //取得報表檔組件
            var assembly = getReportAssembly();
            //取得報表定義檔
            var reportFile = string.Empty;
            reportFile = "CRR010Rpt.rdlc";
            Stream fileStream = assembly.GetManifestResourceStream("ftd.report." + reportFile);

            reportViewer1.LocalReport.LoadReportDefinition(fileStream);

            dt.TableName = "CR_Registration"; 
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource(dt.TableName, dt as DataTable));

            #region 報表參數設定
            var companyName = FtdConfigService.Instance.getAppSettingValue("CompanyName", "");
            var pCompanyName = new ReportParameter("P_CompanyName", companyName);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pCompanyName });
            #endregion

            Microsoft.Reporting.WebForms.Warning[] tWarnings;
            string[] tStreamids;
            string tMimeType;
            string tEncoding;
            string tExtension;
            string fileFormat = getPrintType(contenttype.ToLower());

            byte[] tBytes = reportViewer1.LocalReport.Render(fileFormat, "<DeviceInfo><AutoFit>Never</AutoFit></DeviceInfo>", out tMimeType, out tEncoding, out tExtension, out tStreamids, out tWarnings);
            contenttype = tMimeType;
            return tBytes;
        }

        //簽到表
        public byte[] CRR020(CrRegistrationQryModel qm, ref string contenttype)
        {
            var dt = NsDmHelper.CR_Registration
                .selectAll(t => t.AllExt)
                .where(t => 
                    t.CRR_CourseId_XX == qm.Q_CourseId.toConstReq1()
                    & t.CRR_ClassId == qm.Q_ClassId.toConstOpt1()
                )
                .orderby(t => new[] {
                    t.CRR_ClassDate_XX.Asc,
                    t.CRR_ClassTime_XX.Asc,
                    t.CRR_CreateDate.Asc
                })
                .query();

            //無資料
            if (dt == null)
                dt = new CR_RegistrationDataTable();

            ReportViewer reportViewer1 = new ReportViewer();
            reportViewer1.LocalReport.DataSources.Clear();

            //取得報表檔組件
            var assembly = getReportAssembly();
            //取得報表定義檔
            var reportFile = string.Empty;
            reportFile = "CRR020Rpt.rdlc";
            Stream fileStream = assembly.GetManifestResourceStream("ftd.report." + reportFile);

            reportViewer1.LocalReport.LoadReportDefinition(fileStream);

            dt.TableName = "CR_Registration";
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource(dt.TableName, dt as DataTable));

            #region 報表參數設定
            var companyName = FtdConfigService.Instance.getAppSettingValue("CompanyName", "");
            var pCompanyName = new ReportParameter("P_CompanyName", companyName);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pCompanyName });
            #endregion

            Microsoft.Reporting.WebForms.Warning[] tWarnings;
            string[] tStreamids;
            string tMimeType;
            string tEncoding;
            string tExtension;
            string fileFormat = getPrintType(contenttype.ToLower());

            byte[] tBytes = reportViewer1.LocalReport.Render(fileFormat, "<DeviceInfo><AutoFit>Never</AutoFit></DeviceInfo>", out tMimeType, out tEncoding, out tExtension, out tStreamids, out tWarnings);
            contenttype = tMimeType;
            return tBytes;
        }

        public byte[] CRR030(CrRegistrationQryModel qm, ref string contenttype)
        {
            return null;
        }
    }
}
