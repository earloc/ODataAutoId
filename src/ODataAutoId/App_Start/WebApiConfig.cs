using ODataAutoId.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace ODataAutoId {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Person>("Persons");
            builder.EntitySet<Item>("Items");
            config.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());
        }
    }
}
