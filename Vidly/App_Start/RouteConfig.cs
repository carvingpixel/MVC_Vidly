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
                //remember most specific goes first

            //convention-based Routing 
            routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                new { Controller = "Movies", Action = "ByReleaseDate" },
                new { year = @"\d{4}", month = @"\d{2}" }
                // controller uses Movies and Action used is ByReleaseDate
                // name of this route is MoviesByReleaseDate
                // URL is the second parameter of this maproute method
                // finally, the fourth is parameters with constraints on year and month of digit size
                // or contraint specific such as year = @"2015|2016" so either or
            ); //defined custom route, now to define the action, notice contorller and action invoked //

            //Attribute Routing 
            //enable attribute routing with this method.. then set attributes in the controller
            routes.MapMvcAttributeRoutes(); // just enables attribute routing only 

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
