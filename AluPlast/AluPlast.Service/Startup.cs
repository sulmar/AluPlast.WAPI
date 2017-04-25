using AluPlast.Service.ActionFilters;
using AluPlast.Service.Formatters;
using AluPlast.Service.MessageHandlers;
using FluentValidation.WebApi;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AluPlast.Service
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();


            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute
                (
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );


            config.MessageHandlers.Add(new TraceMessageHandler());
            config.MessageHandlers.Add(new FormatMessageHandler());
        //    config.MessageHandlers.Add(new SecretKeyHandler());
         //   config.MessageHandlers.Add(new UnderConstructionHandler());

            config.Formatters.Add(new QrCodeFormatter());
            config.Formatters.Add(new PdfLoadsFormatter());
            config.Formatters.Add(new PdfLoadFormatter());


            config.Filters.Add(new ValidateModelStateFilter());
            config.Filters.Add(new ExecutionTimeActionFilter());


            appBuilder.UseWebApi(config);

            FluentValidationModelValidatorProvider.Configure(config);
        }
    }
}
