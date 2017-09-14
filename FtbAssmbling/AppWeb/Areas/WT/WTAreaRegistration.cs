using System.Web.Mvc;

namespace ftd.mvc.Areas.WT
{
    public class WTAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "WT";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "WT_default",
                "WT/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
