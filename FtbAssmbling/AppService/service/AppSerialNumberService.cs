using System;
using System.Collections.Generic;
using System.Text;
using ftd.dataaccess;
using ftd.data;

namespace ftd.service
{
    public class AppSerialNumberService : FtdSerialNumberService
    {
        ///// <summary>
        ///// 電腦軟體編號 NS0001
        ///// 第 1 碼為使用版別：主機版Ｍ、單機版Ｐ、網路版Ｎ。
        ///// 第 2 碼為軟體別：系統軟體Ｓ、軟體工具Ｔ、應用軟體Ａ。
        ///// 第 3~6 碼為流水號。
        ///// </summary>
        //public class UsSoftNoNumber : BaseNumber
        //{
        //    public override string getNextSerailNo(SerialContext context)
        //    {
        //        var scope = context.Scope.Split('#');
        //        var pre = "0000";
        //        var dba = FdbAccess.createDbAccessFromConfig("US");
        //        StringBuilder sb = new StringBuilder();
        //        sb.AppendFormat("select max({0}) ", AppDataName.USS_SoftNo);
        //        sb.AppendFormat("from {0} ", AppDataName.US_Software);
        //        sb.AppendFormat("where {0}  = '{1}'", AppDataName.USS_EnterOrgId, scope[0]);
        //        sb.AppendFormat("and substr({0}, 1, 2)  = '{1}'", AppDataName.USS_SoftNo, scope[1] + scope[2]);
        //        var max = dba.executeScalar(sb.ToString());
        //        var sn = "";
        //        if (max == null || max == DBNull.Value)
        //            sn = "1";
        //        else
        //            sn = (int.Parse(((string)max).Substring(2)) + 1).ToString();
        //        var s = string.Concat(pre, sn);
        //        return scope[1] + scope[2] + s.Substring(s.Length - pre.Length);
        //    }

        //    public override string NumberStyle
        //    {
        //        get { return string.Concat("{資料庫電腦軟體編號下一號碼}"); }
        //    }
        //}


        protected override FtdSerialNumberService.BaseNumber createSerialNumber(string serialNumberName)
        {
            //switch (serialNumberName)
            //{
            //    case AppSerialNumberName.SNN_US_SoftNo:    //電腦軟體編號
            //        {
            //            var nums = new ListNumber();
            //            //nums.addNumber(new ConstStringNumber("B"));
            //            //nums.addNumber(new ConstStringNumber("B"));
            //            nums.addNumber(new UsSoftNoNumber());
            //            return nums;
            //        }
            //}
            return base.createSerialNumber(serialNumberName);
        }
    }
}
