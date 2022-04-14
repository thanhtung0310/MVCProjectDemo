using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCProjectDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
                        
            //see all employee
            routes.MapRoute(
                name: "List of Employee",
                url: "findEmployee",
                defaults: new { controller = "Employee", action = "List" }
            );

            //see detail of one employee
            routes.MapRoute(
                name: "Detail of Employee",
                url: "detailEmployee/{emp_id}",
                defaults: new { controller = "Employee", action = "Detail" }
            );

            //
            routes.MapRoute(
                name: "Trang 1",
                url: "trang_1",
                defaults: new { controller = "Employee", action = "Index" }
            );

            //
            routes.MapRoute(
                name: "Trang 2",
                url: "trang_2",
                defaults: new { controller = "Employee", action = "Index2" }
            );

            //default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
