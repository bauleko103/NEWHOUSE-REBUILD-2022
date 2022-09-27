using System.Web;
using System.Web.Mvc;

namespace NEWHOUSE_REBUILD_2022
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
