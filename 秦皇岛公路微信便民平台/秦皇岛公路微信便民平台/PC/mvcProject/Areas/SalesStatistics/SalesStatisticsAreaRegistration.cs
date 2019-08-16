using System.Web.Mvc;

namespace mvcProject.Areas.SalesStatistics
{
    public class SalesStatisticsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SalesStatistics";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SalesStatistics_default",
                "SalesStatistics/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
