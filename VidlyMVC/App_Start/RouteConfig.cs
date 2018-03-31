using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VidlyMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes(); //Enable Attribute Routing.

            //New route:
            //routes.MapRoute(
            //    "MoviesByReleaseDate", //Name.
            //    "movies/released/{year}/{month}",
            //    new { controller = "Movies", action = "ByReleaseDate" },//The defults, and we use an anonymous for that.
            //    //new { year = @"\d{4}", month = @"\d{2}" }
            //    new { year = @"2016|2017", month = @"\d{2}" } //Between 2015 or 2017.

            //    ////With the names before to better read the code:
            //    //name: "MoviesByReleaseDate", //Name.
            //    //url: "movies/released/{year}/{month}", //URL parameter.
            //    //defaults: new { controller = "Movies", action = "ByReleaseDate" },//The defults, and we use an anonymous for that.
            //    //constraints: new { year = @"\d{4}", month = @"\d{2}" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
