using System;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http.Cors;

namespace Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            try
            {
                // Web API configuration and services
                // Configure Web API to use only bearer token authentication.
                config.SuppressDefaultHostAuthentication();
                config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

                var cors = new EnableCorsAttribute("*", "*", "*");
                config.EnableCors(cors);

                // Web API routes
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            }
            catch(Exception ex)
            {
                CatchError.Log4Net("ERROR", ex);
            }
        }
    }
}
