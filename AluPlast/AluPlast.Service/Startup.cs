using AluPlast.ControlLoader.Interfaces;
using AluPlast.ControlLoader.MockService;
using AluPlast.Logowanie.MockService;
using AluPlast.Service.ActionFilters;
using AluPlast.Service.Formatters;
using AluPlast.Service.MessageHandlers;
using FluentValidation.WebApi;
using Microsoft.Practices.Unity;
using Owin;
using Swashbuckle.Application;
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
            // config.MessageHandlers.Add(new FormatMessageHandler());
            //    config.MessageHandlers.Add(new SecretKeyHandler());
            //   config.MessageHandlers.Add(new UnderConstructionHandler());

            config.Formatters.Add(new QrCodeFormatter());
            config.Formatters.Add(new PdfLoadsFormatter());
            config.Formatters.Add(new PdfLoadFormatter());


            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;


      //      config.Filters.Add(new ValidateModelStateFilter());
         //   config.Filters.Add(new ExecutionTimeActionFilter());

            var container = new UnityContainer();

#if DEBUG
            container.RegisterType<ILoadsService, DbLoadsService>(new HierarchicalLifetimeManager());
            container.RegisterType<IItemsService, DbItemsService>(new HierarchicalLifetimeManager());
#else
            container.RegisterType<ILoadsService, DbLoadsService>(new HierarchicalLifetimeManager());
            container.RegisterType<IItemsService, DbItemsService>(new HierarchicalLifetimeManager());
#endif
            config.DependencyResolver = new UnityResolver(container);

            //    config.Filters.Add(new AuthenticationFilter());
            config
                .EnableSwagger(c => c.SingleApiVersion("v1", "AluPlast Service"))
                .EnableSwaggerUi();

            appBuilder.UseWebApi(config);

            FluentValidationModelValidatorProvider.Configure(config);
        }
    }
}
