using System.Web.Mvc;

namespace mvcProject.Areas.CK
{
    public class CKAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CK";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CK_default",
                "CK/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
