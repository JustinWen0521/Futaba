using System.IO;

namespace ftd.service
{
    public class AppLogServiceII : AppLogService
    {
        public override void initService()
        {
            base.initService();
            var logpath = Path.Combine(FtdConfigService.Instance.AppBinPath, @"..\..\log");
            this.LogDirectory = logpath;                       
        }
    }
}
