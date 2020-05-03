using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Restric access of anonymous user
            //Equivalent to applying authorize attribute at every controller
            filters.Add(new AuthorizeAttribute());
        }
    }
}