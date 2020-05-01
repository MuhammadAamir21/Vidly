using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

//For Formatting.Indented
using Newtonsoft.Json;

//For the CamelCasePropertyNamesContractResolver
using Newtonsoft.Json.Serialization;

namespace Vidly
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //To change the json result from pascal case to camel case
            //Beacuse we use camel case in javascript it make it much better to use it
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}