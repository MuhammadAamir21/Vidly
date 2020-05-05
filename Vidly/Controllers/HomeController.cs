using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI;

namespace Vidly.Controllers
{
    //This will allow anonymous user to access this controller
    [AllowAnonymous]
    //Add Authorization to entire controller class
    //[Authorize]
    public class HomeController : Controller
    {
        //Here we can cache our page either or client or server
        //application duration of cache data
        //cache action of different action as well
        // VaryByParam = "*" any paramter will be cache
        //like customers/1...10
        [OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam = "*")]
        public ActionResult Index()
        {
        }

        //Disable cache on a certain action
        [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}