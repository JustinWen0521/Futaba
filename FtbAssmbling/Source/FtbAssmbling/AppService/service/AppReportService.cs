using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using ftd.data;
using ftd.nsql;
using ftd.query.model;
using ftd.web;

//August Lee add 2015/01/30
namespace ftd.service
{
    public class AppReportService
    {
        public static readonly AppReportService Instance;

        static AppReportService()
        {
            Instance = FtdCreatorService.Instance.createObject<AppReportService>();
        }

        public virtual byte[] processReport<T>(T para) where T : AppQryModel
        {
            AppQryModel qm = para as AppQryModel;
            if (qm == null || qm.ReportId.isNullOrEmpty())
                throw new Exception("無效的參數");

            return null;
        }

        //public virtual string processReport(FtbReportModel parameter)
        //{
        //    //Call AppService
        //    Type magicType = Type.GetType("ftd.service.ReportService");
        //    ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
        //    object magicClassObject = magicConstructor.Invoke(new object[] { });
        //    MethodInfo magicMethod = magicType.GetMethod(parameter.ReportId);
        //    object magicValue = magicMethod.Invoke(magicClassObject, new object[] { parameter });

        //    //Write Down the File into physical folder

        //    return "OK";
        //}

        //public virtual string processReport2(FtbReportModel parameter,string cond)
        //{
        //    try
        //    {
        //        //Call AppService
        //        Type magicType = Type.GetType("ftd.service.ReportService");
        //        ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
        //        object magicClassObject = magicConstructor.Invoke(new object[] { });
        //        MethodInfo magicMethod = magicType.GetMethod(parameter.ReportId);
        //        List<object> ls_obj=new List<object>();
        //        if (parameter.ReportSourceType == 0)
        //        {
        //            ls_obj.Add(cond);
        //            ls_obj.Add(parameter.ReportType.ToString());
        //        }
        //        if (parameter.ReportSourceType == 1)
        //            ls_obj.Add(cond);
                
        //        //object magicValue = magicMethod.Invoke(magicClassObject, new object[] { cond, parameter.ReportType });
        //        object magicValue = magicMethod.Invoke(magicClassObject, ls_obj.ToArray());

        //        //Write Down the File into physical folder
        //        var data = (byte[])magicValue;
        //        if (data.Length > 0)
        //            File.WriteAllBytes(System.AppDomain.CurrentDomain.BaseDirectory + "/KM/"+parameter.ExportName, data);
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //    return "OK";
        //}

        //public virtual AppReportService deserializeService(DataRow rowTask)
        //{
        //    //var rowTask2 = (WT_ReportDefineRow)rowTask;
        //    //var type = Type.GetType(rowTask2.WTRD_ObjectTypeName);
        //    //var task = (AppReportService)type.GetConstructor(new Type[] { }).Invoke(new object[] { });
        //    ////task.Db_PrimaryKey = rowTask2.WTST_ScheduleTaskId;
        //    ////task.Db_IsEnable = (rowTask2.WTST_IsEnable == "A");
        //    ////if (rowTask2 != null)
        //    ////    task.Db_LastExecuteDate = rowTask2.WTST_ExecuteBeginDate;
        //    ////task.TaskTitle = rowTask2.WTST_TaskName;
        //    //return task;
        //    return null;
        //}

        /// <summary>
        /// 取得報表檔(RDLC)組件
        /// </summary>
        /// <returns></returns>
        internal Assembly getReportAssembly()
        {
            Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("AppData")).FirstOrDefault();
            if (assembly == null)
            {
                string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");
                assembly = Assembly.LoadFile(path + "/AppData.dll"); 
            }
            return assembly;
        }

        public string addReportTask<T>(T qm, string remark = "") where T : AppQryModel
        {
            try
            {
                //if (!qm.ReportPrintMethod.equalIgnoreCase("S"))
                //    return "列印方式非排程";

                ////取得報表定義
                //var rptDef = NsDmHelper.SY_ReportDefinition
                //    .selectAll()
                //    .where(t =>
                //        t.SYRD_ReportId == qm.ReportId.toConstReq1()
                //        & t.SYRD_Status == "A"
                //    )
                //    .queryFirst();

                //if (rptDef == null)
                //    return "報表未定義或已停用";

                //if (!rptDef.SYRD_AllowScheduling.equalIgnoreCase("Y"))
                //    return "此報表不允許排程";

                ////機關代碼(以目前登入者為準)
                ////Report Owner概念：不論報表條件機關為何，報表應屬於產製人，並存檔至其機關資料夾
                ////var orgId = qm.Q_EnterOrgId;
                ////if (orgId.isNullOrEmpty())
                ////{
                ////    orgId = AppUserSession.User.OrganId;
                ////    //qm.Q_EnterOrgId = orgId;
                ////}
                //var orgId = AppUserSession.User.OrganId;

                ////排程時間
                //var now = DateTime.Now;
                //DateTime scheduleDate = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
                //if (!qm.ReportScheduleDate.isNullOrEmpty())
                //{
                //    var theDate = DateTime.MinValue;
                //    if (qm.ReportScheduleDate.verifyAsTwDate("D", out theDate))
                //    {
                //        scheduleDate = new DateTime(theDate.Year, theDate.Month, theDate.Day, qm.ReportScheduleHour, qm.ReportScheduleMin, 0);
                //    }
                //}

                ////將參數轉成json格式
                //var json = new JavaScriptSerializer().Serialize(qm);

                ////寫入資料庫
                //var dt = new SY_ReportTaskDataTable();
                //var row = dt.newTypedRow();
                //row.ns_AssignNewId();
                //row.SYRT_OrganId = orgId;
                //row.SYRT_ReportId = qm.ReportId;
                //row.SYRT_TaskStatus = "N";
                //row.SYRT_Conditions = json;
                //row.SYRT_ScheduleDate = scheduleDate;
                //row.SYRT_Remark = remark;
                //dt.addTypedRow(row);
                //dt.ns_update();

                return "OK";
            }
            catch (Exception ex)
            {
                return "NG";
            }
        }

        internal string getPrintType(string contenttype)
        {
            string print = "";
            switch (contenttype.ToLower())
            {
                case "pdf":
                    print = "PDF";
                    break;
                case "xls":
                    print = "Excel";
                    break;
                case "xlsx":
                    print = "EXCELOPENXML";
                    break;
                case "doc":
                    print = "Word";
                    break;
                case "docx":
                    print = "WORDOPENXML";
                    break;
                default:
                    throw new Exception("不支援的報表輸出格式：" + contenttype);
            }
            return print;
        }

    }
}
