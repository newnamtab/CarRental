using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCAvis
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           // routes.MapRoute(
           //    name: "edit",
           //    url: "Orders/editOrders/{reservationNumber}",
           //    defaults: new { reservationNumber = UrlParameter.Optional }
           //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{reservationNumber}",
                defaults: new { controller = "Login", action = "Login", reservationNumber = UrlParameter.Optional }
            );
        }
    }
}
