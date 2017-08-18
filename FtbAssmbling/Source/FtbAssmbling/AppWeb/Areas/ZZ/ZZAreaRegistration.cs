using System.Web.Mvc;

namespace ftd.mvc.Areas.ZZ
{
    public class ZZAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ZZ";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ZZ_default",
                "ZZ/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
