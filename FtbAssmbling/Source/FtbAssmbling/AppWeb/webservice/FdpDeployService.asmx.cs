using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ftd.deploy;
using ftd.service;

namespace ftd.webservice
{
    /// <summary>
    ///FdpDeployService 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class FdpDeployService : System.Web.Services.WebService
    {
        private static string _RootPath;

        /// <summary>
        /// ex.(C:\hdb_col)
        /// </summary>
        public static string RootPath
        {
            get
            {
                if (_RootPath == null)
                    _RootPath = HttpContext.Current.Server.MapPath(@"~");
                return _RootPath;
            }
        }

        private static string _UploadRootPath;

        /// <summary>
        /// ex.(C:\hdb_col\upgrade)
        /// </summary>
        public static string UploadRootPath
        {
            get
            {
                if (_UploadRootPath == null)
                    _UploadRootPath = FtdConfigService.Instance.getAppSettingValue("FdpDeployService.UploadRootPath");
                return _UploadRootPath;
            }
        }

        /// <summary>
        /// IN, OUT 都是續列化字串 HEX
        /// </summary>
        [WebMethod]
        public string deployMethod(string in_parameters)
        {
            var ctx = new FdpWebDeployContext(RootPath, UploadRootPath);
            return ctx.deployMethod(in_parameters);
        }
    }
}
