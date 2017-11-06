using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Configuration;
using System.Web.Http.Cors;

namespace api
{
    public static class WebApiConfig
    {
        private const string keyCorsOrigin = "cors:Origins";
        private const string keyCorsHeaders = "cors:Headers";
        private const string keyCorsMethods = "cors:Methods";

        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute(ConfigurationManager.AppSettings[keyCorsOrigin],
          ConfigurationManager.AppSettings[keyCorsHeaders],
          ConfigurationManager.AppSettings[keyCorsMethods]);

            config.EnableCors(cors);

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
