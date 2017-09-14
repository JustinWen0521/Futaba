using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ftd.data.schedule;
using ftd.nsql;
using ftd.service;
using ftd.thread;
using System.Globalization;
using System.Data;
//using NPOI.HSSF.UserModel;

using System.IO;

namespace ftd.data.schedule
{
    /// <summary>
    /// 系統資料庫資源回收
    /// </summary>
    public class AppRecycleTask : FtdScheduleTask
    {
        public override void scheduleMain(ThreadStart doEvent)
        {
            #region [SessionTable逾期2日的資料刪除]
            {
                var str = Db_PrimaryKey;
                var stables = FdmService.Instance.AllTables.Where(x => x.Value.IsSessionEnable).Select(x => x.Value.SessionTable).ToArray();
                //小於此日者刪除之。
                var the_date = DateTime.Today.AddDays(-2).ToString("yyyyMMdd.HHmmss", CultureInfo.InvariantCulture);
                foreach (var stable in stables)
                {
                    var qry = new NsDbQuery();
                    qry.setSelect(s =>
                    {
                        var t1 = s.from(stable.TableName);
                        s.Where = t1[stable.NsSessionId.ColumnName] < the_date;
                        s.select(t1.All);
                    });

                    var dt = qry.queryData();
                    foreach (DataRow row in dt.Rows)
                    {
                        row.Delete();
                    }
                    dt.TableName = stable.TableName;

                    dt.ns_update_import_mode();

                    doEvent();
                }
            }
            #endregion
        }


        ///// <summary>
        ///// 匯出Excel
        ///// </summary>
        //private static void export_excel(DataTable dt, DataColumn[] columns, string excel_path)
        //{
        //    var dir = Path.GetDirectoryName(excel_path);
        //    if (!Directory.Exists(dir))
        //        Directory.CreateDirectory(dir);

        //    //每 65000 筆一個頁籤
        //    int pageSize = 65000;
        //    int pages = (int)Math.Ceiling((double)dt.Rows.Count / pageSize);

        //    var wbook = new HSSFWorkbook();
        //    HSSFSheet sheet = null;
        //    HSSFRow row0 = null;

        //    for (int page = 1; page <= pages; page++)
        //    {
        //        // 新增試算表。
        //        sheet = wbook.CreateSheet(string.Format("{0}_{1}", dt.TableName, page));
        //        row0 = sheet.CreateRow(0);
        //        for (var i = 0; i < columns.Length; i++)
        //        {
        //            row0.CreateCell(i).SetCellValue(columns[i].Caption);
        //        }

        //        var idx = 1;
        //        for (int rowNo = (page - 1) * pageSize; rowNo < page * pageSize; rowNo++)
        //        {
        //            var erow = sheet.CreateRow(idx);
        //            DataRow row = dt.Rows[rowNo];

        //            for (var i = 0; i < columns.Length; i++)
        //            {
        //                var v1 = "";
        //                var v = row[columns[i]];
        //                if (v != DBNull.Value)
        //                {
        //                    if (v is DateTime)
        //                        v1 = ((DateTime)v).ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
        //                    else
        //                        v1 = v.ToString();
        //                }

        //                erow.CreateCell(i).SetCellValue(v1);
        //            }
        //            idx++;

        //            //最後一筆
        //            if (rowNo >= dt.Rows.Count - 1)
        //                break;
        //        }
        //    }

        //    if (File.Exists(excel_path))
        //    {
        //        File.Delete(excel_path);
        //    }

        //    if (!Directory.Exists(Path.GetDirectoryName(excel_path)))
        //    {
        //        Directory.CreateDirectory(Path.GetDirectoryName(excel_path));
        //    }

        //    var fs = new FileStream(excel_path, FileMode.Create, FileAccess.Write);
        //    try
        //    {
        //        wbook.Write(fs);
        //    }
        //    finally
        //    {
        //        if (fs != null)
        //            fs.Close();
        //        wbook = null;
        //        sheet = null;
        //    }
        //}
    }
}
