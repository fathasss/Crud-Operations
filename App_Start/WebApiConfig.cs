using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CrudOperatorUI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear(); //->JSON formatı için
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "StudentApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
