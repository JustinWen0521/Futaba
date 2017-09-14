using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ftd.service;
using System.Threading;
//using ftd.agent.work;

namespace ftd.agent
{
    class Program
    {
        static void Main(string[] args)
        {
            #region //設定服務
            FtdCreatorService.Instance.CreateMethod = (objType) =>
            {
                if (objType == typeof(FtdConfigService))
                {
                    var obj = new FtdConfigService();
                    //obj.initService();
                    return obj;
                }

                //if (objType == typeof(FwnUiService))
                //    return new AppWinUiService();

                if (objType == typeof(FtdLogService))
                    return new AppLogService();

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

            //載入共用代碼
            //SyDataService.Instance.loadSyCodeToCodeTypeNames();

            #endregion

            var productCode = FtdConfigService.Instance.getAppSettingValue("ProductCode");

            string functionCode = "";
            if (args != null && args.Length > 0)
                functionCode = args[0].Trim().Replace("\r", "").Replace("\n", "").ToUpper();

            //switch (functionCode)
            //{
            //    case "RPTTASK":  //報表排程
            //        ReportTask rptTask = new ReportTask();
            //        rptTask.doWork();
            //        break;
            //    case "PIP010":
            //        PIP010 _PIP010 = new PIP010();
            //        _PIP010.doWork();
            //        break;
            //    case "PIP020":
            //        PIP020 _PIP020 = new PIP020();
            //        _PIP020.doWork();
            //        break;
            //    case "PIP030":
            //        PIP030 _PIP030 = new PIP030();
            //        _PIP030.doWork();
            //        break;
            //    case "PIP040":
            //        PIP040 _PIP040 = new PIP040();
            //        _PIP040.doWork();
            //        break;
            //    case "PIP050":
            //        PIP050 _PIP050 = new PIP050();
            //        _PIP050.doWork();
            //        break;
            //    case "PIP060":
            //        PIP060 _PIP060 = new PIP060();
            //        _PIP060.doWork();
            //        break;
            //    case "PIP070":
            //        PIP070 _PIP070 = new PIP070();
            //        _PIP070.doWork();
            //        break;
            //    case "PIP999":
            //        PIP999 _PIP999 = new PIP999();
            //        _PIP999.doWork();
            //        break;
            //    case "PCP010":
            //        PCP010 _PCP010 = new PCP010();
            //        _PCP010.doWork();
            //        break;
            //    case "PMP010":
            //        PMP010 _PMP010 = new PMP010();
            //        _PMP010.doWork();
            //        break;
            //    case "PMP999":
            //        PMP999 _PMP999 = new PMP999();
            //        _PMP999.doWork();
            //        break;
            //    default:
            //        AppAgentLog.writeLog("不支援的參數[" + functionCode + "]");
            //        break;
            //}
        }
    }
}
