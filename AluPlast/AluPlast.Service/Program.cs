using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace AluPlast.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000";

            HostFactory.Run(configurator =>
            {
                configurator.Service<WebApiService>(sc =>
                {
                    sc.ConstructUsing(() => new WebApiService(baseAddress));

                    sc.WhenStarted(s => s.Start());

                    sc.WhenStopped(s => s.Stop());
                });

                configurator.RunAsLocalSystem();
                configurator.EnableShutdown();

                configurator.SetDisplayName("AluPlast Service");
                configurator.SetServiceName("AluPlastService");
                configurator.SetDescription("Opis usługi AluPlast...");

                configurator.StartAutomatically();

            });

            //WebApiService service = new WebApiService(baseAddress);
            //service.Start();

            //Console.WriteLine("Press any key to exit.");

            //Console.ReadKey();

            //service.Stop();


        }
    }
}
