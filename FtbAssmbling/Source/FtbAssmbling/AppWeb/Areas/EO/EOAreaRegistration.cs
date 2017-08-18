using System.Web.Mvc;

namespace ftd.mvc.Areas.EO
{
    public class EOAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "EO";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "EO_default",
                "EO/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
