
namespace ftd.service
{
    public class AppLogServiceII : AppLogService
    {
        public override void initService()
        {
            base.initService();
            //var logpath = Path.Combine(SysConfigService.Instance.AppBinPath, @"..\..\log");
            //this.LogDirectory = logpath;
            IsLogEnable = false;
        }
    }
}
