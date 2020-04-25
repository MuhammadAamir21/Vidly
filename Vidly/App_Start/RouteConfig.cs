using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Defining custom route with 2 parameter
            //Here more specific routes comes first then generic once

            routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                //Below is called a new annyomous object
                new { controller = "Movies", action = "ByReleaseDate" },
                //Adding contrain for year and month
                //@ sign indicates varbatim string(literal string) for exact sting
                //as back slash is a escape character
                //\d indicates digits
                //{num} indicates repeatitions
                //Here we add a regular expression constains
                new { year = @"\d{4}", month = @"\d{2}" }
                //new { year = @"2015|2016", month = @"\d{2}" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}