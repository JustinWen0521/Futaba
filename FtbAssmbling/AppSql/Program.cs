using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Data;
using System.Text.RegularExpressions;
using ftd;
using ftd.data;
using ftd.dataset;
using ftd.nsql;
using ftd.service;
using ftd.dataaccess;
using ftd.upgrade;
using System.Text;
using System.Web;
using System.IO;
using Oracle.ManagedDataAccess.Client;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using System.Text;
using ftd.query.model;
//using Newtonsoft.Json;

namespace FtdDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region //設定服務
            FtdCreatorService.Instance.CreateMethod = (objType) =>
            {
                if (objType == typeof(FtdLogService))
                    return new AppLogServiceII();
                if (objType == typeof(FtdCodeNameService))
                    return new AppCodeNameService();
                if (objType == typeof(FdmService))
                    return new AdmService();
                if (objType == typeof(FtdSerialNumberService))
                    return new AppSerialNumberService();
                if (objType == typeof(FtdPermissionService))
                    return new AppPermissionService();
                return null;
            };
            #endregion

            Program pgm = new Program();
            pgm.GetAssemblingDetailByDate("FPC", "20170201");


        }

        public String GetAssemblingDetailByDate(string code, string date)
        {
            //AlAssmblingDetailQryModel qm = new AlAssmblingDetailQryModel();
            //qm.Q_MCCode = code;
            //qm.Q_Date = date;
            //var dt = AlDataService.Instance.AlAssmblingDetail_getDayList(qm);


            //Dictionary<string, String[,]> data = new Dictionary<string, String[,]>();
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    string codeIdxPast = null;
            //    String[] arrTimeWork = null;
            //    var arrLine = HryDataService.Instance.getArrayForAssemblingDetail(ref arrTimeWork);
            //    Int32 sumMorning = 0, sumNighting = 0;
            //    for (var i = 0; i < dt.Rows.Count; i++)
            //    {
            //        var row = dt.Rows[i];
            //        string codeIdx = Convert.ToString(row[AppDataName.ALA_MCCode]);
            //        var hh = Convert.ToDateTime(row[AppDataName.ALAD_DATE]).Hour.ToString();
            //        hh = (hh.Length == 1) ? String.Concat("0", hh) : hh;
            //        int index = 0;

            //        #region 第一筆
            //        if (codeIdxPast.isNullOrEmpty())
            //        {
            //            index = Array.IndexOf(arrTimeWork, hh);
            //            if (index > 0)
            //            {
            //                arrLine[index, 2] = Convert.ToString(row[AppDataName.ALAD_ITEM]);
            //                arrLine[index, 3] = Convert.ToString(row[AppDataName.ALAD_QTY]);
            //                if (Convert.ToInt32(hh) >= 7 && Convert.ToInt32(hh) <= 18)
            //                {
            //                    sumMorning += Convert.ToInt32(arrLine[index, 3]);
            //                }
            //                if ((Convert.ToInt32(hh) >= 19 && Convert.ToInt32(hh) <= 23) || (Convert.ToInt32(hh) >= 0 && Convert.ToInt32(hh) <= 6))
            //                {
            //                    sumNighting += Convert.ToInt32(arrLine[index, 3]);
            //                }
            //            }
            //            codeIdxPast = codeIdx;
            //            continue;
            //        }
            //        #endregion

            //        #region 下一條LINE
            //        if (!codeIdxPast.equalIgnoreCase(codeIdx))
            //        {
            //            index = Array.IndexOf(arrTimeWork, "Morning小計");
            //            arrLine[index, 3] = Convert.ToString(sumMorning);
            //            index = Array.IndexOf(arrTimeWork, "Morning小計");
            //            arrLine[index, 3] = Convert.ToString(sumNighting);
            //            index = Array.IndexOf(arrTimeWork, "Day合計");
            //            arrLine[index, 3] = Convert.ToString(sumMorning + sumNighting);
            //            data.Add(codeIdxPast, arrLine);
            //            sumMorning = 0;
            //            sumNighting = 0;
            //            codeIdxPast = codeIdx;
            //            arrLine = HryDataService.Instance.getArrayForAssemblingDetail(ref arrTimeWork);
            //        }
            //        #endregion

            //        #region 下一筆
            //        index = Array.IndexOf(arrTimeWork, hh);
            //        if (index > 0)
            //        {
            //            arrLine[index, 2] = Convert.ToString(row[AppDataName.ALAD_ITEM]);
            //            arrLine[index, 3] = Convert.ToString(row[AppDataName.ALAD_QTY]);
            //            if (Convert.ToInt32(hh) >= 7 && Convert.ToInt32(hh) <= 18)
            //            {
            //                sumMorning += Convert.ToInt32(arrLine[index, 3]);
            //            }
            //            if ((Convert.ToInt32(hh) >= 19 && Convert.ToInt32(hh) <= 23) || (Convert.ToInt32(hh) >= 0 && Convert.ToInt32(hh) <= 6))
            //            {
            //                sumNighting += Convert.ToInt32(arrLine[index, 3]);
            //            }
            //        }
            //        #endregion

            //    }
            //    data.Add(codeIdxPast, arrLine);

            //}




            return null;

            //return "value";
        }




    }
}
