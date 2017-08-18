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

            //var dt = NsDmHelper.AS_Tmp1
            //    .selectAll(t => t.AllExt)
            //    .query();
            //var row = dt.FirstOrDefault();


            var dt = NsDmHelper.AL_AssmblingLog
                .selectAll(t => t.AllPhysical)
                .query();

            Console.ReadLine();


        }

        private static void createOrderDetail()
        {
            var dt = new ZZ_OrderDetailDataTable();
            var row = dt.newTypedRow();
            row.ns_AssignNewId();
            row.ZZOD_OrderId = "ZZO_6PB805JA8";
            row.ZZOD_Qty = 2;
            row.ZZOD_UnitPrice = 199;
            dt.addTypedRow(row);
            dt.ns_update();
            dt.AcceptChanges();

            var dt2 = NsDmHelper.ZZ_OrderDetail
                .selectAll(t => t.AllExt)
                .query();
        }

        private static void queryOrder()
        {
            var orderNoFrom = "20161001001";
            var orderNoTo = "";
            var isEnable = "Y";

            var dt = NsDmHelper.ZZ_Order
                .selectAll(t => t.AllExt)
                //.selectAll(new[]{
                //    AppDataName.ZZO_IsEnableName_XX,
                //    AppDataName.ZZO_UpdaterName_XX
                //})
                .where(t =>
                    t.ZZO_OrderNo >= orderNoFrom.toConstOpt1()
                    & t.ZZO_OrderNo < orderNoTo.toConstOpt1()
                    & t.ZZO_IsEnable == isEnable.toConstReq1()
                )
                .query();

            //新增
            var row = dt.newTypedRow();
            row.ns_AssignNewId();
            row.ZZO_OrderNo = string.Format("{0:yyyyMMdd}001", DateTime.Today);
            //row.ZZO_OrderNo = DateTime.Today.ToString("yyyyMMdd") + "001";
            row.ZZO_Desc = "這是一張訂單";
            row.ZZO_IsEnable = "Y";
            dt.addTypedRow(row);
            dt.ns_update();
            dt.AcceptChanges();
            
            //修改
            var row2 = dt.FirstRow;
            row2.ZZO_Desc = "測試修改";
            dt.ns_update();

            //row2.Delete();
            //dt.ns_update();
        }
    }
}
