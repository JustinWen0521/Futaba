using System.Web.Mvc;

namespace ftd.mvc.Areas.AL
{
    public class ALAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AL";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AL_default",
                "AL/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
