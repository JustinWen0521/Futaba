using System;

namespace ftd.service
{
    /// <summary>
    /// 物件鍵構者
    /// </summary>
    public class AppObjectCreator : FtdCreatorService.ObjectCreator
    {
        /// <summary>
        /// 產品類型
        /// </summary>
        public string ProductCode = null;
        /// <summary>
        /// 物件建立
        /// </summary>
        public override object createObject<ObjectType>()
        {
            var objType = typeof(ObjectType);

            if (objType == typeof(FtdConfigService))
            {
                var obj = new FtdConfigService();
                //obj.initWebEnvironment();
                //obj.ConfigFileName = "FtdConfig.cfg";
                return obj;
            }

            if (ProductCode.isNullOrEmpty())               
                ProductCode = FtdConfigService.Instance.getAppSettingValue("ProductCode", "Standard");

            if (objType == typeof(FtdLogService))
            {
                return new AppLogService();
            }
            else if (objType == typeof(FdmService))
            {
                return new AdmService();
            }
            //else if (objType == typeof(FtdMailService))
            //{
            //    return new AppMailService();
            //}
            else if (objType == typeof(FtdScheduleService))
            {
                return new AppScheduleService();
            }
            else if (objType == typeof(FtdPermissionService))
            {
                return new AppPermissionService();
            }
            //else if (objType == typeof(FwbUiService))
            //{
            //    return new AppWebUiService();
            //}
            //else if (objType == typeof(FtdWebFolderService))
            //{
            //    return new AppWebFolderService();
            //}
            else if (objType == typeof(FtdCodeNameService))
            {
                return new AppCodeNameService();
            }
            else if (objType == typeof(FtdSerialNumberService))
            {
                return new AppSerialNumberService();
            }
            return base.createObject<ObjectType>();
        }
    }
}
