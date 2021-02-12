using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using WebApplication;

namespace WebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы Web API
            // Настройка Web API для использования только проверки подлинности посредством маркера-носителя.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Используйте "верблюжий" стиль для данных JSON.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Маршруты Web API
            config.MapHttpAttributeRoutes();

            // Enable CORS
            config.EnableCors();
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<KazakhBest>("KazakhBests");
            builder.EntitySet<Apple_iPad_Pro_A2229>("Apple_iPad_Pro_A2229");
            builder.EntitySet<Apple_Watch_Series_6>("Apple_Watch_Series_6");
            builder.EntitySet<category>("categories");
            builder.EntitySet<Nokia_230_DS>("Nokia_230_DS");
            builder.EntitySet<Samsung_Galaxy_S20_Plus>("Samsung_Galaxy_S20_Plus");
            builder.EntitySet<Skyworth_BD_400>("Skyworth_BD_400");
            builder.EntitySet<History>("Histories");
            builder.EntitySet<category>("categories");
            builder.EntitySet<KazakhBest>("KazakhBests");

            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
