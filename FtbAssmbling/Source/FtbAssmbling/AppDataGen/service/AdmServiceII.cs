using ftd.data;

namespace ftd.service
{
    public class AdmServiceII : FdmService
    {
        protected override void onSchemaLoad()
        {
            FdmService.Instance.loadSchemaFromClass(typeof(AppDataName));            
            base.onSchemaLoad();
        }

        protected override void onSchemaLoaded()
        {
            //stop check 
        }
    }
}
