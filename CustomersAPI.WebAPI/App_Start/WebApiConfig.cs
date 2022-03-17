using CustomersAPI.WebAPI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CustomersAPI.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
           // config.Filters.Add(new ApiExceptionAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
